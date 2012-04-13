using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using TrackControlLib;

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
        ///A test for SetSpeedLimit
        ///</summary>
        [TestMethod()]
        public void SetSpeedLimitTest()
        {
            CTCController target = new CTCController(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            string value = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetSpeedLimit(block, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetAuthority
        ///</summary>
        [TestMethod()]
        public void SetAuthorityTest()
        {
            CTCController target = new CTCController(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            string value = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetAuthority(block, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenTrackBlock
        ///</summary>
        [TestMethod()]
        public void OpenTrackBlockTest()
        {
            CTCController target = new CTCController(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.OpenTrackBlock(block);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetTrackController
        ///</summary>
        [TestMethod()]
        public void GetTrackControllerTest()
        {
            CTCController target = new CTCController(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            ITrackController expected = null; // TODO: Initialize to an appropriate value
            ITrackController actual;
            actual = target.GetTrackController(block);
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
        ///A test for CloseTrackBlock
        ///</summary>
        [TestMethod()]
        public void CloseTrackBlockTest()
        {
            CTCController target = new CTCController(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CloseTrackBlock(block);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CTCController Constructor
        ///</summary>
        [TestMethod()]
        public void CTCControllerConstructorTest()
        {
            CTCController target = new CTCController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
