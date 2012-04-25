using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
	public class TrackStatus
	{
        public bool TrainPresent = false;
        public Direction TrainDirection = Direction.East;
        public bool BrokenRail = false;
        public bool PowerFail = false;
        public bool CircuitFail = false;
        public bool IsOpen = true;
        public TrackSignalState SignalState = TrackSignalState.Red;
	}
}
