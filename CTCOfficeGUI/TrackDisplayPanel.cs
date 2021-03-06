﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using CommonLib;
using TrainLib;

namespace CTCOfficeGUI
{
    public partial class TrackDisplayPanel : UserControl
    {
        #region Private Data

        private Dictionary<TrackBlock, TrackBlockGraphic> m_blockTable = new Dictionary<TrackBlock, TrackBlockGraphic>();
        private Dictionary<ITrain, TrainGraphic> m_trainTable = new Dictionary<ITrain, TrainGraphic>();
        private double m_scale = 1;
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private TrackBlockGraphic m_selectedTrackBlock = null;
        private TrainGraphic m_selectedTrain = null;
        private const int m_margin = 10;
        private CTCController.UpdateDisplay m_updateDelegate;
        private Point m_layoutPosition = Point.Empty;

        #endregion

        #region Events

        /// <summary>
        /// Track block clicked event
        /// </summary>
        public event OnTrackBlockClicked TrackBlockClicked;

        /// <summary>
        /// Train clicked event
        /// </summary>
        public event OnTrainClicked TrainClicked;
       
        #endregion

        #region Delegates

        /// <summary>
        /// Delegate method for handling the track block click event
        /// </summary>
        /// <param name="block"></param>
        public delegate void OnTrackBlockClicked(TrackBlock block);

