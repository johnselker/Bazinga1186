using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;

namespace TrackControlLib
{
	namespace Sean
	{
		public interface ITrackController
		{
			bool AddTrackBlock(TrackBlock block);
			bool SetAdjTrackController(TrackController controller);
			bool SuggestAuthority(string trackId, BlockAuthority auth);
			bool CloseTrack(string trackId);
			bool OpenTrack(string trackId);
			bool IsTrackClosed(string trackId);
			TrackStatus GetTrackStatus(string trackId);
			Dictionary<string, TrackStatus> GetAllTrackStatus();
			void Update();
		}
	}
}
