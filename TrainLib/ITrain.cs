using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Train
{
	public interface ITrain
	{
		double GetSpeed();
		int GetDirection();
		int GetPosition();
		bool SetEmergencyBrake(bool brake);
		bool SetDoors(TrainState.door doors);
		bool SetLights(TrainState.light lights);
		bool SetAnnouncement(string announcement);
		bool SetSlope(double slope);
		bool SetFriction(double friction);
		TrainState GetState();
	}
}
