using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CTCOfficeGUI
{
    public partial class LoginWindow : Form
    {
        #region Events

        public event OnLoginAttempt LoginAttempt;

        public event EventHandler CancelButtonClicked;

        #endregion

        #region Delegates

        public delegate void OnLoginAttempt(string username, string password);

        #endregion

        #region Constructor

        public LoginWindow()
        {
            InitializeComponent();
            txtUserName.Focus();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Login button was clicked
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnLoginClicked(object sender, EventArgs e)
        {
            if (LoginAttempt != null)
            {
                LoginAttempt(txtUserName.Text, txtPassword.Text);
            }
        }

        /// <summary>
        /// Cancel button was clicked
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnCancelClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(this, e);
            }
        }

        #endregion
    }
}
