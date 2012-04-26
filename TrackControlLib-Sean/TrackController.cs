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
			private const int DEFAULT_AUTHORITY = 100;
			private const int AUTH_THRESH_SWITCH = 2;
			private const int AUTH_THRESH_YELLOW = 1;
			private const int AUTH_THRESH_GREEN = 5;
			private const int AUTH_THRESH_SUPERGREEN = 10;

			private Dictionary<string, TrackBlock> m_trackBlocks;
			private Dictionary<string, TrackStatus> m_updatedStatuses;
			private TrackSwitch m_switch;

			public TrackController()
			{
				m_trackBlocks = new Dictionary<string, TrackBlock>();
				m_updatedStatuses = new Dictionary<string, TrackStatus>();
				m_switch = null;
			}

			public bool AddTrackBlock(TrackBlock block)
			{
				if (block == null) return false;
				if (m_trackBlocks.ContainsKey(block.Name))
					return false;
				
				m_trackBlocks.Add(block.Name, block);

				// always set to max, we will only dynamically update authority
				block.Authority.SpeedLimitKPH = System.Convert.ToInt32(block.StaticSpeedLimit);

				return true;
			}

			public bool SetSwitch(TrackSwitch s)
			{
				if (s == null) return false;

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

				return true;
			}

			public bool CloseTrack(string trackId)
			{
				if (m_trackBlocks.ContainsKey(trackId))
				{
					m_trackBlocks[trackId].Authority.Authority = 0;
					m_trackBlocks[trackId].Authority.SpeedLimitKPH = 0;
					m_trackBlocks[trackId].Status.SignalState = TrackSignalState.Red;
					m_trackBlocks[trackId].Status.IsOpen = false;

					return true;
				}
				else
					return false;
			}

			public bool OpenTrack(string trackId)
			{
				if (m_trackBlocks.ContainsKey(trackId))
				{
					m_trackBlocks[trackId].Authority.SpeedLimitKPH = System.Convert.ToInt32(m_trackBlocks[trackId].StaticSpeedLimit);
					m_trackBlocks[trackId].Status.IsOpen = true;
					return true;
				}
				else
					return false;
			}

			public Dictionary<string, TrackStatus> GetUpdatedTrackStatus()
			{
				Dictionary<string, TrackStatus> statuses = new Dictionary<string, TrackStatus>();
				foreach (KeyValuePair<string, TrackStatus> b in m_updatedStatuses)
					statuses.Add(b.Key, b.Value);
				m_updatedStatuses.Clear();
				return m_updatedStatuses;
			}

			public void Update()
			{
				// check for track block errors
				foreach (TrackBlock b in m_trackBlocks.Values)
				{
					if (b.Status.BrokenRail || b.Status.CircuitFail || b.Status.PowerFail)
					{
						AddUpdatedStatus(b);
						if (b.Status.IsOpen) CloseTrack(b.Name);
					}
				}

				foreach (TrackBlock b in m_trackBlocks.Values)
				{
					// update switching
					if (b.HasSwitch && b.Status.TrainPresent) // might need a different test here
					{
						// we are on a switch that is already in the right direction
						if (b.GetNextBlock(b.Status.TrainDirection) != null)
						{
							// a train is approaching, switch so there isn't a collision
							if (IsTrainApproaching(b.GetNextBlock(b.Status.TrainDirection)))
								m_switch.Switch();
						}
						else
						{
							// a train is approaching, switch so there isn't a collision
							if (!IsTrainApproaching(m_trackBlocks[m_switch.TrunkId]))
								m_switch.Switch();
						}
					}
				}

				// update track block authorites, speed and signals
				// work backward from the end of a swicth, a broken track, or a train present
				//if (m_trackBlocks.ContainsValue(b.NextBlock) || m_trackBlocks.ContainsValue(b.PreviousBlock))
				List<TrackBlock> blocks = new List<TrackBlock>(m_trackBlocks.Values);
				while (blocks.Count > 0)
				{
					TrackBlock b = blocks.ElementAt<TrackBlock>(0);
					if (b.Status.TrainPresent)
					{
						TrackBlock t;
						int i;

						for (i = -1, t = (b.GetNextBlock(b.Status.TrainDirection) == b.NextBlock) ? b.PreviousBlock : b.NextBlock;
							t != null && blocks.Contains<TrackBlock>(t) &&
							t.Status.IsOpen;
							++i, t = (t.NextBlock == t) ? t.PreviousBlock : t.NextBlock)
						{
							UpdateAuthoritySignal(t, i);
							if (t.Status.TrainPresent) break;
							blocks.Remove(t);
						}
					}
					else
					{
						UpdateAuthoritySignal(b, DEFAULT_AUTHORITY);
					}
					blocks.Remove(b);
				}
			}

			private void AddUpdatedStatus(TrackBlock b)
			{
				if (!m_updatedStatuses.ContainsKey(b.Name))
					m_updatedStatuses.Add(b.Name, b.Status);
			}

			private void UpdateAuthoritySignal(TrackBlock block, int authority)
			{
				if (block == null) throw new ArgumentNullException();
				if (authority < -1) throw new ArgumentOutOfRangeException();

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
				List<TrackBlock> blocks = new List<TrackBlock>(m_trackBlocks.Values);
				while (blocks.Count > 0)
				{
					TrackBlock b = blocks.ElementAt<TrackBlock>(0);
					if (b == dest) continue;
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
					blocks.Remove(b);
				}
				return false;
			}
		}
	}
}
