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
        //private List<ITrainController> m_trainList = new List<ITrainController>();
        private DateTime m_lastUpdateTime;
        private double m_simulationScale = 1;
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());

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
        /// Sets the simulation scale
        /// </summary>
        /// 
        /// <remarks>Scale of 1 is real time, scale of 10 is 10x real time, etc.</remarks>
        /// 
        /// <param name="scale">Simulation scale</param>
        /// 
        /// <returns>bool success</returns>
        public bool SetSimulationScale(double scale)
        {
            bool result = false;

            if (scale > 1)
            {
                m_simulationScale = scale;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Adds a new train to the table
        /// </summary>
        /// <param name="train">Train to add</param>
        /// <returns>bool success</returns>
        //public bool AddTrain(ITrainController train)
        //{
        //    bool result = false;
        //    if (train != null)
        //    {
        //        if (!m_trainList.Contains(train))
        //        {
        //            m_trainList.Add(train);
        //            result = true;
        //        }
        //    }

        //    return result;
        //}

        /// <summary>
        /// Starts the simulation timer to update train positions
        /// </summary>
        public void StartSimulation()
        {
            m_simulationTimer.Start();
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
                    //train.SetSignalPickupFailure(failure);
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
                    block.Status.CircuitFail = failure;
                }
            }
        }

        /// <summary>
        /// Simulates a track block power failure
        /// </summary>
        /// <param name="block">Block to simulate on</param>
        /// <param name="failure">True to invoke failure or false to clear it</param>
        public void SimulateEngineFailure(TrackBlock block, bool failure)
        {
            if (block != null)
            {
                if (block.Status != null)
                {
                    block.Status.PowerFail = failure;
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

            //foreach (ITrainController train in m_trainList)
            //{
                //train.Update(timeStep);
            //}
        }

        #endregion
    }
}
