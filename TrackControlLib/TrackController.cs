using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;

namespace TrackControlLib
{
	public class TrackController : ITrackController
	{
		private Hashtable m_trackBlocks;
		private TrackController m_next;
		private TrackController m_prev;

		public TrackController(IEnumerable<TrackBlock> blocks)
		{
			if (blocks != null)
			{
				foreach (TrackBlock b in blocks)
				{
					if (b != null)
						m_trackBlocks.Add(b.Name, b);
				}
			}
		}

		public bool SetAdjTrackConroller(TrackController controller)
		{
			if (m_next == null)
				m_next = controller;
			else if (m_prev == null)
				m_prev = controller;
			else
				return false;
			return true;
		}
	
		public bool  SetAuthority(string trackId, BlockAuthority auth)
		{
 			throw new NotImplementedException();
		}

		public bool  CloseTrack(string trackId)
		{
 			throw new NotImplementedException();
		}

		public bool  OpenTrack(string trackId)
		{
 			throw new NotImplementedException();
		}

		public bool  IsTrackClosed(string trackId)
		{
 			throw new NotImplementedException();
		}

		public TrackStatus  GetTrackStatus(string trackId)
		{
			if (m_trackBlocks.ContainsKey(trackId))
				return (TrackStatus)m_trackBlocks[trackId];
			else
				throw new KeyNotFoundException();
		}

		public Dictionary<string, TrackStatus>  GetAllTrackStatus()
		{
			Dictionary<string, TrackStatus> statuses = new Dictionary<string,TrackStatus>();
			foreach (KeyValuePair<string, TrackBlock> b in m_trackBlocks)
				statuses.Add(b.Key, b.Value.Status);
			return statuses;
		}
	}
}
