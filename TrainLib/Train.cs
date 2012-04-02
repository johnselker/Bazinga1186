using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Train
{
	public class Train : ITrain
	{
		private const double g = 9.8;
		private const double carLength = 32.2;
		private const double maxSlope = 0.540419500; // arctan(0.60)
		private const double medAcceleration = 0.5;
		private const double brakeDeceleration = 7.6;
		private const double eBrakeDeceleration = 10.0;
		private const double maxSpeed = 19.444444444;

		private int cars = 1;
		private double speed = 0.0;
		private double acceleration = 0.0;
		private bool emergencyBrake = false;
		private string announcement = "";
		private double slope = 0.0;
		private double friction = 0.01; // arbitrary selection
		private TrainState state = new TrainState();
		private Timer clock = new Timer();

		public Train(int cars=1, double acceleration=0)
		{
			this.cars = cars;
			this.acceleration = acceleration;
			// Add the event and the event handler for the method that will process the timer event to the timer.
			clock.Elapsed += new ElapsedEventHandler(UpdateState);
			// Set the timer interval to 1 ms.
			clock.Interval = 1;
			clock.Start();
		}

		private void UpdateState(Object sender, ElapsedEventArgs arguments)
		{
			UpdateSpeed();
//			UpdateLocation();
		}

		private void UpdateSpeed()
		{
			double normalForce = state.mass * g * Math.Cos(slope); // Should always be positive
			double engineForce = state.mass * acceleration;
			double gravityForce = state.mass * g * Math.Sin(slope); // Negative means downward slope
			double frictionalForce = friction * normalForce;
			double timestep = clock.Interval * 1000;

			// Increase speed based on acceleration
			speed += (engineForce / state.mass) * timestep;
			// Adjust speed according to slope
			speed -= (gravityForce / state.mass) * timestep;
			// Decrease speed based on friction
			speed -= (frictionalForce / state.mass) * timestep;
		}

		public double GetSpeed()
		{
			return speed;
		}

		public int GetDirection()
		{
			return state.direction;
		}

		public int GetPosition()
		{
			throw new NotImplementedException("TODO: Figure out what this method is intended to do.");
			return 0;
		}

		public TrainState GetState()
		{
			return state;
		}

		public bool SetEmergencyBrake(bool brake)
		{
			emergencyBrake = brake;
			return emergencyBrake;
		}

		public bool SetDoors(TrainState.door doors)
		{
			state.doors = doors;
			return true;
		}

		public bool SetLights(TrainState.light lights)
		{
			state.lights = lights;
			return true;
		}

		public bool SetAnnouncement(string announcement)
		{
			this.announcement = announcement;
			return true;
		}

		public bool SetSlope(double slope)
		{
			if (slope > Math.PI / 2 || slope < -Math.PI / 2)
			{
				return false;
			}
			else
			{
				this.slope = slope;
				return true;
			}
		}

		public bool SetFriction(double friction)
		{
			if (friction > 1 || friction < 0)
			{
				return false;
			}
			else
			{
				this.friction = friction;
				return true;
			}
		}
	}
}
