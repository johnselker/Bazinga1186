using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Drawing;
using System.Threading;
using CommonLib;
using System.Diagnostics;

namespace TrainLib
{
	public class Train : ITrain
	{
		private const double g = 9.8;
		private const double carLength = 32.2;
		private const double maxSlope = 0.540419500; // arctan(0.60)
//		private const double medAcceleration = 0.5;
		private const double brakeDeceleration = -7.6;
		private const double eBrakeDeceleration = -10.0;
		private const double maxSpeed = 19.444444444;

		private double power = 0;
		private bool brake = false;
		private bool emergencyBrake = false;
		private double slope = 0;
		private double friction = 0.0124744274; // 5000N / (40900kg * 9.8m/s^2)
		private TrainState state = new TrainState();
		private DateTime lastUpdate;

		/// <summary>
		/// Creates a new Train which can be used to create a TrainController.
		/// </summary>
		/// <param name="trainID">Unique identifier for the Train.</param>
		/// <param name="block">TrackBlock on which the Train is located.</param>
		/// <param name="direction">Direction which the Train is facing.</param>
		/// <param name="cars">Number of cars making up the Train. Default is 1.</param>
		/// <param name="crew">Number of crew members on board the Train. Default is 0.</param>
		/// <param name="passengers">Number of passengers on board the Train. Default is 0.</param>
		public Train(string trainID, TrackBlock block, Direction direction, int cars = 1, int crew = 0, int passengers = 0)
		{
			state.TrainID = trainID;
			state.CurrentBlock = block;
			block.Status.TrainPresent = true;
			block.Status.TrainDirection = direction;
			switch (direction)
			{
				case Direction.East:
				case Direction.North:
				case Direction.Northeast:
				case Direction.Southeast:
					state.X = block.StartPoint.X;
					state.Y = block.StartPoint.Y;
					break;
				case Direction.West:
				case Direction.South:
				case Direction.Northwest:
				case Direction.Southwest:
					state.X = block.EndPoint.X;
					state.Y = block.EndPoint.Y;
					break;
				default:
					break; // Unreachable
			}

			slope = Math.Atan(block.Grade / 100.0); // Store slope in radians
			state.Direction = direction;
			state.Cars = cars;
			state.Crew = crew;
			state.Passengers = passengers;
			state.Doors = TrainState.Door.Open;
			state.Lights = TrainState.Light.Off;
			power = 0;
			lastUpdate = DateTime.Now;
		}

		/// <summary>
		/// Updates the speed and position of the Train.
		/// </summary>
		/// <param name="deltaTime">The number of seconds elapsed since last update.</param>
		public void Update(double deltaTime)
		{
			UpdateSpeed(deltaTime);
			UpdatePosition(deltaTime);
			lastUpdate = DateTime.Now;
		}

		/// <summary>
		/// Updates the speed of the Train.
		/// </summary>
		/// <param name="deltaTime">The number of seconds elapsed since last update.</param>
		private void UpdateSpeed(double deltaTime)
		{
            double timestep = deltaTime; 
            double acceleration = GetAcceleration();

			if (emergencyBrake)
			{
				acceleration = eBrakeDeceleration;
			}
			else if (brake)
			{
				if (state.BrakeFailure)
				{
					acceleration = 0;
				}
				else
				{
					acceleration = brakeDeceleration;
				}
			}
			else if (state.EngineFailure)
			{
				acceleration = 0;
			}

			double normalForce = state.Mass * g * Math.Cos(slope); // Always positive
			double engineForce = state.Mass * acceleration; // Negative means brakes are applied
			double gravityForce = state.Mass * g * Math.Sin(slope); // Negative means downward slope
			double frictionalForce = friction * normalForce; // Always positive

			// Calculate the net force on the train
			double netForce = engineForce - (gravityForce + frictionalForce);
			// Adjust speed based on net force
			double previousSpeed = state.Speed;
			state.Speed += (netForce / state.Mass) * timestep;
			if (state.Speed < 0)
			{
				state.Speed = 0;
			}
			else if (state.Speed > maxSpeed)
			{
				state.Speed = maxSpeed;
			}
		}

