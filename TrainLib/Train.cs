using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Drawing;
using System.Threading;
using CommonLib;

namespace Train
{
	public class Train : ITrain
	{
		private const double g = 9.8;
		private const double carLength = 32.2;
		private const double maxSlope = 0.540419500; // arctan(0.60)
		private const double medAcceleration = 0.5;
		private const double brakeDeceleration = -7.6;
		private const double eBrakeDeceleration = -10.0;
		private const double maxSpeed = 19.444444444;

		private double acceleration = 0;
		private bool emergencyBrake = false;
		private bool brake = false;
		private Point position;
		private Point deltaPosition;
		private string announcement = "";
		private double slope = 0;
		private double friction = 0.01; // arbitrary selection
		private TrainState state = new TrainState();
		private DateTime lastUpdate;

		public Train(string trainID, int x, int y, Direction direction, int cars = 1, int crew = 0, int passengers = 0)
		{
			state.TrainID = trainID;
			position = new Point(x, y);
			state.Direction = direction;
			state.Cars = cars;
			state.Crew = crew;
			state.Passengers = passengers;
			state.Doors = TrainState.Door.Open;
			state.Lights = TrainState.Light.Off;
			acceleration = 0;
			lastUpdate = DateTime.Now;
		}

		public void TestTimestep()
		{
			Random r = new Random();
			double seconds = r.NextDouble() * 60;
			DateTime first = DateTime.Now;
			Thread.Sleep((int)(seconds * 1000));
			DateTime second = DateTime.Now;
			double timestep = DateTime.Now.Subtract(lastUpdate).Duration().TotalSeconds;
			Console.Out.WriteLine("Slept for " + seconds + " seconds.");
			Console.Out.WriteLine(timestep+" seconds of time passed.");
		}

		private void UpdateSpeed()
		{
			// TODO: Test if this actually works
			double timestep = DateTime.Now.Subtract(lastUpdate).Duration().TotalSeconds;

			if (emergencyBrake)
			{
				acceleration = eBrakeDeceleration;
			}
			else if (brake)
			{
				acceleration = brakeDeceleration;
			}

			double normalForce = state.Mass * g * Math.Cos(slope); // Should always be positive
			double engineForce = state.Mass * acceleration;
			double gravityForce = state.Mass * g * Math.Sin(slope); // Negative means downward slope
			double frictionalForce = friction * normalForce;
//			double timestep = clock.Interval * 1000;

			// Ensure that friction cannot cause a negative force
			double forwardForce = engineForce - gravityForce;
			if (frictionalForce > forwardForce)
			{
				forwardForce = 0;
			}
			else
			{
				forwardForce -= frictionalForce;
			}
			// Adjust speed based on net force
			state.Speed += (forwardForce / state.Mass) * timestep;
		}
/*
		private void UpdatePosition()
		{
			double timestep = DateTime.Now.Subtract(lastUpdate).Duration().TotalSeconds;
			switch (state.Direction)
			{
				case Direction.East:
					break;
				case Direction.North:
					break;
				case Direction.Northeast:
					break;
				case Direction.Northwest:
					break;
				case Direction.South:
					break;
				case Direction.Southeast:
					break;
				case Direction.Southwest:
					break;
				case Direction.West:
					break;
				default:
					//Unreachable
					break;
			}
		}
*/
		public double GetSpeed()
		{
			return state.Speed;
		}

		public Direction GetDirection()
		{
			return state.Direction;
		}

		public Point GetPosition()
		{
			return position;
		}

		public TrainState GetState()
		{
			return state;
		}

		public bool SetBrake(bool brake)
		{
			this.brake = brake;
			return this.brake;
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
			if (acceleration < brakeDeceleration)
			{
				this.acceleration = brakeDeceleration;
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

		public bool SetSignalPickupFailure(bool failure)
		{
			// TODO: Implement this
			return false;
		}
		public bool SetEngineFailure(bool failure)
		{
			// TODO: Implement this
			return false;
		}
	}
}
