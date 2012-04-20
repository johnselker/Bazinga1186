namespace CTCOfficeGUI
{
    partial class TrackBlockGraphic
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picTunnel = new System.Windows.Forms.PictureBox();
            this.picRRCrossing = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTunnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRRCrossing)).BeginInit();
            this.SuspendLayout();
            // 
            // picTunnel
            // 
            this.picTunnel.Image = global::CTCOfficeGUI.Properties.Resources.tunnelIcon;
            this.picTunnel.Location = new System.Drawing.Point(46, 0);
            this.picTunnel.Name = "picTunnel";
            this.picTunnel.Size = new System.Drawing.Size(20, 20);
            this.picTunnel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTunnel.TabIndex = 0;
            this.picTunnel.TabStop = false;
            this.picTunnel.Visible = false;
            this.picTunnel.Click += new System.EventHandler(this.OnClick);
            // 
            // picRRCrossing
            // 
            this.picRRCrossing.Image = global::CTCOfficeGUI.Properties.Resources.railroadCrossing;
            this.picRRCrossing.Location = new System.Drawing.Point(0, 0);
            this.picRRCrossing.Name = "picRRCrossing";
            this.picRRCrossing.Size = new System.Drawing.Size(20, 20);
            this.picRRCrossing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRRCrossing.TabIndex = 0;
            this.picRRCrossing.TabStop = false;
            this.picRRCrossing.Visible = false;
            this.picRRCrossing.Click += new System.EventHandler(this.OnClick);
            // 
            // TrackBlockGraphic
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.picTunnel);
            this.Controls.Add(this.picRRCrossing);
            this.Name = "TrackBlockGraphic";
            this.Click += new System.EventHandler(this.OnClick);
            ((System.ComponentModel.ISupportInitialize)(this.picTunnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRRCrossing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRRCrossing;
        private System.Windows.Forms.PictureBox picTunnel;
    }
}
