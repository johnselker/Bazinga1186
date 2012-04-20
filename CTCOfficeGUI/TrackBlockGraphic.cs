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

        //Collection of points for drawing directional arrows
        private Point m_arrow1Start1;
        private Point m_arrow1End1;
        private Point m_arrow1Start2;
        private Point m_arrow1End2;
        private Point m_arrow2Start1;
        private Point m_arrow2End1;
        private Point m_arrow2Start2;
        private Point m_arrow2End2;

        #endregion

        #region Events

        public event EventHandler TrackBlockClicked;

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

                picRRCrossing.Visible = m_block.RailroadCrossing;
                picTunnel.Visible = m_block.HasTunnel;
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

        /// <summary>
        /// Color of dot on the block
        /// </summary>
        public Color DotColor
        {
            get;
            set;
        }

        /// <summary>
        /// Flag to show a dot on the block
        /// </summary>
        public bool ShowDot
        {
            get;
            set;
        }

        /// <summary>
        /// Thickness of the line representing the block
        /// </summary>
        public int LineThickness
        {
            get;
            set;
        }

        /// <summary>
        /// Length of arrows of the block
        /// </summary>
        public int ArrowLength
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
            DotColor = Color.Orange;

            LineThickness = 5;
            ArrowLength = 10;

            Block = block;

            m_currentColor = GetDrawColor();

            SetScale(scale);
            CalculateArrowPoints();
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
            if (scale > 0 && scale < double.PositiveInfinity)
            {
                if (m_block != null)
                {
                    switch (m_block.Orientation)
                    {
                        case TrackOrientation.EastWest:
                            //Horizontal rectangle
                            this.Height = LineThickness + Margin.Top + Margin.Bottom + 2 * ArrowLength;
                            this.Width = System.Convert.ToInt32(m_block.LengthMeters * scale);
                            m_scaledStart = new Point(Margin.Left, (this.Height - LineThickness) / 2);
                            m_scaledEnd = new Point(this.Width - Margin.Right, (this.Height - LineThickness) / 2);
                            break;
                        case TrackOrientation.SouthWestNorthEast:
                            //Create a box to fit the diagonal
                            int dimSize = System.Convert.ToInt32(System.Math.Sqrt((m_block.LengthMeters * m_block.LengthMeters) / 2.0) * scale);
                            this.Width = this.Height = dimSize;
                            m_scaledStart = new Point(Margin.Left, this.Height - Margin.Bottom);
                            m_scaledEnd = new Point(this.Width - Margin.Right, Margin.Top);
                            break;
                        case TrackOrientation.NorthSouth:
                            //Horizontal rectangle
                            this.Width = LineThickness + Margin.Left + Margin.Right + 2 * ArrowLength;
                            this.Height = System.Convert.ToInt32(m_block.LengthMeters * scale);
                            m_scaledStart = new Point((this.Width - LineThickness)/ 2, this.Height - Margin.Bottom);
                            m_scaledEnd = new Point((this.Width - LineThickness)/ 2, Margin.Top);
                            break;
                        case TrackOrientation.NorthWestSouthEast:
                            //Create a box to fit the diagonal
                            dimSize = System.Convert.ToInt32(System.Math.Sqrt((m_block.LengthMeters * m_block.LengthMeters) / 2.0) * scale);
                            this.Width = this.Height = dimSize;
                            m_scaledStart = new Point(Margin.Left, Margin.Top);
                            m_scaledEnd = new Point(this.Width - Margin.Right, this.Height - Margin.Bottom);
                            break;

                    }

                    if (m_block.RailroadCrossing && !m_block.HasTunnel)
                    {
                        picRRCrossing.Left = System.Convert.ToInt32((this.Width - picRRCrossing.Width) / 2.0);
                        picRRCrossing.Top = System.Convert.ToInt32((this.Height - picRRCrossing.Height) / 2.0);
                    }
                    else if (!m_block.RailroadCrossing && m_block.HasTunnel)
                    {
                        picTunnel.Left = System.Convert.ToInt32((this.Width - picRRCrossing.Width) / 2.0);
                        picTunnel.Top = System.Convert.ToInt32((this.Height - picRRCrossing.Height) / 2.0);
                    }
                    else
                    {
                        picRRCrossing.Left = System.Convert.ToInt32((this.Width / 2.0) - picRRCrossing.Width);
                        picTunnel.Left = System.Convert.ToInt32(this.Width / 2.0);
                        picTunnel.Top = picRRCrossing.Top = System.Convert.ToInt32((this.Height - picRRCrossing.Height) / 2.0);
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
            this.Visible = !this.Visible;
        }

        /// <summary>
        /// Causes the graphic to stop blinking
        /// </summary>
        public void StopBlinking()
        {
            this.Visible = true;
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

        /// <summary>
        /// Calculates the points for drawing arrows
        /// </summary>
        private void CalculateArrowPoints()
        {
            if (m_block != null)
            {
                switch (m_block.Orientation)
                {
                    case TrackOrientation.EastWest:
                        if (m_block.AllowedDirection == TrackAllowedDirection.Both || m_block.AllowedDirection == TrackAllowedDirection.RightToLeft)
                        {
                            m_arrow1Start1 = m_arrow1Start2 = m_scaledStart;
                            m_arrow1End1 = new Point(m_scaledStart.X + ArrowLength, m_scaledStart.Y - ArrowLength);
                            m_arrow1End2 = new Point(m_scaledStart.X + ArrowLength, m_scaledStart.Y + ArrowLength);
                        }
                        if (m_block.AllowedDirection == TrackAllowedDirection.Both || m_block.AllowedDirection == TrackAllowedDirection.LeftToRight)
                        {
                            m_arrow2Start1 = m_arrow2Start2 = m_scaledEnd;
                            m_arrow2End1 = new Point(m_scaledEnd.X - ArrowLength, m_scaledEnd.Y - ArrowLength);
                            m_arrow2End2 = new Point(m_scaledEnd.X - ArrowLength, m_scaledEnd.Y + ArrowLength);
                        }
                        break;
                    case TrackOrientation.NorthSouth:
                        if (m_block.AllowedDirection == TrackAllowedDirection.Both || m_block.AllowedDirection == TrackAllowedDirection.RightToLeft)
                        {
                            m_arrow2Start1 = m_arrow2Start2 = m_scaledStart;
                            m_arrow2End1 = new Point(m_scaledStart.X - ArrowLength, m_scaledStart.Y - ArrowLength);
                            m_arrow2End2 = new Point(m_scaledStart.X + ArrowLength, m_scaledStart.Y - ArrowLength);
                        }
                        if (m_block.AllowedDirection == TrackAllowedDirection.Both || m_block.AllowedDirection == TrackAllowedDirection.LeftToRight)
                        {
                            m_arrow1Start1 = m_arrow1Start2 = m_scaledEnd;
                            m_arrow1End1 = new Point(m_scaledEnd.X - ArrowLength, m_scaledEnd.Y + ArrowLength);
                            m_arrow1End2 = new Point(m_scaledEnd.X + ArrowLength, m_scaledEnd.Y + ArrowLength);
                        }
                        break;
                    case TrackOrientation.NorthWestSouthEast:
                        if (m_block.AllowedDirection == TrackAllowedDirection.Both || m_block.AllowedDirection == TrackAllowedDirection.RightToLeft)
                        {
                            m_arrow1Start1 = m_arrow1Start2 = m_scaledStart;
                            m_arrow1End1 = new Point(m_scaledStart.X, m_scaledStart.Y + ArrowLength);
                            m_arrow1End2 = new Point(m_scaledStart.X + ArrowLength, m_scaledStart.Y);
                        }
                        if (m_block.AllowedDirection == TrackAllowedDirection.Both || m_block.AllowedDirection == TrackAllowedDirection.LeftToRight)
                        {
                            m_arrow2Start1 = m_arrow2Start2 = m_scaledEnd;
                            m_arrow2End1 = new Point(m_scaledEnd.X, m_scaledEnd.Y - ArrowLength);
                            m_arrow2End2 = new Point(m_scaledEnd.X - ArrowLength, m_scaledEnd.Y);
                        }
                        break;
                    case TrackOrientation.SouthWestNorthEast:
                        if (m_block.AllowedDirection == TrackAllowedDirection.Both || m_block.AllowedDirection == TrackAllowedDirection.RightToLeft)
                        {
                            m_arrow1Start1 = m_arrow1Start2 = m_scaledStart;
                            m_arrow1End1 = new Point(m_scaledStart.X, m_scaledStart.Y - ArrowLength);
                            m_arrow1End2 = new Point(m_scaledStart.X + ArrowLength, m_scaledStart.Y);
                        }
                        if (m_block.AllowedDirection == TrackAllowedDirection.Both || m_block.AllowedDirection == TrackAllowedDirection.LeftToRight)
                        {
                            m_arrow2Start1 = m_arrow2Start2 = m_scaledEnd;
                            m_arrow2End1 = new Point(m_scaledEnd.X - ArrowLength, m_scaledEnd.Y);
                            m_arrow2End2 = new Point(m_scaledEnd.X, m_scaledEnd.Y + ArrowLength);
                        }
                        break;
                    default:
                        //Unreachable
                        break;
                }
            }
        }

        /// <summary>
        /// Draws the arrows indicating the allowed direction of travel of the block
        /// </summary>
        /// <param name="g">Graphics object</param>
        /// <param name="p">Pen object</param>
        private void DrawArrows(Graphics g, Pen p)
        {
            if (g != null && p != null)
            {
                p.Width = 3;

                if (!m_arrow1Start1.IsEmpty && !m_arrow1End1.IsEmpty)
                {
                    g.DrawLine(p, m_arrow1Start1, m_arrow1End1);
                }
                if (!m_arrow1Start2.IsEmpty && !m_arrow1End2.IsEmpty)
                {
                    g.DrawLine(p, m_arrow1Start2, m_arrow1End2);
                }
                if (!m_arrow2Start1.IsEmpty && !m_arrow2End1.IsEmpty)
                {
                    g.DrawLine(p, m_arrow2Start1, m_arrow2End1);
                }
                if (!m_arrow2Start2.IsEmpty && !m_arrow2End2.IsEmpty)
                {
                    g.DrawLine(p, m_arrow2Start2, m_arrow2End2);
                }
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Catch and rethrow of the click event. Necessary to allow picture boxes to throw the click event as well
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnClick(object sender, EventArgs e)
        {
            if (TrackBlockClicked != null)
            {
                TrackBlockClicked(this, e);
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
            Pen pen = new Pen(m_currentColor, LineThickness);
            
            g.DrawLine(pen, m_scaledStart, m_scaledEnd); //Draw line

            DrawArrows(g, pen);
            
            if (ShowDot)
            {
                Rectangle center = new Rectangle((this.Width - LineThickness) / 2, (this.Height - LineThickness) / 2, 
                                                                                        LineThickness, LineThickness);
                SolidBrush brush = new SolidBrush(DotColor);

                g.FillEllipse(brush, center);
            }

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
