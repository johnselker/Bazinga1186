using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using Train;

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

            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("Authority:", block.Authority.ToString());
            info.Add("End Elevation:", block.EndElevationMeters.ToString() + " " + METERS);
            info.Add("End Point:", block.EndPoint.X.ToString() + ", " + block.EndPoint.Y.ToString());

            if (block.HasTransponder)
            {
                info.Add("Has Transponder:", "yes");
            }
            else
            {
                info.Add("Has Transponder:", "no");
            }

            if (block.HasTunnel)
            {
                info.Add("Has Tunnel:", "yes");
            }
            else
            {
                info.Add("Has Tunnel:", "no");
            }

            info.Add("Length:", block.LengthMeters.ToString() + " " + METERS);
            info.Add("Orientation:", block.Orientation.ToString());

            if (block.RailroadCrossing)
            {
                info.Add("Has RR Crossing:", "yes");
            }
            else
            {
                info.Add("Has RR Crossing:", "no");
            }

            info.Add("Signal:", block.SignalState.ToString());
            info.Add("Speed Limit:", block.SpeedLimitKph.ToString() + " " + KPH);
            info.Add("Start Elevation:", block.StartElevationMeters.ToString() + " " + METERS);
            info.Add("Start Point:", block.StartPoint.X.ToString() + ", " + block.StartPoint.Y.ToString());
            
            if (block.TrainPresent)
            {
                info.Add("Train present:", "yes");
            }
            else
            {
                info.Add("Train present:", "no");
            }

            if (block.Transponder != null) //Could use block.HasTransponder property, but check for null to be on the safe side...
            {
                info.Add("Transponder:", block.Transponder.StationName + "in " + block.Transponder.DistanceToStation.ToString() + "blocks");
            }
            else
            {
                info.Add("Transponder:", "none");
            }

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

            Dictionary<string, string> info = new Dictionary<string, string>();

            info.Add("Number of cars:", state.cars.ToString());
            info.Add("Crew members:", state.crew.ToString());
            info.Add("Direction:", state.direction.ToString());
            info.Add("Door Status:", state.doors.ToString());
            info.Add("Light Status:", state.lights.ToString());
            info.Add("Mass:", state.mass.ToString());
            info.Add("Passengers:", state.passengers.ToString());
            info.Add("Speed:", state.speed.ToString() + " " + KPH);
            info.Add("Temperature:", state.temperature.ToString());
            info.Add("Position:", state.x.ToString() + ", " + state.y.ToString());

            SetInfo(state.trainID.ToString(), info);
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

        #endregion

        #region Private Data

        private List<Label> m_fieldLabels = new List<Label>();
        private List<Label> m_valueLabels = new List<Label>();
        private const int NUM_LABELS = 15;
        private const string UNKNOWN_TEXT = "Unknown";
        private const string METERS = "m";
        private const string KPH = "km/h";

        #endregion
    }
}
