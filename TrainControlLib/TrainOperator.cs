using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainLib;
using CommonLib;

namespace TrainControllerLib
{
    public partial class TrainOperator : Form
    {
        private TrainController m_myTrainController;
        private ITrain m_myTrain;
        private double m_mySpeed = 0;
        private Timer m_myTimer;
        private TrainState m_myTrainState;
        private TrackBlock m_startingBlock;
        private bool m_isDemo;

        #region Constructors

        // METHOD: TrainOperator
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Primary constructor, to be used for a module demo ONLY
        /// </summary>
        //--------------------------------------------------------------------------------------
        public TrainOperator()
        {
            InitializeComponent();
            m_isDemo = true;
        }

        // METHOD: TrainOperator
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Secondary constructor, to be used by the CTC
        /// </summary>
        /// 
        /// <param name="myTrain">The train associated with this GUI</param>
        /// <param name="myTrainController">The train controller associated with this GUI</param>
        //--------------------------------------------------------------------------------------
        public TrainOperator(ITrain myTrain, TrainController myTrainController)
        {
            InitializeComponent();
            m_isDemo = false;
            this.m_myTrain = myTrain;
            this.m_myTrainState = m_myTrain.GetState();
            this.m_myTrainController = myTrainController;

            engineFailure.Enabled = false;
            brakeFailure.Enabled = false;
            powerFailure.Enabled = false;
            circuitFailure.Enabled = false;
        }

        #endregion

        #region Private Methods

        // METHOD: Update
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Refresh the GUI, and update the train controller if in a demo
        /// </summary>
        /// 
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void Update(object sender, EventArgs e)
        {
            if (m_isDemo)
            {
                m_myTrainController.Update(0.08);
            }

            timePassed.Text = m_myTrainController.TimePassed.ToString();

            if (m_myTrainState.Lights == TrainState.Light.Off)
            {
                lights.Text = "OFF";
            }
            else
            {
                lights.Text = "ON";
            }

            if (m_myTrainState.Doors == TrainState.Door.Open)
            {
                doors.Text = "OPEN";
            }
            else
            {
                doors.Text = "CLOSED";
            }

            announcement.Text = m_myTrainState.Announcement;
        }

