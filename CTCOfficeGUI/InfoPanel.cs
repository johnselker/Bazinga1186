using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using TrainLib;

namespace CTCOfficeGUI
{
    /// <summary>
    /// Class for displaying text information to the user
    /// </summary>
    public partial class InfoPanel : UserControl
    {
        #region Public Methods

        /// <summary>
        /// Primary constructor for the info panel
        /// </summary>
        public InfoPanel()
        {
            InitializeComponent();

            //Initialize label lists
            m_fieldLabels.Add(lblField0);
            m_fieldLabels.Add(lblField1);
            m_fieldLabels.Add(lblField2);
            m_fieldLabels.Add(lblField3);
            m_fieldLabels.Add(lblField4);
            m_fieldLabels.Add(lblField5);
            m_fieldLabels.Add(lblField6);
            m_fieldLabels.Add(lblField7);
            m_fieldLabels.Add(lblField8);
            m_fieldLabels.Add(lblField9);
            m_fieldLabels.Add(lblField10);
            m_fieldLabels.Add(lblField11);
            m_fieldLabels.Add(lblField12);
            m_fieldLabels.Add(lblField13);
            m_fieldLabels.Add(lblField14);

            m_valueLabels.Add(lblValue0);
            m_valueLabels.Add(lblValue1);
            m_valueLabels.Add(lblValue2);
            m_valueLabels.Add(lblValue3);
            m_valueLabels.Add(lblValue4);
            m_valueLabels.Add(lblValue5);
            m_valueLabels.Add(lblValue6);
            m_valueLabels.Add(lblValue7);
            m_valueLabels.Add(lblValue8);
            m_valueLabels.Add(lblValue9);
            m_valueLabels.Add(lblValue10);
            m_valueLabels.Add(lblValue11);
            m_valueLabels.Add(lblValue12);
            m_valueLabels.Add(lblValue13);
            m_valueLabels.Add(lblValue14);

            m_updateDelegate = new CTCController.UpdateDisplay(UpdateDisplay);
        }

        /// <summary>
        /// Sets the information to display
        /// </summary>
        /// <param name="information">Dictionary of field:value information</param>
        public void SetInfo(string name, Dictionary<string, string> information)
        {
            if (!String.IsNullOrEmpty(name))
            {
                lblName.Text = name;
            }
            else
            {
                lblName.Text = UNKNOWN_TEXT;
            }

            if (information != null)
            {
                List<string> fields = information.Keys.ToList<string>();
                List<string> values = information.Values.ToList<string>();

                //Set the information
                for (int i = 0; i < information.Count && i < NUM_LABELS; i++)
                {
                    if (!String.IsNullOrEmpty(fields[i]))
                    {
                        m_fieldLabels[i].Text = fields[i];
                        if (!fields[i].EndsWith(":"))
                        {
                            m_fieldLabels[i].Text += ":";
                        }
                    }
                    else //SRS requirement to display "Unknown" if information is unavailable (shouldn't happen)
                    {
                        m_fieldLabels[i].Text = UNKNOWN_TEXT;
                    }

                    if (!String.IsNullOrEmpty(values[i]))
                    {
                        m_valueLabels[i].Text = values[i];
                    }
                    else //SRS requirement to display "Unknown" if information is unavailable (shouldn't happen)
                    {
                        m_valueLabels[i].Text = UNKNOWN_TEXT;
                    }
                    m_fieldLabels[i].Visible = m_valueLabels[i].Visible = true;
                }

                //Hide the unused labels
                for (int i = information.Count; i < NUM_LABELS; i++)
                {
                    m_fieldLabels[i].Visible = m_valueLabels[i].Visible = false;
                }

                AdjustLabelPositions();
            }
        }

        /// <summary>
        /// Hides the labels
        /// </summary>
        public void ClearInfo()
        {
            //Hide all the labels
            lblName.Text = "--";

            foreach (Label l in m_fieldLabels)
            {
                l.Hide();
            }

            foreach (Label l in m_valueLabels)
            {
                l.Hide();
            }
        }

