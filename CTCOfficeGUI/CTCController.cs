using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using TrackLib;
using Train;
using TrackControlLib.Sean;
using System.Reflection;
using System.Drawing;
using System.Timers;

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
        /// Subscribes for train system updates
        /// </summary>
        /// <param name="subscriber">Subscriber</param>
        /// <returns>bool success</returns>
        public bool Subscribe(ITrainSystemWatcher subscriber)
        {
            bool result = false;
            if (subscriber != null)
            {
                if (!m_subscriberList.Contains(subscriber))
                {
                    //Add it to the subscriber list
                    m_subscriberList.Add(subscriber);
                    result = true;
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
                if (limit >= 0 && limit <= block.Authority.SpeedLimitKPH)
                {
                    //Send speed limit to wayside controller
                    ITrackController controller = GetTrackController(block);
                    if (controller != null)
                    {
                        result = controller.SuggestAuthority(block.Name, new BlockAuthority(limit, block.Authority.Authority));
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
        /// <returns>List of track blocks</returns>
        public List<TrackBlock> LoadTrackLayout(string filename)
        {
            List<TrackBlock> blocks = null;

            try
            {
                TrackLayoutSerializer layoutSerializer = new TrackLayoutSerializer(filename);
                layoutSerializer.Restore();
                blocks = layoutSerializer.BlockList;
                if (!BuildLayout(blocks))
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

        #endregion

        #region Constructor

        /// <summary>
        /// Private constructor for the CTC controller
        /// </summary>
        private CTCController()
        {
            m_updateTimer = new Timer(200); //Update every 200 ms
            m_updateTimer.AutoReset = true;
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

            foreach (TrackBlock b in blocks)
            {
                if (!string.IsNullOrEmpty(b.ControllerId))
                {
                    if (!trackControllers.ContainsKey(b.ControllerId))
                    {
                        //Create a new track controller
                        ITrackController controller = new TrackController();
                        controller.AddTrackBlock(b);
                        m_trackTable[b] = controller;
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
                    m_log.LogError("Block primary controller ID was null or empty. Not allowed");
                    return false;
                }

                if (!string.IsNullOrEmpty(b.SecondaryControllerId))
                {
                    if (!trackControllers.ContainsKey(b.SecondaryControllerId))
                    {
                        //Create a new track controller
                        ITrackController controller = new TrackController();
                        controller.AddTrackBlock(b);
                        m_trackTable[b] = controller;
                    }
                    else
                    {
                        //Add it to the existing track controller
                        ITrackController controller = trackControllers[b.ControllerId];
                        controller.AddTrackBlock(b);
                        m_trackTable[b] = controller;
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

        #region Event Handlers

        /// <summary>
        /// Update timer expired
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnUpdateTimerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (m_subscriberList)
            {
                foreach (ITrainSystemWatcher watcher in m_subscriberList)
                {
                    //Update the subscribers
                    watcher.Update();
                }
            }
        }
        #endregion

        #region Private Data

        private static CTCController m_singleton = null;
        private Dictionary<TrackBlock, ITrackController> m_trackTable = new Dictionary<TrackBlock, ITrackController>();
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private Size m_layoutSize;
        private Point m_layoutStartPoint;
        private List<ITrainSystemWatcher> m_subscriberList = new List<ITrainSystemWatcher>();
        private Timer m_updateTimer;

        #endregion
    }
}
