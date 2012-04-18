using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TrackLib;

namespace CTCOfficeGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
            System.AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }

        /// <summary>
        /// Event handler for unhandled exceptions
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                CommonLib.LoggingTool logger = new CommonLib.LoggingTool(System.Reflection.MethodBase.GetCurrentMethod());
                logger.LogError("Unhandled Exception", ex);

                MessageBox.Show("Something bad happened. Check the log files for more information");
            }
            catch
            {
                //Can't do anything
            }
            finally
            {
                //Nothing else we can do at this point. Just die.
                Application.Exit();
            }
        }
    }
}