        /// <summary>
        /// Sets the text information for a track block
        /// </summary>
        /// <param name="block">Track block</param>
        public void SetTrackBlockInfo(TrackBlock block)
        {
            if (block == null) return;

            m_displayedBlock = block;
            m_displayedTrain = null;

            Dictionary<string, string> info = new Dictionary<string, string>();
            if (block.Authority != null)
            {
                info.Add("Authority:", block.Authority.Authority.ToString());
            }

            if (block.Authority != null)
            {
                info.Add("CTC Speed Limit:", block.Authority.SpeedLimitKPH.ToString() + " " + KPH);
            }

            info.Add("Static Speed Limit:", block.StaticSpeedLimit.ToString() + " " + KPH);
           
            if (block.Status.TrainPresent)
            {
                info.Add("Train present:", "yes");
            }
            else
            {
                info.Add("Train present:", "no");
            }

            info.Add("Signal:", block.Status.SignalState.ToString());

            info.Add("Start Elevation:", block.StartElevationMeters.ToString() + " " + METERS);
            
            info.Add("End Elevation", block.EndElevationMeters.ToString() + " " + METERS);

            info.Add("Grade", block.Grade.ToString() + "%");

            info.Add("Length:", block.LengthMeters.ToString() + " " + METERS);

            if (block.HasTunnel)
            {
                info.Add("Has Tunnel:", "yes");
            }
            else
            {
                info.Add("Has Tunnel:", "no");
            }

            if (block.RailroadCrossing)
            {
                info.Add("Has RR Crossing:", "yes");
            }
            else
            {
                info.Add("Has RR Crossing:", "no");
            }

            if (block.Transponder != null) //Could use block.HasTransponder property, but check for null to be on the safe side...
            {
                if (block.Transponder.DistanceToStation != 0)
                {
                    info.Add("Transponder:", block.Transponder.StationName + "in " + block.Transponder.DistanceToStation.ToString() + " block(s)");
                }
                else
                {
                    info.Add("Transponder:", "At " + block.Transponder.StationName);
                }
            }
            else
            {
                info.Add("Transponder:", "none");
            }

            KeyValuePair<string, string> failure = GetBlockFailureStateString(block);
            info.Add(failure.Key, failure.Value);

#if DEBUG
            info.Add("Start Point", block.StartPoint.X + ", " + block.StartPoint.Y);
            info.Add("End Point", block.EndPoint.X + ", " + block.EndPoint.Y);
#endif
            SetInfo(block.Name, info);
        }

        /// <summary>
        /// Sets the text information for a train
        /// </summary>
        /// <param name="train">Train</param>
        public void SetTrainInfo(ITrain train)
        {
            if (train == null) return;
            
            TrainState state = train.GetState();

            if (state == null) return;

            m_displayedBlock = null;
            m_displayedTrain = train;

            Dictionary<string, string> info = new Dictionary<string, string>();

            info.Add("Number of cars:", state.Cars.ToString());
            info.Add("Crew members:", state.Crew.ToString());
            info.Add("Direction:", state.Direction.ToString());
            info.Add("Door Status:", state.Doors.ToString());
            info.Add("Light Status:", state.Lights.ToString());
            info.Add("Mass:", state.Mass.ToString());
            info.Add("Passengers:", state.Passengers.ToString());
            info.Add("Speed:", state.Speed.ToString() + " " + KPH);
            info.Add("Temperature:", state.Temperature.ToString());
            info.Add("Position:", state.X.ToString() + ", " + state.Y.ToString());

            if (state.TrainID != null)
            {
                SetInfo(state.TrainID.ToString(), info);
            }
            else
            {
                SetInfo(UNKNOWN_TEXT, info);
            }
        }

