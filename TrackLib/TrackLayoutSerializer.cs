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

        // METHOD: CreateTrackLayoutFile
        ///------------------------------------------------------------------------
        /// <summary>
        /// Creates a file with a track layout
        /// </summary>
        ///------------------------------------------------------------------------
        public void CreateTrackLayoutFile()
        {
            List<TrackBlock> testRegion = new List<TrackBlock>();
            TrackBlock block1 = new TrackBlock("Block1", TrackOrientation.NorthSouth, new Point(1,1), 100, 0, 0, false, false, 50, TrackAllowedDirection.Both, "Controller1", null);
            TrackBlock block2 = new TrackBlock("Block22", TrackOrientation.NorthSouth, new Point(1, 1), 100, 0, 0, false, false, 50, TrackAllowedDirection.Both, "Controller1", null);
            testRegion.Add(block1);
            testRegion.Add(block2);
            this.m_fileName = "Test.xml";
            this.m_blockList = testRegion;
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
