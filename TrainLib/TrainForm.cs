using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Train
{
	public partial class TrainForm : Form
	{
		private ITrain train;
		private string validPower = "0";

		public TrainForm(ITrain train)
		{
			InitializeComponent();
			this.train = train;
		}

		private void emergencyBrakeBox_CheckedChanged(object sender, EventArgs e)
		{
			train.SetEmergencyBrake(emergencyBrakeBox.Checked);
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
//			try
//			{
				int newPower = int.Parse(powerTextBox.Text);
				train.SetPower(newPower);
				validPower = powerTextBox.Text;
//			}
//			catch(Exception)
//			{
//				powerTextBox.Text = validPower;
//			}
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			speedTextBox.Text = train.GetState().Speed.ToString();
		}
	}
}
