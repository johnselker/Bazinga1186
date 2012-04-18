using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;

namespace TrackControlLib
{
    namespace Gilbert
    {
        public interface ITrackController
        {
            bool AddTrackBlock(TrackBlock block, List<TrackBlock> adjBlocks);
            bool setAuthority(string trackId, BlockAuthority auth);
            bool closeTrack(string trackId);
            bool openTrack(string trackId);
            bool isTrackClosed(string trackId);
            TrackStatus getTrackStatus(string trackId);
        }
    }
}