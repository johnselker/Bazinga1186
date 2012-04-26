using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using System.Collections.Generic;
using TrainLib;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for TableViewScreenTest and is intended
    ///to contain all TableViewScreenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TableViewScreenTest
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
        ///A test for TableViewScreen Constructor
        ///</summary>
        [TestMethod()]
        public void TableViewScreenConstructorTest()
        {
            TableViewScreen target = new TableViewScreen();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest()
        {
            TableViewScreen_Accessor target = new TableViewScreen_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetBlockFailureStateString
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetBlockFailureStateStringTest()
        {
            TableViewScreen_Accessor target = new TableViewScreen_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetBlockFailureStateString(block);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest()
        {
            TableViewScreen_Accessor target = new TableViewScreen_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeTables
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeTablesTest()
        {
            TableViewScreen_Accessor target = new TableViewScreen_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeTables();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateDisplay
        ///</summary>
        [TestMethod()]
        public void UpdateDisplayTest()
        {
            TableViewScreen target = new TableViewScreen(); // TODO: Initialize to an appropriate value
            List<TrackBlock> blocks = null; // TODO: Initialize to an appropriate value
            List<ITrain> trains = null; // TODO: Initialize to an appropriate value
            target.UpdateDisplay(blocks, trains);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TableViewScreen Constructor
        ///</summary>
        [TestMethod()]
        public void TableViewScreenConstructorTest1()
        {
            TableViewScreen target = new TableViewScreen();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest1()
        {
            TableViewScreen_Accessor target = new TableViewScreen_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetBlockFailureStateString
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetBlockFailureStateStringTest1()
        {
            TableViewScreen_Accessor target = new TableViewScreen_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetBlockFailureStateString(block);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest1()
        {
            TableViewScreen_Accessor target = new TableViewScreen_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeTables
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeTablesTest1()
        {
            TableViewScreen_Accessor target = new TableViewScreen_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeTables();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateDisplay
        ///</summary>
        [TestMethod()]
        public void UpdateDisplayTest1()
        {
            TableViewScreen target = new TableViewScreen(); // TODO: Initialize to an appropriate value
            List<TrackBlock> blocks = null; // TODO: Initialize to an appropriate value
            List<ITrain> trains = null; // TODO: Initialize to an appropriate value
            target.UpdateDisplay(blocks, trains);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
