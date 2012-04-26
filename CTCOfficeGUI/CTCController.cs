using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using TrackLib;
using TrainLib;
using TrackControlLib.Sean;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace CTCOfficeGUI
{
    public class CTCController
    {
        #region Delegates

        public delegate void UpdateDisplay(List<TrackBlock> blocks, List<ITrain> trains);

        #endregion

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
        /// Subscribes for train system updates
        /// </summary>
        /// <param name="subscriber">Subscriber</param>
        /// <returns>bool success</returns>
        public bool Subscribe(UpdateDisplay updateDelegate)
        {
            bool result = false;
            if (updateDelegate != null)
            {
                lock (m_subscriberList)
                {
                    if (!m_subscriberList.Contains(updateDelegate))
                    {
                        //Add it to the subscriber list
                        m_subscriberList.Add(updateDelegate);
                        result = true;
                    }
                }
            }
            return result;
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
                //Let the Wayside controller determine if the speed limit is valid

                //Send speed limit to wayside controller
                ITrackController controller = GetTrackController(block);
                if (controller != null)
                {
                    try
                    {
                        result = controller.SuggestAuthority(block.Name, new BlockAuthority(limit, block.Authority.Authority));
                    }
                    catch (Exception e)
                    {
                        m_log.LogError("Error in setting speed limit", e);
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
                //Let the Wayside controller determine if the authority is valid

                //Send authority to wayside controller
                ITrackController controller = GetTrackController(block);
                if (controller != null)
                {
                    try
                    {
                        result = controller.SuggestAuthority(block.Name, new BlockAuthority(block.Authority.SpeedLimitKPH, authority));
                    }
                    catch (Exception e)
                    {
                        m_log.LogError("Error in setting authority", e);
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
            if (block != null)
            {
                if (m_trackTable.ContainsKey(block))
                {
                    return m_trackTable[block];
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a copy of the list of track controllers
        /// </summary>
        /// <returns>List of track controllers</returns>
        public List<ITrackController> GetTrackControllerList()
        {
            return new List<ITrackController>(m_controllerList);
        }


        /// <summary>
        /// Gets a copy of the track block list
        /// </summary>
        /// <returns>Copy of the block list</returns>
        public List<TrackBlock> GetBlockList()
        {
            return new List<TrackBlock>(m_blockList);
        }

        /// <summary>
        /// Gets a copy of the list of trains
        /// </summary>
        /// <returns>Copied list of trains</returns>
        public List<ITrain> GetTrainList()
        {
            return new List<ITrain>(m_trainList);
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
                try
                {
                    result = controller.CloseTrack(block.Name);
                }
                catch (Exception e)
                {
                    m_log.LogError("Error closing track block", e);
                }
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
                try
                {
                    result = controller.OpenTrack(block.Name);
                }
                catch (Exception e)
                {
                    m_log.LogError("Error opening track block", e);
                }
            }

            return result;
        }

        /// <summary>
        /// Initializes the track layout from file
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns>List of track blocks</returns>
        public List<TrackBlock> LoadTrackLayout(string filename)
        {
            List<TrackBlock> blocks = null;
            try
            {
                TrackLayoutSerializer layoutSerializer = new TrackLayoutSerializer(filename);
                layoutSerializer.Restore();
                blocks = layoutSerializer.BlockList;
                if (BuildLayout(blocks))
                {
                    m_updateTimer.Start();
                    m_log.LogInfo("Successfully loaded track layout. Starting update timer");
                }
                else
                {
                    m_log.LogError("Error building track layout");
                }
            }
            catch (Exception e)
            {
                m_log.LogError("Layout restoration failed", e);
            }

            return blocks;
        }

        /// <summary>
        /// Gets the total size of the track layout
        /// </summary>
        /// <returns>Layout size</returns>
        public Size GetLayoutSize()
        {
            return m_layoutSize;
        }

        /// <summary>
        /// Gets the top left corner of the track layout
        /// </summary>
        /// <returns>Layout position</returns>
        public Point GetLayoutPosition()
        {
            return m_layoutStartPoint;
        }

        /// <summary>
        /// Gets the redline schedule
        /// </summary>
        /// <returns>Queue of schedule info</returns>
        public Queue<ScheduleInfo> GetRedlineSchedule()
        {
            Queue<ScheduleInfo> redline = new Queue<ScheduleInfo>();
            ScheduleInfo info = new ScheduleInfo(Constants.StationNames.SHADYSIDE, 3.7);
            redline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.HERRONAVE, 2.3);
            redline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.SWISSVALE, 1.5);
            redline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.PENNSTATION, 1.8);
            redline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.STEELPLAZA, 2.1);
            redline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.FIRSTAVE, 2.1);
            redline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.STATIONSQUARE, 1.7);
            redline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.SOUTHHILLS, 2.3);
            redline.Enqueue(info);

            return redline;
        }

        /// <summary>
        /// Gets the greenline schedule
        /// </summary>
        /// <returns></returns>
        public Queue<ScheduleInfo> GetGreenlineSchedule()
        {
            Queue<ScheduleInfo> greenline = new Queue<ScheduleInfo>();
            ScheduleInfo info = new ScheduleInfo(Constants.StationNames.PIONEER, 2.3);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.EDGEBROOK, 2.3);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.STATION, 2.4);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.WHITED, 2.7);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.SOUTHBANK, 2.6);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.CENTRAL, 1.9);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.INGLEWOOD, 2.0);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.OVERBROOK, 2.0);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.GLENBURY, 2.2);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.DORMONT, 2.5);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.MTLEBANON, 2.2);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.POPLAR, 4.4);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.CASTLESHANNON, 2.2);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.DORMONT, 2.3);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.GLENBURY, 2.4);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.OVERBROOK, 2.1);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.INGLEWOOD, 2.0);
            greenline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.CENTRAL, 2.0);
            greenline.Enqueue(info);

            return greenline;
        }

        /// <summary>
        /// Adds a train to the list of trains
        /// </summary>
        /// <param name="train">Train to add</param>
        /// <returns>bool success</returns>
        public bool AddTrainToList(ITrain train)
        {
            bool result = false;

            if (train != null)
            {
                if (!m_trainList.Contains(train))
                {
                    m_trainList.Add(train);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Removes a train from the list of trains
        /// </summary>
        /// <param name="train">Train to remove</param>
        /// <returns>bool success</returns>
        public bool RemoveTrainFromList(ITrain train)
        {
            bool result = false;

            if (m_trainList.Contains(train))
            {
                m_trainList.Remove(train);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Updates the owners of the track blocks notifiying them that a train moved to a new position
        /// </summary>
        /// <param name="previous">Previous block the train was on</param>
        /// <param name="current">Current block the train is now on</param>
        /// <returns></returns>
        public bool UpdateTrackControllers(TrackBlock previous, TrackBlock current)
        {
            bool result = false;
            if (previous != null && current != null)
            {
                ITrackController previousController = GetTrackController(previous);
                ITrackController newController = GetTrackController(previous);
                
                if (previousController != null && newController != null)
                {
                    previousController.Update();

                    if (newController != previousController)
                    {
                        newController.Update();
                    }

                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Updates the owners of the track blocks notifiying them that a train moved to a new position
        /// </summary>
        /// <param name="previous">Previous block the train was on</param>
        /// <param name="current">Current block the train is now on</param>
        /// <returns></returns>
        public bool UpdateTrackController(TrackBlock block)
        {
            bool result = false;
            if (block != null)
            {
                ITrackController blockOwner = GetTrackController(block);

                if (blockOwner != null)
                {
                    blockOwner.Update();

                    result = true;
                }
            }

            return result;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Private constructor for the CTC controller
        /// </summary>
        private CTCController()
        {
            m_updateTimer = new Timer();
            m_updateTimer.Interval = 200; //Update every 200 ms
            m_updateTimer.Tick += OnUpdateTimerTick;

            CloseTrackBlock(null);
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

            //Variables for calculating the size of the layout
            double minX = Double.PositiveInfinity;
            double maxX = 0;
            double minY = Double.PositiveInfinity;
            double maxY = 0;

            //Reset
            m_controllerList.Clear();
            m_trainList.Clear();
            m_trackTable.Clear();
            m_blockList = new List<TrackBlock>();

            foreach (TrackBlock b in blocks)
            {
                if (!string.IsNullOrEmpty(b.ControllerId))
                {
                    m_blockList.Add(b);
                    if (!trackControllers.ContainsKey(b.ControllerId))
                    {
                        //Create a new track controller
                        ITrackController controller = new TrackController();
                        controller.AddTrackBlock(b);
                        m_trackTable[b] = controller;
                        m_controllerList.Add(controller);
                        trackControllers[b.ControllerId] = controller;
                    }
                    else
                    {
                        //Add it to the existing track controller
                        ITrackController controller = trackControllers[b.ControllerId];
                        controller.AddTrackBlock(b);
                        m_trackTable[b] = controller;
                    }
                }
                else
                {
                    m_log.LogError("Block primary controller ID was null or empty. Skipping block");
                    continue;
                }

                if (!string.IsNullOrEmpty(b.SecondaryControllerId))
                {
                    if (!trackControllers.ContainsKey(b.SecondaryControllerId))
                    {
                        //Create a new track controller
                        ITrackController controller = new TrackController();
                        controller.AddTrackBlock(b);
                        m_controllerList.Add(controller);
                        trackControllers[b.SecondaryControllerId] = controller;

                        //No need to add the controller to the track table. 
                    }
                    else
                    {
                        //Add it to the existing track controller
                        ITrackController controller = trackControllers[b.SecondaryControllerId];
                        controller.AddTrackBlock(b);

                        //No need to add the controller to the track table. 
                    }
                }

                //Calculate the min and max coordinates of the layout
                if (b.StartPoint.X < minX)
                {
                    //Only need to check the start point since it is always smaller
                    minX = b.StartPoint.X;
                }
                if (b.EndPoint.X > maxX)
                {
                    //Only need to check the end point since it is always larger
                    maxX = b.EndPoint.X;
                }

                //Need to check both the start and end point for Y
                if (b.StartPoint.Y < minY)
                {
                    minY = b.StartPoint.Y;
                }
                if (b.EndPoint.Y < minY)
                {
                    minY = b.EndPoint.Y;
                }

                if (b.StartPoint.Y > maxY)
                {
                    maxY = b.StartPoint.Y;
                }
                if (b.EndPoint.Y > maxY)
                {
                    maxY = b.EndPoint.Y;
                }
            }

            //Calculate the start point and total size
            m_layoutStartPoint = new Point(System.Convert.ToInt32(minX), System.Convert.ToInt32(minY));

            if (maxX < Double.PositiveInfinity && maxY < Double.PositiveInfinity)
            {
                m_layoutSize = new Size(System.Convert.ToInt32(maxX - minX), System.Convert.ToInt32(maxY - minY));
            }

            return true;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Update timer expired
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnUpdateTimerTick(object sender, EventArgs e)
        {
            lock (m_subscriberList)
            {
                List<TrackBlock> updatedBlocks = new List<TrackBlock>();

                if (m_controllerList != null)
                {
                    foreach (ITrackController controller in m_controllerList)
                    {
                        Dictionary<string, TrackBlock> blocks = controller.GetUpdatedTrackStatus();
                        if (blocks != null)
                        {
                            updatedBlocks.AddRange(blocks.Values.ToList<TrackBlock>());
                        }
                    }
                }

                foreach (UpdateDisplay updateDelegate in m_subscriberList)
                {
                    updateDelegate(updatedBlocks, m_trainList);
                }
            }
        }

        #endregion

        #region Private Data

        private static CTCController m_singleton = null;
        private Dictionary<TrackBlock, ITrackController> m_trackTable = new Dictionary<TrackBlock, ITrackController>();
        private List<TrackBlock> m_blockList;
        private List<ITrackController> m_controllerList = new List<ITrackController>();
        private List<ITrain> m_trainList = new List<ITrain>();
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private Size m_layoutSize;
        private Point m_layoutStartPoint;
        private List<UpdateDisplay> m_subscriberList = new List<UpdateDisplay>();
        private Timer m_updateTimer;

        #endregion
    }
}
