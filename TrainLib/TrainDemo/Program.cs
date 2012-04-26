using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using TrainLib;
using CommonLib;

namespace TrainDemo
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			TrackBlock redBlock1 = new TrackBlock("red1", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
										false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red8", "red2");
			TrackBlock redBlock2 = new TrackBlock("red2", TrackOrientation.NorthWestSouthEast, new Point(85, 0), 50.0, 0, 0,
										false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red1", "red3");
			TrackBlock redBlock3 = new TrackBlock("red3", TrackOrientation.NorthSouth, new Point(121, 85), 50.0, 0, 0,
										false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red2", "red4");
			TrackBlock redBlock4 = new TrackBlock("red4", TrackOrientation.SouthWestNorthEast, new Point(85, 121), 50.0, 0, 0,
										false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red3", "red5");
			TrackBlock redBlock5 = new TrackBlock("red5", TrackOrientation.EastWest, new Point(35, 121), 50.0, 0, 0,
										false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red4", "red6");
			TrackBlock redBlock6 = new TrackBlock("red6", TrackOrientation.NorthWestSouthEast, new Point(0, 85), 50.0, 0, 0,
										false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red5", "red7");
			TrackBlock redBlock7 = new TrackBlock("red7", TrackOrientation.NorthSouth, new Point(0, 85), 50.0, 0, 0,
										false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red6", "red8");
			TrackBlock redBlock8 = new TrackBlock("red8", TrackOrientation.SouthWestNorthEast, new Point(0, 35), 50.0, 0, 0,
										false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red7", "red1");
			redBlock1.NextBlock = redBlock2;
			redBlock2.NextBlock = redBlock3;
			redBlock3.NextBlock = redBlock4;
			redBlock4.NextBlock = redBlock5;
			redBlock5.NextBlock = redBlock6;
			redBlock6.NextBlock = redBlock7;
			redBlock7.NextBlock = redBlock8;
			redBlock8.NextBlock = redBlock1;
			ITrain t = new Train("Train1", redBlock1, Direction.East);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new TrainForm(t));
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
