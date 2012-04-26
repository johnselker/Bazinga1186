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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTrackLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoPanel = new CTCOfficeGUI.InfoPanel();
            this.commandPanel = new CTCOfficeGUI.CommandPanel();
            this.trackDisplayPanel = new CTCOfficeGUI.TrackDisplayPanel();
            this.tableViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulatorWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1274, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTrackLayoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadTrackLayoutToolStripMenuItem
            // 
            this.loadTrackLayoutToolStripMenuItem.Name = "loadTrackLayoutToolStripMenuItem";
            this.loadTrackLayoutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.loadTrackLayoutToolStripMenuItem.Text = "Load Track Layout";
            this.loadTrackLayoutToolStripMenuItem.Click += new System.EventHandler(this.OnLoadTrackLayoutClicked);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClicked);
            // 
            // infoPanel
            // 
            this.infoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoPanel.Location = new System.Drawing.Point(0, 543);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(1080, 174);
            this.infoPanel.TabIndex = 2;
            // 
            // commandPanel
            // 
            this.commandPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commandPanel.Location = new System.Drawing.Point(1079, 24);
            this.commandPanel.Margin = new System.Windows.Forms.Padding(0);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(196, 520);
            this.commandPanel.TabIndex = 1;
            this.commandPanel.CommandClicked += new CTCOfficeGUI.CommandPanel.OnCommandClicked(this.OnCommandClicked);
            // 
            // trackDisplayPanel
            // 
            this.trackDisplayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trackDisplayPanel.Location = new System.Drawing.Point(0, 24);
            this.trackDisplayPanel.Margin = new System.Windows.Forms.Padding(0);
            this.trackDisplayPanel.Name = "trackDisplayPanel";
            this.trackDisplayPanel.Size = new System.Drawing.Size(1080, 520);
            this.trackDisplayPanel.TabIndex = 0;
            this.trackDisplayPanel.TrackBlockClicked += new CTCOfficeGUI.TrackDisplayPanel.OnTrackBlockClicked(this.OnTrackBlockClicked);
            this.trackDisplayPanel.TrainClicked += new CTCOfficeGUI.TrackDisplayPanel.OnTrainClicked(this.OnTrainClicked);
            // 
            // tableViewToolStripMenuItem
            // 
            this.tableViewToolStripMenuItem.Name = "tableViewToolStripMenuItem";
            this.tableViewToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.tableViewToolStripMenuItem.Text = "Table View";
            this.tableViewToolStripMenuItem.Click += new System.EventHandler(this.OnTableViewClicked);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableViewToolStripMenuItem,
            this.simulatorWindowToolStripMenuItem,
            this.trainWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // simulatorWindowToolStripMenuItem
            // 
            this.simulatorWindowToolStripMenuItem.Name = "simulatorWindowToolStripMenuItem";
            this.simulatorWindowToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.simulatorWindowToolStripMenuItem.Text = "Simulator Window";
            this.simulatorWindowToolStripMenuItem.Click += new System.EventHandler(this.OnViewSimulatorWindowClicked);
            // 
            // trainWindowToolStripMenuItem
            // 
            this.trainWindowToolStripMenuItem.Name = "trainWindowToolStripMenuItem";
            this.trainWindowToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.trainWindowToolStripMenuItem.Text = "Train Window";
            // 
            // MainScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1274, 716);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.commandPanel);
            this.Controls.Add(this.trackDisplayPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainScreen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CTC Office GUI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrackDisplayPanel trackDisplayPanel;
        private CommandPanel commandPanel;
        private InfoPanel infoPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTrackLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulatorWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainWindowToolStripMenuItem;

    }
}

