using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using TrainLib;

namespace CTCOfficeGUI
{
    public partial class TableViewScreen : Form
    {
        public TableViewScreen()
        {
            InitializeComponent();
            InitializeTables();
            m_updateDelegate = new CTCController.UpdateDisplay(UpdateDisplay);
            m_ctcController.Subscribe(UpdateDisplay);
        }

        /// <summary>
        /// Updates the display of block and train information
        /// </summary>
        /// <param name="blocks"></param>
        /// <param name="trains"></param>
        public void UpdateDisplay(List<TrackBlock> blocks, List<ITrain> trains)
        {
            if (InvokeRequired)
            {
                Invoke(m_updateDelegate, blocks, trains);
            }
            else
            {
                if (blocks != null)
                {
                    this.SuspendLayout();

                    for (int i = 0, j = scrollbar.Value; i < m_numRows && j < blocks.Count; i++, j++)
                    {
                        //Display the block information
                        m_labelTable[i].NameLabel.Text = blocks[i].Name;
                        m_labelTable[i].AuthorityLabel.Text = blocks[i].Authority.Authority.ToString();
                        m_labelTable[i].SpeedLimitLabel.Text = blocks[i].Authority.SpeedLimitKPH.ToString() + " " + KPH;
                        m_labelTable[i].StaticLimitLabel.Text = blocks[i].StaticSpeedLimit + " " + KPH;

                        if (blocks[i].Status.TrainPresent)
                        {
                            m_labelTable[i].TrainLabel.Text = "yes";
                        }
                        else
                        {
                            m_labelTable[i].TrainLabel.Text = "no";
                        }

                        m_labelTable[i].SignalLabel.Text = blocks[i].Status.SignalState.ToString();
                        m_labelTable[i].GradeLabel.Text = blocks[i].Grade.ToString() + "%";
                        m_labelTable[i].LengthLabel.Text = blocks[i].LengthMeters.ToString() + " " + METERS;

                        if (blocks[i].HasTunnel)
                        {
                            m_labelTable[i].HasTunnelLabel.Text = "yes";
                        }
                        else
                        {
                            m_labelTable[i].HasTunnelLabel.Text = "no";
                        }

                        if (blocks[i].RailroadCrossing)
                        {
                            m_labelTable[i].RRCrossingLabel.Text = "yes";
                        }
                        else
                        {
                            m_labelTable[i].RRCrossingLabel.Text = "yes";
                        }

                        if (blocks[i].Transponder != null) //Could use block.HasTransponder property, but check for null to be on the safe side...
                        {
                            if (blocks[i].Transponder.DistanceToStation != 0)
                            {
                                m_labelTable[i].TransponderLabel.Text = blocks[i].Transponder.StationName + "in " + blocks[i].Transponder.DistanceToStation.ToString() + " block(s)";
                            }
                            else
                            {
                                m_labelTable[i].TransponderLabel.Text = "At " + blocks[i].Transponder.StationName;
                            }
                        }
                        else
                        {
                            m_labelTable[i].TransponderLabel.Text = "none";
                        }

                        m_labelTable[i].FailureLabel.Text = GetBlockFailureStateString(blocks[i]);
                        m_labelTable[i].ShowLabels();
                    }

                    //Hide the unused labels
                    for (int i = blocks.Count; i < m_numRows; i++)
                    {
                        m_labelTable[i].HideLabels();
                    }
                }

                this.ResumeLayout();
            }
        }

        #region Helper Methods

        /// <summary>
        /// Initializes the table display with labels
        /// </summary>
        private void InitializeTables()
        {
            this.SuspendLayout();

            for (int i = 1; i < m_numRows + 1; i++)
            {
                m_labelTable.Add(new TrackBlockRow());

                //Name label
                Label temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].NameLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 0, i);

                //Authority Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].AuthorityLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 1, i);

                //Speed limit Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].SpeedLimitLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 2, i);

                //Static speed limit Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].StaticLimitLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 3, i);

                //Train Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].TrainLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 4, i);

                //Signal label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].SignalLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 5, i);

                //Grade Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].GradeLabel= temp;
                tableLayoutPanel.Controls.Add(temp, 6, i);

                //Length Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].LengthLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 7, i);

