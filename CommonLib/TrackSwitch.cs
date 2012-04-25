/// TrackBlock.cs
/// Gilbert Liu
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

        private TrackSwitchState m_state;

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

        // PROPERTY: CurrentBranch
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Current branch of the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlIgnore]
        public string CurrentBranchName
        {
            get
            {
                if (m_state == TrackSwitchState.Closed)
                    return BranchClosedId;
                else
                    return BranchOpenId;
            }
        }

        #endregion

        public void Switch()
        {

        }

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

        // PROPERTY: TrunkId
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Id of the trunk block connecting to the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "TrunkId")]
        public string TrunkId
        {
            get;
            set;
        }

        // PROPERTY: BranchClosedId
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Id of the branch blocks connecting to the switch when closed
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "BranchClosedId")]
        public string BranchClosedId
        {
            get;
            set;
        }

        // PROPERTY: BranchOpenId
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Name of the branch blocks connecting to the switch when open
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "BranchOpenId")]
        public string BranchOpenId
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        // METHOD: TrackSwitch
        //--------------------------------------------------------------------------------------
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
        /// <param name="trunkID">ID of the trunk block connecting to the switch</param>
        /// <param name="branchClosedID">ID of the branch blocks connecting to the switch when closed</param>
        /// <param name="branchOpenID">ID of the branch blocks connecting to the switch when open</param>
        //--------------------------------------------------------------------------------------
        public TrackSwitch(string name, string controllerID, string trunkID, string branchClosedID, string branchOpenID)
        {
            Name = name;
            ControllerId = controllerID;
            TrunkId = trunkID;
            BranchClosedId = branchClosedID;
            BranchOpenId = branchOpenID;

            m_state = TrackSwitchState.Closed;
        }

        #endregion
    }
}
