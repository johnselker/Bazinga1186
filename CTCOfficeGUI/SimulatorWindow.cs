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
        /// Gets the singleton simulator window instance
        /// </summary>
        /// <returns>Singleton instance</returns>
        public static SimulatorWindow GetSimulatorWindow()
        {
            if (m_singleton == null)
            {
                m_singleton = new SimulatorWindow();
            }

            return m_singleton;
        }

        /// <summary>
        /// Shows simulation commands for a train
        /// </summary>
        /// <param name="train"></param>
        public void ShowTrainFailCommands(ITrain train)
        {
            m_selectedTrain = train;
            Dictionary<object, string> commands = new Dictionary<object, string>();

            if (train != null)
            {
                
                commands.Add(TrainFailureCommands.EngineFailure, "Engine Failure");
                commands.Add(TrainFailureCommands.SignalPickupFailure, "Signal Pickup Failure");
                SetCommands(commands);
            }
        }

        /// <summary>
        /// Clears the buttons on the panel
        /// </summary>
        public void ClearButtons()
        {
            m_selectedTrain = null;
            m_selectedBlock = null;
            foreach (Button b in m_buttonList)
            {
                Controls.Remove(b);
            }

            m_buttonList.Clear();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Sets the list of commands to display
        /// </summary>
        /// <param name="commands">Command strings and tags for identification</param>
        private void SetCommands(Dictionary<object, string> commands)
        {
            if (commands != null)
            {
                ClearButtons();

                foreach (KeyValuePair<object, string> pair in commands)
                {
                    AddButton(pair.Key, pair.Value);
                }
            }
        }

        /// <summary>
        /// Adds a new button to the display
        /// </summary>
        /// <param name="tag">Tag used to identify the button</param>
        /// <param name="text">Text to display on the button</param>
        private void AddButton(object tag, string text)
        {
            Button b = new Button();
            b.Tag = tag;
            b.Text = text;
            b.Left = (this.Width - m_buttonWidth) / 2;
            b.Top = GetNextYValue();
            b.Height = m_buttonHeight;
            b.Width = m_buttonWidth;
            b.Click += OnButtonClicked;
            Controls.Add(b);
            b.BringToFront();
            b.Show();
            m_buttonList.Add(b);
        }

        /// <summary>
        /// Gets the Y location for the next button
        /// </summary>
        /// <returns>Y location</returns>
        private int GetNextYValue()
        {
            int yLoc = 0;
            if (m_buttonList.Count == 0)
            {
                yLoc = btnSetTime.Bottom + m_verticalSpacing; 
            }
            else
            {
                yLoc = m_buttonList[m_buttonList.Count - 1].Bottom + m_verticalSpacing;
            }
            return yLoc;
        }

        /// <summary>
        /// Processes the simulation command 
        /// </summary>
        /// <param name="tag">Tag of the button that was clicked</param>
        private void ProcessSimulationInput(object tag)
        {
            if (tag.GetType() == typeof(TrainFailureCommands))
            {
                switch ((TrainFailureCommands)tag)
                {
                    case TrainFailureCommands.EngineFailure:
                        m_simulator.SimulateEngineFailure(m_selectedTrain, true);
                        break;
                    case TrainFailureCommands.SignalPickupFailure:
                        m_simulator.SimulatePickupFailure(m_selectedTrain, true);
                        break;
                    case TrainFailureCommands.BrakeFailure:
                        m_simulator.SimulateBrakeFailure(m_selectedTrain, true);
                        break;
                    case TrainFailureCommands.ClearEngineFailure:
                        m_simulator.SimulateEngineFailure(m_selectedTrain, false);
                        break;
                    case TrainFailureCommands.ClearPickupFailure:
                        m_simulator.SimulatePickupFailure(m_selectedTrain, false);
                        break;
                    case TrainFailureCommands.ClearBrakeFailure:
                        m_simulator.SimulateBrakeFailure(m_selectedTrain, false);
                        break;
                    default: 
                        //Unreachable
                        break;

                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for the simulator window
        /// </summary>
        private SimulatorWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Simulation command button was clicked
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;

                ProcessSimulationInput(b.Tag);
            }
            catch (InvalidCastException ex)
            {
                m_log.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region Private Data

        private static SimulatorWindow m_singleton = null;
        private List<Button> m_buttonList = new List<Button>();
        private int m_verticalSpacing = 15;
        private int m_buttonWidth = 100;
        private int m_buttonHeight = 40;
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private Simulator m_simulator = Simulator.GetSimulator();
        private ITrain m_selectedTrain = null;
        private TrackBlock m_selectedBlock = null;

        #endregion
    }
}
