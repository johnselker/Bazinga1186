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
using Train;

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
            Initialize();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Initializes the screen
        /// </summary>
        private void Initialize()
        {
            List<TrackBlock> blocks = new List<TrackBlock>();

            TrackBlock test = new TrackBlock("A", TrackOrientation.EastWest, 100, false, false, TrackSignalState.Green, false, 50, 3, new Point(369, 260), 0, 0);
            blocks.Add(test);

            test = new TrackBlock("B", TrackOrientation.SouthWestNorthEast, 100, false, false, TrackSignalState.Yellow, false, 50, 3, new Point(469, 260), 0, 0);
            blocks.Add(test);

            test = new TrackBlock("C", TrackOrientation.NorthSouth, 100, false, false, TrackSignalState.Red, false, 50, 3, new Point(540, 189), 0, 0);
            blocks.Add(test);

            test = new TrackBlock("D", TrackOrientation.NorthWestSouthEast, 100, false, false, TrackSignalState.SuperGreen, false, 50, 3, new Point(540, 189), 0, 0);
            blocks.Add(test);

            test = new TrackBlock("E", TrackOrientation.EastWest, 100, false, false, TrackSignalState.Green, false, 50, 3, new Point(611, 260), 0, 0);
            blocks.Add(test);

            test = new TrackBlock("F", TrackOrientation.NorthWestSouthEast, 100, false, false, TrackSignalState.Green, false, 50, 3, new Point(469, 260), 0, 0);
            blocks.Add(test);

            test = new TrackBlock("G", TrackOrientation.SouthWestNorthEast, 100, false, false, TrackSignalState.Green, false, 50, 3, new Point(540, 331), 0, 0);
            blocks.Add(test);

            test = new TrackBlock("H", TrackOrientation.NorthSouth, 100, false, false, TrackSignalState.Green, false, 50, 3, new Point(540, 431), 0, 0);
            blocks.Add(test);

            trackDisplayPanel.SetTrackLayout(blocks);
            trackDisplayPanel.Invalidate();
        }

        private void GetCommandInput(object tag)
        {
            if (tag.GetType() == typeof(TrainCommands))
            {
                switch ((TrainCommands)tag)
                {
                    case TrainCommands.SetSchedule:
                        //Launch scheduler
                        break;
                    case TrainCommands.SuggestRoute:
                        //Enter routing mode
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
                        break;
                    case TrackBlockCommands.OpenBlock:
                        //Send open block command
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
        /// <param name="text">Message text</param>
        /// <param name="title">Title Text</param>
        private void ShowOKPopup(string text)
        {
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the track block clicked event
        /// </summary>
        /// <param name="b">Track block that was clicked</param>
        private void OnTrackBlockClicked(TrackBlock b)
        {
            m_log.LogInfo("Track block was clicked");
            m_selectedTrain = null;
            m_selectedTrackBlock = b;
            infoPanel.SetTrackBlockInfo(b);
            commandPanel.ShowTrackBlockCommands(b);

            foreach (Form f in m_openPopups) //Close any open popups 
            {
                f.Close();
            }
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

            foreach (Form f in m_openPopups) //Close any open popups 
            {
                f.Close();
            }
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
                //Show invalid popup
            }
            else
            {
                foreach (Form f in m_openPopups) //Close any open popups 
                {
                    f.Close();
                }
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
                //Show invalid popup
            }
            else
            {
                foreach (Form f in m_openPopups) //Close any open popups 
                {
                    f.Close();
                }
            }
        }

        #endregion

        #region Private Data

        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());
        private TrackBlock m_selectedTrackBlock = null;
        private ITrain m_selectedTrain = null;
        private List<Form> m_openPopups = new List<Form>();
        private CTCController m_ctcController = CTCController.GetCTCController();

        #endregion
    }
}
