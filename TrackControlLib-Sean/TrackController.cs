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
			private Dictionary<string, TrackBlock> m_updatedBlocks;
			private TrackSwitch m_switch;
			private TrackController m_next;
			private TrackController m_prev;

			public TrackController()
			{
				m_trackBlocks = new Dictionary<string, TrackBlock>();
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

				if (auth.SpeedLimitKPH <= m_trackBlocks[trackId].Authority.SpeedLimitKPH)
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

					m_trackBlocks[trackId].PreviousBlock.Authority.Authority = 0;
					m_trackBlocks[trackId].PreviousBlock.Authority.SpeedLimitKPH = 0;
					m_trackBlocks[trackId].PreviousBlock.Status.SignalState = TrackSignalState.Red;

					if (m_trackBlocks[trackId].AllowedDirection == TrackAllowedDirection.Both)
					{
						m_trackBlocks[trackId].NextBlock.Authority.Authority = 0;
						m_trackBlocks[trackId].NextBlock.Authority.SpeedLimitKPH = 0;
						m_trackBlocks[trackId].NextBlock.Status.SignalState = TrackSignalState.Red;
					}

					return true;
				}
				else
					return false;
			}

			public bool OpenTrack(string trackId)
			{
				if (m_trackBlocks.ContainsKey(trackId))
				{
					m_trackBlocks[trackId].Status.IsOpen = true;
					return true;
				}
				else
					return false;
			}

			public TrackStatus GetTrackStatus(string trackId)
			{
				if (m_trackBlocks.ContainsKey(trackId))
					return ((TrackBlock)m_trackBlocks[trackId]).Status;
				else
					throw new KeyNotFoundException();
			}

			public Dictionary<string, TrackStatus> GetAllTrackStatus()
			{
				Dictionary<string, TrackStatus> statuses = new Dictionary<string, TrackStatus>();
				foreach (KeyValuePair<string, TrackBlock> b in m_trackBlocks)
					statuses.Add(b.Key, b.Value.Status);
				return statuses;
			}

			public void Update()
			{
				// check for track block errors
				foreach (TrackBlock b in m_trackBlocks.Values)
				{
					if (b.Status.BrokenRail || b.Status.CircuitFail || b.Status.PowerFail)
					{
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

					//// switching logic
					//if (i <= AUTH_THRESH_SWITCH && t.Status.TrainPresent)
					//{
					//    if (m_next != null)
					//    {
					//        if (!IsTrainApproaching(m_next))
					//        {
					//            if (b.HasSwitch)
					//            {
					//                TrackSwitchState newState;
					//                string newId;

					//                if (b.Switch.State == TrackSwitchState.Closed)
					//                {
					//                    newState = TrackSwitchState.Open;
					//                    newId = b.Switch.BranchOpenId;
					//                }
					//                else
					//                {
					//                    newState = TrackSwitchState.Closed;
					//                    newId = b.Switch.BranchClosedId;
					//                }

					//                b.Switch.State = newState;

					//                if (m_trackBlocks.ContainsKey(newId))
					//                {
					//                    b.NextBlock = m_trackBlocks[newId];

					//                    if (m_trackBlocks[newId].NextBlock.HasSwitch)
					//                        UpdateBlockDirection(b, m_trackBlocks[newId]); //some other stuff
					//                }
					//                else
					//                    throw new Exception("Track Controller blocks did not contain switch block");
					//            }
					//            else
					//            {
					//                throw new Exception("A switch was not found");
					//            }
					//        }
					//    }
					//}
				}
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
						for (TrackBlock t = b;
							t != null && t.Status.IsOpen;
							t = t.NextBlock)
						{
							if (!from.m_trackBlocks.ContainsKey(t.Name) &&
								m_trackBlocks.ContainsKey(t.Name))
								return true;
						}
					}
				}
				return false;
			}
		}
	}
}
