namespace Train
{
	partial class TrainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.emergencyBrakeBox = new System.Windows.Forms.CheckBox();
			this.engineFailureBox = new System.Windows.Forms.CheckBox();
			this.signalPickupFailureBox = new System.Windows.Forms.CheckBox();
			this.powerTextBox = new System.Windows.Forms.TextBox();
			this.powerLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// emergencyBrakeBox
			// 
			this.emergencyBrakeBox.AutoSize = true;
			this.emergencyBrakeBox.Location = new System.Drawing.Point(27, 12);
			this.emergencyBrakeBox.Name = "emergencyBrakeBox";
			this.emergencyBrakeBox.Size = new System.Drawing.Size(110, 17);
			this.emergencyBrakeBox.TabIndex = 0;
			this.emergencyBrakeBox.Text = "Emergency Brake";
			this.emergencyBrakeBox.UseVisualStyleBackColor = true;
			// 
			// engineFailureBox
			// 
			this.engineFailureBox.AutoSize = true;
			this.engineFailureBox.Location = new System.Drawing.Point(27, 35);
			this.engineFailureBox.Name = "engineFailureBox";
			this.engineFailureBox.Size = new System.Drawing.Size(93, 17);
			this.engineFailureBox.TabIndex = 1;
			this.engineFailureBox.Text = "Engine Failure";
			this.engineFailureBox.UseVisualStyleBackColor = true;
			// 
			// signalPickupFailureBox
			// 
			this.signalPickupFailureBox.AutoSize = true;
			this.signalPickupFailureBox.Location = new System.Drawing.Point(27, 58);
			this.signalPickupFailureBox.Name = "signalPickupFailureBox";
			this.signalPickupFailureBox.Size = new System.Drawing.Size(125, 17);
			this.signalPickupFailureBox.TabIndex = 2;
			this.signalPickupFailureBox.Text = "Signal Pickup Failure";
			this.signalPickupFailureBox.UseVisualStyleBackColor = true;
			// 
			// powerTextBox
			// 
			this.powerTextBox.Location = new System.Drawing.Point(73, 78);
			this.powerTextBox.Name = "powerTextBox";
			this.powerTextBox.Size = new System.Drawing.Size(79, 20);
			this.powerTextBox.TabIndex = 3;
			// 
			// powerLabel
			// 
			this.powerLabel.AutoSize = true;
			this.powerLabel.Location = new System.Drawing.Point(27, 81);
			this.powerLabel.Name = "powerLabel";
			this.powerLabel.Size = new System.Drawing.Size(40, 13);
			this.powerLabel.TabIndex = 4;
			this.powerLabel.Text = "Power:";
			// 
			// TrainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(181, 113);
			this.Controls.Add(this.powerLabel);
			this.Controls.Add(this.powerTextBox);
			this.Controls.Add(this.signalPickupFailureBox);
			this.Controls.Add(this.engineFailureBox);
			this.Controls.Add(this.emergencyBrakeBox);
			this.Name = "TrainForm";
			this.Text = "Train";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox emergencyBrakeBox;
		private System.Windows.Forms.CheckBox engineFailureBox;
		private System.Windows.Forms.CheckBox signalPickupFailureBox;
		private System.Windows.Forms.TextBox powerTextBox;
		private System.Windows.Forms.Label powerLabel;
	}
}