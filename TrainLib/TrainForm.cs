﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TrainLib
{
	public partial class TrainForm : Form
	{
		private ITrain train;
		private string validPower = "0";
		private Timer clock = new Timer();

		public TrainForm(ITrain train)
		{
			InitializeComponent();
			this.train = train;
			// Add the event and the event handler for the method that will process the timer event to the timer.
			clock.Tick += UpdateState;
			// Set the timer interval to 100 ms.
			clock.Interval = 100;
			clock.Start();
		}

		private void brakeBox_CheckedChanged(object sender, EventArgs e)
		{
			train.SetBrake(brakeBox.Checked, 0.1);
			powerTextBox.Text = train.GetPower().ToString();
		}

		private void emergencyBrakeBox_CheckedChanged(object sender, EventArgs e)
		{
            train.SetEmergencyBrake(emergencyBrakeBox.Checked, 0.1);
			powerTextBox.Text = train.GetPower().ToString();
		}

		private void brakeFailureBox_CheckedChanged(object sender, EventArgs e)
		{
			train.SetBrakeFailure(brakeFailureBox.Checked);
		}

		private void engineFailureBox_CheckedChanged(object sender, EventArgs e)
		{
			train.SetEngineFailure(engineFailureBox.Checked);
		}

		private void signalPickupFailureBox_CheckedChanged(object sender, EventArgs e)
		{
			train.SetSignalPickupFailure(signalPickupFailureBox.Checked);
		}

		private void setButton_Click(object sender, EventArgs e)
		{
			try
			{
				int newPower = int.Parse(powerTextBox.Text);
                train.SetPower(newPower, 0.1);
				validPower = powerTextBox.Text;
			}
			catch(Exception)
			{
				powerTextBox.Text = validPower;
			}
		}

		private void UpdateState(object sender, EventArgs e)
		{
			train.Update(clock.Interval / 1000.0);
			TrainState ts = train.GetState();
			brakeBox.Checked = train.GetBrake();
			emergencyBrakeBox.Checked = train.GetEmergencyBrake();
			brakeFailureBox.Checked = ts.BrakeFailure;
			switch (ts.Direction)
			{
				case CommonLib.Direction.East:
					directionTextBox.Text = "East";
					break;
				case CommonLib.Direction.North:
					directionTextBox.Text = "North";
					break;
				case CommonLib.Direction.Northeast:
					directionTextBox.Text = "Northeast";
					break;
				case CommonLib.Direction.Northwest:
					directionTextBox.Text = "Northwest";
					break;
				case CommonLib.Direction.South:
					directionTextBox.Text = "South";
					break;
				case CommonLib.Direction.Southeast:
					directionTextBox.Text = "Southeast";
					break;
				case CommonLib.Direction.Southwest:
					directionTextBox.Text = "Southwest";
					break;
				case CommonLib.Direction.West:
					directionTextBox.Text = "West";
					break;
				default:
					break; // Unreachable
			}
			progressTextBox.Text = String.Format("{0:F0}", (ts.BlockProgress / ts.CurrentBlock.LengthMeters) * 100);
			speedTextBox.Text = String.Format("{0:F3}", ts.Speed);
			accelerationTextBox.Text = String.Format("{0:F3}", train.GetAcceleration());
		}
	}
}
