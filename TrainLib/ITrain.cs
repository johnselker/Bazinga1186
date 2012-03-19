using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Train
{
	public interface ITrain
	{
		private int cars;
		private double carLength;
		private double carWeight;
		private double passengerWeight;
		private double maxAcceleration;
		private double maxSpeed;
		private double acceleration;
		private bool emergencyBrake;
		private double slope;
		private double friction;
		private TrainState state;
		private Timer clock;

		public double GetSpeed();
		public int GetDirection();
		public int GetPosition();
		public bool SetEmergencyBrake(bool brake);
		public bool SetDoors(TrainState.door doors);
		public bool SetLights(TrainState.light lights);
		public bool SetAnnouncement(string announcement);
		public bool SetSlope(double slope);
		public bool SetFriction(double friction);
	}
}
