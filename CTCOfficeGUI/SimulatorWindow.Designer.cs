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
            this.SuspendLayout();
            // 
            // btnSetTime
            // 
            this.btnSetTime.Location = new System.Drawing.Point(50, 10);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(200, 40);
            this.btnSetTime.TabIndex = 0;
            this.btnSetTime.Text = "Set Simulation Time";
            this.btnSetTime.UseVisualStyleBackColor = true;
            // 
            // SimulatorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSetTime);
            this.Name = "SimulatorWindow";
            this.Text = "SimulatorWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetTime;
    }
}