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

        public bool SetSwitch(TrackSwitch s)
        {
            return s != null;
        }

        public bool SuggestAuthority(string trackId, BlockAuthority auth)
        {
            return trackId != string.Empty && auth != null;
        }

        public bool CloseTrack(string trackId)
        {
            return trackId != string.Empty;
        }

        public bool OpenTrack(string trackId)
        {
            return trackId != string.Empty;
        }

        public Dictionary<string, TrackBlock> GetUpdatedTrackStatus()
        {
            return null;
        }

        public void Update()
        {
        }
    }
}
