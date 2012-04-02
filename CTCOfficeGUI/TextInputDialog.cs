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
    /// <summary>
    /// Popup form for getting text information from the user
    /// </summary>
    public partial class TextInputDialog : Form
    {
        #region Events

        /// <summary>
        /// Event fired when the user enters a value
        /// </summary>
        public event OnValueEntered ValueEntered;

        #endregion

        #region Delegates

        /// <summary>
        /// Event handler delegate for the value entered event
        /// </summary>
        /// <param name="value">Value entered</param>
        public delegate void OnValueEntered(string value);

        #endregion

        #region Properties

        /// <summary>
        /// Gets/sets the prompt message
        /// </summary>
        public string PromptText
        {
            get { return lblPrompt.Text; }
            set
            {
                this.Text = lblPrompt.Text = value;
                lblPrompt.Left = (this.Width - lblPrompt.Width) / 2;
            }
        }

        /// <summary>
        /// Gets/sets the input text value
        /// </summary>
        public string TextValue
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextInputDialog()
        {
            InitializeComponent();
            lblPrompt.Focus();
        }

        /// <summary>
        /// Constructor that takes prompt text as a parameter
        /// </summary>
        /// <param name="prompt">Message prompt</param>
        public TextInputDialog(string prompt)
        {
            InitializeComponent();
            lblPrompt.Focus();
            PromptText = prompt;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the OK button clicked event
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnOKClicked(object sender, EventArgs e)
        {
            if (ValueEntered != null)
            {
                ValueEntered(txtInput.Text);
            }
        }

        /// <summary>
        /// Event handler for the Cancel button clicked event
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnCancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
