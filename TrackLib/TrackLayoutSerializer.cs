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
            List<TrackBlock> redRegion1 = new List<TrackBlock>();
            TrackBlock redBlock1 = new TrackBlock("red1", TrackOrientation.SouthWestNorthEast, new Point(0, 0), 50.0, 0.25, 0.5, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, null, "red2");
            redRegion1.Add(redBlock1);
            TrackBlock redBlock2 = new TrackBlock("red2", TrackOrientation.SouthWestNorthEast, redBlock1.EndPoint, 50.0, 0.75, 1, 
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red1", "red3");
            redRegion1.Add(redBlock2);
            TrackBlock redBlock3 = new TrackBlock("red3", TrackOrientation.SouthWestNorthEast, redBlock2.EndPoint, 50.0, 1.50, 1.5, 
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red2", "red4");
            redRegion1.Add(redBlock3);
            TrackBlock redBlock4 = new TrackBlock("red4", TrackOrientation.EastWest, redBlock3.EndPoint, 50.0, 2.5, 2, 
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red3", "red5");
            redRegion1.Add(redBlock4);
            TrackBlock redBlock5 = new TrackBlock("red5", TrackOrientation.EastWest, redBlock4.EndPoint, 50, 3.25, 1.5, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red4", "red6");
            redRegion1.Add(redBlock5);
            TrackBlock redBlock6 = new TrackBlock("red6", TrackOrientation.EastWest, redBlock5.EndPoint, 50, 3.75, 1, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red5", "red7");
            redBlock6.Transponder = new Transponder("Shadyside", 50);
            redRegion1.Add(redBlock6);
            TrackBlock redBlock7 = new TrackBlock("red7", TrackOrientation.NorthWestSouthEast, redBlock6.EndPoint, 75, 4.13, 0.5, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red6", "red8");
            redBlock7.Transponder = new Transponder("Shadyside", 0);
            redRegion1.Add(redBlock7);
            TrackBlock redBlock8 = new TrackBlock("red8", TrackOrientation.NorthWestSouthEast, redBlock7.EndPoint, 75, 4.13, 0, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, "red7", "red9");
            redRegion1.Add(redBlock8);
            TrackBlock redBlock9 = new TrackBlock("red9", TrackOrientation.NorthWestSouthEast, redBlock8.EndPoint, 75, 4.13, 0, 
                                        false, false, 40, TrackAllowedDirection.Both, "switch1", "redController1", "Yard", "red8", "red10");
            redRegion1.Add(redBlock9);

            TrackSwitch yardSwitch = new TrackSwitch("switch1", "Yard", "red9", "red10", "redYard1");
            //Add the switch to the serializer list

            // End redController1 and redRegion1
            // Region2 Sections D-E
            // Controlled by redController2
            //Region redRegion2 = new Region("redRegion2");
            //redRegion2.SetPreviousRegion(redRegion1);
            TrackBlock redBlock10 = new TrackBlock("red10", TrackOrientation.EastWest, redBlock9.EndPoint, 75, 4.13, 0, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController2", "redController1", "red9", "red11");
            redRegion1.Add(redBlock10);
            TrackBlock redBlock11 = new TrackBlock("red11", TrackOrientation.EastWest, redBlock10.EndPoint, 75, 3.75, -0.5, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController2", null, "red10", "red12");
            redRegion1.Add(redBlock11);
            TrackBlock redBlock12 = new TrackBlock("red12", TrackOrientation.EastWest, redBlock11.EndPoint, 75, 3.38, -0.5, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController2", null, "red11", "red13");
            redRegion1.Add(redBlock12);
            TrackBlock redBlock13 = new TrackBlock("red13", TrackOrientation.EastWest, redBlock12.EndPoint, 68.4, 2.69, -1, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController2", null, "red12", "red14");
            redRegion1.Add(redBlock13);
            TrackBlock redBlock14 = new TrackBlock("red14", TrackOrientation.EastWest, redBlock13.EndPoint, 60, 2.09, -1, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController2", null, "red13", "red15");
            redRegion1.Add(redBlock14);
            TrackBlock redBlock15 = new TrackBlock("red15", TrackOrientation.EastWest, redBlock14.EndPoint, 60, 1.49, -1, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController2", null, "red14", "red16");
            redBlock15.Transponder = new Transponder("Herron Ave",60);
            redRegion1.Add(redBlock15);
            // End redController2 and redRegion2
            // Region3 Sections F-I
            // Controlled by redController3
            TrackBlock redBlock16 = new TrackBlock("red16", TrackOrientation.EastWest, redBlock15.EndPoint, 50, 1.24, -0.5, 
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController2", "redController3", "red15", "red17");
            redBlock16.Transponder = new Transponder("Herron Ave",0);
            redRegion1.Add(redBlock16);
            TrackBlock redBlock17 = new TrackBlock("red17", TrackOrientation.EastWest, redBlock16.EndPoint, 200, 0.24, -0.5, 
                                        false, false, 55, TrackAllowedDirection.Both, null,  "redController3", null, "red16", "red18");
            redRegion1.Add(redBlock17);
            TrackBlock redBlock18 = new TrackBlock("red18", TrackOrientation.EastWest, redBlock17.EndPoint, 400, 0, -0.06025, 
                                        false, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red17", "red19");
            redRegion1.Add(redBlock18);
            TrackBlock redBlock19 = new TrackBlock("red19", TrackOrientation.EastWest, redBlock18.EndPoint, 400, 0, 0, 
                                        false, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red18", "red20");
            redRegion1.Add(redBlock19);
            TrackBlock redBlock20 = new TrackBlock("red20", TrackOrientation.EastWest, redBlock19.EndPoint, 200, 0, 0, 
                                        false, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red19", "red21");
            redBlock20.Transponder = new Transponder("Swissville", 200);
            redRegion1.Add(redBlock20);
            TrackBlock redBlock21 = new TrackBlock("red21", TrackOrientation.SouthWestNorthEast, redBlock20.EndPoint, 100, 0, 0, 
                                        false, false, 55, TrackAllowedDirection.Both, null, "redController3", null, "red20", "red22");
            redBlock21.Transponder = new Transponder("Swissville", 0);
            redRegion1.Add(redBlock21);
            TrackBlock redBlock22 = new TrackBlock("red22", TrackOrientation.SouthWestNorthEast, redBlock21.EndPoint, 100, 0, 0, 
                                        false, false, 55, TrackAllowedDirection.Both, null, "redController3", null, "red21", "red23");
            redRegion1.Add(redBlock22);
            TrackBlock redBlock23 = new TrackBlock("red23", TrackOrientation.SouthWestNorthEast, redBlock22.EndPoint, 100, 0, 0, 
                                        false, false, 55, TrackAllowedDirection.Both, null, "redController3", null, "red22", "red24");
            redRegion1.Add(redBlock23);
            TrackBlock redBlock24 = new TrackBlock("red24", TrackOrientation.NorthSouth, redBlock23.EndPoint, 50, 0, 0, 
                                        true, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red23", "red25");
            redBlock24.Transponder = new Transponder("Penn Station", 50);
            redRegion1.Add(redBlock24);
            TrackBlock redBlock25 = new TrackBlock("red25", TrackOrientation.NorthSouth, redBlock24.EndPoint, 50, 0, 0, 
                                        true, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red24", "red26");
            redBlock25.Transponder = new Transponder("Penn Station", 0);
            redRegion1.Add(redBlock25);
            TrackBlock redBlock26 = new TrackBlock("red26", TrackOrientation.NorthSouth, redBlock25.EndPoint, 50, 0, 0, 
                                        true, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red25", "red27");
            redRegion1.Add(redBlock26);
            TrackBlock redBlock27 = new TrackBlock("red27", TrackOrientation.NorthSouth, redBlock26.EndPoint, 50, 0, 0, 
                                        true, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red26", "red27");
            redRegion1.Add(redBlock27);
            TrackBlock redBlock28 = new TrackBlock("red28", TrackOrientation.NorthSouth, redBlock27.EndPoint, 50, 0, 0, 
                                        true, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red27", "red29");
            redRegion1.Add(redBlock28);
            TrackBlock redBlock29 = new TrackBlock("red29", TrackOrientation.NorthSouth, redBlock28.EndPoint, 60, 0, 0, 
                                        true, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red28", "red30");
            redRegion1.Add(redBlock29);
            TrackBlock redBlock30 = new TrackBlock("red30", TrackOrientation.NorthSouth, redBlock29.EndPoint, 60, 0, 0, 
                                        true, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red29", "red31");
            redRegion1.Add(redBlock30);
            TrackBlock redBlock31 = new TrackBlock("red31", TrackOrientation.NorthSouth, redBlock30.EndPoint, 50, 0, 0, 
                                        true, false, 70, TrackAllowedDirection.Both, null, "redController3", null, "red30", "red32");
            redRegion1.Add(redBlock31);





            this.m_blockList = redRegion1;

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

        #endregion

    }
}
