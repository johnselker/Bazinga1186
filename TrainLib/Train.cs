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

		private double acceleration = 0;
		private bool emergencyBrake = false;
		private string announcement = "";
		private double slope = 0;
		private double friction = 0.01; // arbitrary selection
		private TrainState state = new TrainState();
		private Timer clock = new Timer();

		public Train(string trainID, int x, int y, int direction, int cars = 1, int crew = 0, int passengers = 0)
		{
			state.TrainID = trainID;
			state.X = x;
			state.Y = y;
			state.Direction = direction;
			state.Cars = cars;
			state.Crew = crew;
			state.Passengers = passengers;
			state.Doors = TrainState.Door.Open;
			state.Lights = TrainState.Light.Off;
			acceleration = 0;
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
			double normalForce = state.Mass * g * Math.Cos(slope); // Should always be positive
			double engineForce = state.Mass * acceleration;
			double gravityForce = state.Mass * g * Math.Sin(slope); // Negative means downward slope
			double frictionalForce = friction * normalForce;
			double timestep = clock.Interval * 1000;

			// Increase speed based on acceleration
			state.Speed += (engineForce / state.Mass) * timestep;
			// Adjust speed according to slope
			state.Speed -= (gravityForce / state.Mass) * timestep;
			// Decrease speed based on friction
			state.Speed -= (frictionalForce / state.Mass) * timestep;
		}

		public double GetSpeed()
		{
			return state.Speed;
		}

		public int GetDirection()
		{
			return state.Direction;
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

		public bool SetDoors(TrainState.Door doors)
		{
			state.Doors = doors;
			return true;
		}

		public bool SetLights(TrainState.Light lights)
		{
			state.Lights = lights;
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

		public bool SetAcceleration(double acceleration)
		{
			if (acceleration < 0)
			{
				this.acceleration = 0;
				return false;
			}
			else if (acceleration > medAcceleration)
			{
				this.acceleration = medAcceleration;
				return false;
			}
			else
			{
				this.acceleration = acceleration;
				return true;
			}
		}

		public bool SetPower(double power)
		{
			if (state.Speed < 0.1)
			{
				acceleration = power / (0.1 * state.Mass);
			}
			else
			{
				acceleration = power / (state.Speed * state.Mass);
			}
			UpdateSpeed();
			return true;
		}
	}
}
