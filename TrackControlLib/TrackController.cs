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
			private Dictionary<string, TrackBlock> m_trackBlocks;
			private TrackController m_next;
			private TrackController m_prev;

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

			public bool IsTrackClosed(string trackId)
			{
				if (m_trackBlocks.ContainsKey(trackId))
					return !((TrackBlock)m_trackBlocks[trackId]).Status.IsOpen;
				else
					throw new KeyNotFoundException();
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
				foreach (TrackBlock b in m_trackBlocks.Values)
				{
					// check for track block errors
					if (b.Status.BrokenRail)
					{
						if (!IsTrackClosed(b.Name)) CloseTrack(b.Name);
					}
					// take suggested authority and determine if safe
					// if safe, execute it
					// if not 

				}
			}
		}
	}
}
