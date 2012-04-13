namespace CTCOfficeGUI
{
    partial class MainScreen
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
            this.commandPanel = new CTCOfficeGUI.CommandPanel();
            this.trackDisplayPanel = new CTCOfficeGUI.TrackDisplayPanel();
            this.infoPanel = new CTCOfficeGUI.InfoPanel();
            this.SuspendLayout();
            // 
            // commandPanel
            // 
            this.commandPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commandPanel.Location = new System.Drawing.Point(1079, 0);
            this.commandPanel.Margin = new System.Windows.Forms.Padding(0);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(196, 520);
            this.commandPanel.TabIndex = 1;
            this.commandPanel.CommandClicked += new CTCOfficeGUI.CommandPanel.OnCommandClicked(this.OnCommandClicked);
            // 
            // trackDisplayPanel
            // 
            this.trackDisplayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trackDisplayPanel.Location = new System.Drawing.Point(0, 0);
            this.trackDisplayPanel.Margin = new System.Windows.Forms.Padding(0);
            this.trackDisplayPanel.Name = "trackDisplayPanel";
            this.trackDisplayPanel.ScaleFactor = 1D;
            this.trackDisplayPanel.Size = new System.Drawing.Size(1080, 520);
            this.trackDisplayPanel.TabIndex = 0;
            this.trackDisplayPanel.TrackBlockClicked += new CTCOfficeGUI.TrackDisplayPanel.OnTrackBlockClicked(this.OnTrackBlockClicked);
            this.trackDisplayPanel.TrainClicked += new CTCOfficeGUI.TrackDisplayPanel.OnTrainClicked(this.OnTrainClicked);
            // 
            // infoPanel
            // 
            this.infoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoPanel.Location = new System.Drawing.Point(0, 519);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(1080, 174);
            this.infoPanel.TabIndex = 2;
            // 
            // MainScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1274, 692);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.commandPanel);
            this.Controls.Add(this.trackDisplayPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainScreen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CTC Office GUI";
            this.ResumeLayout(false);

        }

        #endregion

        private TrackDisplayPanel trackDisplayPanel;
        private CommandPanel commandPanel;
        private InfoPanel infoPanel;

    }
}

