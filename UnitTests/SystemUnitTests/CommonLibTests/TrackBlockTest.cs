using CommonLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace CommonLibTests
{
    
    
    /// <summary>
    ///This is a test class for TrackBlockTest and is intended
    ///to contain all TrackBlockTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TrackBlockTest
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
        ///A test for TrackBlock Constructor
        ///</summary>
        [TestMethod()]
        public void TrackBlockConstructorTest()
        {
            TrackOrientation orientation = TrackOrientation.EastWest; 
            double length = 3.5;
            bool tunnel = false; 
            bool railroadCrossing = false;
            Transponder transponder = new Transponder("Station1", 2); 
            Point startPoint = new Point(0,0);
            //TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder, startPoint);
            //Assert.AreEqual(orientation, target.Orientation);
            //Assert.AreEqual(length, target.LengthMeters);
            //Assert.IsFalse(target.HasTunnel);
            //Assert.IsNotNull(target.Transponder);
            //Assert.AreEqual("Station1", target.Transponder.StationName);
            //Assert.AreEqual(2, target.Transponder.DistanceToStation);
            //Assert.AreEqual(startPoint.X, target.StartPoint.X);
            //Assert.AreEqual(startPoint.Y, startPoint.Y);
        }

        ///// <summary>
        /////A test for HasTransponder
        /////</summary>
        //[TestMethod()]
        //public void HasTransponderTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.HasTransponder;
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Authority
        /////</summary>
        //[TestMethod()]
        //public void AuthorityTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    int expected = 0; // TODO: Initialize to an appropriate value
        //    int actual;
        //    target.Authority = expected;
        //    actual = target.Authority;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for TrackBlock Constructor
        /////</summary>
        //[TestMethod()]
        //public void TrackBlockConstructorTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder);
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        ///// <summary>
        /////A test for TrackBlock Constructor
        /////</summary>
        //[TestMethod()]
        //public void TrackBlockConstructorTest1()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    TrackSignalState signal = new TrackSignalState(); // TODO: Initialize to an appropriate value
        //    bool train = false; // TODO: Initialize to an appropriate value
        //    int speedLimit = 0; // TODO: Initialize to an appropriate value
        //    int authority = 0; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, signal, train, speedLimit, authority);
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        ///// <summary>
        /////A test for Transponder
        /////</summary>
        //[TestMethod()]
        //public void TransponderTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    Transponder actual;
        //    actual = target.Transponder;
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for TrainPresent
        /////</summary>
        //[TestMethod()]
        //public void TrainPresentTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    bool expected = false; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    target.TrainPresent = expected;
        //    actual = target.TrainPresent;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for SpeedLimitKph
        /////</summary>
        //[TestMethod()]
        //public void SpeedLimitKphTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    int expected = 0; // TODO: Initialize to an appropriate value
        //    int actual;
        //    target.SpeedLimitKph = expected;
        //    actual = target.SpeedLimitKph;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for SignalState
        /////</summary>
        //[TestMethod()]
        //public void SignalStateTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    TrackSignalState expected = new TrackSignalState(); // TODO: Initialize to an appropriate value
        //    TrackSignalState actual;
        //    target.SignalState = expected;
        //    actual = target.SignalState;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for RailroadCrossing
        /////</summary>
        //[TestMethod()]
        //public void RailroadCrossingTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.RailroadCrossing;
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Orientation
        /////</summary>
        //[TestMethod()]
        //public void OrientationTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    TrackOrientation actual;
        //    actual = target.Orientation;
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Length
        /////</summary>
        //[TestMethod()]
        //public void LengthTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    double actual;
        //    actual = target.Length;
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for HasTunnel
        /////</summary>
        //[TestMethod()]
        //public void HasTunnelTest()
        //{
        //    TrackOrientation orientation = new TrackOrientation(); // TODO: Initialize to an appropriate value
        //    double length = 0F; // TODO: Initialize to an appropriate value
        //    bool tunnel = false; // TODO: Initialize to an appropriate value
        //    bool railroadCrossing = false; // TODO: Initialize to an appropriate value
        //    Transponder transponder = null; // TODO: Initialize to an appropriate value
        //    TrackBlock target = new TrackBlock(orientation, length, tunnel, railroadCrossing, transponder); // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.HasTunnel;
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}
