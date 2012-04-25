using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using TrainLib;
using ClassStubs;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for MainScreenTest and is intended
    ///to contain all MainScreenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainScreenTest
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
        ///A test for MainScreen Constructor
        ///</summary>
        [TestMethod()]
        public void MainScreenConstructorTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor();

            //Just check that the controls and variables were initialized
            Assert.IsNotNull(target.commandPanel);
            Assert.IsNotNull(target.exitToolStripMenuItem);
            Assert.IsNotNull(target.fileToolStripMenuItem);
            Assert.IsNotNull(target.infoPanel);
            Assert.IsNotNull(target.loadTrackLayoutToolStripMenuItem);
            Assert.IsNotNull(target.m_ctcController);
            Assert.IsNotNull(target.m_log);
            Assert.IsNotNull(target.m_openPopups);
            Assert.IsNull(target.m_selectedTrackBlock);
            Assert.IsNull(target.m_selectedTrain);
            Assert.IsNotNull(target.m_simulatorWindow);
            Assert.IsNotNull(target.m_tableViewWindow);
            Assert.IsNotNull(target.menuStrip1);
            Assert.IsNotNull(target.simulatorWindowToolStripMenuItem);
            Assert.IsNotNull(target.tableViewToolStripMenuItem);
            Assert.IsNotNull(target.trackDisplayPanel);
            Assert.IsNotNull(target.trainWindowToolStripMenuItem);
            Assert.IsNotNull(target.viewToolStripMenuItem);
        }

        /// <summary>
        ///A test for CloseOpenPopups
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CloseOpenPopupsTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            target.CloseOpenPopups();
            Assert.AreEqual(0, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for GetCommandInput
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetCommandInputTest_trackBlockCommand()
        {
            MainScreen_Accessor target = new MainScreen_Accessor();
            object tag = TrackBlockCommands.SuggestAuthority;
            target.GetCommandInput(tag);
            Assert.AreEqual(1, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for GetCommandInput
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("CTCOfficeGUI.exe")]
        //public void GetCommandInputTest_trainCommand()
        //{
        //    MainScreen_Accessor target = new MainScreen_Accessor();
        //    object tag = TrainCommands.ViewSchedule;
        //    target.GetCommandInput(tag);
        //    Assert.AreEqual(1, target.m_openPopups.Count);
        //}

        /// <summary>
        ///A test for GetCommandInput
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetCommandInputTest_yardCommand()
        {
            MainScreen_Accessor target = new MainScreen_Accessor();
            object tag = "Spawn Train";
            target.GetCommandInput(tag);
            Assert.AreEqual(1, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for GetCommandInput
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetCommandInputTest_badTag()
        {
            MainScreen_Accessor target = new MainScreen_Accessor();
            object tag = new object();
            target.GetCommandInput(tag);
            Assert.AreEqual(0, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeTest_emptyFile()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); 
            string filename = string.Empty; 
            bool expected = false; 
            bool actual;
            actual = target.Initialize(filename);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OnAuthorityEntered
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnAuthorityEnteredTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor();
            //Can't set an authority since there is no layout. Verify the OK popup gets displayed
            string value = "0";
            target.OnAuthorityEntered(value);
            Assert.AreEqual(1, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for OnPopupAcknowledged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnPopupAcknowledgedTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); 
            object sender = null;
            EventArgs e = null; 
            target.OnPopupAcknowledged(sender, e);
            Assert.AreEqual(0, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for OnSpeedLimitEntered
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnSpeedLimitEnteredTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor();
            //Can't set an authority since there is no layout. Verify the OK popup gets displayed
            string value = "0";
            target.OnSpeedLimitEntered(value);
            Assert.AreEqual(1, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for OnTableViewClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTableViewClickedTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnTableViewClicked(sender, e);
            Assert.IsNotNull(target.m_tableViewWindow);
        }

        /// <summary>
        ///A test for OnTrackBlockClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrackBlockClickedTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor();
            TrackBlock b = new TrackBlock(); 
            target.OnTrackBlockClicked(b);
            Assert.AreEqual(b, target.m_selectedTrackBlock);
            Assert.IsNull(target.m_selectedTrain);
            Assert.IsNotNull(target.m_simulatorWindow);
            Assert.AreEqual(0, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for OnTrainClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainClickedTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); 
            ITrain train = new TrainStub(); 
            target.OnTrainClicked(train);
            Assert.AreEqual(train, target.m_selectedTrain);
            Assert.IsNull(target.m_selectedTrackBlock);
            Assert.AreEqual(0, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for OnTrainNameEntered
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainNameEnteredTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); 
            string value = string.Empty; 
            target.OnTrainNameEntered(value);
            Assert.AreEqual(1, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for OnTrainNameEntered
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainNameEnteredTest_empty()
        {
            MainScreen_Accessor target = new MainScreen_Accessor();
            string value = string.Empty;
            target.OnTrainNameEntered(value);
            Assert.AreEqual(1, target.m_openPopups.Count);
        }

        /// <summary>
        ///A test for OnViewSimulatorWindowClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnViewSimulatorWindowClickedTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); 
            object sender = null; 
            EventArgs e = null; 
            target.OnViewSimulatorWindowClicked(sender, e);
            Assert.IsNotNull(target.m_simulatorWindow);
        }
    }
}
