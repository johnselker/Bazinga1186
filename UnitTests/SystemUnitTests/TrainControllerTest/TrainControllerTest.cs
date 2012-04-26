using TrainControllerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainLib;
using System.Timers;
using CommonLib;
using System.Collections.Generic;
using System.Drawing;

namespace TrainControllerTest
{


    /// <summary>
    ///This is a test class for TrainControllerTest and is intended
    ///to contain all TrainControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TrainControllerTest
    {
        private string station;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for TrainController Constructor
        ///</summary>
        [TestMethod()]
        public void TrainControllerConstructorTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            Assert.IsNotNull(target);
            Assert.AreEqual(myTrain, target.m_myTrain);
            Assert.AreEqual(myTrain.GetState(), target.m_currentState);
            Assert.AreEqual(myTrain.GetState().TrainID, target.m_trainID);
            Assert.AreEqual(startingBlock, target.m_currentBlock);
            Assert.IsNotNull(target.m_passengerGenerator);
            Assert.AreEqual(-1.0, target.ManualSpeed);
        }

        /// <summary>
        ///A test for CalculateStoppingDistance
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void CalculateStoppingDistanceTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_currentState.Speed = 70 / 3.6;
            double finalVelocity = 0.0;
            double expected = 26.6258;
            double actual;
            actual = target.CalculateStoppingDistance(finalVelocity);
            Assert.AreEqual(expected, Math.Round(actual, 4, MidpointRounding.AwayFromZero));
        }

        /// <summary>
        /// A test for ControlLaw with all parameters set to zero
        /// </summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void ControlLawAllZerosTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_powerCommand = 0;
            target.m_samplePeriod = 0;
            target.m_currentSample = 0;
            target.m_lastSample = 0;
            target.m_currentSample = 0;
            target.m_lastIntegral = 0;

            target.ControlLaw();
            Assert.AreEqual(0, target.m_powerCommand);
        }

        /// <summary>
        /// A test for ControlLaw to test that negative power is set to zero
        /// </summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void ControlLawNegativePowerTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_powerCommand = 0;
            target.m_samplePeriod = 0.001;
            target.m_currentSample = 0;
            target.m_lastSample = 0;
            target.m_currentSample = -100000000;
            target.m_lastIntegral = 0;

            target.ControlLaw();
            Assert.AreEqual(0, target.m_powerCommand);
        }

        /// <summary>
        /// A test for ControlLaw to test that power commands cannot be above the max power
        /// </summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void ControlLawSaturationTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_powerCommand = 0;
            target.m_samplePeriod = 0.001;
            target.m_currentSample = 0;
            target.m_lastSample = 0;
            target.m_currentSample = 100000000;
            target.m_lastIntegral = 0;

            target.ControlLaw();
            Assert.AreEqual(120000, target.m_powerCommand);
        }

        /// <summary>
        /// A test for ControlLaw to test the Proportional Gain
        /// </summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void ControlLawProportionalGainOnlyTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_powerCommand = 120000;
            target.m_samplePeriod = 0.001;
            target.m_lastSample = 0;
            target.m_currentSample = 0.1;
            target.m_lastIntegral = 0;

            target.ControlLaw();
            Assert.AreEqual(100000, target.m_powerCommand);
        }

        /// <summary>
        /// A test for ControlLaw to test the integral gain
        /// </summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void ControlLawIntegralGainOnlyTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_powerCommand = 0;
            target.m_samplePeriod = 0.001;
            target.m_lastSample = 2000;
            target.m_currentSample = 0;
            target.m_lastIntegral = 1;

            target.ControlLaw();
            Assert.AreEqual(20000, target.m_powerCommand);
        }

        /// <summary>
        /// A test for ControlLaw to test the integral gain when the power is already at the max
        /// </summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void ControlLawIntegralGainWithMaxPowerTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_powerCommand = 120000;
            target.m_samplePeriod = 0.001;
            target.m_lastSample = 0;
            target.m_currentSample = 0;
            target.m_lastIntegral = 1;

            target.ControlLaw();
            Assert.AreEqual(10000, target.m_powerCommand);
        }

        /// <summary>
        /// A test for ControlLaw to test the proportional and integral gain
        /// </summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void ControlLawProportionalAndIntegralGain()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_powerCommand = 0;
            target.m_samplePeriod = 0.001;
            target.m_lastSample = 1999.999;
            target.m_currentSample = 0.001;
            target.m_lastIntegral = 1;

            target.ControlLaw();
            Assert.AreEqual(21000, target.m_powerCommand);
        }

        /// <summary>
        ///A test for DetermineSetPoint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void DetermineSetPointTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_currentBlock.Authority = new BlockAuthority(0, 0);
            target.m_currentBlock.NextBlock = new TrackBlock("nextBlock", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block1", "nextBlock2");
            target.m_currentBlock.NextBlock.Authority = new BlockAuthority(100, 0);

            target.m_setPoint = 0;
            target.ManualMode = true;
            target.ManualSpeed = -1;
            target.m_currentState.Speed = 1;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 0;
            target.ManualMode = true;
            target.ManualSpeed = -1;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 0;
            target.ManualMode = true;
            target.ManualSpeed = 72;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 0;
            target.ManualMode = true;
            target.ManualSpeed = 72;
            target.m_currentBlock.Authority.SpeedLimitKPH = 80;
            target.DetermineSetPoint();
            Assert.AreEqual(20.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.SpeedLimitKPH = -36;
            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = -36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);
            Assert.IsTrue(target.EmergencyBrake);

            target.EmergencyBrake = false;
            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentState.Speed = 1;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentState.Speed = 1;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 0;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentBlock.NextBlock.Authority.SpeedLimitKPH = 18;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(5.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentBlock.NextBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;

            target.m_approachingStation = true;

            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentBlock.NextBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;

            target.m_approachingStation = true;
            target.m_currentBlock.Transponder = new Transponder("station1", 2);

            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentBlock.NextBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;

            target.m_approachingStation = true;
            target.m_currentBlock.Transponder = new Transponder("station1", 1);

            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentBlock.NextBlock.Authority.SpeedLimitKPH = 36;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;

            target.m_approachingStation = true;
            target.m_currentBlock.Transponder = new Transponder("station1", 0);

            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);
        }

        /// <summary>
        ///A test for FaultMonitor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void FaultMonitorTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_setPoint = 10.0;
            target.m_currentState.CurrentBlock.Status.PowerFail = false;
            target.m_currentState.CurrentBlock.Status.CircuitFail = false;
            target.m_currentState.EngineFailure = false;
            target.m_currentState.BrakeFailure = false;

            target.FaultMonitor();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 10.0;
            target.m_currentState.CurrentBlock.Status.PowerFail = true;

            target.FaultMonitor();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 10.0;
            target.m_currentState.CurrentBlock.Status.PowerFail = false;
            target.m_currentState.CurrentBlock.Status.CircuitFail = true;

            target.FaultMonitor();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 10.0;
            target.m_currentState.CurrentBlock.Status.CircuitFail = false;
            target.m_currentState.EngineFailure = true;

            target.FaultMonitor();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 10.0;
            target.m_currentState.EngineFailure = false;
            target.m_currentState.BrakeFailure = true;

            target.FaultMonitor();
            Assert.AreEqual(10.0, target.m_setPoint);
            Assert.IsTrue(target.m_brakeFailure);
        }

        /// <summary>
        ///A test for LeaveStation
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void LeaveStationTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            Queue<ScheduleInfo> routeInfo = new Queue<ScheduleInfo>();
            routeInfo.Enqueue(new ScheduleInfo("station123", 1));
            target.Schedule = routeInfo;

            target.LeaveStation();

            Assert.AreEqual(TrainState.Door.Closed, target.m_currentState.Doors);
            Assert.AreEqual("station123", target.m_nextStationInfo.StationName);
            Assert.AreEqual("station123", target.m_currentState.Announcement);
            Assert.IsFalse(target.m_atStation);
            Assert.AreEqual(0.0, target.m_timePassed);
        }

        /// <summary>
        ///A test for LightController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void LightControllerTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_inTunnel = false;
            target.m_currentBlock.HasTunnel = false;
            target.m_currentState.Lights = TrainState.Light.Off;

            target.LightController();

            Assert.AreEqual(TrainState.Light.Off, target.m_currentState.Lights);
            Assert.IsFalse(target.m_inTunnel);

            target.m_currentBlock.HasTunnel = true;

            target.LightController();

            Assert.AreEqual(TrainState.Light.High, target.m_currentState.Lights);
            Assert.IsTrue(target.m_inTunnel);

            target.m_currentBlock.HasTunnel = false;

            target.LightController();

            Assert.AreEqual(TrainState.Light.Off, target.m_currentState.Lights);
            Assert.IsFalse(target.m_inTunnel);

            target.m_inTunnel = true;
            target.m_currentBlock.HasTunnel = true;

            target.LightController();

            Assert.AreEqual(TrainState.Light.Off, target.m_currentState.Lights);
            Assert.IsTrue(target.m_inTunnel);
        }

        /// <summary>
        ///A test for StationController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void StationControllerTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            myTrainController.TrainAtStation += new OnTrainAtStation(myTrainController_TrainAtStation);

            Queue<ScheduleInfo> routeInfo = new Queue<ScheduleInfo>();
            routeInfo.Enqueue(new ScheduleInfo("station123", 1));
            target.Schedule = routeInfo;

            target.m_nextStationInfo = new ScheduleInfo("stationABC", 1);

            station = "";
            target.m_approachingStation = false;
            target.m_currentBlock.Transponder = null;
            target.m_currentState.Speed = 10;
            target.m_atStation = false;
            target.m_timePassed = 1;
            target.m_currentState.Passengers = 0;

            target.StationController();

            Assert.AreEqual("", station);
            Assert.IsFalse(target.m_approachingStation);
            Assert.IsFalse(target.m_atStation);
            Assert.AreEqual(1.0, target.m_timePassed);
            Assert.AreEqual("stationABC", target.m_nextStationInfo.StationName);
            Assert.AreEqual(0, target.m_currentState.Passengers);

            target.m_currentBlock.Transponder = new Transponder("station456", 1);

            target.StationController();

            Assert.AreEqual("", station);
            Assert.IsTrue(target.m_approachingStation);
            Assert.IsFalse(target.m_atStation);
            Assert.AreEqual(1.0, target.m_timePassed);
            Assert.AreEqual("stationABC", target.m_nextStationInfo.StationName);
            Assert.AreEqual(0, target.m_currentState.Passengers);

            target.m_currentBlock.Transponder = new Transponder("station456", 0);
            target.m_approachingStation = true;
            target.m_currentState.Speed = 0;

            target.StationController();

            Assert.AreEqual("station456", station);
            Assert.IsFalse(target.m_approachingStation);
            Assert.IsTrue(target.m_atStation);
            Assert.AreEqual(1.0, target.m_timePassed);
            Assert.AreEqual("stationABC", target.m_nextStationInfo.StationName);
            Assert.IsTrue(target.m_currentState.Passengers >= 0);

            station = "";
            target.m_arrivalTime = 0;
            target.m_timePassed = 60;

            target.StationController();

            Assert.AreEqual("", station);
            Assert.IsFalse(target.m_approachingStation);
            Assert.IsFalse(target.m_atStation);
            Assert.AreEqual(0.0, target.m_timePassed);
            Assert.AreEqual("station123", target.m_nextStationInfo.StationName);

            target.m_currentBlock.Transponder = new Transponder("station456", 1);

            target.StationController();

            Assert.AreEqual("", station);
        }

        void myTrainController_TrainAtStation(ITrainController trainController, string stationName)
        {
            station = stationName;
        }

        /// <summary>
        ///A test for SystemController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void SystemControllerTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            startingBlock.Authority.Authority = -1;
            startingBlock.Transponder = new Transponder("station456", 1);
            startingBlock.NextBlock = new TrackBlock("nextBlock", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block1", "nextBlock2");
            startingBlock.NextBlock.Authority = new BlockAuthority(100, 0);
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_samplePeriod = 1;
            target.m_timePassed = 1;
            target.m_currentBlock = null;
            target.m_setPoint = 10;
            target.m_currentState.BrakeFailure = true;
            target.m_powerCommand = 200000;
            target.m_inTunnel = false;
            target.m_approachingStation = true;

            target.SystemController(0.001);

            Assert.AreEqual(0.001, target.m_samplePeriod);
            Assert.AreEqual(1.001, target.m_timePassed);
            Assert.AreEqual(startingBlock, target.m_currentBlock);
            Assert.AreEqual(0.0, target.m_setPoint);
            Assert.IsTrue(target.m_brakeFailure);
            Assert.AreEqual(200000, target.m_powerCommand);
            Assert.IsTrue(target.m_inTunnel);
            Assert.IsTrue(target.m_approachingStation);

            target.m_samplePeriod = 0;
            Queue<ScheduleInfo> routeInfo = new Queue<ScheduleInfo>();
            routeInfo.Enqueue(new ScheduleInfo("station123", 1));
            target.Schedule = routeInfo;

            target.SystemController(0.002);

            Assert.AreEqual(0.002, target.m_samplePeriod);
            Assert.AreEqual(0.002, target.m_timePassed);
            Assert.AreEqual(startingBlock, target.m_currentBlock);
            Assert.AreEqual(0.0, target.m_setPoint);
            Assert.IsTrue(target.m_brakeFailure);
            Assert.AreEqual(200000, target.m_powerCommand);
            Assert.IsTrue(target.m_inTunnel);
            Assert.IsTrue(target.m_approachingStation);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_samplePeriod = 0.001;

            try
            {
                target.Update(0.123);
            }
            catch (System.NullReferenceException e)
            {
                Assert.IsNotNull(e);
            }

            Assert.AreEqual(0.123, target.m_samplePeriod);
        }

        /// <summary>
        ///A test for VelocityController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void VelocityControllerTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            int lastCommand = 0;

            target.m_powerCommand = 200000;
            target.m_brakeFailure = true;

            lastCommand = target.VelocityController();

            Assert.AreEqual(1, lastCommand);
            Assert.AreEqual(200000, target.m_powerCommand);

            target.EmergencyBrake = true;
            target.m_brakeFailure = false;

            lastCommand = target.VelocityController();

            Assert.AreEqual(1, lastCommand);
            Assert.AreEqual(200000, target.m_powerCommand);

            target.EmergencyBrake = false;
            target.m_currentIntegral = 0;
            target.m_currentSample = 0;
            target.m_setPoint = 0;
            target.m_currentState.Speed = 0;

            lastCommand = target.VelocityController();

            Assert.AreEqual(0, lastCommand);
            Assert.AreEqual(0.0, target.m_lastIntegral);
            Assert.AreEqual(0.0, target.m_lastSample);
            Assert.AreEqual(0.0, target.m_currentSample);
            Assert.AreEqual(0.0, target.m_powerCommand);

            target.m_powerCommand = 200000;
            target.m_currentState.Speed = 100;

            lastCommand = target.VelocityController();

            Assert.AreEqual(2, lastCommand);
            Assert.AreEqual(-100.0, target.m_currentSample);
            Assert.AreEqual(200000, target.m_powerCommand);

            target.m_setPoint = 15;
            target.m_currentState.Speed = 0;
            lastCommand = target.VelocityController();

            Assert.AreEqual(3, lastCommand);
            Assert.AreEqual(120000, target.m_powerCommand);
        }

        /// <summary>
        ///A test for LocationX
        ///</summary>
        [TestMethod()]
        public void LocationXTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_currentState.X = 123.456;

            Assert.AreEqual(123.456, target.LocationX);
        }

        /// <summary>
        ///A test for LocationY
        ///</summary>
        [TestMethod()]
        public void LocationYTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_currentState.Y = 123.456;

            Assert.AreEqual(123.456, target.LocationY);
        }

        /// <summary>
        ///A test for ManualMode
        ///</summary>
        [TestMethod()]
        public void ManualModeTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.ManualMode = true;
            Assert.IsTrue(target.ManualMode);

            target.ManualMode = false;
            Assert.IsFalse(target.ManualMode);
        }

        /// <summary>
        ///A test for ManualSpeed
        ///</summary>
        [TestMethod()]
        public void ManualSpeedTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.ManualSpeed = 123.456;

            Assert.AreEqual(123.456, target.ManualSpeed);
        }

        /// <summary>
        ///A test for Speed
        ///</summary>
        [TestMethod()]
        public void SpeedTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_currentState.Speed = 10.0;

            Assert.AreEqual(36.0, target.Speed);
        }

        /// <summary>
        ///A test for SystemController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void SystemControllerTest2()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(0, 0), 100, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block0", "Block2");
            startingBlock.NextBlock = new TrackBlock("Block2", TrackOrientation.EastWest, new Point(100, 0), 100, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block1", "Block3");
            startingBlock.Authority = new BlockAuthority(50, 1);
            startingBlock.NextBlock.Authority = new BlockAuthority(50, 0);
            startingBlock.NextBlock.NextBlock = new TrackBlock("Block3", TrackOrientation.EastWest, new Point(200, 0), 100, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block2", "Block4");

            startingBlock.Transponder = new Transponder("station1", 1);
            startingBlock.NextBlock.Transponder = new Transponder("station1", 0);

            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);

            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            Queue<ScheduleInfo> routeInfo = new Queue<ScheduleInfo>();
            routeInfo.Enqueue(new ScheduleInfo("station123", 1));
            target.Schedule = routeInfo;

            int BRAKE = 2;
            int POWER = 3;
            int NONE = 0;

            target.m_setPoint = 50;
            target.m_currentState.Speed = Double.MinValue;
            target.SystemController(0.001);
            Assert.AreEqual(POWER, target.m_lastCommand);

            target.m_setPoint = 50;
            target.m_currentState.Speed = -25 / 3.6;
            target.SystemController(0.001);
            Assert.AreEqual(POWER, target.m_lastCommand);

            target.m_setPoint = 50;
            target.m_currentState.Speed = 0;
            target.SystemController(0.001);
            Assert.AreEqual(POWER, target.m_lastCommand);

            target.m_setPoint = 50;
            target.m_currentState.Speed = 25 / 3.6;
            target.SystemController(0.001);
            Assert.AreEqual(POWER, target.m_lastCommand);

            target.m_setPoint = 50;
            target.m_currentState.Speed = 50 / 3.6;
            target.SystemController(0.001);
            Assert.AreEqual(NONE, target.m_lastCommand);

            target.m_setPoint = 50;
            target.m_currentState.Speed = 75 / 3.6;
            target.SystemController(0.001);
            Assert.AreEqual(BRAKE, target.m_lastCommand);

            target.m_setPoint = 50;
            target.m_currentState.Speed = Double.MaxValue;
            target.SystemController(0.001);
            Assert.AreEqual(BRAKE, target.m_lastCommand);
        }

        /// <summary>
        ///A test for SystemController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void SystemControllerTest3()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(0, 0), 100, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block0", "Block2");
            startingBlock.NextBlock = new TrackBlock("Block2", TrackOrientation.EastWest, new Point(100, 0), 100, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block1", "Block3");
            startingBlock.Authority = new BlockAuthority(70, 1);
            startingBlock.NextBlock.Authority = new BlockAuthority(70, 0);
            startingBlock.NextBlock.NextBlock = new TrackBlock("Block3", TrackOrientation.EastWest, new Point(200, 0), 100, 0, 0, true, false, 70, TrackAllowedDirection.Both, false, "controller1", "controller2", "Block2", "Block4");

            startingBlock.Transponder = new Transponder("station1", 1);
            startingBlock.NextBlock.Transponder = new Transponder("station1", 0);

            ITrain myTrain = new Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);

            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            Queue<ScheduleInfo> routeInfo = new Queue<ScheduleInfo>();
            routeInfo.Enqueue(new ScheduleInfo("station123", 1));
            target.Schedule = routeInfo;

            target.EmergencyBrake = false;
            target.m_currentBlock.Authority = new BlockAuthority(50, Int32.MinValue);
            target.SystemController(0.001);
            Assert.AreEqual(50 / 3.6, target.m_setPoint);
            Assert.IsTrue(target.EmergencyBrake);

            target.EmergencyBrake = false;
            target.m_currentBlock.Authority = new BlockAuthority(50, -5);
            target.SystemController(0.001);
            Assert.AreEqual(50 / 3.6, target.m_setPoint);
            Assert.IsTrue(target.EmergencyBrake);

            target.EmergencyBrake = false;
            target.m_currentBlock.Authority = new BlockAuthority(50, -1);
            target.SystemController(0.001);
            Assert.AreEqual(50 / 3.6, target.m_setPoint);
            Assert.IsTrue(target.EmergencyBrake);

            // If the authority is zero but the train has more than enough stopping distance,
            // the setpoint should not be set to zero
            target.EmergencyBrake = false;
            target.m_currentState.Speed = 50 / 3.6;
            target.m_currentBlock.Authority = new BlockAuthority(50, 0);
            target.SystemController(0.001);
            Assert.AreEqual(50.0 / 3.6, target.m_setPoint);

            // If the authority is zero and the train does not have enough stopping distance,
            // the setpoint should be set to zero
            target.m_currentState.Speed = 70 / 3.6;
            target.m_currentBlock.LengthMeters = 10;
            target.SystemController(0.001);
            Assert.AreEqual(0.0, target.m_setPoint);

            // If the authority is zero and the train has stopped,
            // the setpoint should be set to zero
            target.EmergencyBrake = false;
            target.m_currentState.Speed = 0;
            target.m_currentBlock.LengthMeters = 1000;
            target.m_currentBlock.Authority = new BlockAuthority(50, 0);
            target.SystemController(0.001);
            Assert.AreEqual(0, target.m_setPoint);

            target.m_currentBlock.Authority = new BlockAuthority(50, 1);
            target.SystemController(0.001);
            Assert.AreEqual(50.0 / 3.6, target.m_setPoint);

            target.m_currentBlock.Authority = new BlockAuthority(50, 5);
            target.SystemController(0.001);
            Assert.AreEqual(50.0 / 3.6, target.m_setPoint);

            target.m_currentBlock.Authority = new BlockAuthority(50, Int32.MaxValue);
            target.SystemController(0.001);
            Assert.AreEqual(50.0 / 3.6, target.m_setPoint);
        }
    }
}
