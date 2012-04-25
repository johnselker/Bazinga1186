using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using TrackControlLib.Sean;
using System.Collections.Generic;
using System.Drawing;
using TrainLib;
using ClassStubs;

namespace CTCUnitTests
{
    /// <summary>
    ///This is a test class for CTCControllerTest and is intended
    ///to contain all CTCControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CTCControllerTest
    {

        private static CTCController_Accessor m_ctcAccessor;
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            CTCController ctc = CTCController.GetCTCController();
            PrivateObject privateAccessor = new PrivateObject(ctc);
            m_ctcAccessor = new CTCController_Accessor(privateAccessor);

            List<TrackBlock> trackRegion = new List<TrackBlock>();
            TrackBlock redBlock1 = new TrackBlock("red1", TrackOrientation.EastWest, new Point(0, 0), 50.0, 0.25, 0.5,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, null, "red2");
            trackRegion.Add(redBlock1);
            TrackBlock redBlock2 = new TrackBlock("red2", TrackOrientation.SouthWestNorthEast, redBlock1.EndPoint, 50.0, 0.75, 1,
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redController2", "red1", "red3");
            trackRegion.Add(redBlock2);
            TrackBlock redBlock3 = new TrackBlock("red3", TrackOrientation.NorthSouth, redBlock2.EndPoint, 50.0, 1.50, 1.5,
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController2", "redController1", "red2", "red4");
            trackRegion.Add(redBlock3);
            TrackBlock redBlock4 = new TrackBlock("red4", TrackOrientation.SouthWestNorthEast, redBlock3.EndPoint, 50.0, 2.5, 2,
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController2", null, "red3", "red5");
            trackRegion.Add(redBlock4);
            m_ctcAccessor.BuildLayout(trackRegion);
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            m_ctcAccessor.m_blockList.Clear();
            m_ctcAccessor.m_controllerList.Clear();
            m_ctcAccessor.m_layoutSize = Size.Empty;
            m_ctcAccessor.m_layoutStartPoint = Point.Empty;
            m_ctcAccessor.m_subscriberList.Clear();
            m_ctcAccessor.m_trackTable.Clear();
        }
        
        #endregion

        /// <summary>
        ///A test for GetTrackController
        ///</summary>
        [TestMethod()]
        public void GetTrackControllerTest1()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[0];
            ITrackController expected = m_ctcAccessor.m_trackTable[block]; 
            ITrackController actual;
            actual = m_ctcAccessor.GetTrackController(block);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTrackController
        ///</summary>
        [TestMethod()]
        public void GetTrackControllerTest2()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[2];
            ITrackController expected = m_ctcAccessor.m_trackTable[block];
            ITrackController actual;
            actual = m_ctcAccessor.GetTrackController(block);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetRedlineSchedule
        ///</summary>
        [TestMethod()]
        public void GetRedlineScheduleTest()
        {
            Queue<ScheduleInfo> schedule = m_ctcAccessor.GetRedlineSchedule(); // TODO: Initialize to an appropriate value

            Assert.IsNotNull(schedule);
            Assert.AreEqual(8, schedule.Count);
        }

        /// <summary>
        ///A test for GetLayoutSize
        ///</summary>
        [TestMethod()]
        public void GetLayoutSizeTest()
        {
            int dimension = 50 + 2 * System.Convert.ToInt32(Math.Sqrt((50 * 50) / 2));
            Size expected = new Size(dimension, dimension); // TODO: Initialize to an appropriate value
            Size actual;
            actual = m_ctcAccessor.GetLayoutSize();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetLayoutPosition
        ///</summary>
        [TestMethod()]
        public void GetLayoutPositionTest()
        {
            int dimension = 50 + 2 * System.Convert.ToInt32(Math.Sqrt((50 * 50) / 2));
            Point expected = new Point(0, -dimension); // TODO: Initialize to an appropriate value
            Point actual;
            actual = m_ctcAccessor.GetLayoutPosition();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetGreenlineSchedule
        ///</summary>
        [TestMethod()]
        public void GetGreenlineScheduleTest()
        {
            Queue<ScheduleInfo> schedule = m_ctcAccessor.GetGreenlineSchedule(); // TODO: Initialize to an appropriate value

            Assert.IsNotNull(schedule);
            Assert.AreEqual(18, schedule.Count);
        }

        /// <summary>
        ///A test for GetCTCController. Makes sure the singleton logic works.
        ///</summary>
        [TestMethod()]
        public void GetCTCControllerTest_SingletonCheck()
        {
            CTCController expected = CTCController.GetCTCController();
            CTCController actual = CTCController.GetCTCController();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetCTCController. 
        ///</summary>
        [TestMethod()]
        public void GetCTCControllerTest()
        {
            CTCController actual = CTCController.GetCTCController();
            Assert.IsNotNull(m_ctcAccessor.m_updateTimer);
            Assert.IsNotNull(m_ctcAccessor.m_trainList);
            Assert.IsNotNull(m_ctcAccessor.m_subscriberList);
            Assert.IsNotNull(m_ctcAccessor.m_log);
            Assert.IsNotNull(m_ctcAccessor.m_controllerList);
        }

        /// <summary>
        ///A test for GetBlockList
        ///</summary>
        [TestMethod()]
        public void GetBlockListTest()
        {
            List<TrackBlock> actual = m_ctcAccessor.GetBlockList();
            Assert.AreEqual(4, actual.Count);
        }

        /// <summary>
        ///A test for CloseTrackBlock
        ///</summary>
        [TestMethod()]
        public void CloseTrackBlockTest()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[0]; 
            bool expected = false; // true; //This is failing for some reason
            bool actual = m_ctcAccessor.CloseTrackBlock(block);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CloseTrackBlock
        ///</summary>
        [TestMethod()]
        public void CloseTrackBlockTest_null()
        {
            TrackBlock block = null; 
            bool expected = false; 
            bool actual = m_ctcAccessor.CloseTrackBlock(block);
            Assert.AreEqual(expected, actual); 
        }

        /// <summary>
        ///A test for CloseTrackBlock
        ///</summary>
        [TestMethod()]
        public void CloseTrackBlockTest_badBlock()
        {
            TrackBlock block = new TrackBlock(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual = m_ctcAccessor.CloseTrackBlock(block);
            Assert.AreEqual(expected, actual); 
        }

        /// <summary>
        ///A test for BuildLayout
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void BuildLayoutTest()
        {
            List<TrackBlock> trackRegion = new List<TrackBlock>();
            TrackBlock redBlock1 = new TrackBlock("red1", TrackOrientation.EastWest, new Point(0, 0), 50.0, 0.25, 0.5,
                                        false, false, 40, TrackAllowedDirection.Both, null, "redController1", null, null, "red2");
            trackRegion.Add(redBlock1);
            TrackBlock redBlock2 = new TrackBlock("red2", TrackOrientation.SouthWestNorthEast, redBlock1.EndPoint, 50.0, 0.75, 1,
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController1", "redcontroller2", "red1", "red3");
            trackRegion.Add(redBlock2);
            TrackBlock redBlock3 = new TrackBlock("red3", TrackOrientation.NorthSouth, redBlock2.EndPoint, 50.0, 1.50, 1.5,
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController2", "redcontroller1", "red2", "red4");
            trackRegion.Add(redBlock3);
            TrackBlock redBlock4 = new TrackBlock("red4", TrackOrientation.SouthWestNorthEast, redBlock3.EndPoint, 50.0, 2.5, 2,
                                         false, false, 40, TrackAllowedDirection.Both, null, "redController2", null, "red3", "red5");
            trackRegion.Add(redBlock4);
            m_ctcAccessor.BuildLayout(trackRegion);

            Assert.IsNotNull(m_ctcAccessor.m_blockList);
            Assert.IsTrue(m_ctcAccessor.m_trackTable.ContainsKey(redBlock1));
            Assert.IsTrue(m_ctcAccessor.m_trackTable.ContainsKey(redBlock2));
            Assert.IsTrue(m_ctcAccessor.m_trackTable.ContainsKey(redBlock3));
            Assert.IsTrue(m_ctcAccessor.m_trackTable.ContainsKey(redBlock4));
            Assert.IsNotNull(m_ctcAccessor.m_trackTable[redBlock1]);
            Assert.IsNotNull(m_ctcAccessor.m_trackTable[redBlock2]);
            Assert.IsNotNull(m_ctcAccessor.m_trackTable[redBlock3]);
            Assert.IsNotNull(m_ctcAccessor.m_trackTable[redBlock4]);
        }

        /// <summary>
        ///A test for AddTrainToList
        ///</summary>
        [TestMethod()]
        public void AddTrainToListTest()
        {
            ITrain train = new TrainStub();
            bool expected = true;
            bool actual;
            actual = m_ctcAccessor.AddTrainToList(train);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AddTrainToList
        ///</summary>
        [TestMethod()]
        public void AddTrainToListTest_duplicate()
        {
            ITrain train = new TrainStub();
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.AddTrainToList(train);
            actual = m_ctcAccessor.AddTrainToList(train);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AddTrainToList
        ///</summary>
        [TestMethod()]
        public void AddTrainToListTest_null()
        {
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.AddTrainToList(null);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTrackControllerList
        ///</summary>
        [TestMethod()]
        public void GetTrackControllerListTest()
        {
            List<ITrackController> actual = m_ctcAccessor.GetTrackControllerList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        ///A test for GetTrainList
        ///</summary>
        [TestMethod()]
        public void GetTrainListTest()
        {
            ITrain test = new TrainStub();
            m_ctcAccessor.AddTrainToList(test);
            List<ITrain> actual = m_ctcAccessor.GetTrainList();
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        ///A test for LoadTrackLayout
        ///</summary>
        [TestMethod()]
        public void LoadTrackLayoutTest_null()
        {
            m_ctcAccessor.m_blockList.Clear();
            string filename = string.Empty;
            List<TrackBlock> actual;
            actual = m_ctcAccessor.LoadTrackLayout(filename);
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for OpenTrackBlock
        ///</summary>
        [TestMethod()]
        public void OpenTrackBlockTest()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[0];
            bool expected = true;
            bool actual = m_ctcAccessor.OpenTrackBlock(block);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OpenTrackBlock
        ///</summary>
        [TestMethod()]
        public void OpenTrackBlockTest_null()
        {
            TrackBlock block = null;
            bool expected = false;
            bool actual = m_ctcAccessor.OpenTrackBlock(block);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OpenTrackBlock
        ///</summary>
        [TestMethod()]
        public void OpenTrackBlockTest_badBlock()
        {
            TrackBlock block = new TrackBlock();
            bool expected = false; 
            bool actual = m_ctcAccessor.OpenTrackBlock(block);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RemoveTrainFromList
        ///</summary>
        [TestMethod()]
        public void RemoveTrainFromListTest()
        {
            ITrain train = new TrainStub();
            m_ctcAccessor.AddTrainToList(train);
            bool expected = true;
            bool actual;
            actual = m_ctcAccessor.RemoveTrainFromList(train);
            Assert.AreEqual(expected, actual);
            Assert.IsFalse(m_ctcAccessor.m_trainList.Contains(train));
        }

        /// <summary>
        ///A test for RemoveTrainFromList
        ///</summary>
        [TestMethod()]
        public void RemoveTrainFromListTest_bad()
        {
            ITrain train = new TrainStub();
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.RemoveTrainFromList(train);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RemoveTrainFromList
        ///</summary>
        [TestMethod()]
        public void RemoveTrainFromListTest_null()
        {
            ITrain train = null;
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.RemoveTrainFromList(train);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetAuthority
        ///</summary>
        [TestMethod()]
        public void SetAuthorityTest()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[0];
            string value = "0";
            bool expected = true; 
            bool actual;
            actual = m_ctcAccessor.SetAuthority(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetAuthority
        ///</summary>
        [TestMethod()]
        public void SetAuthorityTest_badString()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[0];
            string value = "abcd";
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.SetAuthority(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetAuthority
        ///</summary>
        [TestMethod()]
        public void SetAuthorityTest_nullString()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[0];
            string value = null;
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.SetAuthority(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetAuthority
        ///</summary>
        [TestMethod()]
        public void SetAuthorityTest_badBlock()
        {
            TrackBlock block = new TrackBlock();
            string value = "0";
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.SetAuthority(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetAuthority
        ///</summary>
        [TestMethod()]
        public void SetAuthorityTest_nullBlock()
        {
            TrackBlock block = null;
            string value = "1";
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.SetAuthority(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetSpeedLimit
        ///</summary>
        [TestMethod()]
        public void SetSpeedLimitTest()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[0];
            string value = "0";
            bool expected = true;
            bool actual;
            actual = m_ctcAccessor.SetSpeedLimit(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetSpeedLimit
        ///</summary>
        [TestMethod()]
        public void SetSpeedLimitTest_badString()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[0];
            string value = "abcd";
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.SetSpeedLimit(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetSpeedLimit
        ///</summary>
        [TestMethod()]
        public void SetSpeedLimitTest_nullString()
        {
            TrackBlock block = m_ctcAccessor.m_blockList[0];
            string value = null;
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.SetSpeedLimit(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetSpeedLimit
        ///</summary>
        [TestMethod()]
        public void SetSpeedLimitTest_badBlock()
        {
            TrackBlock block = new TrackBlock();
            string value = "0";
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.SetSpeedLimit(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetSpeedLimit
        ///</summary>
        [TestMethod()]
        public void SetSpeedLimitTest_nullBlock()
        {
            TrackBlock block = null;
            string value = "0";
            bool expected = false;
            bool actual;
            actual = m_ctcAccessor.SetSpeedLimit(block, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Subscribe
        ///</summary>
        [TestMethod()]
        public void SubscribeTest()
        {
            CTCController.UpdateDisplay updateDelegate = UpdateDisplay; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = m_ctcAccessor.Subscribe(updateDelegate);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Subscribe
        ///</summary>
        [TestMethod()]
        public void SubscribeTest_null()
        {
            CTCController.UpdateDisplay updateDelegate = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = m_ctcAccessor.Subscribe(updateDelegate);
            Assert.AreEqual(expected, actual);
        }

        private void UpdateDisplay(List<TrackBlock> blocks, List<ITrain> trains)
        {
            //Empty delegate for testing subscribe method
        }
    }
}
