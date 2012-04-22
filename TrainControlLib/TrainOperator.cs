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
        private double mySpeed;
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            myTrain = new Train.Train("train1", startingBlock, Direction.East);
            myTrainController = new TrainController(myTrain);
            mySpeed = 0;

            Timer updateTimer = new Timer();
            updateTimer.Tick += new EventHandler(updateTrainController);
            updateTimer.Interval = 1;
            updateTimer.Enabled = true;
            updateTimer.Start();

            myTimer = new Timer();
            myTimer.Tick += new EventHandler(updateDisplay);
            myTimer.Interval = 500; // in miliseconds
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
    }
}