        /// <summary>
        /// Displays info about the train yard
        /// </summary>
        /// <param name="b">Track block</param>
        public void SetTrainYardInfo(TrackBlock b)
        {
            //Just show the block name
            m_displayedTrain = null;
            m_displayedBlock = b;
            SetInfo(b.Name, null);
        }

        /// <summary>
        /// Updates the display 
        /// </summary>
        /// <param name="blocks">List of track blocks</param>
        /// <param name="trains">List of trains</param>
        public void UpdateDisplay(List<TrackBlock> blocks, List<ITrain> trains)
        {
            if (InvokeRequired)
            {
                Invoke(m_updateDelegate, blocks, trains);
            }
            else
            {
                //No reason to check if the block or train is in the list, faster to just update anyway
                if (m_displayedBlock != null)
                {
                    SetTrackBlockInfo(m_displayedBlock);
                }
                else if (m_displayedTrain != null)
                {
                    SetTrainInfo(m_displayedTrain);
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Adjusts the location of the field labels to align nicely
        /// </summary>
        private void AdjustLabelPositions()
        {
            for (int i = 0; i < NUM_LABELS; i++)
            {
                //Right align the labels
                m_fieldLabels[i].Left = m_valueLabels[i].Left - m_fieldLabels[i].Width;
            }
        }

        /// <summary>
        /// Gets the failure state string for the given track block
        /// </summary>
        /// 
        /// <remarks>There are 8 different possible strings, so this chunk of code gets ugly</remarks>
        /// <param name="block">Track block</param>
        /// <returns>Failure state string</returns>
        private KeyValuePair<string, string> GetBlockFailureStateString(TrackBlock block)
        {
            KeyValuePair<string, string> pair;

            //Check all 8 possible states
            if (!block.Status.BrokenRail && !block.Status.CircuitFail && !block.Status.PowerFail)
            {
                pair = new KeyValuePair<string, string>("Failure State:", "none");
            }
            else if (!block.Status.BrokenRail && !block.Status.CircuitFail && block.Status.PowerFail)
            {
                pair = new KeyValuePair<string, string>("Failure State:", "Power Failure");
            }
            else if (!block.Status.BrokenRail && block.Status.CircuitFail && !block.Status.PowerFail)
            {
                pair = new KeyValuePair<string, string>("Failure State:", "Circuit Failure");
            }
            else if (!block.Status.BrokenRail && block.Status.CircuitFail && block.Status.PowerFail)
            {
                pair = new KeyValuePair<string, string>("Failure State:", "Circuit & Power Failure");
            }
            else if (block.Status.BrokenRail && !block.Status.CircuitFail && !block.Status.PowerFail)
            {
                pair = new KeyValuePair<string, string>("Failure State:", "Broken Rail");
            }
            else if (block.Status.BrokenRail && !block.Status.CircuitFail && block.Status.PowerFail)
            {
                pair = new KeyValuePair<string, string>("Failure State:", "Broken Rail & Power Failure");
            }
            else if (block.Status.BrokenRail && block.Status.CircuitFail && !block.Status.PowerFail)
            {
                pair = new KeyValuePair<string, string>("Failure State:", "Broken Rail & Circuit Failure");
            }
            else if (block.Status.BrokenRail && block.Status.CircuitFail && block.Status.PowerFail)
            {
                pair = new KeyValuePair<string, string>("Failure State:", "Broken Rail, Circuit, & Power Failure");
            }
            else
            {
                //Unreachable, but needed since pair is not nullable
                pair = new KeyValuePair<string, string>();
            }

            return pair;
        }

        #endregion

        #region Private Data

        private List<Label> m_fieldLabels = new List<Label>();
        private List<Label> m_valueLabels = new List<Label>();
        private TrackBlock m_displayedBlock = null;
        private ITrain m_displayedTrain = null;
        private const int NUM_LABELS = 15;
        private const string UNKNOWN_TEXT = "Unknown";
        private const string METERS = "m";
        private const string KPH = "km/h";
        private CTCController.UpdateDisplay m_updateDelegate;

        #endregion
    }
}
