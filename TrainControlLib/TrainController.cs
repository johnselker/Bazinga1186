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
        private List<String> m_routeInfo;
        private Train.Train m_myTrain;
        private TrainState m_currentState;
        private TrainState m_lastState;
        private Track m_myTrack;
        private TrackSignal m_signal;
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

        // PROPERTY: SpeedUp
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Speed up factor
        /// </summary>
        //--------------------------------------------------------------------------------------
        public int SpeedUp
        {
            get { return m_speedUp; }
            set { m_speedUp = value; }
        }

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
        /// <param name="myTrack">Track</param>
        /// <param name="myTrain">Train</param>
        /// <param name="speedUp">Speed up factor</param>
        //--------------------------------------------------------------------------------------
        public TrainController(Track myTrack, Train.Train myTrain, int speedUp = 1)
        {
            this.m_speedUp = speedUp;
            this.m_samplePeriod = 0.001 * speedUp;
            this.m_myTrack = myTrack;
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
            m_systemTimer.Elapsed += new ElapsedEventHandler(SystemController);
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

        // METHOD: SystemController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Manage the starting, stopping, coordination and scheduling of all system processes
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void SystemController(object sender, ElapsedEventArgs e)
        {
            // Get the state of the train
            GetState();

            // Get the track m_signal
            GetSignal();

            // Pass updated position and block slope to the train
            m_myTrain.SetPosition(m_signal.x, m_signal.y, m_signal.currentBlock.Grade);

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
            // If the last power command was positive but the train speed did not increase
            // there has been an engine failure, so the m_setPoint must be set to zero to 
            // engage the brake.
            if (m_powerCommand > 0 && m_currentState.Speed - m_lastState.Speed <= 0)
            {
                //m_setPoint = 0;
            }
            // If the last power command was negative but the train speed did not decrease
            // there has been a brake failure, so the emergency brake must be engaged.
            else if (m_powerCommand < 0 && m_currentState.Speed - m_lastState.Speed >= 0)
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
                if (m_manualSpeed < m_signal.currentBlock.Authority.SpeedLimitKPH)
                {
                    m_setPoint = m_manualSpeed / 3.6;
                }
                else
                {
                    m_setPoint = m_signal.currentBlock.Authority.SpeedLimitKPH / 3.6;
                }
            }
            else if (m_signal.ctcSpeedLimit < m_signal.currentBlock.Authority.SpeedLimitKPH)
            {
                m_setPoint = m_signal.ctcSpeedLimit / 3.6;
            }
            else
            {
                m_setPoint = m_signal.currentBlock.Authority.SpeedLimitKPH / 3.6;
            }

            if (m_setPoint < 0)
            {
                m_setPoint = 0;
            }

            // If the signal is red, the train should not proceed
            if (m_signal.currentBlock.SignalState == TrackSignalState.Red)
            {
                m_setPoint = 0;
            }
            // If the signal is yellow, the train should proceed at half speed
            else if (m_signal.currentBlock.SignalState == TrackSignalState.Yellow)
            {
                m_setPoint = m_setPoint * 0.5;
            }
            // If the signal is green, the train should proceed at three-quarters speed
            else if (m_signal.currentBlock.SignalState == TrackSignalState.Green)
            {
                m_setPoint = m_setPoint * 0.75;
            }
            // (If the signal is super green, the train should proceed at full speed)

            // If the authority is equal to zero, the train cannot pass into the next block,
            // so the setPoint must be set to zero to engage the brake.
            if (m_signal.currentBlock.Authority.Authority < 0)
            {
                m_setPoint = 0;
            }
            else if (m_stoppingTheTrain && m_currentState.speed <= 2 && CalculateStoppingDistance(0) >= m_signal.currentBlock.LengthMeters - m_signal.blockDelta)
            {
                m_setPoint = 0;
            }
            else if (m_signal.currentBlock.Authority.Authority == 0 && CalculateStoppingDistance(0) >= m_signal.currentBlock.LengthMeters - m_signal.blockDelta)
            {
                m_setPoint = 0;
            }
            else if (m_signal.nextBlock.Authority.SpeedLimitKPH < m_signal.currentBlock.Authority.SpeedLimitKPH && CalculateStoppingDistance(m_signal.nextBlock.Authority.SpeedLimitKPH / 3.6) <= m_signal.currentBlock.LengthMeters - m_currentState.delta)
            {
                m_setPoint = m_signal.nextBlock.Authority.SpeedLimitKPH / 3.6;
            }

            if (m_approachingStation)
            {
                if (m_signal.currentBlock.HasTransponder && CalculateStoppingDistance(0) >= m_signal.currentBlock.LengthMeters + m_signal.nextBlock.LengthMeters * 0.5 - m_signal.blockDelta)
                {
                    m_setPoint = 0;
                }
                else if (!m_signal.currentBlock.HasTransponder && CalculateStoppingDistance(0) >= m_signal.currentBlock.LengthMeters * 0.5 - m_signal.blockDelta)
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
            m_currentSample = m_setPoint - m_currentState.speed;

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
                m_myTrain.setPower(m_powerCommand);
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
            if (!m_inTunnel && m_signal.currentBlock.HasTunnel)
            {
                m_myTrain.SetLights(TrainState.light.High);
                m_inTunnel = true;
            }
            // If the train is in a tunnel and the track m_signal indicates no tunnel, turn the lights off
            else if (m_inTunnel && !m_signal.currentBlock.HasTunnel)
            {
                m_myTrain.SetLights(TrainState.light.Off);
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
            if (!m_approachingStation && m_signal.currentBlock.HasTransponder)
            {
                m_approachingStation = true;
                //m_myTrain.SetAnnouncement(m_signal.m_routeInfo[m_nextStation]);
                m_myTrain.SetAnnouncement(m_signal.currentBlock.Transponder.StationName);
                m_nextStation++;
            }
            // If the train has arrived at the station, start to wait for passengers
            if (m_approachingStation && m_currentState.speed == 0)
            {
                m_atStation = true;
                m_approachingStation = false;
                m_myTrain.SetDoors(TrainState.door.Open);
                m_doorsOpen = true;
                
                m_stationTimer = new Timer();
                m_stationTimer.Elapsed += new ElapsedEventHandler(LeaveStation);
                m_stationTimer.Interval = 60000 / m_speedUp; // in milliseconds
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
            m_myTrain.SetDoors(TrainState.door.Closed);
            m_doorsOpen = false;

            // Announce the next stop
            m_myTrain.SetAnnouncement(m_signal.routeInfo[m_nextStation]);
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
            double time = (finalVelocity - m_currentState.speed) / acceleration;

            // From physics: final_position = 0.5 * acceleration * time^2 + initial_velocity * time + intial_position
            // Use: final_position = stoppingDistance, initial_velocity = m_currentState.speed, intial_position = 0
            double stoppingDistance = 0.5 * acceleration * time * time + m_currentState.speed * time;

            return stoppingDistance;
        }

        #endregion
    }
}
