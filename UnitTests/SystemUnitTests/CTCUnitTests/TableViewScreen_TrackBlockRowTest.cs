using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for TableViewScreen_TrackBlockRowTest and is intended
    ///to contain all TableViewScreen_TrackBlockRowTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TableViewScreen_TrackBlockRowTest
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
        ///A test for TrackBlockRow Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void TableViewScreen_TrackBlockRowConstructorTest()
        {
            TableViewScreen_Accessor.TrackBlockRow target = new TableViewScreen_Accessor.TrackBlockRow();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for HideLabels
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void HideLabelsTest()
        {
            TableViewScreen_Accessor.TrackBlockRow target = new TableViewScreen_Accessor.TrackBlockRow(); // TODO: Initialize to an appropriate value
            target.HideLabels();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowLabels
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void ShowLabelsTest()
        {
            TableViewScreen_Accessor.TrackBlockRow target = new TableViewScreen_Accessor.TrackBlockRow(); // TODO: Initialize to an appropriate value
            target.ShowLabels();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
