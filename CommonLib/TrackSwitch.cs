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
    // CLASS: TrackSwitch
    //--------------------------------------------------------------------------------------
    /// <summary>
    /// Class representing a track switch
    /// </summary>
    //--------------------------------------------------------------------------------------
    [Serializable]
    [XmlType(TypeName = "TrackSwitch")]

    public class TrackSwitch
    {

        #region Private Data

        private TrackSwitchState m_state = TrackSwitchState.Closed;

        #endregion

        #region Properties

        // PROPERTY: State
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// State of the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public TrackSwitchState State
        {
            get { return m_state; }
            set { m_state = value; }
        }

        #endregion

        #region Accessors

        //***NOTE: These only have setters for serialization purposes. The setters should NOT be used during runtime***

        // ACCESSOR: Name
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Unique name identifier for the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Name")]
        public string Name
        {
            get;
            set;
        }

        // ACCESSOR: ControllerId
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// ID of the TrackController assigned to the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "ControllerId")]
        public string ControllerId
        {
            get;
            set;
        }

        // PROPERTY: Trunk
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// The trunk block connected to the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Trunk")]
        public TrackBlock Trunk
        {
            get;
            set;
        }

        // PROPERTY: Branch
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// The branch blocks connected to the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Branch")]
        public Dictionary<string, TrackBlock> Branch
        {
            get;
            set;
        }

        // PROPERTY: DefaultBranch
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// The default branch block
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "DefaultBranch")]
        public TrackBlock DefaultBranch
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Empty constructor for serialization
        /// </summary>
        public TrackSwitch()
        {
            //Do nothing
        }

        
        // METHOD: TrackSwitch
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Primary constructor with initial state
        /// </summary>
        /// 
        /// <param name="name">Track switch name</param>
        /// <param name="controllerID">ID of the TrackController assigned to the switch</param>
        /// <param name="trunk">Trunk block connected to the switch</param>
        /// <param name="branch">Branch blocks connected to the switch</param>
        /// <param name="defaultBranch">default branch block connected to the switch</param>
        //--------------------------------------------------------------------------------------
        public TrackSwitch(string name, string controllerID, TrackBlock trunk, Dictionary<string, TrackBlock> branch, TrackBlock defaultBranch)
        {
            m_state = TrackSwitchState.Closed;
            Name = name;
            Trunk = trunk;
            Branch = branch;
            ControllerId = controllerID;
            DefaultBranch = defaultBranch;
        }

        #endregion
    }
}
