﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
	public struct TrackStatus
	{
		public bool TrainPresent;
		public bool BrokenRail;
		public bool CircuitFail;
		public bool PowerFail;
		public bool IsOpen;
		public TrackSignalState SignalState;
		public TrackSwitchState SwitchState;
	}
}