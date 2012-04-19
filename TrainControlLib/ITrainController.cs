using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;

namespace TrainControllerLib
{
    class ITrainController
    {
        #region Public Methods
        // METHOD: Update
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Call the train contoller
        /// </summary>
        /// <param name="dt">Delta time</param>
        //--------------------------------------------------------------------------------------
        public void Update(double dt) {}

        // METHOD: SetSchedule
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Set the schedule
        /// </summary>
        //--------------------------------------------------------------------------------------
        public void SetSchedule(Queue<ScheduleInfo> routeInfo) {}

        #endregion
    }
}