        /// <summary>
        /// Delegate method for handling the train click event
        /// </summary>
        /// <param name="train"></param>
        public delegate void OnTrainClicked(ITrain train);

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor for the track display panel
        /// </summary>
        public TrackDisplayPanel()
        {
            InitializeComponent();
            m_updateDelegate = new CTCController.UpdateDisplay(UpdateDisplay);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Draws the track layout
        /// </summary>
        /// <param name="blocks">List of track blocks in the layout</param>
        public void SetTrackLayout(List<TrackBlock> blocks, Size layoutSize, Point layoutPosition)
        {
            if (blocks != null)
            {
                m_layoutPosition = layoutPosition;

                //Clear the controls
                foreach (KeyValuePair<TrackBlock, TrackBlockGraphic> graphic in m_blockTable)
                {
                    Controls.Remove(graphic.Value);
                }

                m_blockTable.Clear();

                CalculateScale(layoutSize);

                foreach (TrackBlock b in blocks)
                {
                    //Create a new trackblock graphic
                    TrackBlockGraphic graphic = new TrackBlockGraphic(b, m_scale);

                    graphic.Location = CalculateBlockPosition(b, layoutPosition, graphic.ArrowLength);

                    graphic.TrackBlockClicked += OnBlockClicked;

                    Controls.Add(graphic);
                    m_blockTable[b] = graphic;
                }
            }
        }

        /// <summary>
        /// Updates the display 
        /// </summary>
        /// <param name="blocks">List of track blocks</param>
        /// <param name="trains">List of trains</param>
        public void UpdateDisplay(List<TrackBlock> updatedBlocks, List<ITrain> trains)
        {
            if (InvokeRequired)
            {
                Invoke(m_updateDelegate, updatedBlocks, trains);
            }
            else
            {
                //Update the block layout
                if (updatedBlocks != null)
                {
                    this.SuspendLayout();

                    foreach (TrackBlock b in updatedBlocks)
                    {
                        if (m_blockTable.ContainsKey(b))
                        {
                            m_blockTable[b].Invalidate();
                        }
                    }

                    //Upate the train locations
                    foreach (ITrain train in trains)
                    {
                        if (m_trainTable.ContainsKey(train))
                        {
                            TrainGraphic graphic = m_trainTable[train];

                            graphic.Left = System.Convert.ToInt32((train.GetPosition().X - m_layoutPosition.X) * m_scale - graphic.Width / 2);
                            graphic.Top = System.Convert.ToInt32((train.GetPosition().Y - m_layoutPosition.Y) * m_scale - graphic.Height / 2);
                        }
                        else
                        {
                            //New train, add it to the list
                            TrainGraphic graphic = new TrainGraphic(train);

                            graphic.Location = new Point(System.Convert.ToInt32((train.GetPosition().X - m_layoutPosition.X) * m_scale - graphic.Width / 2),
                                                         System.Convert.ToInt32((train.GetPosition().Y - m_layoutPosition.Y) * m_scale - graphic.Height / 2));

                            graphic.TrainClicked += OnTrainGraphicClicked;
                            graphic.Disposed += OnTrainDisposed;

                            Controls.Add(graphic);
                            graphic.Visible = true;
                            graphic.BringToFront();
                            m_trainTable[train] = graphic;
                        }
                    }

                    this.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// Unselects the selected graphic, if there is one
        /// </summary>
        public void UnselectAll()
        {
            if (m_selectedTrackBlock != null)
            {
                m_selectedTrackBlock.StopBlinking();
                m_selectedTrackBlock = null;
                blinkTimer.Stop();
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Calculates the position of the graphic on the display panel
        /// </summary>
        /// <param name="block">Track block to display</param>
        /// <param name="arrowLength">Length of arrow graphics for position adjustment</param>
        /// <returns>Point of the graphic on the display panel</returns>
        private Point CalculateBlockPosition(TrackBlock block, Point layoutPosition, int arrowLength)
        {
            if (block != null)
            {
                switch (block.Orientation)
                {
                    case TrackOrientation.EastWest:
                        return new Point(System.Convert.ToInt32((block.StartPoint.X - layoutPosition.X) * m_scale),
                                                     System.Convert.ToInt32((block.StartPoint.Y - layoutPosition.Y)  * m_scale - arrowLength));
                    case TrackOrientation.NorthWestSouthEast:
                        return new Point(System.Convert.ToInt32((block.StartPoint.X - layoutPosition.X) * m_scale),
                                                     System.Convert.ToInt32((block.StartPoint.Y - layoutPosition.Y) * m_scale));
                    case TrackOrientation.SouthWestNorthEast:
                        return new Point(System.Convert.ToInt32((block.StartPoint.X - layoutPosition.X) * m_scale),
                                                     System.Convert.ToInt32((block.EndPoint.Y - layoutPosition.Y) * m_scale));
                    case TrackOrientation.NorthSouth:
                        return new Point(System.Convert.ToInt32((block.StartPoint.X - layoutPosition.X) * m_scale - arrowLength),
                                                     System.Convert.ToInt32((block.EndPoint.Y - layoutPosition.Y) * m_scale));
                    default:
                        return new Point();
                }
            }

            return new Point();
        }

        /// <summary>
        /// Calculates the scaling factor for the layout
        /// </summary>
        /// <param name="layoutSize">Size of the layout</param>
        private void CalculateScale(Size layoutSize)
        {
            //Layout is smaller than the panel, scale it up
            if ((layoutSize.Width / (double)(this.Width - m_margin)) > (layoutSize.Height / (double)(this.Height - m_margin)))
            {
                //X is the limiting dimension, scale by it
                m_scale = (this.Width - m_margin) / (double)layoutSize.Width;
            }
            else
            {
                //Y is the limiting dimension, scale by it
                m_scale = (this.Height - m_margin) / (double)layoutSize.Height;
            }
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

                if (m_selectedTrackBlock != null && m_selectedTrackBlock != graphic)
                {
                    m_selectedTrackBlock.StopBlinking();
                }
                if (m_selectedTrain != null)
                {
                    m_selectedTrain.StopBlinking();
                }

                m_selectedTrain = null;
                m_selectedTrackBlock = graphic;

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
        /// Event handler for the train graphic clicked event
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnTrainGraphicClicked(object sender, EventArgs e)
        {
            try
            {
                TrainGraphic graphic = (TrainGraphic)sender;

                if (m_selectedTrackBlock != null)
                {
                    m_selectedTrackBlock.StopBlinking();
                }
                if (m_selectedTrain != null && m_selectedTrain != graphic)
                {
                    m_selectedTrain.StopBlinking();
                }

                m_selectedTrackBlock = null;
                m_selectedTrain = graphic;

                blinkTimer.Start();

                if (TrainClicked != null)
                {
                    TrainClicked(graphic.Train);
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
            if (m_selectedTrackBlock != null)
            {
                m_selectedTrackBlock.Blink();
            }
            if (m_selectedTrain != null)
            {
                m_selectedTrain.Blink();
            }
        }

        /// <summary>
        /// A train was disposed. Remove the graphic
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnTrainDisposed(object sender, EventArgs e)
        {
            try
            {
                ITrain train = (ITrain)sender;

                if (m_trainTable.ContainsKey(train))
                {
                    //Remove the train graphic from the display
                    if (m_selectedTrain == m_trainTable[train])
                    {
                        m_selectedTrain = null;
                    }

                    m_trainTable[train].Dispose();
                    m_trainTable.Remove(train);
                }
            }
            catch (InvalidCastException ex)
            {
                m_log.LogError("Received train disposing event but could not cast to train", ex);
            }
        }

        #endregion
    }
}
