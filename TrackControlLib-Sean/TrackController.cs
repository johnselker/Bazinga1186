using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;

namespace TrackControlLib
{
	namespace Sean
	{
		public class TrackController : ITrackController
		{
			private const int DEFAULT_AUTHORITY = 20;
			private const int AUTH_THRESH_SWITCH = 2;
			private const int AUTH_THRESH_YELLOW = 1;
			private const int AUTH_THRESH_GREEN = 5;
			private const int AUTH_THRESH_SUPERGREEN = 10;

			private Dictionary<string, TrackBlock> m_trackBlocks;
			private Dictionary<string, TrackBlock> m_updatedBlocks;
			private TrackSwitch m_switch;

			public TrackController()
			{
				m_trackBlocks = new Dictionary<string, TrackBlock>();
				m_updatedBlocks = new Dictionary<string, TrackBlock>();
				m_switch = null;
			}

			public bool AddTrackBlock(TrackBlock block)
			{
				if (block == null) return false;
				if (m_trackBlocks.ContainsKey(block.Name)) return false;
				
				m_trackBlocks.Add(block.Name, block);

				// always set to max, we will only dynamically update authority
				block.Authority.SpeedLimitKPH = System.Convert.ToInt32(block.StaticSpeedLimit);

				return true;
			}

			public bool SetSwitch(TrackSwitch s)
			{
				if (s == null) return false;

				if (!m_trackBlocks.ContainsKey(s.BranchClosedId) ||
					!m_trackBlocks.ContainsKey(s.BranchOpenId) ||
					!m_trackBlocks.ContainsKey(s.TrunkId))
				{
					return false;
				}

				m_switch = s;

				return true;
			}

			public bool SuggestAuthority(string trackId, BlockAuthority auth)
			{
				if (!m_trackBlocks.ContainsKey(trackId)) return false;
				if (auth == null) return false;

				if (auth.Authority < -1) return false;
				if (auth.SpeedLimitKPH < 0) return false;

				if (auth.Authority <= m_trackBlocks[trackId].Authority.Authority)
					UpdateAuthoritySignal(m_trackBlocks[trackId], auth.Authority);
				else
					return false;

				if (auth.SpeedLimitKPH <= m_trackBlocks[trackId].StaticSpeedLimit)
					m_trackBlocks[trackId].Authority.SpeedLimitKPH = auth.SpeedLimitKPH;
				else
					return false;
                Update();
				return true;
			}

			public bool CloseTrack(string trackId)
			{
				if (m_trackBlocks.ContainsKey(trackId))
				{
                    if (m_trackBlocks[trackId].Status.IsOpen && !m_trackBlocks[trackId].Status.TrainPresent)
                    {
					    m_trackBlocks[trackId].Authority.Authority = 0;
					    m_trackBlocks[trackId].Authority.SpeedLimitKPH = 0;
					    m_trackBlocks[trackId].Status.SignalState = TrackSignalState.Red;
					    m_trackBlocks[trackId].Status.IsOpen = false;
                        Update();
					    return true;
                    }
				}
                return false;
			}

			public bool OpenTrack(string trackId)
			{
				if (m_trackBlocks.ContainsKey(trackId))
				{
                    if (!m_trackBlocks[trackId].Status.IsOpen)
                    {
                        m_trackBlocks[trackId].Authority.SpeedLimitKPH = System.Convert.ToInt32(m_trackBlocks[trackId].StaticSpeedLimit);
                        m_trackBlocks[trackId].Status.IsOpen = true;
                        Update();
                        return true;
                    }
				}
                return false;
			}

			public Dictionary<string, TrackBlock> GetUpdatedTrackStatus()
			{
				Dictionary<string, TrackBlock> statuses = new Dictionary<string, TrackBlock>();
				foreach (KeyValuePair<string, TrackBlock> b in m_updatedBlocks)
					statuses.Add(b.Key, b.Value);
				m_updatedBlocks.Clear();
				return statuses;
			}

			public void Update()
			{
				// check for track block errors
				CheckFailModes();

                // update switching
				UpdateSwitch();

				// update track block authorites, speed and signals
				// work backward from the end of a swicth, a broken track, or a train present
				List<TrackBlock> blocks = new List<TrackBlock>(m_trackBlocks.Values);
				UpdateAuthority(blocks);
			}

			private void CheckFailModes()
			{
				foreach (TrackBlock b in m_trackBlocks.Values)
				{
					if (b.Status.BrokenRail || b.Status.CircuitFail || b.Status.PowerFail)
					{
						AddUpdatedStatus(b);
						if (b.Status.IsOpen) CloseTrack(b.Name);
					}
				}
			}

