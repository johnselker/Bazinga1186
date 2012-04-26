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
            private const int AUTH_YELLOW = 1;
            private const int AUTH_GREEN = 2;
            private const int AUTH_SUPERGREEN = 4;
            private const int DEFAULT_AUTHORITY = 8;

            private Dictionary<string, TrackBlock> m_trackBlocks;
            private Dictionary<string, TrackBlock> m_updatedBlocks;
            private TrackSwitch m_switch;
            #endregion

            #region Public Methods

            // METHOD: TrackController
            // - TrackController Constructor
            public TrackController()
            {
                m_trackBlocks = new Dictionary<string,TrackBlock>();
                m_switch = null;
            }

            // METHOD: TrackController
            // - TrackController Constructor
            public bool AddTrackBlock(TrackBlock block)
            {
                // Null Arguments
                if (block == null)
                    return false;

                // TrackBlock Duplicated
                if (m_trackBlocks.ContainsKey(block.Name))
                    return false;

                block.Authority.SpeedLimitKPH = System.Convert.ToInt32(block.StaticSpeedLimit);
                m_trackBlocks.Add(block.Name, block);

                return true;
            }

            // METHOD: SetSwitch
            // - Set m_switch
            public bool SetSwitch(TrackSwitch s)
            {
                if (s == null)
                    return false;

                m_switch = s;
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
            public bool SuggestAuthority(string trackId, BlockAuthority auth)
            {
                if (checkTrackBlockExistence(trackId))
                {
                    m_trackBlocks[trackId].Authority = auth;
                    return true;
                }
                return false;
            }

            // METHOD: CloseTrack
            // - Close track by trackId
            public bool CloseTrack(string trackId)
            {
                if (checkTrackBlockExistence(trackId))
                {
                    m_trackBlocks[trackId].Authority.Authority = 0;
                    m_trackBlocks[trackId].Authority.SpeedLimitKPH = 0;
                    m_trackBlocks[trackId].Status.SignalState = TrackSignalState.Red;
                    m_trackBlocks[trackId].Status.IsOpen = false;
                    return true;
                }
                return false;
            }

            // METHOD: OpenTrack
            // - Open track by trackId
            public bool OpenTrack(string trackId)
            {
                if (checkTrackBlockExistence(trackId) && !m_trackBlocks[trackId].Status.IsOpen)
                {
                    m_trackBlocks[trackId].Authority.SpeedLimitKPH = System.Convert.ToInt32(m_trackBlocks[trackId].StaticSpeedLimit);
                    m_trackBlocks[trackId].Status.IsOpen = true;
                    return true;
                }
                return false;
            }

            // METHOD: getTrackStatus
            // - Retrieve track status by trackId
            public Dictionary<string, TrackBlock> GetUpdatedTrackStatus()
            {
                return m_updatedBlocks;
            }

            #endregion
        }
    }
}
