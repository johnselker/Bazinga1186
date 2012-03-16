using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Train
{
	public class Train : ITrain
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

		public Train(int cars, double carLength, double carWeight, double maxAcceleration, double maxSpeed) {
			this.cars = cars;
			this.carLength = carLength;
			this.carWeight = carWeight;
			this.maxAcceleration = maxAcceleration;
			this.maxSpeed = maxSpeed;
		}
	}
}
