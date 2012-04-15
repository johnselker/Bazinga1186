using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using TrackLib;
using Train;
using TrackControlLib.Sean;
using System.Reflection;

namespace CTCOfficeGUI
{
    public class CTCController
    {
        #region Public Methods

        /// <summary>
        /// Gets a reference to the CTC Controller singleton
        /// </summary>
        /// <returns>Singleton reference</returns>
        public static CTCController GetCTCController()
        {
            if (m_singleton == null)
            {
                m_singleton = new CTCController();
            }
            return m_singleton;
        }

        /// <summary>
        /// Attempts to set the speed limit for the specified block
        /// </summary>
        /// <param name="block">Track block</param>
        /// <param name="value">Speed limit value</param>
        /// <returns>Bool success</returns>
        public bool SetSpeedLimit(TrackBlock block, string value)
        {
            bool result = false;
            int limit;

            if (Int32.TryParse(value, out limit)) //Parse the string into an integer
            {
                if (limit >= 0 && limit <= block.Authority.SpeedLimitKPH)
                {
                    //Send speed limit to wayside controller
                    ITrackController controller = GetTrackController(block);
                    if (controller != null)
                    {
                        result = controller.SetAuthority(block.Name, new BlockAuthority(limit, block.Authority.Authority));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Attempts to set the authority for the specified block
        /// </summary>
        /// <param name="block">Track block</param>
        /// <param name="value">Authority value</param>
        /// <returns>Bool success</returns>
        public bool SetAuthority(TrackBlock block, string value)
        {
            bool result = false;
            int authority;

            if (Int32.TryParse(value, out authority)) //Parse the string into an integer
            {
                if (authority >= 0)
                {
                    //Send authority to wayside controller
                    ITrackController controller = GetTrackController(block);
                    if (controller != null)
                    {
                        result = controller.SetAuthority(block.Name, new BlockAuthority(block.Authority.SpeedLimitKPH, authority));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the track controller that controls the given block
        /// </summary>
        /// <param name="block">Track block</param>
        /// <returns>Track controller</returns>
        public ITrackController GetTrackController(TrackBlock block)
        {
            if (m_trackTable.ContainsKey(block))
            {
                return m_trackTable[block];
            }
            return null;
        }

        /// <summary>
        /// Closes the track block 
        /// </summary>
        /// <param name="block">Track block to close</param>
        /// <returns>bool Success</returns>
        public bool CloseTrackBlock(TrackBlock block)
        {
            bool result = false;
            ITrackController controller = GetTrackController(block);
            
            //Attempt to close the track block
            if (controller != null)
            {
                result = controller.CloseTrack(block.Name);
            }

            return result;
        }

        /// <summary>
        /// Opens the track block 
        /// </summary>
        /// <param name="block">Track block to open</param>
        /// <returns>bool Success</returns>
        public bool OpenTrackBlock(TrackBlock block)
        {
            bool result = false;
            ITrackController controller = GetTrackController(block);
           
            //Attempt to open the track block
            if (controller != null)
            {
                result = controller.OpenTrack(block.Name);
            }

            return result;
        }

        /// <summary>
        /// Suggests a route to a train
        /// </summary>
        /// <param name="train">Train to suggest to</param>
        /// <param name="route">List of track blocks</param>
        /// <returns>bool success</returns>
        public bool SuggestTrainRoute(ITrain train, List<TrackBlock> route)
        {
            bool result = false;

            if (train != null && route != null)
            {
                //Suggest the route
            }

            return result;
        }

        /// <summary>
        /// Initializes the track layout from file
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns>bool Success</returns>
        public bool LoadTrackLayout(string filename)
        {
            bool result = false;

            TrackLayoutSerializer serializer = new TrackLayoutSerializer(filename);

            try
            {
                serializer.Restore();
                List<TrackBlock> blocks = serializer.BlockList;
                result = BuildLayout(blocks);
            }
            catch (Exception e)
            {
                m_log.LogError("Layout restoration failed", e);
            }

            return result;
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Creates track controllers and assigns track blocks to them
        /// </summary>
        /// 
        /// <param name="blocks">List of track blocks in the layout</param>
        /// 
        /// <returns>bool Sucess</returns>
        private bool BuildLayout(List<TrackBlock> blocks)
        {
            if (blocks == null)
            {
                return false;
            }

            //Collection of track controllers 
            Dictionary<string, ITrackController> trackControllers = new Dictionary<string, ITrackController>();

            foreach (TrackBlock b in blocks)
            {
                //if (!trackControllers.ContainsKey(b.ControllerId))
                //{
                //    //Create a new track controller
                //    ITrackController controller = new TrackController();
                //    controller.AddTrackBlock(b, GetAdjacentBlocks(b));
                //    m_trackTable[b] = controller;
                //}
                //else
                //{
                //    //Add it to the existing track controller
                //    ITrackController controller = trackControllers[b.ControllerId];
                //    controller.AddTrackBlock(b, GetAdjacentBlocks(b));
                //    m_trackTable[b] = controller;
                //}
            }

            return true;
        }

        /// <summary>
        /// Gets the blocks adjacent to this one based on direction
        /// </summary>
        /// <param name="block">Track block to check</param>
        /// <returns>List of adjacent blocks</returns>
        private List<TrackBlock> GetAdjacentBlocks(TrackBlock block)
        {
            List<TrackBlock> blocks = new List<TrackBlock>();

            if (block != null)
            {
            }

            return blocks;
        }

        #endregion

        #region Private Data

        private static CTCController m_singleton = null;
        private Dictionary<TrackBlock, ITrackController> m_trackTable = new Dictionary<TrackBlock, ITrackController>();
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());

        #endregion
    }
}
