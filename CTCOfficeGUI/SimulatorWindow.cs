using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using System.Reflection;
using Train;

namespace CTCOfficeGUI
{
    public partial class SimulatorWindow : Form
    {
        #region Public Methods

        /// <summary>
        /// Sets the selected track block, or clears it if null
        /// </summary>
        /// <param name="block">Selected track block</param>
        public void SetSelectedTrackBlock(TrackBlock block)
        {
            m_selectedBlock = block;

            if (block != null)
            {
                chkBrokenRail.Visible = chkCircuitFail.Visible = chkPowerFail.Visible = true;

                if (block.Status != null)
                {
                    //Set the failure status
                    chkBrokenRail.Checked = block.Status.BrokenRail;
                    chkCircuitFail.Checked = block.Status.CircuitFail;
                    chkPowerFail.Checked = block.Status.PowerFail;
                }
                else
                {
                    //This shouldn't happen. Uncheck the boxes
                    chkBrokenRail.Checked = chkCircuitFail.Checked = chkPowerFail.Checked = false;
                }
            }
            else
            {
                //Hide the check boxes
                chkBrokenRail.Visible = chkCircuitFail.Visible = chkPowerFail.Visible = false;
                chkBrokenRail.Checked = chkCircuitFail.Checked = chkPowerFail.Checked = false;
            }
        }

        #endregion

        #region Helper Methods

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for the simulator window
        /// </summary>
        public SimulatorWindow()
        {
            InitializeComponent();

            chkRunSimulation.Checked = m_simulator.SimulationRunning;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// User pressed the SetSimulationSpeed button
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnSetSimulationSpeedClicked(object sender, EventArgs e)
        {
            double speed;
            bool valid = false;

            if (Double.TryParse(txtSpeed.Text, out speed))
            {
                if (m_simulator.SetSimulationSpeed(speed)) //Set the simulation speed
                {
                    valid = true;
                }
            }
            
            if (!valid)
            {
                //Show invalid popup
                m_okPopup = new MessageDialog("Time is invalid", "OK", OnPopupAcknowledged);
                m_okPopup.TitleBarText = "Error";
                m_okPopup.Show();
            }
        }

        /// <summary>
        /// User clicked the broken rail checkbox
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnBrokenRailClicked(object sender, EventArgs e)
        {
            if (m_selectedBlock != null)
            {
                m_simulator.SimulateBrokenRail(m_selectedBlock, chkBrokenRail.Checked);
            }
        }

        /// <summary>
        /// User clicked the power failure checkbox
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnPowerFailureClicked(object sender, EventArgs e)
        {
            if (m_selectedBlock != null)
            {
                m_simulator.SimulatePowerFailure(m_selectedBlock, chkPowerFail.Checked);
            }
        }

        /// <summary>
        /// User clicked the circuit failure checkbox
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnCircuitFailureClicked(object sender, EventArgs e)
        {
            if (m_selectedBlock != null)
            {
                m_simulator.SimulateCircuitFailure(m_selectedBlock, chkCircuitFail.Checked);
            }
        }

        /// <summary>
        /// Run simulation checkbox was clicked
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnRunSimulationClicked(object sender, EventArgs e)
        {
            if (chkRunSimulation.Checked)
            {
                m_simulator.StartSimulation();
            }
            else
            {
                m_simulator.PauseSimulation();
            }
        }

        /// <summary>
        /// OK popup was acknowledged
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnPopupAcknowledged(object sender, EventArgs e)
        {
            if (m_okPopup != null)
            {
                m_okPopup.Close();
                m_okPopup = null;
            }
        }

        #endregion

        #region Private Data

        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private Simulator m_simulator = Simulator.GetSimulator();
        private TrackBlock m_selectedBlock = null;
        private MessageDialog m_okPopup = null;

        #endregion

    }
}
