using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;

namespace CTCOfficeGUI
{
    public partial class TrackBlockGraphic : UserControl
    {

        #region Private Data

        private Point m_scaledStart;
        private Point m_scaledEnd;
        private TrackBlock m_block;
        private Color m_currentColor = Color.Green;
        private int m_thickness = 5;

        #endregion

        #region Properties

        // PROPERTY: Block
        ///--------------------------------------------------------------------------------------
        /// <summary>
        /// Reference to the track block which this graphic represents
        /// </summary>
        ///--------------------------------------------------------------------------------------
        public TrackBlock Block
        {
            get { return m_block; }
            set 
            { 
                m_block = value;
                m_currentColor = GetDrawColor();
            }
        }

        /// <summary>
        /// Color for a red signal
        /// </summary>
        public Color RedColor
        {
            get;
            set;
        }

        /// <summary>
        /// Color for a yellow signal
        /// </summary>
        public Color YellowColor
        {
            get;
            set;
        }

        /// <summary>
        /// Color for a green signal
        /// </summary>
        public Color GreenColor
        {
            get;
            set;
        }

        /// <summary>
        /// Color for a super green signal
        /// </summary>
        public Color SuperGreenColor
        {
            get;
            set;
        }

        /// <summary>
        /// Blink color
        /// </summary>
        public Color BlinkColor
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        // METHOD: TrackBlockGraphic
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Primary constructor for the track block graphic class
        /// </summary>
        /// <param name="block">Track block object this graphic represents</param>
        /// <param name="scale">Scaling constant for the screen</param>
        //--------------------------------------------------------------------------------------
        public TrackBlockGraphic(TrackBlock block, double scale)
        {
            this.SuspendLayout();

            InitializeComponent();

            //Need this crap to make it transparent
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            RedColor = Color.Red;
            YellowColor = Color.Yellow;
            GreenColor = Color.Green;
            SuperGreenColor = Color.Green;

            m_block = block;
            m_currentColor = GetDrawColor();

            SetScale(scale);
            this.BackColor = Color.Transparent;

            this.ResumeLayout();
        }

        // METHOD: SetScale
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Sets the scale of the track block relative to the screen
        /// </summary>
        /// 
        /// <remarks>
        /// Scale is represented as a ratio of actual length units per pixel,
        /// e.g. 10 miles/pixel would be set as 0.1
        /// </remarks>
        /// 
        /// <param name="scale">Scale to display</param>
        /// <returns>Bool success</returns>
        //--------------------------------------------------------------------------------------
        public bool SetScale(double scale)
        {
            if (scale > 0)
            {
                if (m_block != null)
                {
                    switch (m_block.Orientation)
                    {
                        case TrackOrientation.EastWest:
                            //Horizontal rectangle
                            this.Height = m_thickness + Margin.Left + Margin.Right;
                            this.Width = System.Convert.ToInt32(m_block.LengthMeters * scale);
                            m_scaledStart = new Point(Margin.Left, (this.Height - m_thickness) / 2);
                            m_scaledEnd = new Point(this.Width - Margin.Right, (this.Height - m_thickness) / 2);
                            break;
                        case TrackOrientation.SouthWestNorthEast:
                            //Create a box to fit the diagonal
                            int dimSize = System.Convert.ToInt32(System.Math.Sqrt((m_block.LengthMeters * m_block.LengthMeters) / 2.0));
                            this.Width = this.Height = dimSize;
                            m_scaledStart = new Point(Margin.Left, this.Height - Margin.Bottom);
                            m_scaledEnd = new Point(this.Width - Margin.Right, Margin.Top);
                            break;
                        case TrackOrientation.NorthSouth:
                            //Horizontal rectangle
                            this.Width = m_thickness + Margin.Left + Margin.Right;
                            this.Height = System.Convert.ToInt32(m_block.LengthMeters * scale);
                            m_scaledStart = new Point((this.Width - m_thickness)/ 2, this.Height - Margin.Bottom);
                            m_scaledEnd = new Point((this.Width - m_thickness)/ 2, Margin.Top);
                            break;
                        case TrackOrientation.NorthWestSouthEast:
                            //Create a box to fit the diagonal
                            dimSize = System.Convert.ToInt32(System.Math.Sqrt((m_block.LengthMeters * m_block.LengthMeters) / 2.0));
                            this.Width = this.Height = dimSize;
                            m_scaledStart = new Point(Margin.Left, Margin.Top);
                            m_scaledEnd = new Point(this.Width - Margin.Right, this.Height - Margin.Bottom);
                            break;

                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Causes the graphic to "blink" to show as selected
        /// </summary>
        public void Blink()
        {
            if (m_currentColor != BlinkColor)
            {
                m_currentColor = BlinkColor;
            }
            else
            {
                m_currentColor = GetDrawColor();
            }
            Invalidate();
        }

        /// <summary>
        /// Causes the graphic to stop blinking
        /// </summary>
        public void StopBlinking()
        {
            m_currentColor = GetDrawColor();
            Invalidate();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Gets the color the block should draw in
        /// </summary>
        /// <returns></returns>
        private Color GetDrawColor()
        {
            switch (m_block.Status.SignalState)
            {
                case TrackSignalState.Red:
                    return RedColor;
                case TrackSignalState.Yellow:
                    return YellowColor;
                case TrackSignalState.Green:
                    return GreenColor;
                case TrackSignalState.SuperGreen:
                    return SuperGreenColor;
                default: //Unreachable
                    return m_currentColor;
            }
        }
        #endregion

        #region Overrides

        // METHOD: OnPaint
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Paint override that draws the block control
        /// </summary>
        /// 
        /// <param name="e">Paint event arguments (from .NET)</param>=
        ///--------------------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_block == null)
                return;

            Graphics g = e.Graphics;

            //Set the color
            Pen pen = new Pen(m_currentColor, m_thickness);
            
            g.DrawLine(pen, m_scaledStart, m_scaledEnd); //Draw line

            pen.Dispose();
        }

        // METHOD: CreateParams
        ///------------------------------------------------------------------------
        /// <summary>
        /// 'CreateParams' override.
        /// </summary>
        /// 
        /// <remarks>
        /// Necessary for transparency
        /// </remarks>
        ///------------------------------------------------------------------------
        protected override CreateParams CreateParams
        {
            get
            {
                //Specifies that the control should not be painted until siblings
                //beneath it (created by the same thread) have been painted.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
                return cp;
            }
        }

        #endregion
    }
}
