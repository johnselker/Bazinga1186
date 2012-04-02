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
    public partial class CommandPanel : UserControl
    {
        #region Events

        public event OnCommandClicked CommandClicked;

        #endregion

        #region Delegates

        public delegate void OnCommandClicked(object tag);

        #endregion

        #region Public Methods

        /// <summary>
        /// Default constructor for the command pannel
        /// </summary>
        public CommandPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the list of commands to display
        /// </summary>
        /// <param name="commands">Command strings and tags for identification</param>
        public void SetCommands(Dictionary<object, string> commands)
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
        /// Displays commands for track blocks
        /// </summary>
        /// <param name="block">Track block</param>
        public void ShowTrackBlockCommands(TrackBlock block)
        {
            Dictionary<object, string> commands = new Dictionary<object, string>();
            commands.Add(TrackBlockCommands.SuggestSpeedLimit, "Suggest Speed Limit");
            commands.Add(TrackBlockCommands.SuggestAuthority, "Suggest Speed Limit");

            if (block.IsOpen)
            {
                commands.Add(TrackBlockCommands.CloseBlock, "Close Block");
            }
            else
            {
                commands.Add(TrackBlockCommands.OpenBlock, "Open Block");
            }

            SetCommands(commands);
        }

        /// <summary>
        /// Displays commands for trains
        /// </summary>
        public void ShowTrainCommands()
        {
            Dictionary<object, string> commands = new Dictionary<object, string>();
            commands.Add(TrainCommands.SuggestRoute, "Suggest Route");
            commands.Add(TrainCommands.SetSchedule, "Set Schedule");

            SetCommands(commands);
        }

        /// <summary>
        /// Clears the buttons on the panel
        /// </summary>
        public void ClearButtons()
        {
            foreach (Button b in m_buttonList)
            {
                Controls.Remove(b);
            }

            m_buttonList.Clear();
        }

        #endregion

        #region Helper Methods

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
                yLoc = m_verticalSpacing;
            }
            else
            {
                yLoc = m_buttonList[m_buttonList.Count - 1].Bottom + m_verticalSpacing;
            }
            return yLoc;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Commad button was clicked
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;

                if (CommandClicked != null)
                {
                    CommandClicked(b.Tag);
                }
            }
            catch (InvalidCastException ex)
            {
                m_log.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Private data

        private List<Button> m_buttonList = new List<Button>();
        private int m_verticalSpacing = 15;
        private int m_buttonWidth = 100;
        private int m_buttonHeight = 40;
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());

        #endregion
    }
}
