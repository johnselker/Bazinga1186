using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCOfficeGUI
{
    public class LoginChecker
    {
        #region Login Parameters

        private const string USERNAME = "admin";
        private const string PASSWORD = "Bazinga!";

        #endregion

        #region Events

        public event EventHandler LoginSuccessful;
        public event EventHandler LoginCancelled;

        #endregion

        #region Public methods

        /// <summary>
        /// Displays a the login window
        /// </summary>
        public void ShowLogin(EventHandler successHandler, EventHandler cancelHandler)
        {
            LoginSuccessful += successHandler;
            LoginCancelled += cancelHandler;
            m_window = new LoginWindow();
            m_window.LoginAttempt += OnLoginAttempt;
            m_window.CancelButtonClicked += OnLoginCancel;
            m_window.ShowDialog();
        }

        /// <summary>
        /// Closes the login window
        /// </summary>
        public void CloseLogin()
        {
            if (m_window != null)
            {
                m_window.Close();
                m_window = null;
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Displays a popup with an OK button 
        /// </summary>
        /// 
        /// <param name="title">Title Text</param>
        /// <param name="text">Message text</param>
        /// <param name="okClickHandler">OK button click handler</param>
        private void ShowOKPopup(string title, string text)
        {
            m_okPopup = new MessageDialog(text, "OK", OnPopupAcknowledged);
            m_okPopup.TitleBarText = title;
            m_okPopup.ShowDialog();
        }

        /// <summary>
        /// User attempted to login
        /// </summary>
        /// <param name="username">Entered username</param>
        /// <param name="password">Entered password</param>
        private void OnLoginAttempt(string username, string password)
        {
            if (username == USERNAME && password == PASSWORD)
            {
                //Send the successful login event
                if (LoginSuccessful != null)
                {
                    LoginSuccessful(this, EventArgs.Empty);
                }
            }
            else
            {
                ShowOKPopup("ERROR", "Authentication failed");
            }
        }

        /// <summary>
        /// User cancelled login
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnLoginCancel(object sender, EventArgs e)
        {
            //Send the login cancel event
            if (LoginCancelled != null)
            {
                LoginCancelled(this, e);
            }
        }

        /// <summary>
        /// User clicked OK on the error popup
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

        private LoginWindow m_window;
        private MessageDialog m_okPopup;

        #endregion
    }
}
