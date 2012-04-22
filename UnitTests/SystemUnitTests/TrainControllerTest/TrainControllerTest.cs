﻿using TrainControllerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Train;
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
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
        ///A test for ControlLaw
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void ControlLawTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_powerCommand = 0;
            target.m_samplePeriod = 0.001;
            target.m_currentSample = 0;
            target.m_lastSample = 0;
            target.m_currentSample = 0;
            target.m_lastIntegral = 0;
            target.ControlLaw();
            Assert.AreEqual(0, target.m_powerCommand);

            target.m_currentSample = -100000000;
            target.ControlLaw();
            Assert.AreEqual(0, target.m_powerCommand);

            target.m_currentSample = 100000000;
            target.ControlLaw();
            Assert.AreEqual(120000, target.m_powerCommand);

            target.m_currentSample = 0.1;
            target.ControlLaw();
            Assert.AreEqual(100000, target.m_powerCommand);

            target.m_powerCommand = 120000;
            target.m_currentSample = 0;
            target.m_lastIntegral = 1;
            target.ControlLaw();
            Assert.AreEqual(10000, target.m_powerCommand);

            target.m_powerCommand = 0;
            target.m_currentSample = 0;
            target.m_lastSample = 2000;
            target.ControlLaw();
            Assert.AreEqual(20000, target.m_powerCommand);
        }

        /// <summary>
        ///A test for DetermineSetPoint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void DetermineSetPointTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_currentBlock.Authority = new BlockAuthority(0, 0);
            target.m_currentBlock.NextBlock = new TrackBlock("nextBlock", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "Block1", "nextBlock2");
            target.m_currentBlock.NextBlock.Authority = new BlockAuthority(100, 0);

            target.m_setPoint = 0;
            target.ManualMode = true;
            target.ManualSpeed = -1;
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
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_stoppingTheTrain = true;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_stoppingTheTrain = true;
            target.m_currentState.Speed = 1;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_stoppingTheTrain = false;
            target.m_currentState.Speed = 1;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_stoppingTheTrain = true;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.ManualMode = false;
            target.m_currentBlock.Authority.Authority = 0;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_stoppingTheTrain = false;
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
            target.m_stoppingTheTrain = false;
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
            target.m_stoppingTheTrain = false;
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
            target.m_stoppingTheTrain = false;
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
            target.m_stoppingTheTrain = false;
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
            target.m_stoppingTheTrain = false;
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_setPoint = 10.0;
            target.m_currentState.CurrentBlock.PowerFailure = false;
            target.m_currentState.CurrentBlock.TrackCircuitFailure = false;
            target.m_currentState.EngineFailure = false;
            target.m_currentState.BrakeFailure = false;

            target.FaultMonitor();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 10.0;
            target.m_currentState.CurrentBlock.PowerFailure = true;

            target.FaultMonitor();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 10.0;
            target.m_currentState.CurrentBlock.PowerFailure = false;
            target.m_currentState.CurrentBlock.TrackCircuitFailure = true;

            target.FaultMonitor();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 10.0;
            target.m_currentState.CurrentBlock.TrackCircuitFailure = false;
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            Queue<ScheduleInfo> routeInfo = new Queue<ScheduleInfo>();
            routeInfo.Enqueue(new ScheduleInfo("station123", 1));
            target.m_routeInfo = routeInfo;

            target.LeaveStation();

            Assert.AreEqual(TrainState.Door.Closed, target.m_currentState.Doors);
            Assert.IsFalse(target.m_doorsOpen);
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
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
        ///A test for SetSchedule
        ///</summary>
        [TestMethod()]
        public void SetScheduleTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            Queue<ScheduleInfo> routeInfo = new Queue<ScheduleInfo>();
            routeInfo.Enqueue(new ScheduleInfo("station123", 1));

            target.SetSchedule(routeInfo);

            Assert.AreEqual(routeInfo, target.m_routeInfo);
        }

        /// <summary>
        ///A test for StationController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void StationControllerTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            myTrainController.TrainAtStation += new OnTrainAtStation(myTrainController_TrainAtStation);

            Queue<ScheduleInfo> routeInfo = new Queue<ScheduleInfo>();
            routeInfo.Enqueue(new ScheduleInfo("station123", 1));
            target.m_routeInfo = routeInfo;

            target.m_nextStationInfo = new ScheduleInfo("stationABC", 1);

            station = "";
            target.m_approachingStation = false;
            target.m_currentBlock.Transponder = null;
            target.m_currentState.Speed = 10;
            target.m_atStation = false;
            target.m_timePassed = 1;
            target.m_doorsOpen = false;
            target.m_currentState.Passengers = -1;

            target.StationController();

            Assert.AreEqual("", station);
            Assert.IsFalse(target.m_approachingStation);
            Assert.IsFalse(target.m_atStation);
            Assert.AreEqual(1.0, target.m_timePassed);
            Assert.IsFalse(target.m_doorsOpen);
            Assert.AreEqual("stationABC", target.m_nextStationInfo.StationName);
            Assert.AreEqual(-1, target.m_currentState.Passengers);

            target.m_currentBlock.Transponder = new Transponder("station456", 1);

            target.StationController();

            Assert.AreEqual("", station);
            Assert.IsTrue(target.m_approachingStation);
            Assert.IsFalse(target.m_atStation);
            Assert.AreEqual(1.0, target.m_timePassed);
            Assert.IsFalse(target.m_doorsOpen);
            Assert.AreEqual("stationABC", target.m_nextStationInfo.StationName);
            Assert.AreEqual(-1, target.m_currentState.Passengers);

            target.m_currentBlock.Transponder = new Transponder("station456", 0);
            target.m_approachingStation = true;
            target.m_currentState.Speed = 0;

            target.StationController();

            Assert.AreEqual("station456", station);
            Assert.IsFalse(target.m_approachingStation);
            Assert.IsTrue(target.m_atStation);
            Assert.AreEqual(1.0, target.m_timePassed);
            Assert.IsTrue(target.m_doorsOpen);
            Assert.AreEqual("stationABC", target.m_nextStationInfo.StationName);
            Assert.IsTrue(target.m_currentState.Passengers >= 0);

            station = "";
            target.m_timePassed = 60;

            target.StationController();

            Assert.AreEqual("", station);
            Assert.IsFalse(target.m_approachingStation);
            Assert.IsFalse(target.m_atStation);
            Assert.AreEqual(0.0, target.m_timePassed);
            Assert.IsFalse(target.m_doorsOpen);
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            startingBlock.Authority.Authority = -1;
            startingBlock.Transponder = new Transponder("station456", 1);
            startingBlock.NextBlock = new TrackBlock("nextBlock", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "Block1", "nextBlock2");
            startingBlock.NextBlock.Authority = new BlockAuthority(100, 0);
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
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
            target.m_doorsOpen = true;

            target.SystemController(0.001);

            Assert.AreEqual(0.001, target.m_samplePeriod);
            Assert.AreEqual(1.001, target.m_timePassed);
            Assert.AreEqual(startingBlock, target.m_currentBlock);
            Assert.AreEqual(0.0, target.m_setPoint);
            Assert.IsTrue(target.m_brakeFailure);
            Assert.AreEqual(200000, target.m_powerCommand);
            Assert.IsTrue(target.m_inTunnel);
            Assert.IsTrue(target.m_approachingStation);
            Assert.IsTrue(target.m_doorsOpen);

            target.m_samplePeriod = 0;
            Queue<ScheduleInfo> routeInfo = new Queue<ScheduleInfo>();
            routeInfo.Enqueue(new ScheduleInfo("station123", 1));
            target.m_routeInfo = routeInfo;

            target.SystemController(0.002);

            Assert.AreEqual(0.002, target.m_samplePeriod);
            Assert.AreEqual(0.002, target.m_timePassed);
            Assert.AreEqual(startingBlock, target.m_currentBlock);
            Assert.AreEqual(0.0, target.m_setPoint);
            Assert.IsTrue(target.m_brakeFailure);
            Assert.AreEqual(200000, target.m_powerCommand);
            Assert.IsTrue(target.m_inTunnel);
            Assert.IsTrue(target.m_approachingStation);
            Assert.IsFalse(target.m_doorsOpen);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_powerCommand = 200000;
            target.m_brakeFailure = true;

            target.VelocityController();

            Assert.AreEqual(200000, target.m_powerCommand);

            target.m_brakeFailure = false;
            target.m_currentIntegral = 0;
            target.m_currentSample = 0;
            target.m_setPoint = 0;
            target.m_currentState.Speed = 0;

            target.VelocityController();

            Assert.AreEqual(0.0, target.m_lastIntegral);
            Assert.AreEqual(0.0, target.m_lastSample);
            Assert.AreEqual(0.0, target.m_currentSample);
            Assert.AreEqual(0.0, target.m_powerCommand);

            target.m_powerCommand = 200000;
            target.m_currentState.Speed = 100;

            target.VelocityController();

            Assert.AreEqual(-100.0, target.m_currentSample);
            Assert.AreEqual(200000, target.m_powerCommand);
        }

        /// <summary>
        ///A test for LocationX
        ///</summary>
        [TestMethod()]
        public void LocationXTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
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
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_currentState.Speed = 10.0;

            Assert.AreEqual(36.0, target.Speed);
        }
    }
}
