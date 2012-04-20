using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using CommonLib;
using TrackLib;
using Train;

namespace TrainControllerLib
{
    public class TrainController
    {
        private const double MAXIMUM_POWER = 120000;
        private const double PORPORTIONAL_GAIN = 1000000;
        private const double INTEGRAL_GAIN = 10000;

        private double m_samplePeriod = 0.001;
        private double m_currentSample = 0;
        private double m_lastSample = 0;
        private double m_currentIntegral = 0;
        private double m_lastIntegral = 0;
        private double m_powerCommand = 0;
        private double m_setPoint = 0;
        private double m_manualSpeed = -1;
        private string m_trainID;
        private int m_speedUp = 1;
        private int m_authority = 0;
        private int m_stationWaitStartTime;
        private int m_nextStation = 0;
        private Queue<ScheduleInfo> m_routeInfo;
        private Train.Train m_myTrain;
        private TrainState m_currentState;
        private TrainState m_lastState;
        private TrackBlock m_currentBlock;
        private bool m_inTunnel = false;
        private bool m_approachingStation = false;
        private bool m_atStation = false;
        private bool m_doorsOpen = false;
        private bool m_brakeFailure = false;
        private bool m_engineFailure = false;
        private bool m_run = true;
        private bool m_stoppingTheTrain = false;
        private bool m_manualMode = false;
        private Timer m_systemTimer;
        private Timer m_stationTimer;

        #region Properties

        // PROPERTY: ManualMode
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Manual mode
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool ManualMode
        {
            get { return m_manualMode; }
            set { m_manualMode = value; }
        }

        // PROPERTY: ManualSpeed
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Manual speed command
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double ManualSpeed
        {
            get { return m_manualSpeed; }
            set { m_manualSpeed = value; }
        }

        #endregion

        #region Accessors

        // PROPERTY: Speed
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// current speed of the train in kilometers per hour
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double Speed
        {
            get { return m_currentState.Speed * 3.6; }
        }

        // PROPERTY: LocationX
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// x coordinate of the train
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double LocationX
        {
            get { return m_currentState.X; }
        }

        // PROPERTY: LocationY
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// y coordinate of the train
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double LocationY
        {
            get { return m_currentState.Y; }
        }

        #endregion

        #region Constructors

        // METHOD: TrainController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Primary constructor
        /// </summary>
        /// 
        /// <param name="startingBlock">The track block that the train starts on</param>
        /// <param name="myTrain">The train associated with this controller</param>
        /// <param name="speedUp">Speed up factor</param>
        //--------------------------------------------------------------------------------------
        public TrainController(TrackBlock startingBlock, Train.Train myTrain)
        {
            this.m_currentBlock = startingBlock;
            this.m_myTrain = myTrain;
            this.m_currentState = m_myTrain.GetState();
            this.m_trainID = m_currentState.TrainID;

            StartController();
        }

        #endregion

        #region Public Methods

        // METHOD: StartController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Start the train contoller; create a timer to trigger the system controller every sample period
        /// </summary>
        //--------------------------------------------------------------------------------------
        public void StartController()
        {
            m_systemTimer = new Timer();
            m_systemTimer.Elapsed += new ElapsedEventHandler(CallSystemController);
            m_systemTimer.Interval = 1; // in milliseconds
            m_systemTimer.Start();
        }

        // METHOD: StopController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Stop the train contoller
        /// </summary>
        //--------------------------------------------------------------------------------------
        public void StopController()
        {
            m_run = false;
        }

        // METHOD: Update
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Call the train contoller
        /// </summary>
        /// <param name="dt">Delta time</param>
        //--------------------------------------------------------------------------------------
        public void Update(double dt)
        {
            SystemController(dt);
        }

        // METHOD: SetSchedule
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Set the schedule
        /// </summary>
        //--------------------------------------------------------------------------------------
        public void SetSchedule(Queue<ScheduleInfo> routeInfo)
        {
            m_routeInfo = routeInfo;
        }

        #endregion

        #region Private Methods

        // METHOD: GetState
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Get a TrainState object from the train
        /// </summary>
        //--------------------------------------------------------------------------------------
        private void GetState()
        {
            m_lastState = m_currentState;
            m_currentState = m_myTrain.GetState();
        }

        /*
        // METHOD: GetSignal
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Get a TrackSignal object from the track
        /// </summary>
        //--------------------------------------------------------------------------------------
        private void GetSignal()
        {
            TrackSignal potentialSignal = m_myTrack.getSignal(m_trainID, m_currentState.X, m_currentState.Y, m_currentState.Delta);

            // Ensure that the m_signal is for this train
            if (potentialSignal.trainID == m_trainID)
            {
                m_signal = potentialSignal;
            }
        }
        */

        // METHOD: CallSystemController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Call the system controller
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void CallSystemController(object sender, ElapsedEventArgs e)
        {
            SystemController(0.001);
        }

