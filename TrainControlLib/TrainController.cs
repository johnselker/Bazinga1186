using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using CommonLib;
using TrackLib;
using TrainLib;

namespace TrainControllerLib
{
    public class TrainController : ITrainController
    {
        private const double MAXIMUM_POWER = 120000;
        private const double PORPORTIONAL_GAIN = 1000000;
        private const double INTEGRAL_GAIN = 10000;

        public event OnTrainAtStation TrainAtStation;

        private ITrain m_myTrain;
        private TrainState m_currentState;
        private TrackBlock m_currentBlock;

        private double m_samplePeriod = 0.0;
        private double m_timePassed = 0;
        private double m_arrivalTime = 0;
        private double m_currentSample = 0;
        private double m_lastSample = 0;
        private double m_currentIntegral = 0;
        private double m_lastIntegral = 0;
        private double m_powerCommand = 0;
        private double m_setPoint = 0;
        private string m_trainID;
        private int m_lastCommand = 0;
        private bool m_inTunnel = false;
        private bool m_approachingStation = false;
        private bool m_atStation = false;
        private bool m_brakeFailure = false;
        private ScheduleInfo m_nextStationInfo;
        private Random m_passengerGenerator;

        #region Properties

        // PROPERTY: ManualMode
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Indicates manual control of the train
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool ManualMode
        {
            get;
            set;
        }

        // PROPERTY: ManualSpeed
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Manual speed command
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double ManualSpeed
        {
            get;
            set;
        }

        // PROPERTY: Schedule
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// The train's schedule
        /// </summary>
        //--------------------------------------------------------------------------------------
        public Queue<ScheduleInfo> Schedule
        {
            get;
            set;
        }

        // PROPERTY: EmergencyBrake
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Set the emergency brake
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool EmergencyBrake
        {
            get;
            set;
        }

        #endregion

        #region Accessors

        // ACCESSOR: Speed
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// current speed of the train in kilometers per hour
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double Speed
        {
            get { return m_currentState.Speed * 3.6; }
        }

        // ACCESSOR: LocationX
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// x coordinate of the train
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double LocationX
        {
            get { return m_currentState.X; }
        }

        // ACCESSOR: LocationY
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// y coordinate of the train
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double LocationY
        {
            get { return m_currentState.Y; }
        }

        // ACCESSOR: TimePassed
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// time passed since the train departed the last station
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double TimePassed
        {
            get { return m_timePassed; }
        }

        #endregion

        #region Constructors

        // METHOD: TrainController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Primary constructor
        /// </summary>
        /// 
        /// <param name="myTrain">The train associated with this controller</param>
        //--------------------------------------------------------------------------------------
        public TrainController(ITrain myTrain)
        {
            this.m_myTrain = myTrain;
            this.m_currentState = m_myTrain.GetState();
            this.m_trainID = m_currentState.TrainID;
            this.m_currentBlock = m_currentState.CurrentBlock;
            this.m_passengerGenerator = new Random((int)DateTime.Now.Ticks);
            this.ManualSpeed = -1;
        }

        #endregion

        #region Public Methods

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

        // METHOD: Dispose
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Dispose of the TrainController
        /// </summary>
        //--------------------------------------------------------------------------------------
        public void Dispose()
        {
            if (this != null)
            {
                this.Dispose();
            }
        }

        #endregion

        #region Private Methods

