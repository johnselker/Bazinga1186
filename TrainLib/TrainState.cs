using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Train
{
	public class TrainState
	{
		public enum light {Off, Low, High};
		public enum door {Closed, Open};

		private const double passengerWeight = 70;
		private const int maxPassengers = 222;
		private const double carMass = 40900;

		public const double width = 2.65;
		public const double height = 3.42;

		public int trainID;
		public double speed;
		public int x;
		public int y;
		public int direction;
		public int cars;
		public int passengers;
		public int crew;
		public door doors;
		public light lights;
		public double temperature;
		public double mass
		{
			get
			{
				return carMass * cars + passengers * passengerWeight;
			}
		}
	}
}
