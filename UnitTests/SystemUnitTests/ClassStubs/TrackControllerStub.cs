using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackControlLib.Sean;
using CommonLib;

namespace ClassStubs
{
    public class TrackControllerStub : ITrackController
    {
        public bool AddTrackBlock(TrackBlock block)
        {
            return block != null;
        }

        public bool SetAdjTrackController(TrackController controller)
        {
            return controller != null;
        }

        public bool SuggestAuthority(string trackId, BlockAuthority auth)
        {
            return (!string.IsNullOrEmpty(trackId) && auth != null);
        }

        public bool CloseTrack(string trackId)
        {
            return (!string.IsNullOrEmpty(trackId));
        }

        public bool OpenTrack(string trackId)
        {
            return (!string.IsNullOrEmpty(trackId));
        }

        public TrackStatus GetTrackStatus(string trackId)
        {
            if (!string.IsNullOrEmpty(trackId))
            {
                return new TrackStatus();
            }
            return null;
        }

        public Dictionary<string, TrackStatus> GetAllTrackStatus()
        {
            return new Dictionary<string, TrackStatus>();
        }

        public void Update()
        { }
    }
}
