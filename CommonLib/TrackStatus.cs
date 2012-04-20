using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
	public class TrackStatus
	{
		public bool TrainPresent;
		public Direction TrainDirection;
		public bool BrokenRail;
		public bool PowerFail;
		public bool CircuitFail;
		public bool IsOpen;
		public TrackSignalState SignalState;
		public TrackSwitchState SwitchState;
	}
}