        // METHOD: SystemController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Manage the starting, stopping, coordination and scheduling of all system processes
        /// </summary>
        /// <param name="samplePeriod">Sample period</param>
        //--------------------------------------------------------------------------------------
        private void SystemController(double samplePeriod)
        {
            //Set the sample period
            m_samplePeriod = samplePeriod;

            // Get the state of the train
            GetState();

            // Set the current track block
            m_currentBlock = m_currentState.CurrentBlock;

            // Pass block slope to the train
            m_myTrain.SetSlope(Math.Atan(m_currentBlock.Grade / 100));

            // Determine the m_setPoint
            DetermineSetPoint();

            // Check for faults
            FaultMonitor();

            // Generate and issue a power command
            VelocityController();

            // Control lights
            LightController();

            // Control announcements and doors
            StationController();
        }

        // METHOD: FaultMonitor
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Monitor the train for engine and brake failures
        /// </summary>
        //--------------------------------------------------------------------------------------
        private void FaultMonitor()
        {
            // If there has been an engine failure or signal pickup failure,
            // the setpoint must be set to zero to engage the brake.
            if(m_currentState.EngineFailure || m_currentState.SignalPickupFailure)
            {
                m_setPoint = 0;
            }
            // If there has been a brake failure, the emergency brake must be engaged.
            else if(m_currentState.BrakeFailure)
            {
                m_brakeFailure = true;
            }
        }

        // METHOD: DetermineSetPoint
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Determine the set point
        /// </summary>
        //--------------------------------------------------------------------------------------
        private void DetermineSetPoint()
        {
            // The setPoint should be set to the lower of the two speed limits
            if (m_manualMode && m_manualSpeed >= 0)
            {
                if (m_manualSpeed < m_currentBlock.Authority.SpeedLimitKPH)
                {
                    m_setPoint = m_manualSpeed / 3.6;
                }
                else
                {
                    m_setPoint = m_currentBlock.Authority.SpeedLimitKPH / 3.6;
                }
            }
            else
            {
                m_setPoint = m_currentBlock.Authority.SpeedLimitKPH / 3.6;
            }

            if (m_setPoint < 0)
            {
                m_setPoint = 0;
            }

            // If the signal is red, the train should not proceed
            if (m_currentBlock.Status.SignalState == TrackSignalState.Red)
            {
                m_setPoint = 0;
            }
            // If the signal is yellow, the train should proceed at half speed
			else if (m_currentBlock.Status.SignalState == TrackSignalState.Yellow)
            {
                m_setPoint = m_setPoint * 0.5;
            }
            // If the signal is green, the train should proceed at three-quarters speed
			else if (m_currentBlock.Status.SignalState == TrackSignalState.Green)
            {
                m_setPoint = m_setPoint * 0.75;
            }
            // (If the signal is super green, the train should proceed at full speed)

            // If the authority is equal to zero, the train cannot pass into the next block,
            // so the setPoint must be set to zero to engage the brake.
            if (m_currentBlock.Authority.Authority < 0)
            {
                m_setPoint = 0;
            }
            else if (m_stoppingTheTrain && m_currentState.Speed <= 2 && CalculateStoppingDistance(0) >= m_currentBlock.LengthMeters - m_currentState.BlockProgress)
            {
                m_setPoint = 0;
            }
            else if (m_currentBlock.Authority.Authority == 0 && CalculateStoppingDistance(0) >= m_currentBlock.LengthMeters - m_currentState.BlockProgress)
            {
                m_setPoint = 0;
            }
            else if (m_currentBlock.NextBlock.Authority.SpeedLimitKPH < m_currentBlock.Authority.SpeedLimitKPH && CalculateStoppingDistance(m_currentBlock.NextBlock.Authority.SpeedLimitKPH / 3.6) <= m_currentBlock.LengthMeters - m_currentState.BlockProgress)
            {
                m_setPoint = m_currentBlock.NextBlock.Authority.SpeedLimitKPH / 3.6;
            }

            if (m_approachingStation)
            {
                if (m_currentBlock.HasTransponder && CalculateStoppingDistance(0) >= m_currentBlock.LengthMeters + m_currentBlock.NextBlock.LengthMeters * 0.5 - m_currentState.BlockProgress)
                {
                    m_setPoint = 0;
                }
                else if (!m_currentBlock.HasTransponder && CalculateStoppingDistance(0) >= m_currentBlock.LengthMeters * 0.5 - m_currentState.BlockProgress)
                {
                    m_setPoint = 0;
                }
            }
        }

