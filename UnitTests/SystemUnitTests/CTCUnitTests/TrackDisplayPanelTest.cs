using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using System.Collections.Generic;
using Train;
using System.Drawing;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for TrackDisplayPanelTest and is intended
    ///to contain all TrackDisplayPanelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TrackDisplayPanelTest
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
        ///A test for SetTrackLayout
        ///</summary>
        [TestMethod()]
        public void SetTrackLayoutTest()
        {
            TrackDisplayPanel target = new TrackDisplayPanel(); // TODO: Initialize to an appropriate value
            List<TrackBlock> blocks = null; // TODO: Initialize to an appropriate value
            target.SetTrackLayout(blocks);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnselectAll
        ///</summary>
        [TestMethod()]
        public void UnselectAllTest()
        {
            TrackDisplayPanel target = new TrackDisplayPanel(); // TODO: Initialize to an appropriate value
            target.UnselectAll();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateDisplay
        ///</summary>
        [TestMethod()]
        public void UpdateDisplayTest()
        {
            TrackDisplayPanel target = new TrackDisplayPanel(); // TODO: Initialize to an appropriate value
            List<TrackBlock> updatedBlocks = null; // TODO: Initialize to an appropriate value
            List<ITrain> trains = null; // TODO: Initialize to an appropriate value
            target.UpdateDisplay(updatedBlocks, trains);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ScaleFactor
        ///</summary>
        [TestMethod()]
        public void ScaleFactorTest()
        {
            TrackDisplayPanel target = new TrackDisplayPanel(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.ScaleFactor = expected;
            actual = target.ScaleFactor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OnTrainGraphicClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainGraphicClickedTest()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnTrainGraphicClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnBlockClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnBlockClickedTest()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnBlockClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnBlinkTimerTick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnBlinkTimerTickTest()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnBlinkTimerTick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CalculateBlockPosition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CalculateBlockPositionTest()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            Point expected = new Point(); // TODO: Initialize to an appropriate value
            Point actual;
            actual = target.CalculateBlockPosition(block);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddTrain
        ///</summary>
        [TestMethod()]
        public void AddTrainTest()
        {
            TrackDisplayPanel target = new TrackDisplayPanel(); // TODO: Initialize to an appropriate value
            ITrain train = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddTrain(train);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TrackDisplayPanel Constructor
        ///</summary>
        [TestMethod()]
        public void TrackDisplayPanelConstructorTest()
        {
            TrackDisplayPanel target = new TrackDisplayPanel();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for TrackDisplayPanel Constructor
        ///</summary>
        [TestMethod()]
        public void TrackDisplayPanelConstructorTest1()
        {
            List<TrackBlock> blocks = null; // TODO: Initialize to an appropriate value
            TrackDisplayPanel target = new TrackDisplayPanel(blocks);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
