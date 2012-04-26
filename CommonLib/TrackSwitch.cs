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
        private TrackBlock m_trunk;
        private TrackBlock m_branch1;
        private TrackBlock m_branch2;

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

        // ACCESSOR: TrunkId
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

        // ACCESSOR: BranchClosedId
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

        // ACCESSOR: BranchOpenId
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

        // ACCESSOR: Branch
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// The branch currently connected to the trunk of the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Branch")]
        public TrackBlock Branch
        {
            get;
            set;
        }

        // ACCESSOR: Trunk1
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// The trunk connected to the first branch of the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Trunk1")]
        public TrackBlock Trunk1
        {
            get;
            set;
        }

        // ACCESSOR: Trunk2
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// The trunck connected to the second branch of the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        [XmlElement(ElementName = "Trunk2")]
        public TrackBlock Trunk2
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
        /// <param name="trunk">the trunk of the switch</param>
        /// <param name="branch1">the first branch of the switch</param>
        /// <param name="branch2">the second branch of the switch</param>
        /// <remarks>
        /// The TrackBlock that you pass as trunk should be connected to Branch
        /// The TrackBlock that you pass as branch1 should be connected to Trunk1
        /// The TrackBlock that you pass as branch2 should be connected to Trunk2
        /// </remarks>
        //--------------------------------------------------------------------------------------
        public TrackSwitch(string name, string controllerID, TrackBlock trunk, TrackBlock branch1, TrackBlock branch2)
        {
            Name = name;
            ControllerId = controllerID;
			
			TrunkId = trunk.Name;
			BranchClosedId = branch1.Name;
			BranchOpenId = branch2.Name;

            m_trunk = trunk;
            m_branch1 = branch1;
            m_branch2 = branch2;

            // initial state
            Branch = branch1;
            Trunk1 = trunk;
            Trunk2 = null;

            m_state = TrackSwitchState.Closed;
        }

        // METHOD: TrackSwitch
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Secondary constructor with initial state
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

        #region Public Methods

        // METHOD: Switch
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Changes the state of the switch
        /// </summary>
        //--------------------------------------------------------------------------------------
        public void Switch()
        {
            if (Branch == m_branch1)
            {
                Branch = m_branch2;
                Trunk1 = null;
                Trunk2 = m_trunk;
                m_state = TrackSwitchState.Open;
            }
            else
            {
                Branch = m_branch1;
                Trunk1 = m_trunk;
                Trunk2 = null;
                m_state = TrackSwitchState.Closed;
            }
        }

        #endregion
    }
}
