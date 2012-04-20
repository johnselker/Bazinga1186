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
		double GetAcceleration();
		bool GetBrake();
		bool GetEmergencyBrake();
		double GetPower();
		Direction GetDirection();
		Point GetPosition();
		void Update();
		void SetBrake(bool brake);
		void SetBrakeFailure(bool failure);
		void SetEmergencyBrake(bool brake);
		void SetEngineFailure(bool failure);
		void SetSignalPickupFailure(bool failure);
		void SetDoors(TrainState.Door doors);
		void SetLights(TrainState.Light lights);
		void SetAnnouncement(string announcement);
		bool SetSlope(double slope);
		bool SetFriction(double friction);
		void SetPower(double power);
		TrainState GetState();
	}
}
