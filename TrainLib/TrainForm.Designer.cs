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
			this.setButton = new System.Windows.Forms.Button();
			this.speedLabel = new System.Windows.Forms.Label();
			this.speedTextBox = new System.Windows.Forms.TextBox();
			this.updateButton = new System.Windows.Forms.Button();
			this.brakeFailureBox = new System.Windows.Forms.CheckBox();
			this.accelerationLabel = new System.Windows.Forms.Label();
			this.accelerationTextBox = new System.Windows.Forms.TextBox();
			this.brakeBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// emergencyBrakeBox
			// 
			this.emergencyBrakeBox.AutoSize = true;
			this.emergencyBrakeBox.Location = new System.Drawing.Point(21, 37);
			this.emergencyBrakeBox.Name = "emergencyBrakeBox";
			this.emergencyBrakeBox.Size = new System.Drawing.Size(110, 17);
			this.emergencyBrakeBox.TabIndex = 0;
			this.emergencyBrakeBox.Text = "Emergency Brake";
			this.emergencyBrakeBox.UseVisualStyleBackColor = true;
			this.emergencyBrakeBox.CheckedChanged += new System.EventHandler(this.emergencyBrakeBox_CheckedChanged);
			// 
			// engineFailureBox
			// 
			this.engineFailureBox.AutoSize = true;
			this.engineFailureBox.Location = new System.Drawing.Point(21, 83);
			this.engineFailureBox.Name = "engineFailureBox";
			this.engineFailureBox.Size = new System.Drawing.Size(93, 17);
			this.engineFailureBox.TabIndex = 1;
			this.engineFailureBox.Text = "Engine Failure";
			this.engineFailureBox.UseVisualStyleBackColor = true;
			this.engineFailureBox.CheckedChanged += new System.EventHandler(this.engineFailureBox_CheckedChanged);
			// 
			// signalPickupFailureBox
			// 
			this.signalPickupFailureBox.AutoSize = true;
			this.signalPickupFailureBox.Location = new System.Drawing.Point(21, 106);
			this.signalPickupFailureBox.Name = "signalPickupFailureBox";
			this.signalPickupFailureBox.Size = new System.Drawing.Size(125, 17);
			this.signalPickupFailureBox.TabIndex = 2;
			this.signalPickupFailureBox.Text = "Signal Pickup Failure";
			this.signalPickupFailureBox.UseVisualStyleBackColor = true;
			this.signalPickupFailureBox.CheckedChanged += new System.EventHandler(this.signalPickupFailureBox_CheckedChanged);
			// 
			// powerTextBox
			// 
			this.powerTextBox.Location = new System.Drawing.Point(96, 126);
			this.powerTextBox.Name = "powerTextBox";
			this.powerTextBox.Size = new System.Drawing.Size(47, 20);
			this.powerTextBox.TabIndex = 3;
			this.powerTextBox.Text = "0";
			this.powerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// powerLabel
			// 
			this.powerLabel.AutoSize = true;
			this.powerLabel.Location = new System.Drawing.Point(21, 129);
			this.powerLabel.Name = "powerLabel";
			this.powerLabel.Size = new System.Drawing.Size(40, 13);
			this.powerLabel.TabIndex = 4;
			this.powerLabel.Text = "Power:";
			// 
			// setButton
			// 
			this.setButton.Location = new System.Drawing.Point(149, 123);
			this.setButton.Name = "setButton";
			this.setButton.Size = new System.Drawing.Size(50, 23);
			this.setButton.TabIndex = 5;
			this.setButton.Text = "Set";
			this.setButton.UseVisualStyleBackColor = true;
			this.setButton.Click += new System.EventHandler(this.setButton_Click);
			// 
			// speedLabel
			// 
			this.speedLabel.AutoSize = true;
			this.speedLabel.Location = new System.Drawing.Point(21, 152);
			this.speedLabel.Name = "speedLabel";
			this.speedLabel.Size = new System.Drawing.Size(41, 13);
			this.speedLabel.TabIndex = 6;
			this.speedLabel.Text = "Speed:";
			// 
			// speedTextBox
			// 
			this.speedTextBox.Location = new System.Drawing.Point(96, 149);
			this.speedTextBox.Name = "speedTextBox";
			this.speedTextBox.ReadOnly = true;
			this.speedTextBox.Size = new System.Drawing.Size(47, 20);
			this.speedTextBox.TabIndex = 7;
			this.speedTextBox.Text = "0";
			this.speedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(149, 149);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(50, 41);
			this.updateButton.TabIndex = 8;
			this.updateButton.Text = "Update";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// brakeFailureBox
			// 
			this.brakeFailureBox.AutoSize = true;
			this.brakeFailureBox.Location = new System.Drawing.Point(21, 60);
			this.brakeFailureBox.Name = "brakeFailureBox";
			this.brakeFailureBox.Size = new System.Drawing.Size(88, 17);
			this.brakeFailureBox.TabIndex = 9;
			this.brakeFailureBox.Text = "Brake Failure";
			this.brakeFailureBox.UseVisualStyleBackColor = true;
			// 
			// accelerationLabel
			// 
			this.accelerationLabel.AutoSize = true;
			this.accelerationLabel.Location = new System.Drawing.Point(21, 173);
			this.accelerationLabel.Name = "accelerationLabel";
			this.accelerationLabel.Size = new System.Drawing.Size(69, 13);
			this.accelerationLabel.TabIndex = 10;
			this.accelerationLabel.Text = "Acceleration:";
			// 
			// accelerationTextBox
			// 
			this.accelerationTextBox.Location = new System.Drawing.Point(96, 170);
			this.accelerationTextBox.Name = "accelerationTextBox";
			this.accelerationTextBox.ReadOnly = true;
			this.accelerationTextBox.Size = new System.Drawing.Size(47, 20);
			this.accelerationTextBox.TabIndex = 11;
			this.accelerationTextBox.Text = "0";
			this.accelerationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// brakeBox
			// 
			this.brakeBox.AutoSize = true;
			this.brakeBox.Location = new System.Drawing.Point(21, 14);
			this.brakeBox.Name = "brakeBox";
			this.brakeBox.Size = new System.Drawing.Size(54, 17);
			this.brakeBox.TabIndex = 12;
			this.brakeBox.Text = "Brake";
			this.brakeBox.UseVisualStyleBackColor = true;
			// 
			// TrainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(217, 204);
			this.Controls.Add(this.brakeBox);
			this.Controls.Add(this.accelerationTextBox);
			this.Controls.Add(this.accelerationLabel);
			this.Controls.Add(this.brakeFailureBox);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.speedTextBox);
			this.Controls.Add(this.speedLabel);
			this.Controls.Add(this.setButton);
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
		private System.Windows.Forms.Button setButton;
		private System.Windows.Forms.Label speedLabel;
		private System.Windows.Forms.TextBox speedTextBox;
		private System.Windows.Forms.Button updateButton;
		private System.Windows.Forms.CheckBox brakeFailureBox;
		private System.Windows.Forms.Label accelerationLabel;
		private System.Windows.Forms.TextBox accelerationTextBox;
		private System.Windows.Forms.CheckBox brakeBox;
	}
}