using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    public class ScheduleInfo
    {
        #region Private Data

        private string m_stationName;
        private double m_timeToStation;

        #endregion

        #region Accessors

        // ACCESSOR: StationName
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Name of the station
        /// </summary>
        //--------------------------------------------------------------------------------------
        public String StationName
        {
            get { return m_stationName; }
        }

        // ACCESSOR: TimeToStationMinutes
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Total time to the station in minutes
        /// </summary>
        //--------------------------------------------------------------------------------------
        public double TimeToStationMinutes
        {
            get { return m_timeToStation; }
        }

        #endregion

        #region Constructor

        // METHOD: ScheduleInfo
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        /// 
        /// <param name="stationName">Name of the station</param>
        /// <param name="timeToStation">Total time to the station in minutes</param>
        //--------------------------------------------------------------------------------------
        public ScheduleInfo(string stationName, double timeToStation)
        {
            m_stationName = stationName;
            m_timeToStation = timeToStation;
        }

        #endregion
    }
}
