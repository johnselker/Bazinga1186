using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Train;

namespace CTCOfficeGUI
{
    /// <summary>
    /// Graphic for displaying a train
    /// </summary>
    public partial class TrainGraphic : UserControl
    {
        #region Events

        public event EventHandler TrainClicked;

        #endregion

        #region Properties

        /// <summary>
        /// Reference to the train this graphic represents
        /// </summary>
        public ITrain Train
        {
            get { return m_train; }
            set { m_train = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TrainGraphic(ITrain train)
        {
            InitializeComponent();
            m_train = train;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the scale of the train relative to the screen
        /// </summary>
        /// 
        /// <remarks>
        /// Scale is represented as a ratio of the original size to the new size
        /// </remarks>
        /// 
        /// <param name="scale">Scale to display</param>
        /// <returns>Bool success</returns>
        public bool SetScale(double scale)
        {
            if (scale > 0)
            {
                this.Width = this.Height = System.Convert.ToInt32(scale * m_originalSize);
                picIcon.Size = this.Size;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Causes the graphic to stop blinking
        /// </summary>
        public void StopBlinking()
        {
            this.Visible = true;
        }

        /// <summary>
        /// Causes the graphic to "blink" to show as selected
        /// </summary>
        public void Blink()
        {
            this.Visible = !this.Visible; //Toggle visibility
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Catch and rethrow the click event (necessary for some reason)
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnPictureBoxClicked(object sender, EventArgs e)
        {
            if (TrainClicked != null)
            {
                TrainClicked(this, e);
            }
        }

        #endregion

        #region Private Data

        private ITrain m_train = null;
        private const int m_originalSize = 30;

        #endregion
    }
}
