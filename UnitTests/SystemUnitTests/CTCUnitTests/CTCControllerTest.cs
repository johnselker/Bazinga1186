using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using TrackControlLib.Sean;
using System.Collections.Generic;
using System.Drawing;
using Train;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for CTCControllerTest and is intended
    ///to contain all CTCControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CTCControllerTest
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
        ///A test for GetTrackController
        ///</summary>
        [TestMethod()]
        public void GetTrackControllerTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            ITrackController expected = null; // TODO: Initialize to an appropriate value
            ITrackController actual;
            actual = target.GetTrackController(block);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRedlineSchedule
        ///</summary>
        [TestMethod()]
        public void GetRedlineScheduleTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            Queue<ScheduleInfo> expected = null; // TODO: Initialize to an appropriate value
            Queue<ScheduleInfo> actual;
            actual = target.GetRedlineSchedule();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetLayoutSize
        ///</summary>
        [TestMethod()]
        public void GetLayoutSizeTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            Size expected = new Size(); // TODO: Initialize to an appropriate value
            Size actual;
            actual = target.GetLayoutSize();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetLayoutPosition
        ///</summary>
        [TestMethod()]
        public void GetLayoutPositionTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            Point expected = new Point(); // TODO: Initialize to an appropriate value
            Point actual;
            actual = target.GetLayoutPosition();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetGreenlineSchedule
        ///</summary>
        [TestMethod()]
        public void GetGreenlineScheduleTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            Queue<ScheduleInfo> expected = null; // TODO: Initialize to an appropriate value
            Queue<ScheduleInfo> actual;
            actual = target.GetGreenlineSchedule();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCTCController
        ///</summary>
        [TestMethod()]
        public void GetCTCControllerTest()
        {
            CTCController expected = null; // TODO: Initialize to an appropriate value
            CTCController actual;
            actual = CTCController.GetCTCController();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBlockList
        ///</summary>
        [TestMethod()]
        public void GetBlockListTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            List<TrackBlock> expected = null; // TODO: Initialize to an appropriate value
            List<TrackBlock> actual;
            actual = target.GetBlockList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CloseTrackBlock
        ///</summary>
        [TestMethod()]
        public void CloseTrackBlockTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CloseTrackBlock(block);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuildLayout
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void BuildLayoutTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            List<TrackBlock> blocks = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.BuildLayout(blocks);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddTrainToList
        ///</summary>
        [TestMethod()]
        public void AddTrainToListTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            ITrain train = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddTrainToList(train);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CTCController Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CTCControllerConstructorTest()
        {
            CTCController_Accessor target = new CTCController_Accessor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetTrackControllerList
        ///</summary>
        [TestMethod()]
        public void GetTrackControllerListTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            List<ITrackController> expected = null; // TODO: Initialize to an appropriate value
            List<ITrackController> actual;
            actual = target.GetTrackControllerList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetTrainList
        ///</summary>
        [TestMethod()]
        public void GetTrainListTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            List<ITrain> expected = null; // TODO: Initialize to an appropriate value
            List<ITrain> actual;
            actual = target.GetTrainList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadTrackLayout
        ///</summary>
        [TestMethod()]
        public void LoadTrackLayoutTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            string filename = string.Empty; // TODO: Initialize to an appropriate value
            List<TrackBlock> expected = null; // TODO: Initialize to an appropriate value
            List<TrackBlock> actual;
            actual = target.LoadTrackLayout(filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OnUpdateTimerTick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnUpdateTimerTickTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnUpdateTimerTick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OpenTrackBlock
        ///</summary>
        [TestMethod()]
        public void OpenTrackBlockTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.OpenTrackBlock(block);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveTrainFromList
        ///</summary>
        [TestMethod()]
        public void RemoveTrainFromListTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            ITrain train = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RemoveTrainFromList(train);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetAuthority
        ///</summary>
        [TestMethod()]
        public void SetAuthorityTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            string value = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetAuthority(block, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetSpeedLimit
        ///</summary>
        [TestMethod()]
        public void SetSpeedLimitTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            string value = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetSpeedLimit(block, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Subscribe
        ///</summary>
        [TestMethod()]
        public void SubscribeTest()
        {
            CTCController_Accessor target = new CTCController_Accessor(); // TODO: Initialize to an appropriate value
            CTCController.UpdateDisplay updateDelegate = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Subscribe(updateDelegate);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
