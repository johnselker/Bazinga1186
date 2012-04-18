using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Drawing;
using CommonLib;

namespace Train
{
	public interface ITrain
	{
		double GetSpeed();
		Direction GetDirection();
		Point GetPosition();
		void Update();
		bool SetBrake(bool brake);
		bool SetEmergencyBrake(bool brake);
		bool SetEngineFailure(bool failure);
		bool SetSignalPickupFailure(bool failure);
		bool SetDoors(TrainState.Door doors);
		bool SetLights(TrainState.Light lights);
		bool SetAnnouncement(string announcement);
		bool SetSlope(double slope);
		bool SetFriction(double friction);
		bool SetAcceleration(double acceleration);
		bool SetPower(double power);
		TrainState GetState();
	}
}
