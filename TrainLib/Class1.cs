using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Train
{
	public class Train
	{
		private int cars;
		private double carLength;
		private double carWeight;
		private int passengers;
		private double passengerWeight;
		private double maxAcceleration;
		private double maxSpeed;
		private double width;
		private double height;
		private enum light {Off, Low, High};
		private enum door {Closed, Open};
		private door doors;
		private light lights;
		private double temperature;

		public Train() {
		}

		public double getSpeed() {
			return 0;
		}

		public double getWeight() {
			return cars * carWeight + passengers * passengerWeight;
		}
	}
}
