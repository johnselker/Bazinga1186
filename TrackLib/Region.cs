using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackLib;
using CommonLib;

namespace TrackLib
{
    class Region
    {
        #region Private Virables
        private List<TrackBlock> m_blockList;
        private string m_regionName;
        private Region m_nextRegion;
        private Region m_previousRegion;
        #endregion

        #region Constructors
        // Empty Constructor
        public Region()
        {
            this.m_blockList = new List<TrackBlock>();
            this.m_regionName = "";
        }
        public Region(string name, List<TrackBlock> blockList)
        {
            this.m_blockList = blockList;
            this.m_regionName = name;
        }
        public Region(string name, List<TrackBlock> blockList, Region next, Region previous)
        {
            this.m_blockList = blockList;
            this.m_regionName = name;
            this.m_nextRegion = next;
            this.m_previousRegion = previous;
        }
        #endregion
        #region Methods
        public void AddBlock(TrackBlock block)
        {
            this.m_blockList.Add(block);
        }
        public void SetNextRegion(Region nextRegion)
        {
            this.m_nextRegion = nextRegion;
        }
        public void SetPreviousRegion(Region previousRegion)
        {
            this.m_previousRegion = previousRegion;
        }
        public Region GetNextRegion()
        {
            return this.m_nextRegion;
        }
        public Region GetPreviousRegion()
        {
            return this.m_previousRegion;
        }
        #endregion
    }
}
