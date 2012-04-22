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
            // TrainOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 197);
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
    }
}