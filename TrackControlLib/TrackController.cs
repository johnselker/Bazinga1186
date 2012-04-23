using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CommonLib;

namespace TrackControlLib
{
	namespace Sean
	{
		public class TrackController : ITrackController
		{		
			private const double SPEED_SCALAR_RED = 0.0;
			private const double SPEED_SCALAR_YELLOW = 0.45;
			private const double SPEED_SCALAR_GREEN = 0.95;
			private const double SPEED_SCALAR_SUPERGREEN = 1.0;

			private const int AUTH_THRESH_SWITCH = 2;
			private const int AUTH_THRESH_YELLOW = 1;
			private const int AUTH_THRESH_GREEN = 10;
			private const int AUTH_THRESH_SUPERGREEN = 20;

			private Dictionary<string, TrackBlock> m_trackBlocks;
			private TrackController m_next;
			private TrackController m_prev;
			private TrackBlock m_switch;

			private BlockAuthority m_suggAuth;
			private string m_currBlockId;

			public TrackController()
			{
				m_trackBlocks = new Dictionary<string, TrackBlock>();
				m_next = m_prev = null;

				m_suggAuth = null;
				m_currBlockId = string.Empty;
			}

			public bool AddTrackBlock(TrackBlock block)
			{
				if (block == null) return false;
				if (m_trackBlocks.ContainsKey(block.Name))
					return false;
				
				m_trackBlocks.Add(block.Name, block);
				if (block.HasSwitch) m_switch = block;
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

				m_currBlockId = trackId;
				m_suggAuth = auth;

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

				// update switching

				// update track block authorites
				foreach (TrackBlock b in m_trackBlocks.Values)
				{
					if (b.Status.TrainPresent)
					{
						TrackBlock t;
						int i;

						for (t = b.PreviousBlock, i = 0;
							t != null && !t.Status.TrainPresent &&
							t.Status.IsOpen && m_trackBlocks.ContainsKey(t.Name);
							++i, t = t.PreviousBlock)
						{
							UpdateSpeedAuthoritySignal(t, i);
						}
					}

					if (b.NextBlock == null)
					{
						TrackBlock t;
						int i;

						// update the authorites
						for (t = b, i = 0;
							t != null && !t.Status.TrainPresent &&
							t.Status.IsOpen && m_trackBlocks.ContainsKey(t.Name);
							++i, t = t.PreviousBlock)
						{
							UpdateSpeedAuthoritySignal(t, i);
						}
					}
				}

				// update block to suggested auth if safe
				if (m_currBlockId != string.Empty && m_suggAuth != null)
				{
					if (m_suggAuth.Authority < m_trackBlocks[m_currBlockId].Authority.Authority)
						UpdateSpeedAuthoritySignal(m_trackBlocks[m_currBlockId], m_suggAuth.Authority);
					if (m_suggAuth.SpeedLimitKPH < m_trackBlocks[m_currBlockId].Authority.SpeedLimitKPH)
						m_trackBlocks[m_currBlockId].Authority.SpeedLimitKPH = m_suggAuth.SpeedLimitKPH;

					m_currBlockId = string.Empty;
					m_suggAuth = null;
				}
			}

			private void UpdateSpeedAuthoritySignal(TrackBlock block, int authority)
			{
				double speedScalar;
				block.Authority.Authority = authority;

				if (authority > AUTH_THRESH_SUPERGREEN)
				{
					block.Status.SignalState = TrackSignalState.SuperGreen;
					speedScalar = SPEED_SCALAR_SUPERGREEN;
				}
				else if (authority > AUTH_THRESH_GREEN)
				{
					block.Status.SignalState = TrackSignalState.Green;
					speedScalar = SPEED_SCALAR_GREEN;
				}
				else if (authority > AUTH_THRESH_YELLOW)
				{
					block.Status.SignalState = TrackSignalState.Yellow;
					speedScalar = SPEED_SCALAR_YELLOW;
				}
				else
				{
					block.Status.SignalState = TrackSignalState.Red;
					speedScalar = SPEED_SCALAR_RED;
				}

				block.Authority.SpeedLimitKPH = System.Convert.ToInt32(block.StaticSpeedLimit * speedScalar);
			}
		}
	}
}
