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

		public int trainID;
		public double speed;
		public int direction;
		public int x;
		public int y;
		public int cars;
		public int passengers;
		public int crew;
		public double width;
		public double height;
		public double mass;
		public door doors;
		public light lights;
		public double temperature;
	}
}
