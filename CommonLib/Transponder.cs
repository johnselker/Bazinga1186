using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace CommonLib
{
    // CLASS: Transponder
    //--------------------------------------------------------------------------------------
    /// <summary>
    /// Class representing a transponder on a track block.
    /// A transponder indicates the presence of an upcoming station
    /// </summary>
    //--------------------------------------------------------------------------------------
    [Serializable]
    [XmlType(TypeName = "Transponder")]
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
        [XmlElement(ElementName = "StationName")]
        public String StationName
        {
            get;
            set;
        }

        // ACCESSOR: DistanceToStation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Distance to the upcoming station
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "DistanceToStation")]
        public int DistanceToStation
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Empty constructor for serialization
        /// </summary>
        public Transponder() { }

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
            StationName = stationName;
            DistanceToStation = distance;
        }

        #endregion
    }
}