        // METHOD: SystemController
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Manage the starting, stopping, coordination and scheduling of all system processes
        /// </summary>
        /// <param name="samplePeriod">Sample period</param>
        //--------------------------------------------------------------------------------------
        private void SystemController(double samplePeriod)
        {
            // If this is the first time SystemController has been called,
            // the train is at the yard and needs to leave
            if (m_samplePeriod == 0.0)
            {
                LeaveStation();
            }

            // Keep track of the time that has passed since leaving the last station
            m_timePassed += samplePeriod;

            // Set the sample period
            m_samplePeriod = samplePeriod;

            // Set the current track block
            m_currentBlock = m_currentState.CurrentBlock;

            // Determine the m_setPoint
            DetermineSetPoint();

            // Check for faults
            FaultMonitor();

            // Generate and issue a power command
            m_lastCommand = VelocityController();

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
            // If the Track Block has a power failure or a track circuit failure,
            // the train will not be able to pick up the track signal, thus there is a signal pickup failure
            // and the setpoint must be set to zero to engage the brake.
            if (m_currentState.CurrentBlock.Status.PowerFail|| m_currentState.CurrentBlock.Status.CircuitFail)
            {
                m_setPoint = 0;
            }

            // If there has been an engine failure, the setpoint must be set to zero to engage the brake.
            if (m_currentState.EngineFailure)
            {
                m_setPoint = 0;
            }

            // If there has been a brake failure, the emergency brake must be engaged.
            m_brakeFailure = m_currentState.BrakeFailure;
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
            if (ManualMode && ManualSpeed >= 0)
            {
                if (ManualSpeed < m_currentBlock.Authority.SpeedLimitKPH)
                {
                    m_setPoint = ManualSpeed / 3.6;
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

            // If the authority is equal to zero, the train cannot pass into the next block,
            // so the setPoint must be set to zero to engage the brake.
            if (m_currentBlock.Authority.Authority < 0)
            {
                EmergencyBrake = true;
            }
            else if (m_currentBlock.Authority.Authority == 0 && (CalculateStoppingDistance(0) >= m_currentBlock.LengthMeters - m_currentState.BlockProgress || (!m_atStation && m_currentState.Speed <= 2)))
            {
                m_setPoint = 0;
            }
			else if (m_currentBlock.GetNextBlock(m_currentState.Direction).Authority.SpeedLimitKPH < m_currentBlock.Authority.SpeedLimitKPH && CalculateStoppingDistance(m_currentBlock.GetNextBlock(m_currentState.Direction).Authority.SpeedLimitKPH / 3.6) >= m_currentBlock.LengthMeters - m_currentState.BlockProgress)
            {
				m_setPoint = m_currentBlock.GetNextBlock(m_currentState.Direction).Authority.SpeedLimitKPH / 3.6;
            }

            if (m_approachingStation)
            {
				if (m_currentBlock.HasTransponder && m_currentBlock.Transponder.DistanceToStation == 1 && CalculateStoppingDistance(0) >= m_currentBlock.LengthMeters + m_currentBlock.GetNextBlock(m_currentState.Direction).LengthMeters * 0.5 - m_currentState.BlockProgress)
                {
                    m_setPoint = 0;
                }
                else if (m_currentBlock.HasTransponder && m_currentBlock.Transponder.DistanceToStation == 0 && CalculateStoppingDistance(0) >= m_currentBlock.LengthMeters * 0.5 - m_currentState.BlockProgress)
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
        private int VelocityController()
        {
            // If there has been a brake failure, set the emergency brake and do not issue a power command.
            if (EmergencyBrake || m_brakeFailure)
            {
                m_myTrain.SetEmergencyBrake(true, m_samplePeriod);
                return 1;
            }

            // Store values from the last iteration
            m_lastIntegral = m_currentIntegral;
            m_lastSample = m_currentSample;

            // Calculate the error signal
            m_currentSample = m_setPoint - m_currentState.Speed;

            if (m_currentSample < 0)
            {
                m_myTrain.SetBrake(true, m_samplePeriod);
                return 2;
            }

            // Invoke the control law to calculate the next power command
            ControlLaw();

            // Issue the power command to the train if it's not waiting at a station
            if (!m_atStation && m_currentSample != 0)
            {
                m_myTrain.SetPower(m_powerCommand, m_samplePeriod);
                return 3;
            }

            return 0;
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
            if (!m_approachingStation && m_currentBlock.HasTransponder && m_currentBlock.Transponder.DistanceToStation == 1)
            {
                m_approachingStation = true;
                m_myTrain.SetAnnouncement(m_currentBlock.Transponder.StationName);
            }

            // If the train has arrived at the station, open the doors and load and unload passengers
            if (m_approachingStation && m_currentState.Speed == 0 && m_currentBlock.HasTransponder && m_currentBlock.Transponder.DistanceToStation == 0)
            {
                m_atStation = true;
                m_approachingStation = false;
                m_myTrain.SetDoors(TrainState.Door.Open);
                m_arrivalTime = m_timePassed;

                // Simulate passengers getting on and off at the station
                m_currentState.Passengers = m_passengerGenerator.Next(0, 222);

                // Fire an event to let the CTC know the train has arrived at a station
                if (TrainAtStation != null)
                {
                    TrainAtStation(this, m_currentBlock.Transponder.StationName);
                }
            }

            // If the train is at the station and the dwell time is up, leave the station
            if (m_atStation && m_timePassed >= m_nextStationInfo.TimeToStationMinutes * 60 && m_timePassed - m_arrivalTime >= 60)
            {
                LeaveStation();
            }
        }

        // METHOD: LeaveStation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Close the doors, announce the next stop and notify train to leave the station
        /// </summary>
        //--------------------------------------------------------------------------------------
        private void LeaveStation()
        {
            // Close the doors
            m_myTrain.SetDoors(TrainState.Door.Closed);

            // Announce the next stop
            if (Schedule != null && Schedule.Count > 0)
            {
                m_nextStationInfo = Schedule.Dequeue();
                m_myTrain.SetAnnouncement(m_nextStationInfo.StationName);
            }

            // Notify train to leave the station
            m_atStation = false;

            m_timePassed = 0;
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
