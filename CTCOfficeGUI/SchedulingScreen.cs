using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CTCOfficeGUI
{
    public partial class SchedulingScreen : Form
    {
        #region Public Methods

        /// <summary>
        /// Gets reference to the singleton scheduling screen
        /// </summary>
        /// <returns>Singleton instance</returns>
        public static SchedulingScreen GetSchedulingScreen()
        {
            if (m_singleton == null)
            {
                m_singleton = new SchedulingScreen();
            }

            return m_singleton;
        }

        #endregion

        #region Construtor

        /// <summary>
        /// Default constructor for the scheduling screen
        /// </summary>
        private SchedulingScreen()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Data

        private static SchedulingScreen m_singleton;

        #endregion

        /// <summary>
        /// Private class for grouping controls
        /// </summary>
        private class ScheduleGroup
        {
            #region Private Data

            private ComboBox m_stationDropdown;
            private TextBox m_arrivalTextBox;
            private Button m_editButton;
            private Button m_deleteButton;

            #endregion

            #region Accessors

            /// <summary>
            /// Gets the station drop down control
            /// </summary>
            public ComboBox StationDropdown 
            { 
                get { return m_stationDropdown;}
            }

            /// <summary>
            /// Gets the arrival text box 
            /// </summary>
            public TextBox ArrivalTextBox
            {
                get { return m_arrivalTextBox; }
            }

            /// <summary>
            /// Gets the edit button
            /// </summary>
            public Button EditButton
            {
                get { return m_editButton; }
            }

            /// <summary>
            /// Gets the delete button
            /// </summary>
            public Button DeleteButton
            {
                get { return m_deleteButton; }
            }

            #endregion

            #region Constructor

            /// <summary>
            /// Primary constructor for the schedule group class
            /// </summary>
            /// <param name="stationDropdown">Drop down selector for the station</param>
            /// <param name="arrivalTextBox">Text box for the arrival time</param>
            /// <param name="editButton">Edit button</param>
            /// <param name="deleteButton">Delete button</param>
            public ScheduleGroup(ComboBox stationDropdown, TextBox arrivalTextBox, Button editButton, Button deleteButton)
            {
                m_stationDropdown = stationDropdown;
                m_arrivalTextBox = arrivalTextBox;
                m_editButton = editButton;
                m_deleteButton = deleteButton;
            }

            #endregion
        }
    }
}
