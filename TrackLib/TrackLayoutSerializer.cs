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
            TrackBlock redBlock1 = new TrackBlock("1", TrackOrientation.SouthWestNorthEast, new Point(0, 0), 50.0, 0.25, 0.5, false, false, 40, TrackAllowedDirection.Both, "redController1", null);
            redRegion1.Add(redBlock1);
            TrackBlock redBlock2 = new TrackBlock("2", TrackOrientation.SouthWestNorthEast, redBlock1.EndPoint, 50.0, 0.75, 1, false, false, 40, TrackAllowedDirection.Both, "redController1", null);
            redRegion1.Add(redBlock2);
            TrackBlock redBlock3 = new TrackBlock("3", TrackOrientation.SouthWestNorthEast, redBlock2.EndPoint, 50.0, 1.50, 1.5, false, false, 40, TrackAllowedDirection.Both, "redController1", null);
            redRegion1.Add(redBlock3);
            TrackBlock redBlock4 = new TrackBlock("4", TrackOrientation.EastWest, redBlock3.EndPoint, 50.0, 2.5, 2, false, false, 40, TrackAllowedDirection.Both, "redController1", null);
            redRegion1.Add(redBlock4);
            TrackBlock redBlock5 = new TrackBlock("5", TrackOrientation.EastWest, redBlock4.EndPoint, 50, 3.25, 1.5, false, false, 40, TrackAllowedDirection.Both, "redController1", null);
            redRegion1.Add(redBlock5);
            TrackBlock redBlock6 = new TrackBlock("6", TrackOrientation.EastWest, redBlock5.EndPoint, 50, 3.75, 1, false, false, 40, TrackAllowedDirection.Both, "redController1", null);
            redBlock6.Transponder = new Transponder("Shadyside", 50);
            redRegion1.Add(redBlock6);
            TrackBlock redBlock7 = new TrackBlock("7", TrackOrientation.NorthWestSouthEast, redBlock6.EndPoint, 75, 4.13, 0.5, false, false, 40, TrackAllowedDirection.Both, "redController1", null);
            redBlock7.Transponder = new Transponder("Shadyside", 0);
            redRegion1.Add(redBlock7);
            TrackBlock redBlock8 = new TrackBlock("8", TrackOrientation.NorthWestSouthEast, redBlock7.EndPoint, 75, 4.13, 0, false, false, 40, TrackAllowedDirection.Both, "redController1", null);
            redRegion1.Add(redBlock8);
            TrackBlock redBlock9 = new TrackBlock("9", TrackOrientation.NorthWestSouthEast, redBlock8.EndPoint, 75, 4.13, 0, false, false, 40, TrackAllowedDirection.Both, "redController1", "Yard");
            redBlock9.HasSwitch = true;
            redRegion1.Add(redBlock9);
            // End redController1 and redRegion1
            // Region2 Sections D-E
            // Controlled by redController2
            //Region redRegion2 = new Region("redRegion2");
            //redRegion2.SetPreviousRegion(redRegion1);
            TrackBlock redBlock10 = new TrackBlock("10", TrackOrientation.EastWest, redBlock9.EndPoint, 75, 4.13, 0, false, false, 40, TrackAllowedDirection.Both, "redController2", "redController1");
            redRegion1.Add(redBlock10);
            TrackBlock redBlock11 = new TrackBlock("11", TrackOrientation.EastWest, redBlock10.EndPoint, 75, 3.75, -0.5, false, false, 40, TrackAllowedDirection.Both, "redController2", null);
            redRegion1.Add(redBlock11);
            TrackBlock redBlock12 = new TrackBlock("12", TrackOrientation.EastWest, redBlock11.EndPoint, 75, 3.38, -0.5, false, false, 40, TrackAllowedDirection.Both, "redController2", null);
            redRegion1.Add(redBlock12);
            TrackBlock redBlock13 = new TrackBlock("13", TrackOrientation.EastWest, redBlock12.EndPoint, 68.4, 2.69, -1, false, false, 40, TrackAllowedDirection.Both, "redController2", null);
            redRegion1.Add(redBlock13);
            TrackBlock redBlock14 = new TrackBlock("14", TrackOrientation.EastWest, redBlock13.EndPoint, 60, 2.09, -1, false, false, 40, TrackAllowedDirection.Both, "redController2", null);
            redRegion1.Add(redBlock14);
            TrackBlock redBlock15 = new TrackBlock("15", TrackOrientation.EastWest, redBlock14.EndPoint, 60, 1.49, -1, false, false, 40, TrackAllowedDirection.Both, "redController2", null);
            redBlock15.HasSwitch = true;
            redBlock15.HasTransponder = true;
            redBlock15.Transponder = new Transponder("Herron Ave",60);
            redRegion1.Add(redBlock15);
            // End redController2 and redRegion2
            // Region3 Sections F-I
            // Controlled by redController3
            TrackBlock redBlock16 = new TrackBlock("16", TrackOrientation.EastWest, redBlock15.EndPoint, 50, 1.24, -0.5, false, false, 40, TrackAllowedDirection.Both, "redController2", "redController3");
            redBlock16.Transponder = new Transponder("Herron Ave",0);
            redRegion1.Add(redBlock16);
            TrackBlock redBlock17 = new TrackBlock("17", TrackOrientation.EastWest, redBlock16.EndPoint, 200, 0.24, -0.5, false, false, 55, TrackAllowedDirection.Both, "redController3", null);
            redRegion1.Add(redBlock17);
            TrackBlock redBlock18 = new TrackBlock("18", TrackOrientation.EastWest, redBlock17.EndPoint, 400, 0, -0.06025, false, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redRegion1.Add(redBlock18);
            TrackBlock redBlock19 = new TrackBlock("19", TrackOrientation.EastWest, redBlock18.EndPoint, 400, 0, 0, false, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redRegion1.Add(redBlock19);
            TrackBlock redBlock20 = new TrackBlock("20", TrackOrientation.EastWest, redBlock19.EndPoint, 200, 0, 0, false, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redBlock20.HasTransponder = true;
            redBlock20.Transponder = new Transponder("Swissville", 200);
            redRegion1.Add(redBlock20);
            TrackBlock redBlock21 = new TrackBlock("21", TrackOrientation.SouthWestNorthEast, redBlock20.EndPoint, 100, 0, 0, false, false, 55, TrackAllowedDirection.Both, "redController3", null);
            redBlock21.HasTransponder = true;
            redBlock21.Transponder = new Transponder("Swissville", 0);
            redRegion1.Add(redBlock21);
            TrackBlock redBlock22 = new TrackBlock("22", TrackOrientation.SouthWestNorthEast, redBlock21.EndPoint, 100, 0, 0, false, false, 55, TrackAllowedDirection.Both, "redController3", null);
            redRegion1.Add(redBlock22);
            TrackBlock redBlock23 = new TrackBlock("23", TrackOrientation.SouthWestNorthEast, redBlock22.EndPoint, 100, 0, 0, false, false, 55, TrackAllowedDirection.Both, "redController3", null);
            redRegion1.Add(redBlock23);
            TrackBlock redBlock24 = new TrackBlock("24", TrackOrientation.NorthSouth, redBlock23.EndPoint, 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redBlock24.HasTransponder = true;
            redBlock24.Transponder = new Transponder("Penn Station", 50);
            redRegion1.Add(redBlock24);
            TrackBlock redBlock25 = new TrackBlock("25", TrackOrientation.NorthSouth, redBlock24.EndPoint, 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redBlock25.HasTransponder = true;
            redBlock25.Transponder = new Transponder("Penn Station", 0);
            redRegion1.Add(redBlock25);
            TrackBlock redBlock26 = new TrackBlock("26", TrackOrientation.NorthSouth, redBlock25.EndPoint, 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redRegion1.Add(redBlock26);
            TrackBlock redBlock27 = new TrackBlock("27", TrackOrientation.NorthSouth, redBlock26.EndPoint, 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redBlock27.HasSwitch = true;
            redRegion1.Add(redBlock27);
            TrackBlock redBlock28 = new TrackBlock("28", TrackOrientation.NorthSouth, redBlock27.EndPoint, 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redRegion1.Add(redBlock28);
            TrackBlock redBlock29 = new TrackBlock("29", TrackOrientation.NorthSouth, redBlock28.EndPoint, 60, 0, 0, true, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redRegion1.Add(redBlock29);
            TrackBlock redBlock30 = new TrackBlock("30", TrackOrientation.NorthSouth, redBlock29.EndPoint, 60, 0, 0, true, false, 70, TrackAllowedDirection.Both, "redController3", null);
            redRegion1.Add(redBlock30);
            TrackBlock redBlock31 = new TrackBlock("31", TrackOrientation.NorthSouth, redBlock30.EndPoint, 50, 0, 0, true, false, 70, TrackAllowedDirection.Both, "redController3", null);
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
