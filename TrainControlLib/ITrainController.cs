using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;

namespace TrainControllerLib
{
    public delegate void OnTrainAtStation(ITrainController trainController, string stationName);

    public interface ITrainController
    {
        // EVENT: TrainAtStation
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// An event that indicates that the train has arrived at a station
        /// </summary>
        //--------------------------------------------------------------------------------------
        event OnTrainAtStation TrainAtStation;

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

        // METHOD: Dispose
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Dispose of the TrainController
        /// </summary>
        //--------------------------------------------------------------------------------------
        void Dispose();
    }
}
