using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using CommonLib;

namespace CTCOfficeGUI
{
    public partial class TrackDisplayPanel : UserControl
    {
        #region Private Data

        private Dictionary<TrackBlock, TrackBlockGraphic> m_blockTable = new Dictionary<TrackBlock, TrackBlockGraphic>();
        private double m_scale = 1;
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private TrackBlockGraphic m_selectedGraphic = null;

        #endregion

        #region Events

        /// <summary>
        /// Track block clicked event
        /// </summary>
        public event OnTrackBlockClicked TrackBlockClicked;
       
        #endregion

        #region Delegates

        /// <summary>
        /// Delegate method for handling the track block click event
        /// </summary>
        /// <param name="block"></param>
        public delegate void OnTrackBlockClicked(TrackBlock block);

        #endregion

        #region Properties

        /// <summary>
        /// Factor by which to scale the graphics (scale of 1 = 1 pixel per km)
        /// </summary>
        public double ScaleFactor
        {
            get { return m_scale; }
            set
            {
                if (value > 0)
                {
                    //Update the scaling factor
                    m_scale = value;

                    foreach (KeyValuePair<TrackBlock, TrackBlockGraphic> block in m_blockTable)
                    {
                        block.Value.SetScale(value);
                    }
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor for the track display panel
        /// </summary>
        public TrackDisplayPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Primary constructor for the track display panel
        /// </summary>
        public TrackDisplayPanel(List<TrackBlock> blocks)
        {
            InitializeComponent();
            SetTrackLayout(blocks);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Draws the track layout
        /// </summary>
        /// <param name="blocks"></param>
        public void SetTrackLayout(List<TrackBlock> blocks)
        {
            if (blocks != null)
            {
                //Clear the controls
                foreach (KeyValuePair<TrackBlock, TrackBlockGraphic> graphic in m_blockTable)
                {
                    Controls.Remove(graphic.Value);
                }

                m_blockTable.Clear();

                foreach (TrackBlock b in blocks)
                {
                    //Create a new trackblock graphic
                    TrackBlockGraphic graphic = new TrackBlockGraphic(b, m_scale);
                    graphic.Margin = new Padding(3);

                    graphic.Location = CalculateGraphicPosition(b);

                    graphic.Click += OnBlockClicked;

                    Controls.Add(graphic);
                    m_blockTable[b] = graphic;
                }
            }
        }

        /// <summary>
        /// Redraws the track layout with the new state
        /// </summary>
        /// <param name="updatedBlocks">List of blocks that have changed state</param>
        public void UpdateTrackLayout(List<TrackBlock> updatedBlocks)
        {
            if (updatedBlocks != null)
            {
                foreach (TrackBlock b in updatedBlocks)
                {
                    if (m_blockTable.ContainsKey(b))
                    {
                        m_blockTable[b].Location = CalculateGraphicPosition(b);
                        m_blockTable[b].Block = b;
                        m_blockTable[b].Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Unselects the selected graphic, if there is one
        /// </summary>
        public void UnselectAll()
        {
            if (m_selectedGraphic != null)
            {
                m_selectedGraphic.StopBlinking();
                m_selectedGraphic = null;
                blinkTimer.Stop();
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Calculates the position of the graphic on the display panel
        /// </summary>
        /// <param name="block">Track block to display</param>
        /// <returns>Point of the graphic on the display panel</returns>
        private Point CalculateGraphicPosition(TrackBlock block)
        {
            if (block != null)
            {
                switch (block.Orientation)
                {
                    case TrackOrientation.EastWest:
                    case TrackOrientation.NorthWestSouthEast:
                        return new Point(System.Convert.ToInt32(block.StartPoint.X * m_scale),
                                                     System.Convert.ToInt32(block.StartPoint.Y * m_scale));
                    case TrackOrientation.SouthWestNorthEast:
                    case TrackOrientation.NorthSouth:
                        return new Point(System.Convert.ToInt32(block.StartPoint.X * m_scale),
                                                     System.Convert.ToInt32(block.EndPoint.Y * m_scale));
                    default:
                        return new Point();
                }
            }

            return new Point();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the track block clicked event
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnBlockClicked(object sender, EventArgs e)
        {
            try
            {
                TrackBlockGraphic graphic = (TrackBlockGraphic)sender;

                if (m_selectedGraphic != null)
                {
                    m_selectedGraphic.StopBlinking();
                }

                m_selectedGraphic = graphic;

                blinkTimer.Start();

                if (TrackBlockClicked != null)
                {
                    TrackBlockClicked(graphic.Block);
                }
            }
            catch (InvalidCastException ex)
            {
                m_log.LogError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Event handler for the blink event
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event Arguments</param>
        private void OnBlinkTimerTick(object sender, EventArgs e)
        {
            if (m_selectedGraphic != null)
            {
                m_selectedGraphic.Blink();
            }
        }

        #endregion
    }
}
