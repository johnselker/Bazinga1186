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
    /// Popup form for displaying information to the user to acknowledge
    /// </summary>
    public partial class MessageDialog : Form
    {
        #region Events

        /// <summary>
        /// Event fired when the user presses the first button
        /// </summary>
        public event EventHandler ButtonOneClicked;

        /// <summary>
        /// Event fired when the user presses the second button
        /// </summary>
        public event EventHandler ButtonTwoClicked;

        #endregion

        #region Properties

        /// <summary>
        /// Gets/sets the title bar text
        /// </summary>
        public string TitleBarText
        {
            get { return this.Text; }
            set { this.Text = value;}
        }

        /// <summary>
        /// Gets/sets the prompt message
        /// </summary>
        public string PromptText
        {
            get { return lblPrompt.Text; }
            set
            {
                lblPrompt.Text = value;
            }
        }

        /// <summary>
        /// Gets/sets the text of button 1
        /// </summary>
        public string ButtonOneText
        {
            get { return btnOne.Text; }
            set { btnOne.Text = value; }
        }

        /// <summary>
        /// Gets/sets the text of button 2
        /// </summary>
        public string ButtonTwoText
        {
            get { return btnTwo.Text; }
            set { btnTwo.Text = value; }
        }

        /// <summary>
        /// Gets/Sets the spacing between the buttons
        /// </summary>
        public int ButtonSpacing
        {
            get { return m_buttonSpacing; }
            set
            {
                if (value > 0)
                {
                    m_buttonSpacing = value;
                    AdjustButtonLocations();
                }
            }
        }
        /// <summary>
        /// Number of buttons to display
        /// </summary>
        public int ButtonCount
        {
            get { return m_numButtons; }
            set
            {
                if (value > 0 && value <= 2)
                {
                    m_numButtons = value;

                    if (m_numButtons == 1)
                    {
                        //Show one button
                        btnOne.Visible = true;
                        btnTwo.Visible = false;
                    }
                    else
                    {
                        //Show two buttons
                        btnOne.Visible = btnTwo.Visible = true;
                    }

                    AdjustButtonLocations();
                }
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MessageDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor that takes prompt text and button texts as a parameter to display two buttons
        /// </summary>
        /// <param name="prompt">Message prompt</param>
        /// <param name="buttonOneText">First button text</param>
        /// <param name="buttonTwoText">Second button text</param>
        public MessageDialog(string prompt, string buttonOneText, string buttonTwoText)
        {
            InitializeComponent();
            PromptText = prompt;
            btnOne.Text = buttonOneText;
            btnTwo.Text = buttonTwoText;
        }

        /// <summary>
        /// Constructor that takes prompt text and button texts as a parameter to display one button
        /// </summary>
        /// <param name="prompt">Message prompt</param>
        /// <param name="buttonOneText">First button text</param>
        public MessageDialog(string prompt, string buttonOneText)
        {
            InitializeComponent();
            PromptText = prompt;
            btnOne.Text = buttonOneText;
            ButtonCount = 1;
        }

        /// <summary>
        /// Constructor that takes prompt text and button texts as a parameter to display two buttons
        /// </summary>
        /// <param name="prompt">Message prompt</param>
        /// <param name="buttonOneText">First button text</param>
        /// <param name="buttonTwoText">Second button text</param>
        /// <param name="buttonOneClickHandler">Event handler for the first button text</param>
        /// <param name="buttonTwoClickHandler">Event handler for the second button text</param>
        public MessageDialog(string prompt, string buttonOneText, string buttonTwoText, 
                                            EventHandler buttonOneClickHandler, EventHandler buttonTwoClickHandler)
        {
            InitializeComponent();
            PromptText = prompt;
            btnOne.Text = buttonOneText;
            btnTwo.Text = buttonTwoText;
            ButtonOneClicked += buttonOneClickHandler;
            ButtonTwoClicked += buttonTwoClickHandler;
        }

        /// <summary>
        /// Constructor that takes prompt text and button text as a parameter to display one button
        /// </summary>
        /// <param name="prompt">Message prompt</param>
        /// <param name="buttonOneText">First button text</param>
        /// <param name="buttonOneClickHandler">Event handler for the first button text</param>
        public MessageDialog(string prompt, string buttonOneText, EventHandler buttonOneClickHandler)
        {
            InitializeComponent();
            PromptText = prompt;
            btnOne.Text = buttonOneText;
            ButtonOneClicked += buttonOneClickHandler;
            ButtonCount = 1;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Adjusts the location of the buttons
        /// </summary>
        private void AdjustButtonLocations()
        {
            if (m_numButtons == 1)
            {
                //Center the button
                btnOne.Left = (this.Width - btnOne.Width) / 2;
            }
            else
            {
                //Show the buttons in the center with the specified spacing
                btnOne.Left = this.Width / 2 - btnOne.Width - m_buttonSpacing / 2;
                btnTwo.Left = this.Width / 2 + m_buttonSpacing / 2;
            }
        }
        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the button one click event
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnButtonOneClicked(object sender, EventArgs e)
        {
            if (ButtonOneClicked != null)
            {
                ButtonOneClicked(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Event handler for the button two click event
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnButtonTwoClicked(object sender, EventArgs e)
        {
            if (ButtonTwoClicked != null)
            {
                ButtonTwoClicked(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Private Data

        private int m_numButtons = 2;
        private int m_buttonSpacing = 50;

        #endregion
    }
}
