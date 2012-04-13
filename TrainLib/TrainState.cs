using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;

namespace Train
{
	public class TrainState
	{
		private const double PASSENGER_WEIGHT = 70;
		private const int MAX_PASSENGERS = 222;
		private const double CAR_MASS = 40900;

		public enum Light {Off, Low, High};
		public enum Door {Closed, Open};

		public const double WIDTH = 2.65;
		public const double HEIGHT = 3.42;

		public string TrainID {get; set;}
		public double Speed {get; set;}
		public int X {get; set;}
		public int Y {get; set;}
        public int Delta { get; set; }
		public Direction Direction {get; set;}
		public int Cars {get; set;}
		public int Passengers {get; set;}
		public int Crew {get; set;}
		public Door Doors {get; set;}
		public Light Lights {get; set;}
		public double Temperature {get; set;}
		public double Mass
		{
			get
			{
				return CAR_MASS * Cars + Passengers * PASSENGER_WEIGHT;
			}
		}
	}
}
