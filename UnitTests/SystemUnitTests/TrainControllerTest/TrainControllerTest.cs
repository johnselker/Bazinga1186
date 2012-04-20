using TrainControllerLib;
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
            Assert.AreEqual(startingBlock, target.m_currentBlock);
            Assert.AreEqual(myTrain.GetState(), target.m_currentState);
            Assert.AreEqual(myTrain.GetState().TrainID, target.m_trainID);
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
        ///A test for CallSystemController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void CallSystemControllerTest()
        {
            TrackBlock startingBlock = new TrackBlock("Block1", TrackOrientation.EastWest, new Point(123, 456), 100, 50, 1, true, false, 70, TrackAllowedDirection.Both, null, "controller1", "controller2", "previousBlock", "nextBlock");
            ITrain myTrain = new Train.Train("train1", startingBlock, Direction.East);
            TrainController myTrainController = new TrainController(myTrain);
            PrivateObject param0 = new PrivateObject(myTrainController);
            TrainController_Accessor target = new TrainController_Accessor(param0);

            target.m_samplePeriod = 0.02;

            Timer myTimer = new Timer();
            myTimer.Elapsed += new ElapsedEventHandler(target.CallSystemController);
            myTimer.Interval = 1;
            myTimer.Start();
            int i = 0;
            while (target.m_samplePeriod == 0.02 && i < 1000000000)
            {
                i++;
            }
            Assert.AreEqual(0.001, target.m_samplePeriod);
            myTimer.Stop();
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
            target.m_manualMode = true;
            target.m_manualSpeed = -1;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 0;
            target.m_manualMode = true;
            target.m_manualSpeed = 72;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 0;
            target.m_manualMode = true;
            target.m_manualSpeed = 72;
            target.m_currentBlock.Authority.SpeedLimitKPH = 80;
            target.DetermineSetPoint();
            Assert.AreEqual(20.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.m_manualMode = false;
            target.m_currentBlock.Authority.SpeedLimitKPH = -36;
            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.m_manualMode = false;
            target.m_currentBlock.Authority.Authority = -36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.m_manualMode = false;
            target.m_stoppingTheTrain = true;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.m_manualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_stoppingTheTrain = true;
            target.m_currentState.Speed = 1;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.m_manualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_stoppingTheTrain = false;
            target.m_currentState.Speed = 1;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.m_manualMode = false;
            target.m_currentBlock.Authority.Authority = 36;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_stoppingTheTrain = true;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(10.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.m_manualMode = false;
            target.m_currentBlock.Authority.Authority = 0;
            target.m_currentBlock.Authority.SpeedLimitKPH = 36;
            target.m_stoppingTheTrain = false;
            target.m_currentState.Speed = 10;
            target.m_currentBlock.LengthMeters = 0;
            target.m_currentState.BlockProgress = 100;
            target.DetermineSetPoint();
            Assert.AreEqual(0.0, target.m_setPoint);

            target.m_setPoint = 20.0;
            target.m_manualMode = false;
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
            target.m_manualMode = false;
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
        }

        /// <summary>
        ///A test for FaultMonitor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void FaultMonitorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainController_Accessor target = new TrainController_Accessor(param0); // TODO: Initialize to an appropriate value
            target.FaultMonitor();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetState
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void GetStateTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainController_Accessor target = new TrainController_Accessor(param0); // TODO: Initialize to an appropriate value
            target.GetState();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LeaveStation
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void LeaveStationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainController_Accessor target = new TrainController_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.LeaveStation(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LightController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void LightControllerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainController_Accessor target = new TrainController_Accessor(param0); // TODO: Initialize to an appropriate value
            target.LightController();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetSchedule
        ///</summary>
        [TestMethod()]
        public void SetScheduleTest()
        {
            ITrain myTrain = null; // TODO: Initialize to an appropriate value
            TrainController target = new TrainController(myTrain); // TODO: Initialize to an appropriate value
            Queue<ScheduleInfo> routeInfo = null; // TODO: Initialize to an appropriate value
            target.SetSchedule(routeInfo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StationController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void StationControllerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainController_Accessor target = new TrainController_Accessor(param0); // TODO: Initialize to an appropriate value
            target.StationController();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SystemController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void SystemControllerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainController_Accessor target = new TrainController_Accessor(param0); // TODO: Initialize to an appropriate value
            double samplePeriod = 0F; // TODO: Initialize to an appropriate value
            target.SystemController(samplePeriod);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            ITrain myTrain = null; // TODO: Initialize to an appropriate value
            TrainController target = new TrainController(myTrain); // TODO: Initialize to an appropriate value
            double dt = 0F; // TODO: Initialize to an appropriate value
            target.Update(dt);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for VelocityController
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrainControllerLib.dll")]
        public void VelocityControllerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainController_Accessor target = new TrainController_Accessor(param0); // TODO: Initialize to an appropriate value
            target.VelocityController();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LocationX
        ///</summary>
        [TestMethod()]
        public void LocationXTest()
        {
            ITrain myTrain = null; // TODO: Initialize to an appropriate value
            TrainController target = new TrainController(myTrain); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.LocationX;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LocationY
        ///</summary>
        [TestMethod()]
        public void LocationYTest()
        {
            ITrain myTrain = null; // TODO: Initialize to an appropriate value
            TrainController target = new TrainController(myTrain); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.LocationY;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ManualMode
        ///</summary>
        [TestMethod()]
        public void ManualModeTest()
        {
            ITrain myTrain = null; // TODO: Initialize to an appropriate value
            TrainController target = new TrainController(myTrain); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ManualMode = expected;
            actual = target.ManualMode;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ManualSpeed
        ///</summary>
        [TestMethod()]
        public void ManualSpeedTest()
        {
            ITrain myTrain = null; // TODO: Initialize to an appropriate value
            TrainController target = new TrainController(myTrain); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.ManualSpeed = expected;
            actual = target.ManualSpeed;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Speed
        ///</summary>
        [TestMethod()]
        public void SpeedTest()
        {
            ITrain myTrain = null; // TODO: Initialize to an appropriate value
            TrainController target = new TrainController(myTrain); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.Speed;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
