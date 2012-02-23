using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    // CLASS: Transponder
    //--------------------------------------------------------------------------------------
    /// <summary>
    /// Class representing a transponder on a track block.
    /// A transponder indicates the presence of an upcoming station
    /// </summary>
    //--------------------------------------------------------------------------------------
    public class Transponder
    {
        #region Private Data

        private string m_stationName;
        private int m_stationDistance;

        #endregion

        #region Accessors

        // ACCESSOR: StationName
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Name of the upcoming station
        /// </summary>
        //--------------------------------------------------------------------------------------
        public String StationName
        {
            get { return m_stationName; }
        }

        // ACCESSOR: DistanceToStation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Distance to the upcoming station
        /// </summary>
        //--------------------------------------------------------------------------------------
        public int DistanceToStation
        {
            get { return m_stationDistance; }
        }

        #endregion

        #region Constructor

        // METHOD: Transponder
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        /// 
        /// <param name="stationName">Name of the upcoming station</param>
        /// <param name="distance">Distance to the upcoming station</param>
        //--------------------------------------------------------------------------------------
        public Transponder(string stationName, int distance)
        {
            m_stationName = stationName;
            m_stationDistance = distance;
        }

        #endregion
    }
}
