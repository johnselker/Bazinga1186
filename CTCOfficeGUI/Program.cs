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
            //TrackLayoutSerializer serial = new TrackLayoutSerializer("RedLine.xml");
            //serial.CreateTrackLayoutFileRedLine();
            //serial.Save();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
            
        }
    }
}
