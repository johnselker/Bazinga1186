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

namespace CTCOfficeGUI
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            Initialize();
            PlayWithButtons();
        }

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

        private void PlayWithButtons()
        {
            Dictionary<object, string> commands = new Dictionary<object, string>();
            commands.Add("Set Speed Limit", "Set Speed Limit");
            commands.Add("Set Authority", "Set Authority");
            commands.Add("Close Block", "Close Block");
            commandPanel.SetCommands(commands);
        }

        #region Event Handlers

        /// <summary>
        /// Event handler for the track block clicked event
        /// </summary>
        /// <param name="b">Track block that was clicked</param>
        private void OnTrackBlockClicked(TrackBlock b)
        {
            m_log.LogInfo("Track block was clicked");
            infoPanel.SetTrackBlockInfo(b);
        }

        /// <summary>
        /// Event handler for the command clicked event
        /// </summary>
        /// <param name="tag">Command tag</param>
        private void OnCommandClicked(object tag)
        {
            m_log.LogInfoFormat("Command was clicked: {0}", tag);
        }

        #endregion

        #region Private Data

        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());

        #endregion
    }
}
