using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using TrackControlLib.Gilbert;

namespace TrackControlLib
{
    namespace Gilbert
    {
        public class TrackController : ITrackController
        {
            #region Private Data
            private const int AUTH_YELLOW = 1;
            private const int AUTH_GREEN = 5;
            private const int AUTH_SUPERGREEN = 10;
            private const int AUTH_SWITCH = 2;
            private const int DEFAULT_AUTHORITY = 20;

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
                m_updatedBlocks = new Dictionary<string, TrackBlock>();
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
                if(trackId == null)
                    return false;
                if (!m_trackBlocks.ContainsKey(trackId))
                    return false;
                return true;
            }

            // METHOD: SuggestAuthority
            // - Set track authority by trackId
            public bool SuggestAuthority(string trackId, BlockAuthority auth)
            {
                if(!checkTrackBlockExistence(trackId) || auth==null)
                    return false;
                if (auth.Authority < -1 || auth.SpeedLimitKPH < 0)
                    return false;

                if (auth.Authority <= m_trackBlocks[trackId].Authority.Authority)
                    UpdateAuthoritySignal(m_trackBlocks[trackId], auth.Authority);
                else
                    return false;

                if (auth.SpeedLimitKPH <= m_trackBlocks[trackId].StaticSpeedLimit)
                    m_trackBlocks[trackId].Authority.SpeedLimitKPH = auth.SpeedLimitKPH;
                else
                    return false;

                AddUpdatedStatus(m_trackBlocks[trackId]);

                return true;
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
                    AddUpdatedStatus(m_trackBlocks[trackId]);
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
                    AddUpdatedStatus(m_trackBlocks[trackId]);
                    return true;
                }
                return false;
            }

            public void Update()
            {
                CheckFailure();

                // Ensure safety on Switches
                UpdateSwitch();

                // Ensure safety on Authority
                UpdateAuthority();
            }

            // METHOD: CheckFailure
            // - Check block failures
            public void CheckFailure()
            {
                foreach (TrackBlock b in m_trackBlocks.Values)
                {
                    if (b.Status.BrokenRail || b.Status.CircuitFail || b.Status.PowerFail)
                        if (b.Status.IsOpen)
                            CloseTrack(b.Name);
                }
            }

            // METHOD: GetUpdatedTrackStatus
            // - Retrieve track status by trackId
            public Dictionary<string, TrackBlock> GetUpdatedTrackStatus()
            {
                Dictionary<string, TrackBlock> updatedBlocks = new Dictionary<string, TrackBlock>();
                foreach (KeyValuePair<string, TrackBlock> b in m_updatedBlocks)
                    updatedBlocks.Add(b.Key, b.Value);
                m_updatedBlocks.Clear();

                return updatedBlocks;
            }

            // METHOD: AddUpdatedStatus
            // - Add updated blocks to the dictionary
            public bool AddUpdatedStatus(TrackBlock block)
            {
                if (m_updatedBlocks.ContainsKey(block.Name))
                    m_updatedBlocks.Remove(block.Name);

                m_updatedBlocks.Add(block.Name, block);

                return true;
            }

            // METHOD: UpdateAuthoritySignal
            // - Update block signal from block authority
            public bool UpdateAuthoritySignal(TrackBlock block, int authority)
            {
                if (authority > AUTH_YELLOW)
                    block.Status.SignalState = TrackSignalState.Yellow;
                else
                    block.Status.SignalState = TrackSignalState.Red;
                if (authority > AUTH_GREEN)
                    block.Status.SignalState = TrackSignalState.Green;
                if (authority > AUTH_SUPERGREEN)
                    block.Status.SignalState = TrackSignalState.SuperGreen;

                AddUpdatedStatus(block);
                
                return true;
            }

            // METHOD: UpdateSwitch
            // - Update switches for safety
            private void UpdateSwitch()
            {
                if (m_switch == null)
                    return;

                foreach (TrackBlock b in m_trackBlocks.Values)
                {
                    if (b.Status.TrainPresent && b.HasSwitch)
                        if((m_switch.State == TrackSwitchState.Closed && b != m_switch.BranchClosed)
                            || (m_switch.State == TrackSwitchState.Open && b != m_switch.BranchOpen))
                            m_switch.Switch();
                }

                if (m_switch.State == TrackSwitchState.Closed)
                {
                    CloseTrack(m_switch.BranchOpenId);
                    if (m_switch.BranchOpen.NextBlock == null)
                        CloseTrack(m_switch.BranchOpen.PreviousBlockId);
                    else
                        CloseTrack(m_switch.BranchOpen.NextBlockId);
                }
                else
                {
                    CloseTrack(m_switch.BranchClosedId);
                    if (m_switch.BranchClosed.NextBlock == null)
                        CloseTrack(m_switch.BranchClosed.PreviousBlockId);
                    else
                        CloseTrack(m_switch.BranchClosed.NextBlockId);
                }
            }

