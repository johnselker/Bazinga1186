using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Train;
using CommonLib;

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
        ///A test for OnTrainClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrainClickedTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            ITrain train = null; // TODO: Initialize to an appropriate value
            target.OnTrainClicked(train);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnTrackBlockClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnTrackBlockClickedTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock b = null; // TODO: Initialize to an appropriate value
            target.OnTrackBlockClicked(b);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnSpeedLimitEntered
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnSpeedLimitEnteredTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            string value = string.Empty; // TODO: Initialize to an appropriate value
            target.OnSpeedLimitEntered(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnPopupAcknowledged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnPopupAcknowledgedTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnPopupAcknowledged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnCommandClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnCommandClickedTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            object tag = null; // TODO: Initialize to an appropriate value
            target.OnCommandClicked(tag);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnAuthorityEntered
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnAuthorityEnteredTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            string value = string.Empty; // TODO: Initialize to an appropriate value
            target.OnAuthorityEntered(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            target.Initialize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetCommandInput
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetCommandInputTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            object tag = null; // TODO: Initialize to an appropriate value
            target.GetCommandInput(tag);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest()
        {
            MainScreen_Accessor target = new MainScreen_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
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
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MainScreen Constructor
        ///</summary>
        [TestMethod()]
        public void MainScreenConstructorTest()
        {
            MainScreen target = new MainScreen();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
