using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using CommonLib;
using TrainLib;

namespace CTCOfficeGUI
{
    public partial class MainScreen : Form
    {
        #region Constructor

        /// <summary>
        /// Constructor for the main screen
        /// </summary>
        public MainScreen()
        {
            InitializeComponent();

            m_ctcController.Subscribe(trackDisplayPanel.UpdateDisplay);
            m_ctcController.Subscribe(infoPanel.UpdateDisplay);

#if !DEBUG
            m_login = new LoginChecker();
            m_login.ShowLogin(OnLoginSuccessful, OnExitClicked);
#endif

            m_simulatorWindow.Show();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Initializes the screen
        /// </summary>
        /// <param name="filename">Filename of the track layout</param>
        /// <returns>bool Success</returns>
        private bool Initialize(string filename)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(filename))
            {
                List<TrackBlock> blocks = m_ctcController.LoadTrackLayout(filename);

                if (blocks != null)
                {
                    Point p = m_ctcController.GetLayoutPosition();
                    Size s = m_ctcController.GetLayoutSize();
                    trackDisplayPanel.SetTrackLayout(blocks, s, p);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the input for the user command or executes the command if possible
        /// </summary>
        /// <param name="tag">Tag of the command</param>
        private void GetCommandInput(object tag)
        {
            if (tag.GetType() == typeof(TrainCommands))
            {
                switch ((TrainCommands)tag)
                {
                    case TrainCommands.ViewSchedule:
                        //Show scheduling screen
                        break;
                    default:
                        //Unreachable
                        break;
                }
            }
            else if (tag.GetType() == typeof(TrackBlockCommands))
            {
                switch ((TrackBlockCommands)tag)
                {
                    case TrackBlockCommands.CloseBlock:
                        //Send close block command
                        if (!m_ctcController.CloseTrackBlock(m_selectedTrackBlock))
                        {
                            ShowOKPopup("Error", "Track block cannot be closed", OnPopupAcknowledged);
                        }
                        break;
                    case TrackBlockCommands.OpenBlock:
                        //Send open block command
                        if (!m_ctcController.OpenTrackBlock(m_selectedTrackBlock))
                        {
                            ShowOKPopup("Error", "Track block cannot be opened", OnPopupAcknowledged);
                        }
                        break;
                    case TrackBlockCommands.SuggestAuthority:
                        //Show popup to enter authority
                        ShowTextInputPopup("Enter Authority", string.Empty, OnAuthorityEntered);
                        break;
                    case TrackBlockCommands.SuggestSpeedLimit:
                        //Show popup to enter speed limit
                        ShowTextInputPopup("Enter Speed Limit", string.Empty, OnSpeedLimitEntered);
                        break;
                    default:
                        //Unreachable
                        break;
                }
            }
            else if (tag.GetType() == typeof(string))
            {
                if ((string) tag == Constants.SPAWNTRAIN)
                {
                    ShowTextInputPopup("Enter train name", "Train1", OnTrainNameEntered);
                }
            }
        }

        /// <summary>
        /// Displays a popup to get text input from the user
        /// </summary>
        /// <param name="prompt">Prompt message</param>
        /// <param name="initialValue">Initial value of the text input box</param>
        /// <param name="OnValueEnteredHandler">Event handler for the value entered event</param>
        private void ShowTextInputPopup(string prompt, string initialValue, TextInputDialog.OnValueEntered OnValueEnteredHandler)
        {
            TextInputDialog popup = new TextInputDialog(prompt);
            popup.TextValue = initialValue;
            popup.ValueEntered += OnValueEnteredHandler;
            m_openPopups.Add(popup);
            popup.Show();
        }

        /// <summary>
        /// Displays a popup with an OK button 
        /// </summary>
        /// 
        /// <param name="title">Title Text</param>
        /// <param name="text">Message text</param>
        /// <param name="okClickHandler">OK button click handler</param>
        private void ShowOKPopup(string title, string text, EventHandler okClickHandler)
        {
            MessageDialog popup = new MessageDialog(text, "OK", okClickHandler);
            popup.TitleBarText = title;
            m_openPopups.Add(popup);
            popup.Show();
        }

        /// <summary>
        /// Closes any open popups
        /// </summary>
        private void CloseOpenPopups()
        {
            foreach (Form f in m_openPopups) //Close any open popups 
            {
                f.Close();
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Successfully logged in
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnLoginSuccessful(object sender, EventArgs e)
        {
            m_login.CloseLogin();
        }

        /// <summary>
        /// Event handler for the track block clicked event
        /// </summary>
        /// <param name="b">Track block that was clicked</param>
        private void OnTrackBlockClicked(TrackBlock b)
        {
            m_log.LogInfo("Track block was clicked");
            m_selectedTrain = null;
            m_selectedTrackBlock = b;

            if (m_simulatorWindow == null || m_simulatorWindow.IsDisposed || m_simulatorWindow.Disposing)
            {
                m_simulatorWindow = new SimulatorWindow(); //User may have closed the simulator
                m_simulatorWindow.Show();
            }

            m_simulatorWindow.SetSelectedTrackBlock(m_selectedTrackBlock);

            if (b != null)
            {
                bool trainYard = false;
                if (b.HasTransponder)
                {
                    if (!string.IsNullOrEmpty(b.Transponder.StationName))
                    {
                        if (b.Transponder.StationName.Contains(Constants.TRAINYARD) && b.Transponder.DistanceToStation == 0)
                        {
                            //This is a train yard, handle it specially
                            infoPanel.SetTrainYardInfo(b);
                            commandPanel.ShowTrainYardCommands();
                            trainYard = true;
                        }
                    }
                }
                
                if (!trainYard)
                {
                    //Normal track block
                    infoPanel.SetTrackBlockInfo(b);
                    commandPanel.ShowTrackBlockCommands(b);
                }
            }

            CloseOpenPopups();
        }

        /// <summary>
        /// Event handler for the train clicked event
        /// </summary>
        /// <param name="train">Train that was clicked</param>
        private void OnTrainClicked(ITrain train)
        {
            m_log.LogInfo("Train was clicked");
            m_selectedTrackBlock = null;
            m_selectedTrain = train;
            infoPanel.SetTrainInfo(train);
            commandPanel.ShowTrainCommands();

            CloseOpenPopups();
        }

        /// <summary>
        /// Event handler for the command clicked event
        /// </summary>
        /// <param name="tag">Command tag</param>
        private void OnCommandClicked(object tag)
        {
            m_log.LogInfoFormat("Command was clicked: {0}", tag);
            GetCommandInput(tag);
        }

        /// <summary>
        /// User entered a speed limit
        /// </summary>
        /// <param name="value">Speed limit entered</param>
        private void OnSpeedLimitEntered(string value)
        {
            //Send speed limit and track block to CTC controller
            if (!m_ctcController.SetSpeedLimit(m_selectedTrackBlock, value))
            {
                ShowOKPopup("Error", "Speed limit cannot be set because it is invalid", OnPopupAcknowledged);
            }
            else
            {
                CloseOpenPopups();
            }
        }

        /// <summary>
        /// User entered an authority
        /// </summary>
        /// <param name="value">Authority entered</param>
        private void OnAuthorityEntered(string value)
        {
            //Send authority and track block to CTC controller
            if (!m_ctcController.SetAuthority(m_selectedTrackBlock, value))
            {
                ShowOKPopup("Error", "Authority cannot be set because it is invalid", OnPopupAcknowledged);
            }
            else
            {
                CloseOpenPopups();
            }
        }

        /// <summary>
        /// User acknowledged a message popup
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnPopupAcknowledged(object sender, EventArgs e)
        {
            CloseOpenPopups();
        }

        /// <summary>
        /// User selected the load track layout menu item
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnLoadTrackLayoutClicked(object sender, EventArgs e)
        {
            //Show file dialog to select the track layout
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.RestoreDirectory = true;
            dialog.Multiselect = false;
            dialog.Title = "Select Track Layout";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                if (Initialize(filename))
                {
                    dialog.Dispose();
                    dialog = null;
                }
                else
                {
                    ShowOKPopup("Error", "Could not load track layout", OnPopupAcknowledged);
                }
            }
        }

        /// <summary>
        /// User selected the exit menu item
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnExitClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// User selected the table view menu item
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnTableViewClicked(object sender, EventArgs e)
        {
            if (m_tableViewWindow == null || m_tableViewWindow.IsDisposed || m_tableViewWindow.Disposing)
            {
                m_tableViewWindow = new TableViewScreen();
            }

            m_tableViewWindow.WindowState = FormWindowState.Normal;
            m_tableViewWindow.Show();
        }

        /// <summary>
        /// User selected the view simulator window menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewSimulatorWindowClicked(object sender, EventArgs e)
        {
            if (m_simulatorWindow == null || m_simulatorWindow.IsDisposed || m_simulatorWindow.Disposing)
            {
                m_simulatorWindow = new SimulatorWindow();
                m_simulatorWindow.SetSelectedTrackBlock(m_selectedTrackBlock);
            }

            m_simulatorWindow.WindowState = FormWindowState.Normal;
            m_simulatorWindow.Show();
        }

        /// <summary>
        /// Train name was entered for a new train
        /// </summary>
        /// <param name="value">Train name</param>
        private void OnTrainNameEntered(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Simulator.GetSimulator().SpawnNewTrain(m_selectedTrackBlock, value);
            }
            else
            {
                ShowOKPopup("Error", "Train name cannot be empty", OnPopupAcknowledged);
            }
        }

        #endregion

        #region Private Data

        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private TrackBlock m_selectedTrackBlock = null;
        private ITrain m_selectedTrain = null;
        private List<Form> m_openPopups = new List<Form>();
        private CTCController m_ctcController = CTCController.GetCTCController();
        private SimulatorWindow m_simulatorWindow = new SimulatorWindow();
        private TableViewScreen m_tableViewWindow = new TableViewScreen();
        private LoginChecker m_login;

        #endregion
    }
}
