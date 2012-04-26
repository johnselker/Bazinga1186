namespace CTCOfficeGUI
{
    partial class SimulatorWindow
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
            this.btnSetTime = new System.Windows.Forms.Button();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.chkPowerFail = new System.Windows.Forms.CheckBox();
            this.chkBrokenRail = new System.Windows.Forms.CheckBox();
            this.chkCircuitFail = new System.Windows.Forms.CheckBox();
            this.chkRunSimulation = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSetTime
            // 
            this.btnSetTime.Location = new System.Drawing.Point(155, 15);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(125, 40);
            this.btnSetTime.TabIndex = 0;
            this.btnSetTime.Text = "Set Simulation Speed";
            this.btnSetTime.UseVisualStyleBackColor = true;
            this.btnSetTime.Click += new System.EventHandler(this.OnSetSimulationSpeedClicked);
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(80, 25);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(65, 20);
            this.txtSpeed.TabIndex = 1;
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkPowerFail
            // 
            this.chkPowerFail.AutoSize = true;
            this.chkPowerFail.Location = new System.Drawing.Point(91, 134);
            this.chkPowerFail.Name = "chkPowerFail";
            this.chkPowerFail.Size = new System.Drawing.Size(90, 17);
            this.chkPowerFail.TabIndex = 2;
            this.chkPowerFail.Text = "Power Failure";
            this.chkPowerFail.UseVisualStyleBackColor = true;
            this.chkPowerFail.Visible = false;
            this.chkPowerFail.Click += new System.EventHandler(this.OnPowerFailureClicked);
            // 
            // chkBrokenRail
            // 
            this.chkBrokenRail.AutoSize = true;
            this.chkBrokenRail.Location = new System.Drawing.Point(91, 107);
            this.chkBrokenRail.Name = "chkBrokenRail";
            this.chkBrokenRail.Size = new System.Drawing.Size(81, 17);
            this.chkBrokenRail.TabIndex = 2;
            this.chkBrokenRail.Text = "Broken Rail";
            this.chkBrokenRail.UseVisualStyleBackColor = true;
            this.chkBrokenRail.Visible = false;
            this.chkBrokenRail.Click += new System.EventHandler(this.OnBrokenRailClicked);
            // 
            // chkCircuitFail
            // 
            this.chkCircuitFail.AutoSize = true;
            this.chkCircuitFail.Location = new System.Drawing.Point(91, 80);
            this.chkCircuitFail.Name = "chkCircuitFail";
            this.chkCircuitFail.Size = new System.Drawing.Size(89, 17);
            this.chkCircuitFail.TabIndex = 2;
            this.chkCircuitFail.Text = "Circuit Failure";
            this.chkCircuitFail.UseVisualStyleBackColor = true;
            this.chkCircuitFail.Visible = false;
            this.chkCircuitFail.Click += new System.EventHandler(this.OnCircuitFailureClicked);
            // 
            // chkRunSimulation
            // 
            this.chkRunSimulation.AutoSize = true;
            this.chkRunSimulation.Location = new System.Drawing.Point(15, 27);
            this.chkRunSimulation.Name = "chkRunSimulation";
            this.chkRunSimulation.Size = new System.Drawing.Size(46, 17);
            this.chkRunSimulation.TabIndex = 2;
            this.chkRunSimulation.Text = "Run";
            this.chkRunSimulation.UseVisualStyleBackColor = true;
            this.chkRunSimulation.Click += new System.EventHandler(this.OnCircuitFailureClicked);
            // 
            // SimulatorWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.chkRunSimulation);
            this.Controls.Add(this.chkCircuitFail);
            this.Controls.Add(this.chkBrokenRail);
            this.Controls.Add(this.chkPowerFail);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.btnSetTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SimulatorWindow";
            this.ShowIcon = false;
            this.Text = "SimulatorWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetTime;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.CheckBox chkPowerFail;
        private System.Windows.Forms.CheckBox chkBrokenRail;
        private System.Windows.Forms.CheckBox chkCircuitFail;
        private System.Windows.Forms.CheckBox chkRunSimulation;
    }
}