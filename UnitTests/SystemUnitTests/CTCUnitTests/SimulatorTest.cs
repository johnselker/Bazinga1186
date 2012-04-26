using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Timers;
using TrainControllerLib;
using CommonLib;
using TrainLib;
using ClassStubs;
using System.Collections.Generic;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for SimulatorTest and is intended
    ///to contain all SimulatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SimulatorTest
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
        ///A test for Simulator Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void SimulatorConstructorTest()
        {
            Simulator_Accessor target = new Simulator_Accessor();

            Assert.IsNotNull(target.m_log);
            Assert.IsFalse(target.m_running);
            Assert.AreEqual(1, target.m_simulationScale);
            Assert.IsNotNull(target.m_simulationTimer);
            Assert.IsNotNull(target.m_startingDirections);
            Assert.AreEqual(2, target.m_startingDirections.Count);
            Assert.IsNotNull(target.m_trainControllerList);
        }

        /// <summary>
        ///A test for GetSimulator
        ///</summary>
        [TestMethod()]
        public void GetSimulatorTest_singletonCheck()
        {
            Simulator expected = Simulator.GetSimulator();
            Simulator actual = Simulator.GetSimulator();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OnSimulationTimerElapsed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnSimulationTimerElapsedTest()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            object sender = null;
            ElapsedEventArgs e = null;
            target.m_lastUpdateTime = DateTime.Now;
            target.OnSimulationTimerElapsed(sender, e);
            //Make sure the time updates within the minute
            //Chances of the minute rolling over in the middle of the test are slim
            Assert.AreEqual(DateTime.Now.Minute, target.m_lastUpdateTime.Minute);
        }

        /// <summary>
        ///A test for OnTrainAtStation
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainAtStationTest()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            ITrainController train = new TrainControllerStub();
            target.m_trainControllerList.Add(train);
            string stationName = "YARD";
            target.OnTrainAtStation(train, stationName);

            Assert.AreEqual(0, target.m_trainControllerList.Count);
        }

        /// <summary>
        ///A test for OnTrainAtStation
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainAtStationTest_notYard()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            ITrainController train = new TrainControllerStub();
            target.m_trainControllerList.Add(train);
            string stationName = "station1"; 
            target.OnTrainAtStation(train, stationName);

            Assert.AreEqual(1, target.m_trainControllerList.Count);
        }

        ///A test for OnTrainAtStation
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainAtStationTest_null()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            ITrainController train = new TrainControllerStub();
            target.m_trainControllerList.Add(train);
            string stationName = null;
            target.OnTrainAtStation(null, stationName);

            Assert.AreEqual(1, target.m_trainControllerList.Count);
        }

        /// <summary>
        ///A test for PauseSimulation
        ///</summary>
        [TestMethod()]
        public void PauseSimulationTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); 
            target.PauseSimulation();
            Assert.IsFalse(target.m_running);
        }

        /// <summary>
        ///A test for SetSimulationSpeed
        ///</summary>
        [TestMethod()]
        public void SetSimulationSpeedTest()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            double scale = 1;
            bool expected = true;
            bool actual;
            actual = target.SetSimulationSpeed(scale);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(scale, target.m_simulationScale);
        }


        /// <summary>
        ///A test for SetSimulationSpeed
        ///</summary>
        [TestMethod()]
        public void SetSimulationSpeedTest_lowerBound()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            double scale = 1;
            bool expected = true;
            bool actual;
            actual = target.SetSimulationSpeed(scale);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(scale, target.m_simulationScale);
        }

        /// <summary>
        ///A test for SetSimulationSpeed
        ///</summary>
        [TestMethod()]
        public void SetSimulationSpeedTest_upperBound()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            double scale = 99;
            bool expected = true;
            bool actual;
            actual = target.SetSimulationSpeed(scale);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(scale, target.m_simulationScale);
        }

        /// <summary>
        ///A test for SetSimulationSpeed
        ///</summary>
        [TestMethod()]
        public void SetSimulationSpeedTest_lowBad()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            double scale = 0;
            bool expected = false;
            bool actual;
            actual = target.SetSimulationSpeed(scale);
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(scale, target.m_simulationScale);
        }

        /// <summary>
        ///A test for SetSimulationSpeed
        ///</summary>
        [TestMethod()]
        public void SetSimulationSpeedTest_highBad()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            double scale = 100;
            bool expected = false;
            bool actual;
            actual = target.SetSimulationSpeed(scale);
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(scale, target.m_simulationScale);
        }

        /// <summary>
        ///A test for SpawnNewTrain
        ///</summary>
        [TestMethod()]
        public void SpawnNewTrainTest()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            TrackBlock block = new TrackBlock();
            block.Transponder = new Transponder("REDYARD", 0);
            string name = "train"; 
            target.SpawnNewTrain(block, name);
            Assert.AreEqual(1, target.m_trainControllerList.Count);
        }

        /// <summary>
        ///A test for SpawnNewTrain
        ///</summary>
        [TestMethod()]
        public void SpawnNewTrainTest_badBlock()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            TrackBlock block = new TrackBlock();
            block.Transponder = new Transponder("BLOCK", 0);
            string name = "train";
            target.SpawnNewTrain(block, name);
            Assert.AreEqual(0, target.m_trainControllerList.Count);
        }

        /// <summary>
        ///A test for SpawnNewTrain
        ///</summary>
        [TestMethod()]
        public void SpawnNewTrainTest_nullBlock()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            TrackBlock block = null;
            string name = "train";
            target.SpawnNewTrain(block, name);
            Assert.AreEqual(0, target.m_trainControllerList.Count);
        }

        /// <summary>
        ///A test for SpawnNewTrain
        ///</summary>
        [TestMethod()]
        public void SpawnNewTrainTest_nullTransponder()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            TrackBlock block = new TrackBlock();
            block.Transponder = null;
            string name = "train";
            target.SpawnNewTrain(block, name);
            Assert.AreEqual(0, target.m_trainControllerList.Count);
        }

        /// <summary>
        ///A test for StartSimulation
        ///</summary>
        [TestMethod()]
        public void StartSimulationTest()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            target.StartSimulation();
            Assert.IsTrue(target.m_running);
            //Make sure the time updates within the minute
            //Chances of the minute rolling over in the middle of the test are slim
            Assert.AreEqual(DateTime.Now.Minute, target.m_lastUpdateTime.Minute);
            Assert.IsNotNull(target.m_trackControllerList);
        }

        /// <summary>
        ///A test for StopSimulation
        ///</summary>
        [TestMethod()]
        public void StopSimulationTest()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            target.m_trainControllerList.Add(new TrainControllerStub());
            target.m_trackControllerList = new List<TrackControlLib.Sean.ITrackController>(){new TrackControllerStub()};
            target.StopSimulation();
            Assert.IsFalse(target.m_running);
            Assert.AreEqual(0, target.m_trainControllerList.Count);
            Assert.AreEqual(0, target.m_trackControllerList.Count);
        }

        /// <summary>
        ///A test for SimulationRunning
        ///</summary>
        [TestMethod()]
        public void SimulationRunningTest_false()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            bool expected = target.m_running;
            bool actual = target.SimulationRunning;
            Assert.AreEqual(expected, actual);
        }

        ///A test for SimulationRunning
        ///</summary>
        [TestMethod()]
        public void SimulationRunningTest_true()
        {
            Simulator_Accessor target = new Simulator_Accessor();
            bool expected = target.m_running = true;
            bool actual = target.SimulationRunning;
            Assert.AreEqual(expected, actual);
        }
    }
}
