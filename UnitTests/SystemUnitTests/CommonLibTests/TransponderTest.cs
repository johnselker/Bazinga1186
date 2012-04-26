using CommonLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CommonLibTests
{
    
    
    /// <summary>
    ///This is a test class for TransponderTest and is intended
    ///to contain all TransponderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TransponderTest
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
        ///A test for Transponder Constructor
        ///</summary>
        [TestMethod()]
        public void TransponderConstructorTest()
        {
            string stationName = "TestStation"; // TODO: Initialize to an appropriate value
            int distance = 1; // TODO: Initialize to an appropriate value
            Transponder target = new Transponder(stationName, distance);
            Assert.AreEqual(stationName, target.StationName);
            Assert.AreEqual(distance, target.DistanceToStation);
        }

        /// <summary>
        ///A test for DistanceToStation
        ///</summary>
        [TestMethod()]
        public void DistanceToStationTest()
        {
            string stationName = ""; // TODO: Initialize to an appropriate value
            int distance = 2; // TODO: Initialize to an appropriate value
            Transponder target = new Transponder(stationName, distance); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.DistanceToStation;
            Assert.AreEqual(distance, actual);
        }

        /// <summary>
        ///A test for StationName
        ///</summary>
        [TestMethod()]
        public void StationNameTest()
        {
            string stationName = "NameTest"; // TODO: Initialize to an appropriate value
            int distance = 0; // TODO: Initialize to an appropriate value
            Transponder target = new Transponder(stationName, distance); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.StationName;
            Assert.AreEqual(stationName, actual);
        }
    }
}