		/// <summary>
		/// Updates the position of the Train.
		/// </summary>
		/// <param name="deltaTime">The number of seconds elapsed since last update.</param>
		private void UpdatePosition(double deltaTime)
		{
            double timestep = deltaTime;
			double distance = timestep * state.Speed;
			TrackBlock block = state.CurrentBlock;
			int startX = block.StartPoint.X;
			int startY = block.StartPoint.Y;
			int endX = block.EndPoint.X;
			int endY = block.EndPoint.Y;
			double length = block.LengthMeters;

			switch (state.Direction)
			{
				case Direction.East:
					state.X += distance;
					state.BlockProgress = (state.X - startX);
					break;
				case Direction.North:
					state.Y -= distance;
					state.BlockProgress = (state.Y - startY);
					break;
				case Direction.Northeast:
					distance /= Math.Sqrt(2);
					state.X += distance;
					state.Y -= distance;
					state.BlockProgress = Math.Sqrt(Math.Pow(state.Y - startY, 2) + Math.Pow(state.X - startX, 2));
					break;
				case Direction.Northwest:
					distance /= Math.Sqrt(2);
					state.X -= distance;
					state.Y -= distance;
					state.BlockProgress = Math.Sqrt(Math.Pow(state.Y - endY, 2) + Math.Pow(state.X - endX, 2));
					break;
				case Direction.South:
					state.Y += distance;
					state.BlockProgress = (state.Y - endY);
					break;
				case Direction.Southeast:
					distance /= Math.Sqrt(2);
					state.X += distance;
					state.Y += distance;
					state.BlockProgress = Math.Sqrt(Math.Pow(state.Y - startY, 2) + Math.Pow(state.X - startX, 2));
					break;
				case Direction.Southwest:
					distance /= Math.Sqrt(2);
					state.X -= distance;
					state.Y += distance;
					state.BlockProgress = Math.Sqrt(Math.Pow(state.Y - endY, 2) + Math.Pow(state.X - endX, 2));
					break;
				case Direction.West:
					state.X -= distance;
					state.BlockProgress = (state.X - endX);
					break;
				default:
					break; // Unreachable
			}
			state.BlockProgress = Math.Abs(state.BlockProgress);

			// Move to next block
			if (state.BlockProgress > length)
			{
				// Subtract length of previous block from progress
				state.BlockProgress -= length;

				// Move train's presence to next block
				state.CurrentBlock.Status.TrainPresent = false;
				state.CurrentBlock = block.NextBlock;
				state.CurrentBlock.Status.TrainPresent = true;

				// Set the train's direction according to new block
				switch (state.CurrentBlock.Orientation)
				{
					case TrackOrientation.EastWest:
						if (state.Direction == Direction.East || state.Direction == Direction.Northeast || state.Direction == Direction.Southeast)
						{
							state.Direction = Direction.East;
						}
						else if (state.Direction == Direction.West || state.Direction == Direction.Northwest || state.Direction == Direction.Southwest)
						{
							state.Direction = Direction.West;
						}
						else
						{
							Debug.Fail("Invalid transition to EastWest block!");
						}
						break;
					case TrackOrientation.NorthSouth:
						if (state.Direction == Direction.North || state.Direction == Direction.Northeast || state.Direction == Direction.Northwest)
						{
							state.Direction = Direction.North;
						}
						else if (state.Direction == Direction.South || state.Direction == Direction.Southeast || state.Direction == Direction.Southwest)
						{
							state.Direction = Direction.South;
						}
						else
						{
							Debug.Fail("Invalid transition to NorthSouth block!");
						}
						break;
					case TrackOrientation.NorthWestSouthEast:
						if (state.Direction == Direction.North || state.Direction == Direction.West || state.Direction == Direction.Northwest)
						{
							state.Direction = Direction.Northwest;
						}
						else if (state.Direction == Direction.South || state.Direction == Direction.East || state.Direction == Direction.Southeast)
						{
							state.Direction = Direction.Southeast;
						}
						else
						{
							Debug.Fail("Invalid transition to NorthwestSoutheast block!");
						}
						break;
					case TrackOrientation.SouthWestNorthEast:
						if (state.Direction == Direction.South || state.Direction == Direction.West || state.Direction == Direction.Southwest)
						{
							state.Direction = Direction.Southwest;
						}
						else if (state.Direction == Direction.North || state.Direction == Direction.East || state.Direction == Direction.Northeast)
						{
							state.Direction = Direction.Northeast;
						}
						else
						{
							Debug.Fail("Invalid transition to NorthSouth block!");
						}
						break;
					default:
						break; // Unreachable
				}
				// Set the train's direction in the TrainBlock
				state.CurrentBlock.Status.TrainDirection = state.Direction;
				// Update the slope according to the new block
				slope = Math.Atan(block.Grade / 100.0);
			}
		}

		/// <summary>
		/// Returns the speed of the TrainState.
		/// </summary>
		/// <returns>Speed of the TrainState.</returns>
		public double GetSpeed()
		{
			return state.Speed;
		}

		/// <summary>
		/// Returns the acceleration of the Train.
		/// </summary>
		/// <returns>Acceleration calculated using the following equation: power / (speed * mass).</returns>
		public double GetAcceleration()
		{
			if (state.Speed < 0.1)
			{
				return power / (0.1 * state.Mass);
			}
			else
			{
				return power / (state.Speed * state.Mass);
			}
		}