			private void UpdateSwitch()
			{
				foreach (TrackBlock b in m_trackBlocks.Values)
				{
					if (b.HasSwitch && b.Status.TrainPresent) // might need a different test here
					{
						// we are on a switch that is already in the right direction
						if (b.GetNextBlock(b.Status.TrainDirection) != null)
						{
							// a train is approaching, switch so there isn't a collision
							if (IsTrainApproaching(b.GetNextBlock(b.Status.TrainDirection)))
							{
								m_switch.Switch();
								AddUpdatedStatus(b);
							}
						}
						else
						{
							// a train is approaching, switch so there isn't a collision
							if (!IsTrainApproaching(m_trackBlocks[m_switch.TrunkId]))
							{
								m_switch.Switch();
								AddUpdatedStatus(b);
							}
						}
					}
				}
			}

			private void UpdateAuthority(List<TrackBlock> blocks)
			{
				while (blocks.Count > 0)
				{
					TrackBlock t;
					int i;

					TrackBlock b = blocks.ElementAt<TrackBlock>(0);
					blocks.Remove(b);
					if (b.Status.TrainPresent)
					{
						for (i = -1, t = (b.GetNextBlock(b.Status.TrainDirection) == b.NextBlock) ? b.PreviousBlock : b.NextBlock;
							t != null && blocks.Contains(t) &&
							t.Status.IsOpen;
							++i, t = (t.NextBlock == t) ? t.PreviousBlock : t.NextBlock)
						{
							UpdateAuthoritySignal(t, i);
							if (t.Status.TrainPresent) break;
							blocks.Remove(t);
						}
					}

					if (!m_trackBlocks.ContainsValue(b.NextBlock) || b.NextBlock == null)
					{
						for (i = -1, t = b;
							t != null && m_trackBlocks.ContainsValue(t) &&
							t.Status.IsOpen;
							++i, t = t.PreviousBlock)
						{
							UpdateAuthoritySignal(t, i);
							blocks.Remove(t);
							if (t.Status.TrainPresent) break;
						}
					}
					else if (!m_trackBlocks.ContainsValue(b.PreviousBlock) || b.PreviousBlock == null)
					{
						for (i = -1, t = b;
							t != null && m_trackBlocks.ContainsValue(t) &&
							t.Status.IsOpen;
							++i, t = t.NextBlock)
						{
							UpdateAuthoritySignal(t, i);
							blocks.Remove(t);
							if (t.Status.TrainPresent) break;
						}
					}
				}
			}

			private void AddUpdatedStatus(TrackBlock b)
			{
				if (!m_updatedBlocks.ContainsKey(b.Name))
					m_updatedBlocks.Add(b.Name, b);
			}

			private void UpdateAuthoritySignal(TrackBlock block, int authority)
			{
				if (block == null) throw new ArgumentNullException();
				if (authority < -1) throw new ArgumentOutOfRangeException();

                AddUpdatedStatus(block);

				block.Authority.Authority = authority;

				if (authority > AUTH_THRESH_SUPERGREEN)
				{
					block.Status.SignalState = TrackSignalState.SuperGreen;
				}
				else if (authority > AUTH_THRESH_GREEN)
				{
					block.Status.SignalState = TrackSignalState.Green;
				}
				else if (authority > AUTH_THRESH_YELLOW)
				{
					block.Status.SignalState = TrackSignalState.Yellow;
				}
				else
				{
					block.Status.SignalState = TrackSignalState.Red;
				}
			}

			private bool IsTrainApproaching(TrackBlock dest)
			{
                if (dest == null) throw new ArgumentNullException();

				List<TrackBlock> blocks = new List<TrackBlock>(m_trackBlocks.Values);
				while (blocks.Count > 0)
				{
					TrackBlock b = blocks.ElementAt<TrackBlock>(0);
					blocks.Remove(b);
					if (b.Status.TrainPresent)
					{
						for(TrackBlock t = b.GetNextBlock(b.Status.TrainDirection);
							t != null && blocks.Contains<TrackBlock>(t) &&
							t.Status.IsOpen && !t.Status.TrainPresent;
							t = (t.NextBlock == t) ? t.PreviousBlock : t.NextBlock)
						{
							if (t == dest) return true;
							blocks.Remove(t);
						}
					}
				}
				return false;
			}
		}
	}
}