        // METHOD: CreateTrain_Click
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Start the GUI, and create a train and train controller if in a demo
        /// </summary>
        /// 
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void CreateTrain_Click(object sender, EventArgs e)
        {
            if (m_isDemo)
            {
                m_startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(0, 0), 1650, 0, 0, false, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block0", "Block2");
                m_startingBlock.NextBlock = new TrackBlock("Block2", TrackOrientation.EastWest, new Point(1650, 0), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block1", "Block3");
                m_startingBlock.Authority = new BlockAuthority(70, 3);
                m_startingBlock.NextBlock.Authority = new BlockAuthority(70, 2);
                m_startingBlock.NextBlock.NextBlock = new TrackBlock("Block3", TrackOrientation.EastWest, new Point(1700, 0), 1000, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block2", "Block4");
                m_startingBlock.NextBlock.NextBlock.NextBlock = new TrackBlock("Block4", TrackOrientation.EastWest, new Point(2700, 0), 100, 0, 0, false, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block3", "Block5");
                m_startingBlock.NextBlock.NextBlock.NextBlock.NextBlock = new TrackBlock("Block5", TrackOrientation.EastWest, new Point(2800, 0), 100, 0, 0, false, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block4", "Block6");
                m_startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.NextBlock = new TrackBlock("Block6", TrackOrientation.EastWest, new Point(2800, 0), 100, 0, 0, false, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block5", "Block7");
                m_startingBlock.NextBlock.NextBlock.Authority = new BlockAuthority(70, 1);

                m_startingBlock.NextBlock.NextBlock.NextBlock.Authority = new BlockAuthority(40, 0);
                m_startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.Authority = new BlockAuthority(40, 0);
                m_startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.NextBlock.Authority = new BlockAuthority(40, 0);

                m_startingBlock.Transponder = new Transponder("SHADYSIDE", 1);
                m_startingBlock.NextBlock.Transponder = new Transponder("SHADYSIDE", 0);

                m_myTrain = new TrainLib.Train("train1", m_startingBlock, Direction.East);
                m_myTrainState = m_myTrain.GetState();
                m_myTrainController = new TrainController(m_myTrain);
                m_myTrainController.Schedule = GetRedlineSchedule();

                Timer updateTimer = new Timer();
                updateTimer.Tick += new EventHandler(Update);
                updateTimer.Interval = 40;
                updateTimer.Enabled = true;
                updateTimer.Start();
            }

            m_myTimer = new Timer();
            m_myTimer.Tick += new EventHandler(UpdateDisplay);
            m_myTimer.Interval = 500;
            m_myTimer.Enabled = true;
            m_myTimer.Start();
        }

        // METHOD: UpdateDisplay
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Update the current speed and position of the train
        /// </summary>
        /// 
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void UpdateDisplay(object sender, EventArgs e)
        {
            currentSpeed.Text = m_myTrainController.Speed.ToString();
            currentPosition.Text = m_myTrainController.LocationX.ToString();
        }

        // METHOD: EnterSpeed_Click
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Send a manual speed command to the train controller
        /// </summary>
        /// 
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void EnterSpeed_Click(object sender, EventArgs e)
        {
            m_myTrainController.ManualMode = true;
            if (Double.TryParse(manualSpeed.Text, out m_mySpeed))
            {
                m_myTrainController.ManualSpeed = m_mySpeed;
            }
        }

        // METHOD: GetRedlineSchedule
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the redline schedule
        /// </summary>
        /// 
        /// <returns>Queue of schedule info</returns>
        //--------------------------------------------------------------------------------------
        private Queue<ScheduleInfo> GetRedlineSchedule()
        {
            Queue<ScheduleInfo> redline = new Queue<ScheduleInfo>();
            ScheduleInfo info = new ScheduleInfo(Constants.StationNames.SHADYSIDE, 1.0);
            redline.Enqueue(info);
            info = new ScheduleInfo(Constants.StationNames.HERRONAVE, 1.0);
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

        // METHOD: EngineFailure_Click
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Simulate an Engine Failure
        /// </summary>
        /// 
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void EngineFailure_Click(object sender, EventArgs e)
        {
            m_myTrainState.EngineFailure = !m_myTrainState.EngineFailure;
        }

        // METHOD: BrakeFailure_Click
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Simulate a Brake Failure
        /// </summary>
        /// 
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void BrakeFailure_Click(object sender, EventArgs e)
        {
            m_myTrainState.BrakeFailure = !m_myTrainState.BrakeFailure;
        }

        // METHOD: PowerFailure_Click
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Simulate a Track Power Failure
        /// </summary>
        /// 
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void PowerFailure_Click(object sender, EventArgs e)
        {
            m_startingBlock.Status.PowerFail = !m_startingBlock.Status.PowerFail;
            m_startingBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.PowerFail;
            m_startingBlock.NextBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.PowerFail;
            m_startingBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.PowerFail;
            m_startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.PowerFail;
            m_startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.PowerFail;
        }

        // METHOD: CircuitFailure_Click
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Simulate a Track Circuit Failure
        /// </summary>
        /// 
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void CircuitFailure_Click(object sender, EventArgs e)
        {
            m_startingBlock.Status.CircuitFail = !m_startingBlock.Status.CircuitFail;
            m_startingBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.CircuitFail;
            m_startingBlock.NextBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.CircuitFail;
            m_startingBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.CircuitFail;
            m_startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.CircuitFail;
            m_startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = m_startingBlock.Status.CircuitFail;
        }

        // METHOD: EmergencyBrake_Click
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Engage the train's emergency brake
        /// </summary>
        /// 
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        //--------------------------------------------------------------------------------------
        private void EmergencyBrake_Click(object sender, EventArgs e)
        {
            m_myTrainController.EmergencyBrake = !m_myTrainController.EmergencyBrake;
        }

        #endregion
    }
}