		/// <summary>
		/// Returns the state of the brake.
		/// </summary>
		/// <returns>Whether or not the brake is applied.</returns>
		public bool GetBrake()
		{
			return brake;
		}

		/// <summary>
		/// Returns the state of the emergency brake.
		/// </summary>
		/// <returns>Whether or not the emergency brake is applied.</returns>
		public bool GetEmergencyBrake()
		{
			return emergencyBrake;
		}

		/// <summary>
		/// Returns the direction stored in the TrainState.
		/// </summary>
		/// <returns>Direction which the Train is facing.</returns>
		public Direction GetDirection()
		{
			return state.Direction;
		}

		/// <summary>
		/// Returns the position of the Train.
		/// </summary>
		/// <returns>The X and Y coordinates of the TrainState as a Point.</returns>
		public Point GetPosition()
		{
			return new Point(System.Convert.ToInt32(state.X), System.Convert.ToInt32(state.Y));
		}

		/// <summary>
		/// Returns the TrainState.
		/// </summary>
		/// <returns>The TrainState which stores pertinent information about the Train.</returns>
		public TrainState GetState()
		{
			return state;
		}

		/// <summary>
		/// Sets the state of the brake.
		/// </summary>
		/// <param name="brake">Whether or not the brake should be applied.</param>
		/// <param name="deltaTime">Amount of time since last update.</param>
		public void SetBrake(bool brake, double deltaTime)
		{
			this.brake = brake;
			if (brake)
			{
				power = 0;
			}
            Update(deltaTime);
		}

		/// <summary>
		/// Sets the state of the emergency brake.
		/// </summary>
		/// <param name="brake">Whether or not the emergency brake should be applied.</param>
		/// <param name="deltaTime">Amount of time since last update.</param>
        public void SetEmergencyBrake(bool brake, double deltaTime)
		{
			emergencyBrake = brake;
			if (brake)
			{
				power = 0;
			}
            Update(deltaTime);
		}

		/// <summary>
		/// Sets the state of the doors.
		/// </summary>
		/// <param name="doors">Whether or not the doors are open.</param>
		public void SetDoors(TrainState.Door doors)
		{
			state.Doors = doors;
		}

		/// <summary>
		/// Sets the state of the lights.
		/// </summary>
		/// <param name="lights">Whether or not the lights are on.</param>
		public void SetLights(TrainState.Light lights)
		{
			state.Lights = lights;
		}

		/// <summary>
		/// Sets the announcement of the next stop.
		/// </summary>
		/// <param name="announcement">Announcement message.</param>
		public void SetAnnouncement(string announcement)
		{
			state.Announcement = announcement;
		}

		/// <summary>
		/// Sets the slope of the current Track.
		/// </summary>
		/// <param name="slope">The slope of the Track in radians. Slopes greater than pi/2 or less than -pi/2 are invalid.</param>
		/// <returns>Whether or not the slope was valid. Invalid slopes are ignored.</returns>
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

		/// <summary>
		/// Sets the friction of the current Track.
		/// </summary>
		/// <param name="friction">The coefficient of friction of the current track. Coefficients greater than 1 or less than 0 are invalid.</param>
		/// <returns>Whether or not the coefficient of friction was valid. Invalid coefficients are ignored.</returns>
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

		/// <summary>
		/// Returns the power of the Train's engine.
		/// </summary>
		/// <returns>The power in Watts.</returns>
		public double GetPower()
		{
			return power;
		}

		/// <summary>
		/// Sets the power of the Train's engine.
		/// </summary>
		/// <param name="power">The power in Watts. Negative powers are ignored.</param>
		/// <param name="deltaTime">The time in seconds since the last update.</param>
        public void SetPower(double power, double deltaTime)
		{
			if (power < 0)
			{
				this.power = 0;
			}
			else
			{
				this.power = power;
			}
			Update(deltaTime);
		}

		/// <summary>
		/// Sets the state of the brake failure.
		/// </summary>
		/// <param name="failure">Whether or not the brakes have failed.</param>
		public void SetBrakeFailure(bool failure)
		{
			state.BrakeFailure = failure;
		}

		/// <summary>
		/// Sets the state of the signal pickup failure.
		/// </summary>
		/// <param name="failure">Whether or not the signal pickup failure has occurred.</param>
		public void SetSignalPickupFailure(bool failure)
		{
			state.SignalPickupFailure = failure;
		}

		/// <summary>
		/// Sets the state of the engine failure.
		/// </summary>
		/// <param name="failure">Whether or not the engine has failed.</param>
		public void SetEngineFailure(bool failure)
		{
			state.EngineFailure = failure;
		}
	}
}
