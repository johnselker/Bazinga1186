/// TrackBlock.cs
/// Jeremy Nelson
/// Bazinga! 

using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        int m_authority = 0;
        int m_speedLimitKph = 0;
        bool m_hasTunnel = false;
        bool m_trainPresent = false;
        double m_length = 0;
        TrackOrientation m_orientation;
        TrackSignalState m_signalState;
        bool m_railroadCrossing = false;
        Transponder m_transponder = null;

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
        /// Length of the track block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double Length
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
                          Transponder transponder)
        {
            m_orientation = orientation;
            m_length = length;
            m_hasTunnel = tunnel;
            m_railroadCrossing = railroadCrossing;
            m_transponder = transponder;
        }

        // METHOD: TrackBlock
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Overloaded constructor with initial state
        /// </summary>
        /// 
        /// <param name="orientation">Track block orientation</param>
        /// <param name="length">Track block length</param>
        /// <param name="tunnel">Flag indicating the presence of a tunnel</param>
        /// <param name="signal">Track signal state</param>
        /// <param name="train">Flag indicating the presence of a train</param>
        /// <param name="speedLimit">Speed limit of the block</param>
        /// <param name="authority">Authority of the block</param>
        //--------------------------------------------------------------------------------------
        public TrackBlock(TrackOrientation orientation, double length, bool tunnel, bool railroadCrossing, 
                            TrackSignalState signal, bool train, int speedLimit, int authority)
        {
            m_orientation = orientation;
            m_length = length;
            m_hasTunnel = tunnel;
            m_railroadCrossing = railroadCrossing;
            m_signalState = signal;
            m_trainPresent = train;
            m_speedLimitKph = speedLimit;
            m_authority = authority;
        }

        #endregion
    }
}
