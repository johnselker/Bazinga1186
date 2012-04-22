using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Train;
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

        public TrainOperator()
        {
            InitializeComponent();
        }

        public void updateTrainController(object sender, EventArgs e)
        {
            myTrainController.Update(0.01);
        }

        private void createTrain_Click(object sender, EventArgs e)
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(0, 0), 100, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "Block0", "Block2");
            startingBlock.NextBlock = new TrackBlock("Block2", TrackOrientation.EastWest, new Point(100, 0), 100, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "Block1", "Block3");
            startingBlock.Authority = new BlockAuthority(70, 1);
            startingBlock.NextBlock.Authority = new BlockAuthority(70,0);
            startingBlock.NextBlock.NextBlock = new TrackBlock("Block3", TrackOrientation.EastWest, new Point(200, 0), 100, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "Block2", "Block4");
            
            myTrain = new Train.Train("train1", startingBlock, Direction.East);
            myTrainController = new TrainController(myTrain);
            myTrainController.SetSchedule(GetRedlineSchedule());

            Timer updateTimer = new Timer();
            updateTimer.Tick += new EventHandler(updateTrainController);
            updateTimer.Interval = 1;
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
    }
}
