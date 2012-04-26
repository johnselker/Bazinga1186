using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using CommonLib;

namespace TrackLib
{
    // CLASS: TrackLayoutSerializer
    ///--------------------------------------------------------------------------------------
    /// <summary>
    /// Class responsible for serialization/deserialization of the track layout 
    /// </summary>
    ///--------------------------------------------------------------------------------------
    [Serializable]
    [XmlRoot(ElementName = "TrackLayout")]
    public class TrackLayoutSerializer
    {
        #region Properties
        /// <summary>
        /// Timestamp when disk file is updated most recently.
        /// </summary>
        public DateTime LastUpdated
        {
            get { return m_serializeTimeStamp; }
            set { m_serializeTimeStamp = value; }
        }

        /// <summary>
        /// List of track blocks to be serialized/deserialized to/from disks.
        /// </summary>
        public List<TrackBlock> BlockList
        {
            get { return m_blockList; }
            set
            {
                m_blockList = value;
            }
        }
        /// <summary>
        /// List of Switches
        /// </summary>
        public List<TrackSwitch> SwitchList
        {
            get { return m_switchList; }
            set
            {
                m_switchList = value;
            }
        }
        #endregion

        #region Public Methods

        // METHOD: TrackLayoutSerializer
        ///--------------------------------------------------------------------------------------
        /// <summary>
        /// Default Constructor needed for deserialization
        /// </summary>
        ///--------------------------------------------------------------------------------------
        private TrackLayoutSerializer() { }

        // METHOD: TrackLayoutSerializer
        ///--------------------------------------------------------------------------------------
        /// <summary>
        /// Primary constructor that takes disk filename as parameter
        /// </summary>
        ///--------------------------------------------------------------------------------------
        public TrackLayoutSerializer(string fileName)
        {
            m_fileName = fileName;
        }

        // METHOD: Save()
        ///--------------------------------------------------------------------------------------
        /// <summary>
        /// Method responsible for serializing the track layout into disk file.
        /// </summary>
        ///--------------------------------------------------------------------------------------
        public void Save()
        {
            if (m_fileName == string.Empty || m_blockList == null)
            {
                throw new InvalidDataException();
            }

            LastUpdated = DateTime.Now;

            //Determine the file path
            string file = Path.Combine(Environment.CurrentDirectory, m_filePath);
            file = Path.Combine(file, m_fileName);

            if (!Directory.Exists(m_filePath))
            {
                Directory.CreateDirectory(m_filePath);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(TrackLayoutSerializer), new Type[] { typeof(TrackLayoutSerializer) });

            TextWriter textWriter = null;

            try
            {
                //Write the data
                textWriter = new StreamWriter(file, false);
                serializer.Serialize(textWriter, this);
            }
            catch (Exception ex)
            {
                //m_log.LogError("Serialization failed", ex);
                throw ex;
            }
            finally
            {
                if (textWriter != null)
                {
                    textWriter.Close();
                }
            }
        }

