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
			private const int AUTH_THRESH_SWITCH = 2;
			private const int AUTH_THRESH_YELLOW = 1;
			private const int AUTH_THRESH_GREEN = 5;
			private const int AUTH_THRESH_SUPERGREEN = 10;

			private Dictionary<string, TrackBlock> m_trackBlocks;
			private Dictionary<string, TrackStatus> m_updatedStatuses;
			private TrackSwitch m_switch;
			private TrackController m_next;
			private TrackController m_prev;

			public TrackController()
			{
				m_trackBlocks = new Dictionary<string, TrackBlock>();
				m_updatedStatuses = new Dictionary<string, TrackStatus>();
				m_switch = null;
				m_next = m_prev = null;
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

			public bool SetAdjTrackController(TrackController controller)
			{
				if (controller == null) return false;

				if (m_next == null)
					m_next = controller;
				else if (m_prev == null)
					m_prev = controller;
				else
					return false;

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
					if (b.Status.TrainPresent)
					{
						

					}

					// update track block authorites, speed and signals
					// work backward from the end of a swicth, a broken track, or a train present
					if (t == null || 
						t.Status.TrainPresent ||
						!t.Status.IsOpen)
					{
						int i;

						// update the authorites
						for (t = b, i = -1;
							t != null && t.Status.IsOpen && 
							m_trackBlocks.ContainsKey(t.Name);
							++i, t = t.PreviousBlock)
						{
							UpdateAuthoritySignal(t, i);
							if (t.Status.TrainPresent) break;
						}
					}
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
				if (authority < 0) throw new ArgumentOutOfRangeException();

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

			private bool IsTrainApproaching(TrackController from)
			{
				if (from == null) throw new ArgumentNullException();

				foreach (TrackBlock b in from.m_trackBlocks.Values)
				{
					if (b.Status.TrainPresent)
					{
						if (from.m_trackBlocks.ContainsKey(b.Name) &&
							m_trackBlocks.ContainsKey(b.Name))
						{
							for (TrackBlock t = b.GetNextBlock(b.Status.TrainDirection);
								t != null && t.Status.IsOpen;
								t = t.GetNextBlock(b.Status.TrainDirection))
							{
								if (!from.m_trackBlocks.ContainsKey(t.Name) &&
									m_trackBlocks.ContainsKey(t.Name))
									return true;
							}
						}
						else
							return false;
					}
				}
				return false;
			}
		}
	}
}
