/// TrackBlock.cs
/// Jeremy Nelson
/// Bazinga! 

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System;

namespace CommonLib
{
    // CLASS: TrackBlock
    //--------------------------------------------------------------------------------------
    /// <summary>
    /// Class representing a track block
    /// </summary>
    //--------------------------------------------------------------------------------------
    public class TrackBlock
    {
        #region Private Data

        private int m_authority = 0;
        private int m_speedLimitKph = 0;
        private bool m_hasTunnel = false;
        private bool m_trainPresent = false;
        private bool m_isOpen = true;
        private double m_length = 0;
        private TrackOrientation m_orientation;
        private TrackSignalState m_signalState;
        private bool m_railroadCrossing = false;
        private Transponder m_transponder = null;
        private Point m_startPoint = new Point(0, 0);
        private Point m_endPoint = new Point(0, 0);
        private double m_startElevation = 0;
        private double m_endElevation = 0;
        private string m_name = string.Empty;

        #endregion

        #region Properties

        // PROPERTY: Authority
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Authority to send to any train on this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public int Authority
        {
            get { return m_authority; }
            set
            {
                m_authority = value;
            }
        }

        // PROPERTY: Name
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Unique name identifier for the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        // PROPERTY: SpeedLimitKph
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Speed limit to send to any train on this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public int SpeedLimitKph
        {
            get { return m_speedLimitKph; }
            set { m_speedLimitKph = value; }
        }

        // PROPERTY: TrainPresent
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Flag indicating the presence of a train on this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool TrainPresent
        {
            get { return m_trainPresent; }
            set { m_trainPresent = value; }
        }

        // PROPERTY: SignalState
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Current signal state of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public TrackSignalState SignalState
        {
            get { return m_signalState; }
            set { m_signalState = value; }
        }

        // PROPERTY: IsOpen
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Flag indicating the block is open or closed
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool IsOpen
        {
            get { return m_isOpen; }
            set
            {
                m_isOpen = value;
                if (!m_isOpen)
                {
                    SignalState = TrackSignalState.Red;
                    Authority = 0;
                }
            }
        }
        #endregion

        #region Accessors

        // ACCESSOR: HasTunnel
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Flag indicating this block is within or contains a tunnel
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool HasTunnel
        {
            get { return m_hasTunnel; }
        }

        // ACCESSOR: Length
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Length of the track block in meters
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double LengthMeters
        {
            get { return m_length; }
        }

        // ACCESSOR: Orientation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Orientation of the track block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public TrackOrientation Orientation
        {
            get { return m_orientation; }
        }

        // ACCESSOR: RailroadCrossing
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Flag indicating the presence of a railroad crossing
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool RailroadCrossing
        {
            get { return m_railroadCrossing; }
        }

        // ACCESSOR: Transponder
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Transponder on the track block, if exists
        /// </summary>
        //--------------------------------------------------------------------------------------
        public Transponder Transponder
        {
            get { return m_transponder; }
        }

        // ACCESSOR: HasTransponder
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Shortcut to indicate the presence of a transponder
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool HasTransponder
        {
            get { return (m_transponder != null); }
        }

        // ACCESSOR: StartPoint
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Starting point of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public Point StartPoint
        {
            get { return m_startPoint; }
        }

        // ACCESSOR: EndPoint
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Ending point of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public Point EndPoint
        {
            get { return m_endPoint; }
        }

        // ACCESSOR: StartElevation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Starting elevation of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double StartElevationMeters
        {
            get { return m_startElevation; }
        }

        // ACCESSOR: EndElevation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Ending elevation of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double EndElevationMeters
        {
            get { return m_endElevation; }
        }

        #endregion

        #region Constructors

        // METHOD: TrackBlock
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Primary constructor
        /// </summary>
        /// 
        /// <param name="orientation">Track block orientation</param>
        /// <param name="length">Track block length</param>
        /// <param name="tunnel">Flag indicating the presence of a tunnel</param>
        /// <param name="railroadCrossing">Flag indicating the presence of a railroad crossing</param>
        /// <param name="transponder">Transponder object</param>
        //--------------------------------------------------------------------------------------
        public TrackBlock(TrackOrientation orientation, double length, bool tunnel, bool railroadCrossing, 
                          Transponder transponder, Point startPoint)
        {
            m_orientation = orientation;
            m_length = length;
            m_hasTunnel = tunnel;
            m_railroadCrossing = railroadCrossing;
            m_transponder = transponder;
            m_startPoint = startPoint;
            m_name = Guid.NewGuid().ToString();
            CalculateEndPoint();
        }

        // METHOD: TrackBlock
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Overloaded constructor with initial state
        /// </summary>
        /// 
        /// <param name="name">Track block name</param>
        /// <param name="orientation">Track block orientation</param>
        /// <param name="length">Track block length</param>
        /// <param name="tunnel">Flag indicating the presence of a tunnel</param>
        /// <param name="signal">Track signal state</param>
        /// <param name="train">Flag indicating the presence of a train</param>
        /// <param name="speedLimit">Speed limit of the block</param>
        /// <param name="authority">Authority of the block</param>
        //--------------------------------------------------------------------------------------
        public TrackBlock(string name, TrackOrientation orientation, double length, bool tunnel, bool railroadCrossing,
                            TrackSignalState signal, bool train, int speedLimit, int authority, Point startPoint,
                            double startElevation, double endElevation)
        {
            m_name = name;
            m_orientation = orientation;
            m_length = length;
            m_hasTunnel = tunnel;
            m_railroadCrossing = railroadCrossing;
            m_signalState = signal;
            m_trainPresent = train;
            m_speedLimitKph = speedLimit;
            m_authority = authority;
            m_startPoint = startPoint;
            CalculateEndPoint();
            m_startElevation = startElevation;
            m_endElevation = endElevation;
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
            switch (m_orientation)
            {
                case TrackOrientation.EastWest:
                    m_endPoint = new Point(m_startPoint.X + (int) m_length, m_startPoint.Y);
                    break;
                case TrackOrientation.SouthWestNorthEast:
                    delta = System.Math.Sqrt((LengthMeters * LengthMeters) / 2.0); 
                    m_endPoint = new Point(m_startPoint.X + (int)delta, m_startPoint.Y - (int) delta);
                    break;
                case TrackOrientation.NorthSouth:
                    m_endPoint = new Point(m_startPoint.X, m_startPoint.Y - (int) m_length);
                    break;
                case TrackOrientation.NorthWestSouthEast:
                    delta = System.Math.Sqrt((LengthMeters * LengthMeters) / 2.0);
                    m_endPoint = new Point(m_startPoint.X + (int)delta, m_startPoint.Y + (int) delta);
                    break;
            }
        }

        #endregion
    }
}