        // METHOD: Restore()
        ///--------------------------------------------------------------------------------------
        /// <summary>
        /// Method responsible for deserializing the track model from the disk file.
        /// </summary>
        ///--------------------------------------------------------------------------------------
        public void Restore()
        {
            //m_log.LogInfo("Restoring track model...");
            if (m_fileName == string.Empty)
            {
                throw new InvalidDataException();
            }

            // TODO : Validating the XML File before its processed.
            XmlSerializer serializer = new XmlSerializer(typeof(TrackLayoutSerializer), new Type[] { typeof(TrackLayoutSerializer) });

            //Determine the file path
            string file;
#if DEBUG
            file = Path.Combine(Environment.CurrentDirectory, m_filePath);
            file = Path.Combine(file, m_fileName);
#else
            file = Path.Combine(Environment.CurrentDirectory, m_filePath);
            file = Path.Combine(file, m_fileName);
#endif

            if (!File.Exists(file))
            {
                //m_log.LogError("file does not exist ; file path: " + file);
                throw new FileNotFoundException();
            }

            TrackLayoutSerializer restoreObject;

            FileStream textReader = null;
            try
            {
                //Read the data
                File.SetAttributes(file, FileAttributes.Normal);
                textReader = new FileStream(file, FileMode.Open);
                restoreObject = (TrackLayoutSerializer)serializer.Deserialize(textReader);
                LastUpdated = restoreObject.LastUpdated;

                m_blockList = restoreObject.BlockList;

                m_log.LogInfo("Track layout restore complete");
            }
            catch (Exception ex)
            {
                //throw the exception
                m_log.LogError("Deserialization Failed", ex);
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
        }
        #endregion

        #region Helper Methods

        // METHOD: CreateTrackLayoutFileRedLine
        ///------------------------------------------------------------------------
        /// <summary>
        /// Creates a file with a track layout fior the red line
        /// </summary>
        ///------------------------------------------------------------------------
        public void CreateTrackLayoutFileRedLine()
        {
            // Region1 Sections A-C
            // Controlled by redController1
            // Block Names correspond to number in given list
            //Region redRegion1 = new Region("redRegion1");
            List<TrackBlock> redTrack = new List<TrackBlock>();
            List<TrackSwitch> switchList = new List<TrackSwitch>();
            TrackBlock redBlock1 = new TrackBlock("red1", TrackOrientation.SouthWestNorthEast, new Point(0,0), 50.0, 0.25, 0.5,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", null, "red2");
            
            TrackBlock redBlock2 = new TrackBlock("red2", TrackOrientation.SouthWestNorthEast, redBlock1.EndPoint, 50.0, 0.75, 1,
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red1", "red3");
            redBlock1.StartPoint = new Point(-25, 24);
            redTrack.Add(redBlock1);
            redTrack.Add(redBlock2);
            TrackBlock redBlock3 = new TrackBlock("red3", TrackOrientation.SouthWestNorthEast, redBlock2.EndPoint, 50.0, 1.50, 1.5,
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red2", "red4");
            redTrack.Add(redBlock3);
            TrackBlock redBlock4 = new TrackBlock("red4", TrackOrientation.SouthWestNorthEast, redBlock3.EndPoint, 50.0, 2.5, 2,
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red3", "red5");
            redTrack.Add(redBlock4);
            TrackBlock redBlock5 = new TrackBlock("red5", TrackOrientation.SouthWestNorthEast, redBlock4.EndPoint, 50, 3.25, 1.5,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red4", "red6");
            redTrack.Add(redBlock5);
            TrackBlock redBlock6 = new TrackBlock("red6", TrackOrientation.SouthWestNorthEast, redBlock5.EndPoint, 50, 3.75, 1,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red5", "red7");
            redTrack.Add(redBlock6);
            TrackBlock redBlock7 = new TrackBlock("red7", TrackOrientation.EastWest, redBlock6.EndPoint, 75, 4.13, 0.5,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red6", "red8");
            redBlock7.Transponder = new Transponder("Shadyside", 1);

            redTrack.Add(redBlock7);
            TrackBlock redBlock8 = new TrackBlock("red8", TrackOrientation.EastWest, redBlock7.EndPoint, 75, 4.13, 0,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red7", "red9");
            redBlock8.Transponder = new Transponder("Shadyside", 0);

            redTrack.Add(redBlock8);
            TrackBlock redBlock9 = new TrackBlock("red9", TrackOrientation.NorthWestSouthEast, redBlock8.EndPoint, 75, 4.13, 0,
                                        false, false, 40, TrackAllowedDirection.Both, "Yard Switch", "redController1", "redController2", "red8", "red10");
            TrackBlock redBlock10 = new TrackBlock("red10", TrackOrientation.NorthWestSouthEast, redBlock9.EndPoint, 75, 4.13, 0,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red8", "red10");
            TrackBlock YARD = new TrackBlock(Constants.REDYARD, TrackOrientation.NorthWestSouthEast, redBlock10.EndPoint, 150, 0, 0, false, false, 0, TrackAllowedDirection.Both, "YardSwitch", "redController1", "redController2", "red9", null);
            YARD.Transponder = new Transponder(Constants.REDYARD, 0);
            TrackBlock redBlock11 = new TrackBlock("red11", TrackOrientation.NorthSouth, new Point(redBlock10.EndPoint.X, redBlock10.EndPoint.Y + 75), 75, 3.75, -0.5,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red9", "red11");
 
            redTrack.Add(redBlock9);
            redTrack.Add(YARD);
            redTrack.Add(redBlock10);
            
            redTrack.Add(redBlock11);
            TrackBlock redBlock12 = new TrackBlock("red12", TrackOrientation.SouthWestNorthEast, new Point(redBlock11.StartPoint.X - Convert.ToInt32(Math.Sqrt((redBlock11.LengthMeters * redBlock11.LengthMeters) / 2)), redBlock11.StartPoint.Y + Convert.ToInt32(Math.Sqrt((redBlock11.LengthMeters * redBlock11.LengthMeters) / 2))), 75, 3.38, -0.5,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red11", "red13");
            redTrack.Add(redBlock12);
            TrackBlock redBlock13 = new TrackBlock("red13", TrackOrientation.EastWest, new Point(Convert.ToInt32(redBlock12.StartPoint.X - 68.4), redBlock12.StartPoint.Y), 68.4, 2.69, -1,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red12", "red14");
            redTrack.Add(redBlock12);
            redTrack.Add(redBlock13);
            TrackBlock redBlock14 = new TrackBlock("red14", TrackOrientation.EastWest, new Point(redBlock13.StartPoint.X - 60, redBlock13.StartPoint.Y), 60, 2.09, -1, false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red13", "red15");
            redTrack.Add(redBlock14);
            TrackBlock redBlock15 = new TrackBlock("red15", TrackOrientation.EastWest, new Point(redBlock14.StartPoint.X - 60, redBlock14.StartPoint.Y), 60, 1.49, -1, false, false, 40, TrackAllowedDirection.Both, null, "redController2", "redController1", "red14", "red16");

            redBlock15.Transponder = new Transponder("Herron Ave", 1);
            // NEED SWITCH
            redTrack.Add(redBlock15);
            TrackBlock redBlock16 = new TrackBlock("red16", TrackOrientation.EastWest, new Point(redBlock15.StartPoint.X - 50, redBlock15.StartPoint.Y), 50, 1.24, -0.5, false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red15", "red17"); //16

            redBlock16.Transponder = new Transponder("Herron Ave", 0);
            redTrack.Add(redBlock16);
            TrackBlock redBlock17 = new TrackBlock("red17", TrackOrientation.EastWest, new Point(redBlock16.StartPoint.X - 200, redBlock16.StartPoint.Y), 200, 0.24, -0.5, false, false, 55, TrackAllowedDirection.Both, null, "redController1", "redController2", "red16", "red18");
            redTrack.Add(redBlock17);
            TrackBlock redBlock18 = new TrackBlock("red18", TrackOrientation.EastWest, new Point(redBlock17.StartPoint.X - 400, redBlock17.StartPoint.Y), 400, 0.0, -0.06025, false, false, 70, TrackAllowedDirection.Both, null, "redController2", "redController1", "red17", "red19");
            
            redTrack.Add(redBlock18);
            TrackBlock redBlock19 = new TrackBlock("red19", TrackOrientation.EastWest, new Point(redBlock18.StartPoint.X - 400, redBlock18.StartPoint.Y), 400, 0.0, 0, false, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController2", "red18", "red20");
            redTrack.Add(redBlock19);
            TrackBlock redBlock20 = new TrackBlock("red20", TrackOrientation.EastWest, new Point(redBlock19.StartPoint.X - 200, redBlock17.StartPoint.Y), 200, 0.0, 0, false, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController2", "red19", "red21");

            redBlock20.Transponder = new Transponder("Swissville", 1);
            redTrack.Add(redBlock20);
            TrackBlock redBlock21 = new TrackBlock("red21", TrackOrientation.SouthWestNorthEast, new Point(redBlock20.StartPoint.X - Convert.ToInt32(Math.Sqrt((100 * 100) / 2)) + 1, redBlock20.StartPoint.Y + Convert.ToInt32(Math.Sqrt((100 * 100) / 2)) - 1), 100, 0, 0,
                                        false, false, 55, TrackAllowedDirection.Both, null, "redController3", "redController2", "red20", "red22");
            redTrack.Add(redBlock21);
            TrackBlock redBlock22 = new TrackBlock("red22", TrackOrientation.SouthWestNorthEast, new Point(redBlock21.StartPoint.X - Convert.ToInt32(Math.Sqrt((100 * 100) / 2)) + 1, redBlock21.StartPoint.Y + Convert.ToInt32(Math.Sqrt((100 * 100) / 2)) - 1), 100, 0, 0,
                                       false, false, 55, TrackAllowedDirection.Both, null, "redController3", "redController2", "red21", "red23");
            redTrack.Add(redBlock22);
            TrackBlock redBlock23 = new TrackBlock("red23", TrackOrientation.SouthWestNorthEast, new Point(redBlock22.StartPoint.X - Convert.ToInt32(Math.Sqrt((100 * 100) / 2)) + 1, redBlock22.StartPoint.Y + Convert.ToInt32(Math.Sqrt((100 * 100) / 2)) - 1), 100, 0, 0,
                                       false, false, 55, TrackAllowedDirection.Both, null, "redController3", "redController2", "red22", "red24");
            redTrack.Add(redBlock23);
            TrackBlock redBlock24 = new TrackBlock("red24", TrackOrientation.NorthSouth, new Point(redBlock23.StartPoint.X, redBlock23.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController2", "redBlock23", "redBlock25");

            redBlock24.Transponder = new Transponder("Penn", 1);
            redTrack.Add(redBlock24);
            TrackBlock redBlock25 = new TrackBlock("red25", TrackOrientation.NorthSouth, new Point(redBlock24.StartPoint.X, redBlock24.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController2", "redBlock24", "redBlock26");

            redBlock25.Transponder = new Transponder("Penn", 0);
            redTrack.Add(redBlock25);
            // 27 should have switch!
            TrackBlock redBlock26 = new TrackBlock("red26", TrackOrientation.NorthSouth, new Point(redBlock25.StartPoint.X, redBlock25.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock25", "redBlock27"); //26
            redTrack.Add(redBlock26);
            TrackBlock redBlock27 = new TrackBlock("red27", TrackOrientation.NorthSouth, new Point(redBlock26.StartPoint.X, redBlock26.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock26", "redBlock28");//27
            redTrack.Add(redBlock27);
            TrackBlock redBlock28 = new TrackBlock("red28", TrackOrientation.NorthSouth, new Point(redBlock27.StartPoint.X, redBlock27.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock27", "redBlock29");
            TrackBlock redBlock29 = new TrackBlock("red29", TrackOrientation.NorthSouth, new Point(redBlock28.StartPoint.X, redBlock28.StartPoint.Y + 60), 60, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock28", "redBlock30");
            
            redTrack.Add(redBlock28);
            redTrack.Add(redBlock29);
            TrackBlock redBlock30 = new TrackBlock("red30", TrackOrientation.NorthSouth, new Point(redBlock29.StartPoint.X, redBlock29.StartPoint.Y + 60), 60, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock29", "redBlock31");
            redTrack.Add(redBlock30);
            TrackBlock redBlock31 = new TrackBlock("red31", TrackOrientation.NorthSouth, new Point(redBlock30.StartPoint.X, redBlock30.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock30", "redBlock32");
            redTrack.Add(redBlock31);
            TrackBlock redBlock32 = new TrackBlock("red32", TrackOrientation.NorthSouth, new Point(redBlock31.StartPoint.X, redBlock31.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController4", "redController3", "redBlock31", "redBlock33");//32
            redTrack.Add(redBlock32);
            TrackBlock redBlock33 = new TrackBlock("red33", TrackOrientation.NorthSouth, new Point(redBlock32.StartPoint.X, redBlock32.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController4", "redController5", "redBlock32", "redBlock34");
            
            redTrack.Add(redBlock33);
            TrackBlock redBlock34 = new TrackBlock("red34", TrackOrientation.NorthSouth, new Point(redBlock33.StartPoint.X, redBlock33.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController4", "redController5", "redBlock33", "redBlock35");

            redBlock34.Transponder = new Transponder("Steel Plaza", 1);
            redTrack.Add(redBlock34);
            TrackBlock redBlock35 = new TrackBlock("red35", TrackOrientation.NorthSouth, new Point(redBlock34.StartPoint.X, redBlock34.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController4", "redController5", "redBlock34", "redBlock36");

            redBlock35.Transponder = new Transponder("Steel Plaza", 0);
            redTrack.Add(redBlock35);
            TrackBlock redBlock36 = new TrackBlock("red36", TrackOrientation.NorthSouth, new Point(redBlock35.StartPoint.X, redBlock35.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController4", "redController5", "redBlock35", "redBlock37");
            redTrack.Add(redBlock36);
            TrackBlock redBlock37 = new TrackBlock("red37", TrackOrientation.NorthSouth, new Point(redBlock36.StartPoint.X, redBlock36.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController4", "redController5", "redBlock36", "redBlock38");
            redTrack.Add(redBlock37);
            TrackBlock redBlock38 = new TrackBlock("red38", TrackOrientation.NorthSouth, new Point(redBlock37.StartPoint.X, redBlock37.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController5", "redController4", "redBlock37", "redBlock39");
            redTrack.Add(redBlock38);
            TrackBlock redBlock39 = new TrackBlock("red39", TrackOrientation.NorthSouth, new Point(redBlock38.StartPoint.X, redBlock38.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController5", "redController6", "redBlock38", "redBlock40");
            
            redTrack.Add(redBlock39);
            TrackBlock redBlock40 = new TrackBlock("red40", TrackOrientation.NorthSouth, new Point(redBlock39.StartPoint.X, redBlock39.StartPoint.Y + 60), 60, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController5", "redController6", "redBlock39", "redBlock41");
            redTrack.Add(redBlock40);
            TrackBlock redBlock41 = new TrackBlock("red41", TrackOrientation.NorthSouth, new Point(redBlock40.StartPoint.X, redBlock40.StartPoint.Y + 60), 60, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController5", "redController6", "redBlock40", "redBlock42");
            redTrack.Add(redBlock41);
            TrackBlock redBlock42 = new TrackBlock("red42", TrackOrientation.NorthSouth, new Point(redBlock41.StartPoint.X, redBlock41.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController5", "redController6", "redBlock41", "redBlock43");
            redTrack.Add(redBlock42);
            TrackBlock redBlock43 = new TrackBlock("red43", TrackOrientation.NorthSouth, new Point(redBlock42.StartPoint.X, redBlock42.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController6", "redController5", "redBlock42", "redBlock44");

            redBlock43.Transponder = new Transponder("First Ave", 1);
            
            redTrack.Add(redBlock43);
            TrackBlock redBlock44 = new TrackBlock("red44", TrackOrientation.NorthSouth, new Point(redBlock43.StartPoint.X, redBlock43.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController6", "redController7", "redBlock43", "redBlock45");

            redBlock44.Transponder = new Transponder("First Ave", 0);
            redTrack.Add(redBlock44);
            TrackBlock redBlock45 = new TrackBlock("red45", TrackOrientation.NorthSouth, new Point(redBlock44.StartPoint.X, redBlock44.StartPoint.Y + 50), 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController6", "redController7", "redBlock44", "redBlock46");
            redTrack.Add(redBlock45);
            TrackBlock redBlock46 = new TrackBlock("red46", TrackOrientation.SouthWestNorthEast, new Point(redBlock45.StartPoint.X - Convert.ToInt32(Math.Sqrt((75 * 75) / 2)), redBlock45.StartPoint.Y + Convert.ToInt32(Math.Sqrt((75 * 75) / 2))), 75, 0, 0, true, false, 70, TrackAllowedDirection.Both, null, "redController6", "redController7", "redBlock45", "redBlock47");
            redTrack.Add(redBlock46);
            TrackBlock redBlock47 = new TrackBlock("red47", TrackOrientation.SouthWestNorthEast, new Point(redBlock46.StartPoint.X - Convert.ToInt32(Math.Sqrt((75 * 75) / 2)), redBlock46.StartPoint.Y + Convert.ToInt32(Math.Sqrt((75 * 75) / 2))), 75, 0, 0, false, true, 70, TrackAllowedDirection.Both, null, "redController6", "redController7", "redBlock46", "redBlock48");
            redTrack.Add(redBlock47);
            TrackBlock redBlock48 = new TrackBlock("red48", TrackOrientation.EastWest, new Point(redBlock47.StartPoint.X - 75, redBlock47.StartPoint.Y), 75, 0, 0, false, false, 70, TrackAllowedDirection.Both, null, "redController6", "redController7", "redBlock47", "redBlock49");

            redBlock48.Transponder = new Transponder("Station Square", 1);
            redTrack.Add(redBlock48);
            TrackBlock redBlock49 = new TrackBlock("red49", TrackOrientation.EastWest, new Point(redBlock48.StartPoint.X - 50, redBlock48.StartPoint.Y), 50, 0, 0, false, false, 60, TrackAllowedDirection.Both, null, "redController6", "redController7", "redBlock48", "redBlock50");

            redBlock49.Transponder = new Transponder("Station Square", 0);
            redTrack.Add(redBlock49);
            TrackBlock redBlock50 = new TrackBlock("red50", TrackOrientation.EastWest, new Point(redBlock49.StartPoint.X - 50, redBlock49.StartPoint.Y), 50, 0, 0, false, false, 60, TrackAllowedDirection.Both, null, "redController6", "redController7", "redBlock49", "redBlock51");
            redTrack.Add(redBlock50);
            TrackBlock redBlock51 = new TrackBlock("red51", TrackOrientation.EastWest, new Point(redBlock50.StartPoint.X - 50, redBlock50.StartPoint.Y), 50, 0, 0, false, false, 55, TrackAllowedDirection.Both, null, "redController6", "redController7", "redBlock50", "redBlock52");
            
            redTrack.Add(redBlock51);
            TrackBlock redBlock52 = new TrackBlock("red52", TrackOrientation.EastWest, new Point(redBlock51.StartPoint.X - 43, redBlock51.StartPoint.Y), 43.2, 0, 0, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock51", "redBlock53");
            redTrack.Add(redBlock52);
            TrackBlock redBlock53 = new TrackBlock("red53", TrackOrientation.EastWest, new Point(redBlock52.StartPoint.X - 50, redBlock52.StartPoint.Y), 50, 0, 0, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock52", "redBlock54");
            redTrack.Add(redBlock53);
            TrackBlock redBlock54 = new TrackBlock("red54", TrackOrientation.NorthWestSouthEast, new Point(redBlock53.StartPoint.X - Convert.ToInt32(Math.Sqrt((50 * 50) / 2)) + 1, redBlock53.StartPoint.Y - Convert.ToInt32(Math.Sqrt((50 * 50) / 2)) + 1), 50, 0, 0, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock53", "redBlock55");
            redTrack.Add(redBlock54);
            TrackBlock redBlock55 = new TrackBlock("red55", TrackOrientation.NorthWestSouthEast, new Point(redBlock54.StartPoint.X - Convert.ToInt32(Math.Sqrt((75 * 75) / 2)), redBlock54.StartPoint.Y - Convert.ToInt32(Math.Sqrt((75 * 75) / 2))), 75, 0.38, 0.5, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock54", "redBlock56");
            redTrack.Add(redBlock55);
            TrackBlock redBlock56 = new TrackBlock("red56", TrackOrientation.NorthWestSouthEast, new Point(redBlock55.StartPoint.X - Convert.ToInt32(Math.Sqrt((75 * 75) / 2)), redBlock55.StartPoint.Y - Convert.ToInt32(Math.Sqrt((75 * 75) / 2))), 75, 0.75, 0.5, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock55", "redBlock57");
            redTrack.Add(redBlock56);
            TrackBlock redBlock57 = new TrackBlock("red57", TrackOrientation.NorthSouth, new Point(redBlock56.StartPoint.X, redBlock56.StartPoint.Y), 75, 1.13, 0.5, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock56", "redBlock58");
            redTrack.Add(redBlock57);
            TrackBlock redBlock58 = new TrackBlock("red58", TrackOrientation.NorthSouth, new Point(redBlock57.StartPoint.X, redBlock57.StartPoint.Y - 75), 75, 1.88, 1, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock57", "redBlock59");
            redTrack.Add(redBlock58);
            TrackBlock redBlock59 = new TrackBlock("red59", TrackOrientation.SouthWestNorthEast, redBlock58.EndPoint, 75, 2.25, 0.5, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock58", "redBlock60");
            
            redBlock59.Transponder = new Transponder("South Hills Junction", 1);
            redTrack.Add(redBlock59);
            TrackBlock redBlock60 = new TrackBlock("red60", TrackOrientation.EastWest, redBlock59.EndPoint, 75, 2.25, 0.5, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock59", "redBlock61");
            
            redBlock60.Transponder = new Transponder("South Hills Junction", 0);
            TrackBlock redBlock61 = new TrackBlock("red61", TrackOrientation.NorthWestSouthEast, redBlock60.EndPoint, 75, 1.88, -0.5, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock60", "redBlock62");
            redTrack.Add(redBlock60);
            redTrack.Add(redBlock61);
            TrackBlock redBlock62 = new TrackBlock("red62", TrackOrientation.NorthSouth, new Point(redBlock61.EndPoint.X, redBlock61.EndPoint.Y+75 ), 75, 1.13, -1, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock61", "redBlock63");
            redTrack.Add(redBlock62);
            TrackBlock redBlock63 = new TrackBlock("red63", TrackOrientation.NorthSouth, new Point(redBlock62.EndPoint.X, redBlock62.EndPoint.Y+150 ), 75, 0.38, -1, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock61", "redBlock63");
            redTrack.Add(redBlock63);
            TrackBlock redBlock64 = new TrackBlock("red64", TrackOrientation.NorthSouth, new Point(redBlock63.EndPoint.X, redBlock63.EndPoint.Y+150), 75, 0.00, -0.5, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock62", "redBlock64");
            redTrack.Add(redBlock64);
            TrackBlock redBlock65 = new TrackBlock("red65", TrackOrientation.NorthWestSouthEast, new Point(redBlock64.StartPoint.X, redBlock64.StartPoint.Y), 75, 0, 0, false, false, 55, TrackAllowedDirection.Both, null, "redController7", null, "redBlock62", "redBlock64");
            redTrack.Add(redBlock65);

            // Start Branch Sections
           
            TrackBlock redBlock67 = new TrackBlock("red67", TrackOrientation.NorthWestSouthEast, new Point(redBlock43.StartPoint.X - Convert.ToInt32(Math.Sqrt((50 * 50) / 2)), redBlock43.StartPoint.Y - Convert.ToInt32(Math.Sqrt((50 * 50) / 2))), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController5", "redController6", "redBlock43", "redBlock68");
            redTrack.Add(redBlock67);
            TrackBlock redBlock68 = new TrackBlock("red68", TrackOrientation.NorthSouth, new Point(redBlock67.StartPoint.X, redBlock67.StartPoint.Y), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController5", "redController6", "redBlock67", "redBlock69");
            redTrack.Add(redBlock68);
            TrackBlock redBlock69 = new TrackBlock("red69", TrackOrientation.NorthSouth, new Point(redBlock68.EndPoint.X, redBlock68.EndPoint.Y), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController5", "redController6", "redBlock68", "redBlock70");
            redTrack.Add(redBlock69);
            TrackBlock redBlock70 = new TrackBlock("red70", TrackOrientation.NorthSouth, new Point(redBlock69.EndPoint.X, redBlock69.EndPoint.Y), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController5", "redController6", "redBlock69", "redBlock71");
            redTrack.Add(redBlock70);
            TrackBlock redBlock71 = new TrackBlock("red71", TrackOrientation.SouthWestNorthEast, new Point(redBlock70.EndPoint.X, redBlock70.EndPoint.Y), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController5", "redController6", "redBlock70", "redBlock38");
            redTrack.Add(redBlock71);
            // End Branch 1
            // Begin Branch 2
            TrackBlock redBlock72 = new TrackBlock("red72", TrackOrientation.NorthWestSouthEast, new Point(redBlock32.StartPoint.X - Convert.ToInt32(Math.Sqrt((50 * 50) / 2)), redBlock32.StartPoint.Y - Convert.ToInt32(Math.Sqrt((50 * 50) / 2))), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock32", "redBlock73");
            redTrack.Add(redBlock72);
            TrackBlock redBlock73 = new TrackBlock("red73", TrackOrientation.NorthSouth, new Point(redBlock72.StartPoint.X, redBlock72.StartPoint.Y), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock72", "redBlock74");
            redTrack.Add(redBlock73);
            TrackBlock redBlock74 = new TrackBlock("red74", TrackOrientation.NorthSouth, new Point(redBlock73.EndPoint.X, redBlock73.EndPoint.Y), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock73", "redBlock75");
            redTrack.Add(redBlock74);
            TrackBlock redBlock75 = new TrackBlock("red75", TrackOrientation.NorthSouth, new Point(redBlock74.EndPoint.X, redBlock74.EndPoint.Y), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock74", "redBlock76");
            redTrack.Add(redBlock75);
            TrackBlock redBlock76 = new TrackBlock("red76", TrackOrientation.SouthWestNorthEast, new Point(redBlock75.EndPoint.X, redBlock75.EndPoint.Y), 50, 0, 0, true, false, 55, TrackAllowedDirection.Both, null, "redController3", "redController4", "redBlock75", "redBlock27");
            redTrack.Add(redBlock76);
            // End Branch 2

            // Switch List
            TrackSwitch Switch1 = new TrackSwitch("Switch1", "redController1", redBlock10, redBlock11, YARD);
            TrackSwitch Switch2 = new TrackSwitch("Switch2", "redController2", redBlock18, redBlock17, redBlock1);
            TrackSwitch Switch3 = new TrackSwitch("Switch3", "redController3", redBlock28, redBlock29, redBlock76);
            TrackSwitch Switch4 = new TrackSwitch("Switch4", "redController4", redBlock33, redBlock32, redBlock72);
            TrackSwitch Switch5 = new TrackSwitch("Switch5", "redController5", redBlock39, redBlock40, redBlock71);
            TrackSwitch Switch6 = new TrackSwitch("Switch6", "redController6", redBlock43, redBlock44, redBlock67);
            TrackSwitch Switch7 = new TrackSwitch("Switch7", "redController7", redBlock51, redBlock52, redBlock65);
            // Set Has Switch
            redBlock10.HasSwitch = true;
            redBlock11.HasSwitch = true;
            YARD.HasSwitch = true;
            redBlock18.HasSwitch = true;
            redBlock17.HasSwitch = true;
            redBlock1.HasSwitch = true;
            redBlock28.HasSwitch = true;
            redBlock29.HasSwitch = true;
            redBlock76.HasSwitch = true;
            redBlock33.HasSwitch = true;
            redBlock32.HasSwitch = true;
            redBlock72.HasSwitch = true;
            redBlock39.HasSwitch = true;
            redBlock40.HasSwitch = true;
            redBlock71.HasSwitch = true;
            redBlock43.HasSwitch = true;
            redBlock44.HasSwitch = true;
            redBlock67.HasSwitch = true;
            redBlock51.HasSwitch = true;
            redBlock52.HasSwitch = true;
            redBlock65.HasSwitch = true;

            switchList.Add(Switch1);
            switchList.Add(Switch2);
            switchList.Add(Switch3);
            switchList.Add(Switch4);
            switchList.Add(Switch5);
            switchList.Add(Switch6);
            switchList.Add(Switch7);
            // End Switches
            this.m_switchList = switchList;
            this.m_blockList = redTrack;

        }
        // METHOD: CreateTrackLayoutFileGreenLine
        ///------------------------------------------------------------------------
        /// <summary>
        /// Creates a file with a track layout fior the green line
        /// </summary>
        ///------------------------------------------------------------------------
        public void CreateTrackLayoutFileGreenLine()
        {

        }
        #endregion

        #region Private Data
        /// <summary>
        /// timestamp when serialization operation was last performed.
        /// </summary>
        private DateTime m_serializeTimeStamp = new DateTime();

        /// <summary>
        /// file path for debug mode.
        /// </summary>
        private string m_fileName = string.Empty;

        /// <summary>
        /// File path to save/restore from
        /// </summary>
        private string m_filePath = "TrackLayouts\\";

        /// <summary>
        /// list of track blocks
        /// </summary>
        private List<TrackBlock> m_blockList = new List<TrackBlock>();

        /// <summary>
        /// Log tool
        /// </summary>
        private LoggingTool m_log = new LoggingTool(MethodBase.GetCurrentMethod());

        /// <summary>
        /// List of Switches
        /// </summary>
        private List<TrackSwitch> m_switchList = new List<TrackSwitch>();

        #endregion

    }
}
