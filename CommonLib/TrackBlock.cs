/// TrackBlock.cs
/// Jeremy Nelson
/// Bazinga!

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace CommonLib
{
    // CLASS: TrackBlock
    //--------------------------------------------------------------------------------------
    /// <summary>
    /// Class representing a track block
    /// </summary>
    //--------------------------------------------------------------------------------------
    [Serializable]
    [XmlType(TypeName = "TrackBlock")]
    public class TrackBlock
    {
        #region Private Data

        private BlockAuthority m_authority = new BlockAuthority(0, 0);
        private TrackStatus m_status = new TrackStatus();
        private TrackSwitch m_switch = null;

        #endregion

        #region Properties

        // PROPERTY: Authority
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Authority to send to any train on this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public BlockAuthority Authority
        {
            get { return m_authority; }
            set
            {
                m_authority = value;
            }
        }

        // PROPERTY: NextBlock
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// The block imediately after this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public TrackBlock NextBlock
        {
            get;
            set;
        }

        // PROPERTY: PreviousBlock
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// The block imediately before this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public TrackBlock PreviousBlock
        {
            get;
            set;
        }

        // PROPERTY: BrokenRail
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Indicates the presence of a broken rail in the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public bool BrokenRail
        {
            get;
            set;
        }

        // PROPERTY: PowerFailure
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Indicates a power failure in the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public bool PowerFailure
        {
            get;
            set;
        }

        // PROPERTY: TrackCircuitFailure
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Indicates a failure of the track circuit in the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public bool TrackCircuitFailure
        {
            get;
            set;
        }


        #endregion

        #region Accessors

        //***NOTE: These only have setters for serialization purposes. The setters should NOT be used during runtime***

        // ACCESSOR: Name
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Unique name identifier for the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Name")]
        public string Name
        {
            get;
            set;
        }

        // ACCESSOR: HasTunnel
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Flag indicating this block is within or contains a tunnel
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "HasTunnel")]
        public bool HasTunnel
        {
            get;
            set;
        }

        // ACCESSOR: StaticSpeedLimit
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Static Speed Limit set outside the CTC's speed limit
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "StaticSpeedLimit")]
        public double StaticSpeedLimit
        {
            get;
            set;
        }

        // ACCESSOR: Length
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Length of the track block in meters
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Length")]
        public double LengthMeters
        {
            get;
            set;
        }

        // ACCESSOR: Orientation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Orientation of the track block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Orientation")]
        public TrackOrientation Orientation
        {
            get;
            set;
        }

        // ACCESSOR: RailroadCrossing
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Flag indicating the presence of a railroad crossing
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "RailroadCrossing")]
        public bool RailroadCrossing
        {
            get;
            set;
        }

        // ACCESSOR: Transponder
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Transponder on the track block, if exists
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Transponder")]
        public Transponder Transponder
        {
            get;
            set;
        }

        // ACCESSOR: StartPoint
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Starting point of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "StartPoint")]
        public Point StartPoint
        {
            get;
            set;
        }

        // ACCESSOR: EndPoint
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Ending point of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "EndPoint")]
        public Point EndPoint
        {
            get;
            set;
        }

        // ACCESSOR: StartElevation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Starting elevation of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public double StartElevationMeters
        {
            get;
            set;
        }

        // ACCESSOR: EndElevation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Ending elevation of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "EndElevation")]
        public double EndElevationMeters
        {
            get;
            set;
        }

        // ACCESSOR: Grade
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Grade of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Grade")]
        public double Grade
        {
            get;
            set;
        }

        // ACCESSOR: SwitchId
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Id of the switch connecting to this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "SwitchId")]
        public string SwitchId
        {
            get;
            set;
        }

        // ACCESSOR: ControllerId
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Id of the primary track controller controlling this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "ControllerId")]
        public string ControllerId
        {
            get;
            set;
        }

        // ACCESSOR: SecondaryControllerId
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Id of the secondary track controller controlling this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "SecondaryControllerId")]
        public string SecondaryControllerId
        {
            get;
            set;
        }

        // ACCESSOR: AllowedDirection
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Allowed direction of travel of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "AllowedDirection")]
        public TrackAllowedDirection AllowedDirection
        {
            get;
            set;
        }

        // ACCESSOR: Switch
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Switch object
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public TrackSwitch Switch
        {
            get { return m_switch; }
            set
            {
                m_switch = value;
                if (m_switch != null)
                {
                    SwitchId = m_switch.Name;
                }
                else
                {
                    SwitchId = string.Empty;
                }
            }
        }

        // ACCESSOR: PreviousBlockId
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Id of the previous block attached to this one for connectivity
        /// </summary>
        ///
        /// <remarks>
        /// Only used for serialization. During runtime, NextBlock/PreviousBlock
        /// fields should be used
        /// </remarks>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "PreviousBlockId")]
        public string PreviousBockId
        {
            get;
            set;
        }

        // ACCESSOR: NextBlockId
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Id of the next block attached to this one for connectivity
        /// </summary>
        ///
        /// <remarks>
        /// Only used for serialization. During runtime, NextBlock/PreviousBlock
        /// fields should be used
        /// </remarks>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "NextBlockId")]
        public string NextBockId
        {
            get;
            set;
        }

        // ACCESSOR: HasTransponder
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Shortcut to indicate the presence of a transponder
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public bool HasTransponder
        {
            get;
            set;
        }

        // ACCESSOR: HasSwitch
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Shortcut to determine if the block has a switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public Boolean HasSwitch
        {
            get;
            set;
        }

        // ACCESSOR: Status
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Status of the track block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public TrackStatus Status
        {
            get { return m_status; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Empty constructor for serialization
        /// </summary>
        public TrackBlock()
        {
            //Do nothing
        }


        // METHOD: TrackBlock
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Primary constructor with initial state
        /// </summary>
        ///
        /// <param name="name">Track block name</param>
        /// <param name="orientation">Track block orientation</param>
        /// <param name="length">Track block length</param>
        /// <param name="grade">Grade of the block expressed as a percent</param>
        /// <param name="tunnel">Flag indicating the presence of a tunnel</param>
        /// <param name="railroadCrossing">Flag indicating the presence of a railroad crossing</param>
        /// <param name="signal">Track signal state</param>
        /// <param name="train">Flag indicating the presence of a train</param>
        /// <param name="authority">Authority of the block</param>
        /// <param name="startPoint">Starting coordinates</param>
        /// <param name="endElevation">Elevation at the end point</param>
        /// <param name="direction">Direction of the block</param>
        /// <param name="switchID">Switch ID</param>
        /// <param name="controllerID">Primary Controller ID</param>
        /// <param name="secondaryControllerID">Secondary Controller ID</param>
        //--------------------------------------------------------------------------------------
        public TrackBlock(string name, TrackOrientation orientation, Point startPoint, double length, double endElevation,
                            double grade, bool tunnel, bool railroadCrossing, int staticSpeedLimit,
                            TrackAllowedDirection direction, string switchID, string controllerID,
                            string secondaryControllerID, string prevBlockID, string nextBlockID)
        {
            Name = name;
            Orientation = orientation;
            LengthMeters = length;
            // Use arctangent to express the grade as an angle of inclination to the horizontal
            Grade = grade;
            HasTunnel = tunnel;
            RailroadCrossing = railroadCrossing;
            m_status.IsOpen = true;
            StartPoint = startPoint;
            CalculateEndPoint();
            EndElevationMeters = endElevation;
            AllowedDirection = direction;
            SwitchId = switchID;
            ControllerId = controllerID;
            SecondaryControllerId = secondaryControllerID;
            // Set default static max speed to physical limit
            StaticSpeedLimit = staticSpeedLimit;
            if (LengthMeters > 0)
            {
                StartElevationMeters = EndElevationMeters - ((LengthMeters * grade) / 100);
            }
            PreviousBockId = prevBlockID;
            NextBockId = nextBlockID;
        }

        #endregion

        #region Private Methods

        // METHOD: CalculateEndPoint
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Calculates the endpoint of the block based on the length and orientation
        /// </summary>
        ///
        /// <remarks>
        /// The starting point is assumed to be the leftmost point, or
        /// the southern point if oriented vertically. Y coordinates are
        /// relative to the screen where (0,0) is the top left corner.
        /// Diagonal blocks are assumed to be at 45 degree angles.
        /// </remarks>
        //--------------------------------------------------------------------------------------
        private void CalculateEndPoint()
        {
            double delta = 0;
            switch (Orientation)
            {
                case TrackOrientation.EastWest:
                    EndPoint = new Point(StartPoint.X + (int)LengthMeters, StartPoint.Y);
                    break;
                case TrackOrientation.SouthWestNorthEast:
                    delta = System.Math.Sqrt((LengthMeters * LengthMeters) / 2.0);
                    EndPoint = new Point(StartPoint.X + (int)delta, StartPoint.Y - (int)delta);
                    break;
                case TrackOrientation.NorthSouth:
                    EndPoint = new Point(StartPoint.X, StartPoint.Y - (int)LengthMeters);
                    break;
                case TrackOrientation.NorthWestSouthEast:
                    delta = System.Math.Sqrt((LengthMeters * LengthMeters) / 2.0);
                    EndPoint = new Point(StartPoint.X + (int)delta, StartPoint.Y + (int)delta);
                    break;
            }
        }

        #endregion
    }
}