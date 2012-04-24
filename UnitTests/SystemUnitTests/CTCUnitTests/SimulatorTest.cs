using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Timers;
using TrainControllerLib;
using Train;
using CommonLib;

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
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetSimulator
        ///</summary>
        [TestMethod()]
        public void GetSimulatorTest()
        {
            Simulator expected = null; // TODO: Initialize to an appropriate value
            Simulator actual;
            actual = Simulator.GetSimulator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OnSimulationTimerElapsed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnSimulationTimerElapsedTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            ElapsedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnSimulationTimerElapsed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnTrainAtStation
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainAtStationTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            ITrainController train = null; // TODO: Initialize to an appropriate value
            string stationName = string.Empty; // TODO: Initialize to an appropriate value
            target.OnTrainAtStation(train, stationName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PauseSimulation
        ///</summary>
        [TestMethod()]
        public void PauseSimulationTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            target.PauseSimulation();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetSimulationSpeed
        ///</summary>
        [TestMethod()]
        public void SetSimulationSpeedTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetSimulationSpeed(scale);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimulateBrakeFailure
        ///</summary>
        [TestMethod()]
        public void SimulateBrakeFailureTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            ITrain train = null; // TODO: Initialize to an appropriate value
            bool failure = false; // TODO: Initialize to an appropriate value
            target.SimulateBrakeFailure(train, failure);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SimulateBrokenRail
        ///</summary>
        [TestMethod()]
        public void SimulateBrokenRailTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            bool failure = false; // TODO: Initialize to an appropriate value
            target.SimulateBrokenRail(block, failure);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SimulateCircuitFailure
        ///</summary>
        [TestMethod()]
        public void SimulateCircuitFailureTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            bool failure = false; // TODO: Initialize to an appropriate value
            target.SimulateCircuitFailure(block, failure);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SimulateEngineFailure
        ///</summary>
        [TestMethod()]
        public void SimulateEngineFailureTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            ITrain train = null; // TODO: Initialize to an appropriate value
            bool failure = false; // TODO: Initialize to an appropriate value
            target.SimulateEngineFailure(train, failure);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SimulatePickupFailure
        ///</summary>
        [TestMethod()]
        public void SimulatePickupFailureTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            ITrain train = null; // TODO: Initialize to an appropriate value
            bool failure = false; // TODO: Initialize to an appropriate value
            target.SimulatePickupFailure(train, failure);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SimulatePowerFailure
        ///</summary>
        [TestMethod()]
        public void SimulatePowerFailureTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            bool failure = false; // TODO: Initialize to an appropriate value
            target.SimulatePowerFailure(block, failure);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SpawnNewTrain
        ///</summary>
        [TestMethod()]
        public void SpawnNewTrainTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock initialBlock = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            target.SpawnNewTrain(initialBlock, name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StartSimulation
        ///</summary>
        [TestMethod()]
        public void StartSimulationTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            target.StartSimulation();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StopSimulation
        ///</summary>
        [TestMethod()]
        public void StopSimulationTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            target.StopSimulation();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SimulationRunning
        ///</summary>
        [TestMethod()]
        public void SimulationRunningTest()
        {
            Simulator_Accessor target = new Simulator_Accessor(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SimulationRunning;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
