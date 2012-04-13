using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Train;
using CommonLib;
using System.Collections.Generic;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for InfoPanelTest and is intended
    ///to contain all InfoPanelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InfoPanelTest
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
        ///A test for SetTrainInfo
        ///</summary>
        [TestMethod()]
        public void SetTrainInfoTest()
        {
            InfoPanel target = new InfoPanel(); // TODO: Initialize to an appropriate value
            ITrain train = null; // TODO: Initialize to an appropriate value
            target.SetTrainInfo(train);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetTrackBlockInfo
        ///</summary>
        [TestMethod()]
        public void SetTrackBlockInfoTest()
        {
            InfoPanel target = new InfoPanel(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            target.SetTrackBlockInfo(block);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetInfo
        ///</summary>
        [TestMethod()]
        public void SetInfoTest()
        {
            InfoPanel target = new InfoPanel(); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Dictionary<string, string> information = null; // TODO: Initialize to an appropriate value
            target.SetInfo(name, information);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest()
        {
            InfoPanel_Accessor target = new InfoPanel_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetBlockFailureStateString
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetBlockFailureStateStringTest()
        {
            InfoPanel_Accessor target = new InfoPanel_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            KeyValuePair<string, string> expected = new KeyValuePair<string, string>(); // TODO: Initialize to an appropriate value
            KeyValuePair<string, string> actual;
            actual = target.GetBlockFailureStateString(block);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest()
        {
            InfoPanel_Accessor target = new InfoPanel_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearInfo
        ///</summary>
        [TestMethod()]
        public void ClearInfoTest()
        {
            InfoPanel target = new InfoPanel(); // TODO: Initialize to an appropriate value
            target.ClearInfo();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AdjustLabelPositions
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void AdjustLabelPositionsTest()
        {
            InfoPanel_Accessor target = new InfoPanel_Accessor(); // TODO: Initialize to an appropriate value
            target.AdjustLabelPositions();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InfoPanel Constructor
        ///</summary>
        [TestMethod()]
        public void InfoPanelConstructorTest()
        {
            InfoPanel target = new InfoPanel();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
