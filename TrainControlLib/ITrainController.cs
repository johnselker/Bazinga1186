using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;

namespace TrainControllerLib
{
    public interface ITrainController
    {
        // METHOD: Update
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Call the train contoller
        /// </summary>
        /// <param name="dt">Delta time</param>
        //--------------------------------------------------------------------------------------
        void Update(double dt);

        // METHOD: SetSchedule
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Set the schedule
        /// </summary>
        //--------------------------------------------------------------------------------------
        void SetSchedule(Queue<ScheduleInfo> routeInfo);
    }
}
