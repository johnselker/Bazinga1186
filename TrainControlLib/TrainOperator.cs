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
        private TrainController myTrainController;
        private ITrain myTrain;
        private double mySpeed = 0;
        private Timer myTimer;
        //private double currentSpeedD;
        private double time = 0;
        private DateTime start;
        private TimeSpan myTimeSpan;
        private TrainState myTrainState;
        private TrackBlock startingBlock;

        public TrainOperator()
        {
            InitializeComponent();
        }

        public void updateTrainController(object sender, EventArgs e)
        {
            myTrainController.Update(0.08);
            time += 0.01;
            timePassed.Text = myTrainController.TimePassed.ToString(); // time.ToString();
            if (myTrainState.Lights == TrainState.Light.Off)
            {
                lights.Text = "OFF";
            }
            else
            {
                lights.Text = "ON";
            }

            if (myTrainState.Doors == TrainState.Door.Open)
            {
                doors.Text = "OPEN";
            }
            else
            {
                doors.Text = "CLOSED";
            }

            announcement.Text = myTrainState.Announcement;

            //myTimeSpan = DateTime.Now - start;
            //lights.Text = myTimeSpan.Milliseconds.ToString();
            //start = DateTime.Now;
        }

        private void createTrain_Click(object sender, EventArgs e)
        {
            startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(0, 0), 1650, 0, 0, false, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block0", "Block2");
            startingBlock.NextBlock = new TrackBlock("Block2", TrackOrientation.EastWest, new Point(1650, 0), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block1", "Block3");
            startingBlock.Authority = new BlockAuthority(70, 3);
            startingBlock.NextBlock.Authority = new BlockAuthority(70, 2);
            startingBlock.NextBlock.NextBlock = new TrackBlock("Block3", TrackOrientation.EastWest, new Point(1700, 0), 1000, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block2", "Block4");
            startingBlock.NextBlock.NextBlock.NextBlock = new TrackBlock("Block4", TrackOrientation.EastWest, new Point(2700, 0), 100, 0, 0, false, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block3", "Block5");
            startingBlock.NextBlock.NextBlock.NextBlock.NextBlock = new TrackBlock("Block5", TrackOrientation.EastWest, new Point(2800, 0), 100, 0, 0, false, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block4", "Block6");
            startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.NextBlock = new TrackBlock("Block6", TrackOrientation.EastWest, new Point(2800, 0), 100, 0, 0, false, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block5", "Block7");
            //startingBlock.NextBlock.NextBlock = startingBlock;
            startingBlock.NextBlock.NextBlock.Authority = new BlockAuthority(70, 1);
            startingBlock.NextBlock.NextBlock.NextBlock.Authority = new BlockAuthority(40, 0);
            startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.Authority = new BlockAuthority(40, 0);
            startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.NextBlock.Authority = new BlockAuthority(40, 0);

            startingBlock.Transponder = new Transponder("SHADYSIDE", 1);
            startingBlock.NextBlock.Transponder = new Transponder("SHADYSIDE", 0);

            myTrain = new TrainLib.Train("train1", startingBlock, Direction.East);
            myTrainState = myTrain.GetState();
            myTrainController = new TrainController(myTrain);
            myTrainController.Schedule = GetRedlineSchedule();

            start = DateTime.Now;

            Timer updateTimer = new Timer();
            updateTimer.Tick += new EventHandler(updateTrainController);
            updateTimer.Interval = 40;
            updateTimer.Enabled = true;
            updateTimer.Start();

            myTimer = new Timer();
            myTimer.Tick += new EventHandler(updateDisplay);
            myTimer.Interval = 500;
            myTimer.Enabled = true;
            myTimer.Start();
        }

        private void updateDisplay(object sender, EventArgs e)
        {
            currentSpeed.Text = myTrainController.Speed.ToString();
            currentPosition.Text = myTrainController.LocationX.ToString();
        }

        private void enterSpeed_Click(object sender, EventArgs e)
        {
            myTrainController.ManualMode = true;
            if (Double.TryParse(manualSpeed.Text, out mySpeed))
            {
                myTrainController.ManualSpeed = mySpeed;
            }
        }

        /// <summary>
        /// Gets the redline schedule
        /// </summary>
        /// <returns>Queue of schedule info</returns>
        public Queue<ScheduleInfo> GetRedlineSchedule()
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

        private void engineFailure_Click(object sender, EventArgs e)
        {
            myTrainState.EngineFailure = !myTrainState.EngineFailure;
        }

        private void brakeFailure_Click(object sender, EventArgs e)
        {
            myTrainState.BrakeFailure = !myTrainState.BrakeFailure;
        }

        private void powerFailure_Click(object sender, EventArgs e)
        {
            startingBlock.Status.PowerFail = !startingBlock.Status.PowerFail;
            startingBlock.NextBlock.Status.PowerFail = startingBlock.Status.PowerFail;
            startingBlock.NextBlock.NextBlock.Status.PowerFail = startingBlock.Status.PowerFail;
            startingBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = startingBlock.Status.PowerFail;
            startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = startingBlock.Status.PowerFail;
            startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = startingBlock.Status.PowerFail;
        }

        private void circuitFailure_Click(object sender, EventArgs e)
        {
            startingBlock.Status.CircuitFail = !startingBlock.Status.CircuitFail;
            startingBlock.NextBlock.Status.PowerFail = startingBlock.Status.CircuitFail;
            startingBlock.NextBlock.NextBlock.Status.PowerFail = startingBlock.Status.CircuitFail;
            startingBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = startingBlock.Status.CircuitFail;
            startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = startingBlock.Status.CircuitFail;
            startingBlock.NextBlock.NextBlock.NextBlock.NextBlock.NextBlock.Status.PowerFail = startingBlock.Status.CircuitFail;
        }

        private void emergencyBrake_Click(object sender, EventArgs e)
        {
            myTrainController.EmergencyBrake = !myTrainController.EmergencyBrake;
        }
    }
}