        // METHOD: VelocityController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Determine and issue the next power command (control train speed)
        /// </summary>
        //--------------------------------------------------------------------------------------
        private void VelocityController()
        {
            // If there has been a brake failure, do not issue a power command.
            if (m_brakeFailure)
            {
                m_myTrain.SetEmergencyBrake(true);
                return;
            }

            // Store values from the last iteration
            m_lastIntegral = m_currentIntegral;
            m_lastSample = m_currentSample;

            // Calculate the error signal
            m_currentSample = m_setPoint - m_currentState.Speed;

            if (m_currentSample < 0)
            {
                m_myTrain.SetBrake(true);
                return;
            }

            // Invoke the control law to calculate the next power command
            ControlLaw();

            // Issue the power command to the train if it's not waiting at a station
            if (!m_atStation && m_currentSample != 0)
            {
                m_myTrain.SetPower(m_powerCommand);
            }
        }

        // METHOD: ControlLaw
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Determine the next power command
        /// </summary>
        //--------------------------------------------------------------------------------------
        private void ControlLaw()
        {
            if (m_powerCommand < MAXIMUM_POWER)
            {
                m_currentIntegral = m_lastIntegral + (m_samplePeriod / 2) * (m_currentSample + m_lastSample);
            }
            else
            {
                m_currentIntegral = m_lastIntegral;
            }

            m_powerCommand = PORPORTIONAL_GAIN * m_currentSample + INTEGRAL_GAIN * m_currentIntegral;

            if (m_powerCommand > MAXIMUM_POWER)
            {
                m_powerCommand = MAXIMUM_POWER;
            }
            else if (m_powerCommand < 0)
            {
                m_powerCommand = 0;
            }
        }

        // METHOD: LightController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Control the train lights
        /// </summary>
        //--------------------------------------------------------------------------------------
        private void LightController()
        {
            // If the train is not in a tunnel and the track m_signal indicates a tunnel, turn the lights on
            if (!m_inTunnel && m_currentBlock.HasTunnel)
            {
                m_myTrain.SetLights(TrainState.Light.High);
                m_inTunnel = true;
            }
            // If the train is in a tunnel and the track m_signal indicates no tunnel, turn the lights off
            else if (m_inTunnel && !m_currentBlock.HasTunnel)
            {
                m_myTrain.SetLights(TrainState.Light.Off);
                m_inTunnel = false;
            }
        }

        // METHOD: StationController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Control the train announcements and doors
        /// </summary>
        //--------------------------------------------------------------------------------------
        private void StationController()
        {
            // If the train controller receives a transponder input, announce the next station
            if (!m_approachingStation && m_currentBlock.HasTransponder)
            {
                m_approachingStation = true;
                //m_myTrain.SetAnnouncement(m_signal.m_routeInfo[m_nextStation]);
                m_myTrain.SetAnnouncement(m_currentBlock.Transponder.StationName);
                m_nextStation++;
            }
            // If the train has arrived at the station, start to wait for passengers
            if (m_approachingStation && m_currentState.Speed == 0)
            {
                m_atStation = true;
                m_approachingStation = false;
                m_myTrain.SetDoors(TrainState.Door.Open);
                m_doorsOpen = true;

                m_stationTimer = new Timer();
                m_stationTimer.Elapsed += new ElapsedEventHandler(LeaveStation);
                m_stationTimer.Interval = 60 / m_samplePeriod;
                m_stationTimer.Start();
            }
        }

        // METHOD: LeaveStation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Close the doors, announce the next stop and notify train to leave the station
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void LeaveStation(object sender, EventArgs e)
        {
            // Close the doors
            m_myTrain.SetDoors(TrainState.Door.Closed);
            m_doorsOpen = false;

            // Announce the next stop
            //m_myTrain.SetAnnouncement(m_signal.routeInfo[m_nextStation]);
            m_stationTimer.Stop();

            // Notify train to leave the station
            m_atStation = false;
        }

        // METHOD: CalculateStoppingDistance
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Calculate the distance needed to stop or slow to a certain velocity
        /// </summary>
        /// <param name="finalVelocity">Target Velocity</param>
        //--------------------------------------------------------------------------------------
        private double CalculateStoppingDistance(double finalVelocity)
        {
            // Service brake deceleration = 7.6 m/s^2
            // Maximum acceleration due to track grade = 0.5 m/s^2
            // Net acceleration = -7.6 + 0.5= -7.1 m/s^2
            double acceleration = -7.1;

            // From physics: final_velocity = acceleration * time + intial_velocity
            // Use: final_velocity = finalVelocity, initial_velocity = m_currentState.speed
            // solving for time yields: time = (finalVelocity - m_currentState.speed) / acceleration
            double time = (finalVelocity - m_currentState.Speed) / acceleration;

            // From physics: final_position = 0.5 * acceleration * time^2 + initial_velocity * time + intial_position
            // Use: final_position = stoppingDistance, initial_velocity = m_currentState.speed, intial_position = 0
            double stoppingDistance = 0.5 * acceleration * time * time + m_currentState.Speed * time;

            return stoppingDistance;
        }

        #endregion
    }
}