                //Has Tunnel Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].HasTunnelLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 8, i);

                //Has RRCrossing Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].RRCrossingLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 9, i);

                //Transponder Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].TransponderLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 10, i);

                //Failure Label
                temp = new Label();
                temp.AutoSize = true;
                temp.Text = "Text";
                m_labelTable[i - 1].FailureLabel = temp;
                tableLayoutPanel.Controls.Add(temp, 11, i);

                m_labelTable[i - 1].HideLabels();
            }

            this.ResumeLayout();
        }

        /// <summary>
        /// Gets the failure state string for the given track block
        /// </summary>
        /// 
        /// <remarks>There are 8 different possible strings, so this chunk of code gets ugly</remarks>
        /// <param name="block">Track block</param>
        /// <returns>Failure state string</returns>
        private string GetBlockFailureStateString(TrackBlock block)
        {
            string failString = string.Empty; 
            //Check all 8 possible states
            if (!block.Status.BrokenRail && !block.Status.CircuitFail && !block.Status.PowerFail)
            {
                failString = "none";
            }
            else if (!block.Status.BrokenRail && !block.Status.CircuitFail && block.Status.PowerFail)
            {
                failString = "Power Failure";
            }
            else if (!block.Status.BrokenRail && block.Status.CircuitFail && !block.Status.PowerFail)
            {
                failString =  "Circuit Failure";
            }
            else if (!block.Status.BrokenRail && block.Status.CircuitFail && block.Status.PowerFail)
            {
                failString = "Circuit & Power Failure";
            }
            else if (block.Status.BrokenRail && !block.Status.CircuitFail && !block.Status.PowerFail)
            {
                failString = "Broken Rail";
            }
            else if (block.Status.BrokenRail && !block.Status.CircuitFail && block.Status.PowerFail)
            {
                failString = "Broken Rail & Power Failure";
            }
            else if (block.Status.BrokenRail && block.Status.CircuitFail && !block.Status.PowerFail)
            {
                failString = "Broken Rail & Circuit Failure";
            }
            else if (block.Status.BrokenRail && block.Status.CircuitFail && block.Status.PowerFail)
            {
                failString = "Broken Rail, Circuit, & Power Failure";
            }

            return failString;
        }
        #endregion

        CTCController m_ctcController = CTCController.GetCTCController();
        private const int m_numRows = 30;
        private List<TrackBlockRow> m_labelTable = new List<TrackBlockRow>();
        private const string METERS = "m";
        private const string KPH = "km/h";
        private CTCController.UpdateDisplay m_updateDelegate;

        #region Private Data Types

        /// <summary>
        /// Structure for collecting track block labels
        /// </summary>
        private class TrackBlockRow
        {
            public Label NameLabel;
            public Label AuthorityLabel;
            public Label SpeedLimitLabel;
            public Label StaticLimitLabel;
            public Label TrainLabel;
            public Label SignalLabel;
            public Label GradeLabel;
            public Label LengthLabel;
            public Label HasTunnelLabel;
            public Label RRCrossingLabel;
            public Label TransponderLabel;
            public Label FailureLabel;

            /// <summary>
            /// Shows all the labels in this group
            /// </summary>
            public void ShowLabels()
            {
                NameLabel.Show();
                AuthorityLabel.Show();
                SpeedLimitLabel.Show();
                StaticLimitLabel.Show();
                TrainLabel.Show();
                SignalLabel.Show();
                GradeLabel.Show();
                LengthLabel.Show();
                HasTunnelLabel.Show();
                RRCrossingLabel.Show();
                TransponderLabel.Show();
                FailureLabel.Show();
            }

            /// <summary>
            /// Hides all the labels in this group
            /// </summary>
            public void HideLabels()
            {
                NameLabel.Hide();
                AuthorityLabel.Hide();
                SpeedLimitLabel.Hide();
                StaticLimitLabel.Hide();
                TrainLabel.Hide();
                SignalLabel.Hide();
                GradeLabel.Hide();
                LengthLabel.Hide();
                HasTunnelLabel.Hide();
                RRCrossingLabel.Hide();
                TransponderLabel.Hide();
                FailureLabel.Hide();
            }
        }

        #endregion
    }
}
