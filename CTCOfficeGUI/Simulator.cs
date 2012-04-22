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
using Train;

namespace CTCOfficeGUI
{
    public class Simulator
    {
        #region Private Data

        private System.Timers.Timer m_simulationTimer = new System.Timers.Timer(1);
        private static Simulator m_singleton;
        private List<ITrainController> m_trainList = new List<ITrainController>();
        private DateTime m_lastUpdateTime;
        private double m_simulationScale = 1;
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private Dictionary<string, Direction> m_startingDirections;
        private bool m_running = false;

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

            if (scale >= 1)
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
                catch (Exception e)
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
                catch (Exception e)
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
                catch (Exception e)
                {
                    m_log.LogError("Error in setting signal pickup failure");
                }
            }
        }

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
                }
            }
        }

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
                    if (m_startingDirections.ContainsKey(start))
                    {
                        m_log.LogInfoFormat("Spawning new train \"{0}\" at start {1}", name, start); 
                        //Create the new train and train controller
                        ITrain train = new Train.Train(name, initialBlock, m_startingDirections[start]);
                        ITrainController trainController = new TrainController(train);
                        m_trainList.Add(trainController);

                        //Set the train schedule
                        if (start == Constants.REDYARD)
                        {
                            m_log.LogInfoFormat("Setting schedule of {0} to red line", name);
                            trainController.SetSchedule(CTCController.GetCTCController().GetRedlineSchedule());
                        }
                        else if (start == Constants.GREENYARDOUT)
                        {
                            m_log.LogInfoFormat("Setting schedule of {0} to green line", name);
                            trainController.SetSchedule(CTCController.GetCTCController().GetGreenlineSchedule());
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

            m_startingDirections = new Dictionary<string, Direction>(){
            {Constants.REDYARD, Direction.North}, {Constants.GREENYARDIN, Direction.Southwest}, {Constants.GREENYARDOUT, Direction.South} };
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

            lock (m_trainList)
            {
                //Update all the trains
                foreach (ITrainController train in m_trainList)
                {
                    train.Update(timeStep);
                }
            }
        }

        #endregion
    }
}
