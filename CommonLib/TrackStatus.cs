using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
	public class TrackStatus
	{
		bool trainPresent;
		bool brokenRail;
		bool circuitFail;
		bool powerFail;
		bool isOpen;
		TrackSignalState signalState;
		TrackSwitchState switchState;
	}
}
