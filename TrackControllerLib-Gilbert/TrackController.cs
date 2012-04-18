using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using TrackControlLib.Gilbert;

namespace TrackControllerLib
{
    namespace Gilbert
    {
        public class TrackController : ITrackController
        {
            #region Private Data
            private Dictionary<string, TrackBlock> m_trackBlocks;
            #endregion

            #region Public Methods

            // METHOD: TrackController
            // - TrackController Constructor
            public TrackController()
            {
                m_trackBlocks = new Dictionary<string,TrackBlock>();
            }

            // METHOD: TrackController
            // - TrackController Constructor
            public bool AddTrackBlock(TrackBlock block, List<TrackBlock> adjBlocks)
            {
                // Null Arguments
                if (block == null)
                    return false;
                if (adjBlocks == null)
                    return false;

                // TrackBlock Duplicated
                if (m_trackBlocks.ContainsKey(block.Name))
                    return false;

                m_trackBlocks.Add(block.Name, block);

                // TODO: Add code for adjecent blocks

                return true;
            }

            // METHOD: checkTrackBlockExistence
            // - Check track block existence with given trackId
            public bool checkTrackBlockExistence(string trackId)
            {
                if (!m_trackBlocks.ContainsKey(trackId))
                    throw new KeyNotFoundException();
                return true;
            }

            // METHOD: setAuthority
            // - Set track authority by trackId
            public bool setAuthority(string trackId, BlockAuthority auth)
            {
                if (checkTrackBlockExistence(trackId))
                {
                    m_trackBlocks[trackId].Authority = auth;
                    return true;
                }
                return false;
            }

            // METHOD: closeTrack
            // - Close track by trackId
            public bool closeTrack(string trackId)
            {
                if (checkTrackBlockExistence(trackId))
                {
                    m_trackBlocks[trackId].Status.IsOpen = false;
                    return true;
                }
                return false;
            }

            // METHOD: openTrack
            // - Open track by trackId
            public bool openTrack(string trackId)
            {
                if (checkTrackBlockExistence(trackId))
                {
                    m_trackBlocks[trackId].Status.IsOpen = true;
                    return true;
                }
                return false;
            }

            // METHOD: isTrackClosed
            // - Check track open status by trackId
            public bool isTrackClosed(string trackId)
            {
                if (checkTrackBlockExistence(trackId))
                    return !(m_trackBlocks[trackId].Status.IsOpen);
                return true;
            }

            // METHOD: getTrackStatus
            // - Retrieve track status by trackId
            public TrackStatus getTrackStatus(string trackId)
            {
                if (checkTrackBlockExistence(trackId))
                    return m_trackBlocks[trackId].Status;
                return null;
            }

            #endregion
        }
    }
}
