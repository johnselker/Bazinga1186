namespace TrainControllerLib
{
    partial class TrainOperator
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
            this.createTrain = new System.Windows.Forms.Button();
            this.currentSpeed = new System.Windows.Forms.TextBox();
            this.enterSpeed = new System.Windows.Forms.Button();
            this.manualSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentPosition = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timePassed = new System.Windows.Forms.TextBox();
            this.lights = new System.Windows.Forms.TextBox();
            this.doors = new System.Windows.Forms.TextBox();
            this.announcement = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.engineFailure = new System.Windows.Forms.Button();
            this.brakeFailure = new System.Windows.Forms.Button();
            this.powerFailure = new System.Windows.Forms.Button();
            this.circuitFailure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createTrain
            // 
            this.createTrain.Location = new System.Drawing.Point(10, 13);
            this.createTrain.Name = "createTrain";
            this.createTrain.Size = new System.Drawing.Size(94, 23);
            this.createTrain.TabIndex = 0;
            this.createTrain.Text = "Start";
            this.createTrain.UseVisualStyleBackColor = true;
            this.createTrain.Click += new System.EventHandler(this.createTrain_Click);
            // 
            // currentSpeed
            // 
            this.currentSpeed.Location = new System.Drawing.Point(189, 13);
            this.currentSpeed.Name = "currentSpeed";
            this.currentSpeed.ReadOnly = true;
            this.currentSpeed.Size = new System.Drawing.Size(100, 20);
            this.currentSpeed.TabIndex = 1;
            // 
            // enterSpeed
            // 
            this.enterSpeed.Location = new System.Drawing.Point(10, 39);
            this.enterSpeed.Name = "enterSpeed";
            this.enterSpeed.Size = new System.Drawing.Size(94, 23);
            this.enterSpeed.TabIndex = 2;
            this.enterSpeed.Text = "Enter Speed";
            this.enterSpeed.UseVisualStyleBackColor = true;
            this.enterSpeed.Click += new System.EventHandler(this.enterSpeed_Click);
            // 
            // manualSpeed
            // 
            this.manualSpeed.Location = new System.Drawing.Point(189, 39);
            this.manualSpeed.Name = "manualSpeed";
            this.manualSpeed.Size = new System.Drawing.Size(100, 20);
            this.manualSpeed.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Target Speed";
            // 
            // currentPosition
            // 
            this.currentPosition.Location = new System.Drawing.Point(189, 65);
            this.currentPosition.Name = "currentPosition";
            this.currentPosition.ReadOnly = true;
            this.currentPosition.Size = new System.Drawing.Size(100, 20);
            this.currentPosition.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Current Position";
            // 
            // timePassed
            // 
            this.timePassed.Location = new System.Drawing.Point(189, 91);
            this.timePassed.Name = "timePassed";
            this.timePassed.ReadOnly = true;
            this.timePassed.Size = new System.Drawing.Size(100, 20);
            this.timePassed.TabIndex = 8;
            // 
            // lights
            // 
            this.lights.Location = new System.Drawing.Point(189, 117);
            this.lights.Name = "lights";
            this.lights.ReadOnly = true;
            this.lights.Size = new System.Drawing.Size(100, 20);
            this.lights.TabIndex = 9;
            // 
            // doors
            // 
            this.doors.Location = new System.Drawing.Point(189, 143);
            this.doors.Name = "doors";
            this.doors.ReadOnly = true;
            this.doors.Size = new System.Drawing.Size(100, 20);
            this.doors.TabIndex = 10;
            // 
            // announcement
            // 
            this.announcement.Location = new System.Drawing.Point(189, 169);
            this.announcement.Name = "announcement";
            this.announcement.ReadOnly = true;
            this.announcement.Size = new System.Drawing.Size(100, 20);
            this.announcement.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Lights";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Doors";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Announcement";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Time Since Last Station";
            // 
            // engineFailure
            // 
            this.engineFailure.Location = new System.Drawing.Point(10, 68);
            this.engineFailure.Name = "engineFailure";
            this.engineFailure.Size = new System.Drawing.Size(94, 23);
            this.engineFailure.TabIndex = 16;
            this.engineFailure.Text = "Engine Failure";
            this.engineFailure.UseVisualStyleBackColor = true;
            this.engineFailure.Click += new System.EventHandler(this.engineFailure_Click);
            // 
            // brakeFailure
            // 
            this.brakeFailure.Location = new System.Drawing.Point(10, 110);
            this.brakeFailure.Name = "brakeFailure";
            this.brakeFailure.Size = new System.Drawing.Size(94, 23);
            this.brakeFailure.TabIndex = 17;
            this.brakeFailure.Text = "Brake Failure";
            this.brakeFailure.UseVisualStyleBackColor = true;
            this.brakeFailure.Click += new System.EventHandler(this.brakeFailure_Click);
            // 
            // powerFailure
            // 
            this.powerFailure.Location = new System.Drawing.Point(10, 139);
            this.powerFailure.Name = "powerFailure";
            this.powerFailure.Size = new System.Drawing.Size(101, 23);
            this.powerFailure.TabIndex = 18;
            this.powerFailure.Text = "Track Power Fail";
            this.powerFailure.UseVisualStyleBackColor = true;
            this.powerFailure.Click += new System.EventHandler(this.powerFailure_Click);
            // 
            // circuitFailure
            // 
            this.circuitFailure.Location = new System.Drawing.Point(10, 166);
            this.circuitFailure.Name = "circuitFailure";
            this.circuitFailure.Size = new System.Drawing.Size(94, 23);
            this.circuitFailure.TabIndex = 19;
            this.circuitFailure.Text = "Track Circuit Fail";
            this.circuitFailure.UseVisualStyleBackColor = true;
            this.circuitFailure.Click += new System.EventHandler(this.circuitFailure_Click);
            // 
            // TrainOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 197);
            this.Controls.Add(this.circuitFailure);
            this.Controls.Add(this.powerFailure);
            this.Controls.Add(this.brakeFailure);
            this.Controls.Add(this.engineFailure);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.announcement);
            this.Controls.Add(this.doors);
            this.Controls.Add(this.lights);
            this.Controls.Add(this.timePassed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentPosition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.manualSpeed);
            this.Controls.Add(this.enterSpeed);
            this.Controls.Add(this.currentSpeed);
            this.Controls.Add(this.createTrain);
            this.Name = "TrainOperator";
            this.Text = "TrainOperator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createTrain;
        private System.Windows.Forms.TextBox currentSpeed;
        private System.Windows.Forms.Button enterSpeed;
        private System.Windows.Forms.TextBox manualSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox currentPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox timePassed;
        private System.Windows.Forms.TextBox lights;
        private System.Windows.Forms.TextBox doors;
        private System.Windows.Forms.TextBox announcement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button engineFailure;
        private System.Windows.Forms.Button brakeFailure;
        private System.Windows.Forms.Button powerFailure;
        private System.Windows.Forms.Button circuitFailure;
    }
}