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

        public enum Light { Off, Low, High };
        public enum Door { Closed, Open };

        public const double WIDTH = 2.65;
        public const double HEIGHT = 3.42;

        public TrackBlock CurrentBlock { get; set; }
        public string TrainID { get; set; }
        public double Speed { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double BlockProgress { get; set; }
        public Direction Direction { get; set; }
        public int Cars { get; set; }
        public int Passengers { get; set; }
		public int Crew { get; set; }
		public string Announcement { get; set; }
        public Door Doors { get; set; }
        public Light Lights { get; set; }
		public double Temperature { get; set; }
		public bool BrakeFailure { get; set; }
		public bool EngineFailure { get; set; }
		public bool SignalPickupFailure { get; set; }
        public double Mass
        {
            get
            {
                return CAR_MASS * Cars + Passengers * PASSENGER_WEIGHT;
            }
        }
    }
}
