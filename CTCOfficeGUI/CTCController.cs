using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using TrackLib;
using Train;
using TrackControlLib;

namespace CTCOfficeGUI
{
    public class CTCController
    {
        #region Public Methods

        /// <summary>
        /// Gets a reference to the CTC Controller singleton
        /// </summary>
        /// <returns>Singleton reference</returns>
        public static CTCController GetCTCController()
        {
            if (m_singleton == null)
            {
                m_singleton = new CTCController();
            }
            return m_singleton;
        }

        /// <summary>
        /// Attempts to set the speed limit for the specified block
        /// </summary>
        /// <param name="block">Track block</param>
        /// <param name="value">Speed limit value</param>
        /// <returns>Bool success</returns>
        public bool SetSpeedLimit(TrackBlock block, string value)
        {
            bool result = false;
            int limit;

            if (Int32.TryParse(value, out limit)) //Parse the string into an integer
            {
                if (limit >= 0 && limit <= block.Authority.SpeedLimitKPH)
                {
                    //Send speed limit to wayside controller
                    ITrackController controller = GetTrackController(block);
                    if (controller != null)
                    {
                        result = controller.setAuthority(block.Name, new BlockAuthority(limit, block.Authority.Authority));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Attempts to set the authority for the specified block
        /// </summary>
        /// <param name="block">Track block</param>
        /// <param name="value">Authority value</param>
        /// <returns>Bool success</returns>
        public bool SetAuthority(TrackBlock block, string value)
        {
            bool result = false;
            int authority;

            if (Int32.TryParse(value, out authority)) //Parse the string into an integer
            {
                if (authority >= 0)
                {
                    //Send authority to wayside controller
                    ITrackController controller = GetTrackController(block);
                    if (controller != null)
                    {
                        result = controller.setAuthority(block.Name, new BlockAuthority(block.Authority.SpeedLimitKPH, authority));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the track controller that controls the given block
        /// </summary>
        /// <param name="block">Track block</param>
        /// <returns>Track controller</returns>
        public ITrackController GetTrackController(TrackBlock block)
        {
            //Lookup the track controller 
            return null;
        }

        /// <summary>
        /// Closes the track block 
        /// </summary>
        /// <param name="block">Track block to close</param>
        /// <returns>bool Success</returns>
        public bool CloseTrackBlock(TrackBlock block)
        {
            bool result = false;
            ITrackController controller = GetTrackController(block);
            
            //Attempt to close the track block
            if (controller != null)
            {
                result = controller.closeTrack(block.Name);
            }

            return result;
        }

        /// <summary>
        /// Opens the track block 
        /// </summary>
        /// <param name="block">Track block to open</param>
        /// <returns>bool Success</returns>
        public bool OpenTrackBlock(TrackBlock block)
        {
            bool result = false;
            ITrackController controller = GetTrackController(block);
           
            //Attempt to open the track block
            if (controller != null)
            {
                result = controller.openTrack(block.Name);
            }

            return result;
        }

        #endregion

        #region Private Data

        private static CTCController m_singleton = null;

        #endregion
    }
}
