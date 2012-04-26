using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using TrackLib;
using CommonLib;
using System.Reflection;
using TrackControlLib.Sean;
using TrainControllerLib;
using TrainLib;

namespace CTCOfficeGUI
{
    public class Simulator
    {
        #region Private Data

        private System.Timers.Timer m_simulationTimer = new System.Timers.Timer(1);
        private static Simulator m_singleton;
        private List<ITrainController> m_trainControllerList = new List<ITrainController>();
        private List<ITrackController> m_trackControllerList;
        private DateTime m_lastUpdateTime;
        private double m_simulationScale = 1;
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private Dictionary<string, Direction> m_startingDirections;
        private bool m_running = false;
        private CTCController m_ctcController = CTCController.GetCTCController();
        
        #endregion

        #region Accessors

        /// <summary>
        /// Flag indicating that the simulation is running
        /// </summary>
        public bool SimulationRunning
        {
            get { return m_running; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the singleton simulator instance
        /// </summary>
        /// <returns>Singleton instance</returns>
        public static Simulator GetSimulator()
        {
            if (m_singleton == null)
            {
                m_singleton = new Simulator();
            }

            return m_singleton;
        }

        #region Simulation Methods

        /// <summary>
        /// Sets the simulation speed
        /// </summary>
        /// 
        /// <remarks>Scale of 1 is real time, scale of 10 is 10x real time, etc.</remarks>
        /// 
        /// <param name="scale">Simulation scale</param>
        /// 
        /// <returns>bool success</returns>
        public bool SetSimulationSpeed(double scale)
        {
            bool result = false;

            if (scale >= 1 && scale < 100)
            {
                m_log.LogInfoFormat("Setting simulation speed to {0}", scale);
                m_simulationScale = scale;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Starts the simulation timer to update train positions
        /// </summary>
        public void StartSimulation()
        {
            m_running = true;
            m_lastUpdateTime = DateTime.Now;
            m_trackControllerList = m_ctcController.GetTrackControllerList();

            //Initialize the track controllers 
            if (m_trackControllerList != null)
            {
                foreach (ITrackController controller in m_trackControllerList)
                {
                    controller.Update();
                }
            }

            m_simulationTimer.Start();
        }

        /// <summary>
        /// Pauses the simulation timer 
        /// </summary>
        public void PauseSimulation()
        {
            m_running = false;
            m_simulationTimer.Stop();
        }

        /// <summary>
        /// Stops the simulation and clears the lists of components to update
        /// </summary>
        public void StopSimulation()
        {
            m_running = false;
            m_simulationTimer.Stop();
            m_trackControllerList.Clear();
            m_trainControllerList.Clear();
        }

        #endregion

        #region Train Failure Simulations

        /// <summary>
        /// Simulates a train pickup failure
        /// </summary>
        /// <param name="train">Train to simulate on</param>
        /// <param name="failure">True to invoke failure or false to clear it</param>
        public void SimulatePickupFailure(ITrain train, bool failure)
        {
            if (train != null)
            {
                try
                {
                    m_log.LogInfoFormat("Setting signal pickup failure of train {0}", failure);
                    train.SetSignalPickupFailure(failure);
                }
                catch (Exception)
                {
                    m_log.LogError("Error in setting signal pickup failure");
                }
            }
        }

        /// <summary>
        /// Simulates a train brake failure
        /// </summary>
        /// <param name="train">Train to simulate on</param>
        /// <param name="failure">True to invoke failure or false to clear it</param>
        public void SimulateBrakeFailure(ITrain train, bool failure)
        {
            if (train != null)
            {
                try
                {
                    m_log.LogInfoFormat("Setting brake failure of train {0}", failure);
                    train.SetBrakeFailure(failure);
                }
                catch (Exception)
                {
                    m_log.LogError("Error in setting signal pickup failure");
                }
            }
        }

        /// <summary>
        /// Simulates a train engine failure
        /// </summary>
        /// <param name="train">Train to simulate on</param>
        /// <param name="failure">True to invoke failure or false to clear it</param>
        public void SimulateEngineFailure(ITrain train, bool failure)
        {
            if (train != null)
            {
                try
                {
                    m_log.LogInfoFormat("Setting engine failure of train {0}", failure);
                    train.SetEngineFailure(failure);
                }
                catch (Exception)
                {
                    m_log.LogError("Error in setting signal pickup failure");
                }
            }
        }

        #endregion

        #region Track Failure Simulations

        /// <summary>
        /// Simulates a track broken rail
        /// </summary>
        /// <param name="block">Block to simulate on</param>
        /// <param name="failure">True to invoke failure or false to clear it</param>
        public void SimulateBrokenRail(TrackBlock block, bool failure)
        {
            if (block != null)
            {
                if (block.Status != null)
                {
                    m_log.LogInfoFormat("Setting broken rail of block {0} to {1}", block.Name, failure);
                    block.Status.BrokenRail = failure;
                    m_ctcController.UpdateTrackController(block);
                }
            }
        }

        /// <summary>
        /// Simulates a track block circuit failure
        /// </summary>
        /// <param name="block">Track block to simulate on</param>
        /// <param name="failure">True to invoke failure or false to clear it</param>
        public void SimulateCircuitFailure(TrackBlock block, bool failure)
        {
            if (block != null)
            {
                if (block.Status != null)
                {
                    m_log.LogInfoFormat("Setting circuit fail of block {0} to {1}", block.Name, failure);
                    block.Status.CircuitFail = failure;
                    m_ctcController.UpdateTrackController(block);
                }
            }
        }

        /// <summary>
        /// Simulates a track block power failure
        /// </summary>
        /// <param name="block">Track block to simulate on</param>
        /// <param name="failure">True to invoke failure or false to clear it</param>
        public void SimulatePowerFailure(TrackBlock block, bool failure)
        {
            if (block != null)
            {
                if (block.Status != null)
                {
                    m_log.LogInfoFormat("Setting power fail of block {0} to {1}", block.Name, failure);
                    block.Status.PowerFail = failure;
                    m_ctcController.UpdateTrackController(block);
                }
            }
        }

        #endregion

        /// <summary>
        /// Creates a new train on the track
        /// 
        /// </summary>
        /// <param name="initialBlock">Starting block of the train</param>
        /// <param name="name">Name of the train</param>
        public void SpawnNewTrain(TrackBlock initialBlock, string name)
        {
            if (initialBlock != null)
            {
                if (initialBlock.HasTransponder) 
                {
                    string start = initialBlock.Transponder.StationName;
                    if (start.Contains(Constants.TRAINYARD)) //Can only spawn trains from stations
                    {
                        if (m_startingDirections.ContainsKey(start))
                        {
                            m_log.LogInfoFormat("Spawning new train \"{0}\" at start {1}", name, start); 
                            //Create the new train and train controller
                            ITrain train = new TrainLib.Train(name, initialBlock, m_startingDirections[start]);
                            train.TrainEnteredNewBlock += OnTrainEnteredNewBlock;
                            ITrainController trainController = new TrainController(train);
                            m_trainControllerList.Add(trainController);
                            CTCController.GetCTCController().AddTrainToList(train); 

                            //Set the train schedule
                            if (start == Constants.REDYARD)
                            {
                                m_log.LogInfoFormat("Setting schedule of {0} to red line", name);
                                trainController.Schedule = CTCController.GetCTCController().GetRedlineSchedule();
                            }
                            else if (start == Constants.GREENYARDOUT)
                            {
                                m_log.LogInfoFormat("Setting schedule of {0} to green line", name);
                                trainController.Schedule = CTCController.GetCTCController().GetGreenlineSchedule();
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Private constructor
        /// </summary>
        private Simulator()
        {
            m_simulationTimer.AutoReset = true;
            m_simulationTimer.Elapsed += OnSimulationTimerElapsed;
            m_lastUpdateTime = DateTime.Now;

            //Hard-coded starting diretions for spawning trains from the train yard
            m_startingDirections = new Dictionary<string, Direction>(){
            {Constants.REDYARD, Direction.Northwest}, {Constants.GREENYARDOUT, Direction.South} };
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Timer elapsed
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Elapsed event arguments</param>
        private void OnSimulationTimerElapsed(object sender, ElapsedEventArgs e)
        {
            //Calculate the time step and scale it by the simulation time
            //Scale of 1 is real time, scale of 10 is 10x real time, etc.
            DateTime timeFreeze = DateTime.Now;
            TimeSpan timeDiff = timeFreeze - m_lastUpdateTime;
            double timeStep = (timeDiff.Ticks / (double)TimeSpan.TicksPerSecond) * m_simulationScale;
            m_lastUpdateTime = timeFreeze;

            lock (m_trainControllerList)
            {
                //Update all the trains
                foreach (ITrainController train in m_trainControllerList)
                {
                    train.Update(timeStep);
                }
            }
        }

        /// <summary>
        /// Train arrived at a station
        /// </summary>
        /// <param name="train">Train</param>
        /// <param name="stationName">Name of the station</param>
        private void OnTrainAtStation(ITrainController train, string stationName)
        {
            if (stationName != null && train != null)
            {
                if (stationName.Contains(Constants.TRAINYARD))
                {
                    //Train arrived at the train yard. Destroy it.
                    m_log.LogInfo("Train has arrived at the train yard");
                    m_trainControllerList.Remove(train);

                    train.Dispose();
                }
            }
        }

        /// <summary>
        /// A train entered a new track block. Need to push an update to the track controllers
        /// </summary>
        /// <param name="previous">Previous track block</param>
        /// <param name="next">Next track block</param>
        private void OnTrainEnteredNewBlock(TrackBlock previous, TrackBlock next)
        {
            if (!m_ctcController.UpdateTrackControllers(previous, next))
            {
                m_log.LogError("Failed to update track controllers");
            }
        }

        #endregion
    }
}