            // METHOD: UpdateAuthority
            // - Update blocks authority for safety
            private void UpdateAuthority()
            {
                List<TrackBlock> blocks = new List<TrackBlock>(m_trackBlocks.Values);
                foreach (TrackBlock b in blocks)
                {
                    if (b.NextBlock == null || !checkTrackBlockExistence(b.NextBlock.Name))
                    {
                        int i = 0;
                        TrackBlock prevBlock = b.PreviousBlock;
                        while (prevBlock != null && blocks.Contains(prevBlock) && prevBlock.Status.IsOpen)
                        {
                            prevBlock.Authority.Authority = i;
                            UpdateAuthoritySignal(prevBlock, prevBlock.Authority.Authority);
                            prevBlock = prevBlock.PreviousBlock;
                            i++;
                        }
                    }
                    if (b.PreviousBlock == null || !checkTrackBlockExistence(b.PreviousBlock.Name))
                    {
                        int i = 0;
                        TrackBlock nextBlock = b.NextBlock;
                        while (nextBlock != null && blocks.Contains(nextBlock) && nextBlock.Status.IsOpen)
                        {
                            nextBlock.Authority.Authority = i;
                            UpdateAuthoritySignal(nextBlock, nextBlock.Authority.Authority);
                            nextBlock = nextBlock.NextBlock;
                            i++;
                        }
                    }

                    if (b.Status.TrainPresent)
                    {
                        b.Authority.Authority = 10;
                        UpdateAuthoritySignal(b, b.Authority.Authority);

                        bool TrainDirectionSameToBlocks;
                        TrackBlock nextBlock = b.GetNextBlock(b.Status.TrainDirection);
                        TrackBlock prevBlock;
                        if (b.NextBlock != nextBlock)
                        {
                            TrainDirectionSameToBlocks = false;
                            prevBlock = b.NextBlock;
                        }
                        else
                        {
                            prevBlock = b.PreviousBlock;
                            TrainDirectionSameToBlocks = true;
                        }

                        // Go over blocks ahead the train
                        if (nextBlock != null)
                        {
                            int i = 1;
                            if (TrainDirectionSameToBlocks)
                                do
                                {
                                    nextBlock.Authority.Authority = i;
                                    UpdateAuthoritySignal(nextBlock, nextBlock.Authority.Authority);
                                    nextBlock = nextBlock.NextBlock;
                                    i++;
                                }
                                while (nextBlock != null && blocks.Contains(nextBlock) && nextBlock.Status.IsOpen);
                            else
                                do
                                {
                                    nextBlock.Authority.Authority = i;
                                    UpdateAuthoritySignal(nextBlock, nextBlock.Authority.Authority);
                                    nextBlock = nextBlock.PreviousBlock;
                                    i++;
                                }
                                while (nextBlock != null && blocks.Contains(nextBlock) && nextBlock.Status.IsOpen);
                        }

                        // Go over blocks behind the train
                        if (prevBlock != null)
                        {
                            int i = 1;
                            if (!TrainDirectionSameToBlocks)
                                do
                                {
                                    prevBlock.Authority.Authority = i;
                                    UpdateAuthoritySignal(prevBlock, prevBlock.Authority.Authority);
                                    prevBlock = prevBlock.NextBlock;
                                    i++;
                                }
                                while (prevBlock != null && blocks.Contains(prevBlock) && prevBlock.Status.IsOpen);
                            else
                                do
                                {
                                    prevBlock.Authority.Authority = i;
                                    UpdateAuthoritySignal(prevBlock, prevBlock.Authority.Authority);
                                    prevBlock = prevBlock.PreviousBlock;
                                    i++;
                                }
                                while (prevBlock != null && blocks.Contains(prevBlock) && prevBlock.Status.IsOpen);
                        }
                    }
                }
            }

            #endregion
        }
    }
}
