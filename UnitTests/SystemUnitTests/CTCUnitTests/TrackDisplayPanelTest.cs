using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using System.Drawing;
using System.Collections.Generic;
using TrainLib;

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
        ///A test for TrackDisplayPanel Constructor
        ///</summary>
        [TestMethod()]
        public void TrackDisplayPanelConstructorTest()
        {
            TrackDisplayPanel target = new TrackDisplayPanel();
            Assert.Inconclusive("TODO: Implement code to verify target");
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
            Point layoutPosition = new Point(); // TODO: Initialize to an appropriate value
            int arrowLength = 0; // TODO: Initialize to an appropriate value
            Point expected = new Point(); // TODO: Initialize to an appropriate value
            Point actual;
            actual = target.CalculateBlockPosition(block, layoutPosition, arrowLength);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CalculateScale
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CalculateScaleTest()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            Size layoutSize = new Size(); // TODO: Initialize to an appropriate value
            target.CalculateScale(layoutSize);
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
        ///A test for OnTrainDisposed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainDisposedTest()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnTrainDisposed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
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
        ///A test for SetTrackLayout
        ///</summary>
        [TestMethod()]
        public void SetTrackLayoutTest()
        {
            TrackDisplayPanel target = new TrackDisplayPanel(); // TODO: Initialize to an appropriate value
            List<TrackBlock> blocks = null; // TODO: Initialize to an appropriate value
            Size layoutSize = new Size(); // TODO: Initialize to an appropriate value
            Point layoutPosition = new Point(); // TODO: Initialize to an appropriate value
            target.SetTrackLayout(blocks, layoutSize, layoutPosition);
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
        ///A test for TrackDisplayPanel Constructor
        ///</summary>
        [TestMethod()]
        public void TrackDisplayPanelConstructorTest1()
        {
            TrackDisplayPanel target = new TrackDisplayPanel();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CalculateBlockPosition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CalculateBlockPositionTest1()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            Point layoutPosition = new Point(); // TODO: Initialize to an appropriate value
            int arrowLength = 0; // TODO: Initialize to an appropriate value
            Point expected = new Point(); // TODO: Initialize to an appropriate value
            Point actual;
            actual = target.CalculateBlockPosition(block, layoutPosition, arrowLength);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CalculateScale
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CalculateScaleTest1()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            Size layoutSize = new Size(); // TODO: Initialize to an appropriate value
            target.CalculateScale(layoutSize);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest1()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest1()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnBlinkTimerTick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnBlinkTimerTickTest1()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnBlinkTimerTick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnBlockClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnBlockClickedTest1()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnBlockClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnTrainDisposed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainDisposedTest1()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnTrainDisposed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnTrainGraphicClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainGraphicClickedTest1()
        {
            TrackDisplayPanel_Accessor target = new TrackDisplayPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnTrainGraphicClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetTrackLayout
        ///</summary>
        [TestMethod()]
        public void SetTrackLayoutTest1()
        {
            TrackDisplayPanel target = new TrackDisplayPanel(); // TODO: Initialize to an appropriate value
            List<TrackBlock> blocks = null; // TODO: Initialize to an appropriate value
            Size layoutSize = new Size(); // TODO: Initialize to an appropriate value
            Point layoutPosition = new Point(); // TODO: Initialize to an appropriate value
            target.SetTrackLayout(blocks, layoutSize, layoutPosition);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnselectAll
        ///</summary>
        [TestMethod()]
        public void UnselectAllTest1()
        {
            TrackDisplayPanel target = new TrackDisplayPanel(); // TODO: Initialize to an appropriate value
            target.UnselectAll();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateDisplay
        ///</summary>
        [TestMethod()]
        public void UpdateDisplayTest1()
        {
            TrackDisplayPanel target = new TrackDisplayPanel(); // TODO: Initialize to an appropriate value
            List<TrackBlock> updatedBlocks = null; // TODO: Initialize to an appropriate value
            List<ITrain> trains = null; // TODO: Initialize to an appropriate value
            target.UpdateDisplay(updatedBlocks, trains);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
