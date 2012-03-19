using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Train
{
	public class Train : ITrain
	{
		private const double G = 9.8;
		private double speed;
		private int cars;
		private double carLength;
		private double carWeight;
		private double passengerWeight;
		private double maxAcceleration;
		private double maxSpeed;
		private double acceleration;
		private bool emergencyBrake;
		private string announcement;
		private double slope;
		private double friction;
		private TrainState state;
		private Timer clock;

		public Train(int cars, double carLength, double carWeight, double maxAcceleration, double maxSpeed) {
			this.cars = cars;
			this.carLength = carLength;
			this.carWeight = carWeight;
			this.maxAcceleration = maxAcceleration;
			this.maxSpeed = maxSpeed;
			// Adds the event and the event handler for the method that will process the timer event to the timer.
			clock = new Timer();
			clock.Elapsed += new ElapsedEventHandler(UpdateSpeed);
			// Sets the timer interval to 10 ms.
			clock.Interval = 10;
			clock.Start();
		}

		private void UpdateSpeed(Object sender, ElapsedEventArgs arguments) {
			speed += (acceleration - state.mass * G * Math.Cos(slope)) * clock.Interval;
			speed -= speed * friction;
		}

		public double GetSpeed() {
			return speed;
		}

		public int GetDirection()
		{
			return state.direction;
		}

		public bool SetEmergencyBrake(bool brake) {
			emergencyBrake = brake;
			return true;
		}

		public bool SetDoors(TrainState.door doors) {
			state.doors = doors;
			return true;
		}

		public bool SetLights(TrainState.light lights) {
			state.lights = lights;
			return true;
		}

		public bool SetAnnouncement(string announcement) {
			this.announcement = announcement;
			return true;
		}

		public bool SetSlope(double slope) {
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

		public bool SetFriction(double friction) {
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
