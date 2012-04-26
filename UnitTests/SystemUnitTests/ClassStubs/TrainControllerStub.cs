using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainControllerLib;
using CommonLib;

namespace ClassStubs
{
    public class TrainControllerStub : ITrainController
    {
        public event OnTrainAtStation TrainAtStation;

        public void Update(double dt)
        { }

        public void SetSchedule(Queue<ScheduleInfo> routeInfo)
        { }

        public void Dispose()
        { }
    }
}
