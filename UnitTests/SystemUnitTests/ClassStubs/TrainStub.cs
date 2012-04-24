using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Train;
using CommonLib;
using System.Drawing;

namespace ClassStubs
{
    public class TrainStub : ITrain
    {
        public double GetSpeed()
        {
            return 0;
        }

        public double GetAcceleration()
        {
            return 0;
        }

        public bool GetBrake()
        {
            return false;
        }

        public bool GetEmergencyBrake()
        {
            return false;
        }

        public double GetPower()
        {
            return 0;
        }

        public Direction GetDirection()
        {
            return Direction.East;
        }

        public Point GetPosition()
        {
            return new Point();
        }

        public void Update(double deltaTime)
        { }

        public void SetBrake(bool brake, double deltaTime)
        { }

        public void SetBrakeFailure(bool failure)
        { }

        public void SetEmergencyBrake(bool brake, double deltaTime)
        { }

        public void SetEngineFailure(bool failure)
        { }
        
        public void SetSignalPickupFailure(bool failure)
        { }

        public void SetDoors(TrainState.Door doors)
        { }

        public void SetLights(TrainState.Light lights)
        { }

        public void SetAnnouncement(string announcement)
        { }

        public bool SetSlope(double slope)
        {
            return slope > 0;
        }

        public bool SetFriction(double friction)
        {
            return friction > 0;
        }

        public void SetPower(double power, double deltaTime)
        { }

        public TrainState GetState()
        {
            return new TrainState();
        }
    }
}
