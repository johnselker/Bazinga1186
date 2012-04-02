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

        private Authority mAuthority;
		private TrackStatus mStatus;
        private bool mHasTunnel = false;
        private double mLength = 0;
        private TrackOrientation mOrientation;
        private TrackSignalState mSignalState;
        private bool mRailroadCrossing = false;
        private Transponder mTransponder = null;
        private Point mStartPoint = new Point(0, 0);
        private Point mEndPoint = new Point(0, 0);
        private double mStartElevation = 0;
        private double mEndElevation = 0;
        private string mName = string.Empty;

        #endregion

        #region Properties

        // PROPERTY: Authority
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Authority to send to any train on this block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public Authority Authority
        {
            get { return mAuthority; }
            set
            {
                mAuthority = value;
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
            get { return mName; }
            set { mName = value; }
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
            get { return mHasTunnel; }
        }

        // ACCESSOR: Length
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Length of the track block in meters
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double LengthMeters
        {
            get { return mLength; }
        }

        // ACCESSOR: Orientation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Orientation of the track block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public TrackOrientation Orientation
        {
            get { return mOrientation; }
        }

        // ACCESSOR: RailroadCrossing
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Flag indicating the presence of a railroad crossing
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool RailroadCrossing
        {
            get { return mRailroadCrossing; }
        }

        // ACCESSOR: Transponder
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Transponder on the track block, if exists
        /// </summary>
        //--------------------------------------------------------------------------------------
        public Transponder Transponder
        {
            get { return mTransponder; }
        }

        // ACCESSOR: HasTransponder
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Shortcut to indicate the presence of a transponder
        /// </summary>
        //--------------------------------------------------------------------------------------
        public bool HasTransponder
        {
            get { return (mTransponder != null); }
        }

        // ACCESSOR: StartPoint
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Starting point of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public Point StartPoint
        {
            get { return mStartPoint; }
        }

        // ACCESSOR: EndPoint
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Ending point of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public Point EndPoint
        {
            get { return mEndPoint; }
        }

        // ACCESSOR: StartElevation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Starting elevation of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double StartElevationMeters
        {
            get { return mStartElevation; }
        }

        // ACCESSOR: EndElevation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Ending elevation of the block
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double EndElevationMeters
        {
            get { return mEndElevation; }
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
            mOrientation = orientation;
            mLength = length;
            mHasTunnel = tunnel;
            mRailroadCrossing = railroadCrossing;
            mTransponder = transponder;
            mStartPoint = startPoint;
            mName = Guid.NewGuid().ToString();
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
                            TrackSignalState signal, bool train, int speedLimit, Authority authority, Point startPoint,
                            double startElevation, double endElevation)
        {
            mName = name;
            mOrientation = orientation;
            mLength = length;
            mHasTunnel = tunnel;
            mRailroadCrossing = railroadCrossing;
            mAuthority = authority;
            mStartPoint = startPoint;
            CalculateEndPoint();
            mStartElevation = startElevation;
            mEndElevation = endElevation;
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
            switch (mOrientation)
            {
                case TrackOrientation.EastWest:
                    mEndPoint = new Point(mStartPoint.X + (int) mLength, mStartPoint.Y);
                    break;
                case TrackOrientation.SouthWestNorthEast:
                    delta = System.Math.Sqrt((LengthMeters * LengthMeters) / 2.0); 
                    mEndPoint = new Point(mStartPoint.X + (int)delta, mStartPoint.Y - (int) delta);
                    break;
                case TrackOrientation.NorthSouth:
                    mEndPoint = new Point(mStartPoint.X, mStartPoint.Y - (int) mLength);
                    break;
                case TrackOrientation.NorthWestSouthEast:
                    delta = System.Math.Sqrt((LengthMeters * LengthMeters) / 2.0);
                    mEndPoint = new Point(mStartPoint.X + (int)delta, mStartPoint.Y + (int) delta);
                    break;
            }
        }

        #endregion
    }
}
