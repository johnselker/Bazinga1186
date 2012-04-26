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
            string name = "TestBlock";
            double length = 3.5;
            double endElevation = 1.5;
            double grade = 1;
            int staticSpeed = 75;
            bool tunnel = false;
            bool railroadCrossing = false;
            Point startPoint = new Point(0, 0);

            TrackBlock target = new TrackBlock(name, orientation, startPoint, length, endElevation, grade, false, true, staticSpeed, TrackAllowedDirection.Both, false, "controller", "controller2", "prevBlock", "nextBlock");
            target.Transponder = new Transponder("Station1", 2);
            Assert.AreEqual(orientation, target.Orientation);
            Assert.AreEqual(length, target.LengthMeters);
            Assert.IsFalse(target.HasTunnel);
            Assert.IsNotNull(target.Transponder);
            Assert.AreEqual("Station1", target.Transponder.StationName);
            Assert.AreEqual(name, target.Name);
            Assert.AreEqual(2, target.Transponder.DistanceToStation);
            Assert.AreEqual(startPoint.X, target.StartPoint.X);
            Assert.AreEqual(startPoint.Y, startPoint.Y);
            Assert.AreEqual(grade, target.Grade);
            Assert.AreEqual(endElevation, target.EndElevationMeters);
        }

        /// <summary>
        ///A test for CalculateEndPoint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CommonLib.dll")]
        public void CalculateEndPointTest()
        {
            TrackBlock_Accessor target = new TrackBlock_Accessor(); // TODO: Initialize to an appropriate value
            target.StartPoint = new Point(0, 0);
            target.LengthMeters = 75;
            target.Orientation = TrackOrientation.SouthWestNorthEast;
            int xgoal = Convert.ToInt32(Math.Sqrt((75 * 75) / 2));
            int ygoal = -Convert.ToInt32(Math.Sqrt((75 * 75) / 2));
            target.CalculateEndPoint();
            Assert.AreEqual(xgoal, target.EndPoint.X);
            Assert.AreEqual(ygoal, target.EndPoint.Y);
        }

        /// <summary>
        ///A test for GetNextBlock
        ///</summary>
        [TestMethod()]
        public void GetNextBlockTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            TrackBlock NextBlock = new TrackBlock();

            target.NextBlock = NextBlock; 
            Direction direction = Direction.East; // TODO: Initialize to an appropriate value
            TrackBlock expected = null; // TODO: Initialize to an appropriate value
            TrackBlock actual;
            actual = target.GetNextBlock(direction);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Authority
        ///</summary>
        [TestMethod()]
        public void AuthorityTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            BlockAuthority expected = new BlockAuthority(75, 1); ; // TODO: Initialize to an appropriate value
            target.Authority = expected;
            BlockAuthority actual;
            target.Authority = expected;
            actual = target.Authority;
            Assert.AreEqual(expected.SpeedLimitKPH, actual.SpeedLimitKPH);
            Assert.AreEqual(expected.Authority, actual.Authority);
        }

        /// <summary>
        ///A test for ControllerId
        ///</summary>
        [TestMethod()]
        public void ControllerIdTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            string expected = "TestController"; // TODO: Initialize to an appropriate value
            target.ControllerId = expected;
            string actual;
            target.ControllerId = expected;
            actual = target.ControllerId;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EndElevationMeters
        ///</summary>
        [TestMethod()]
        public void EndElevationMetersTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            double expected = 5.01; // TODO: Initialize to an appropriate value
            target.EndElevationMeters = expected;
            double actual;
            target.EndElevationMeters = expected;
            actual = target.EndElevationMeters;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EndPoint
        ///</summary>
        [TestMethod()]
        public void EndPointTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            Point expected = new Point(5,7); // TODO: Initialize to an appropriate value
            target.EndPoint = expected;
            Point actual;
            target.EndPoint = expected;
            actual = target.EndPoint;
            Assert.AreEqual(expected, actual);
           ;
        }

        /// <summary>
        ///A test for Grade
        ///</summary>
        [TestMethod()]
        public void GradeTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            double expected = 0.0056; // TODO: Initialize to an appropriate value
            target.Grade = expected;
            double actual;
            target.Grade = expected;
            actual = target.Grade;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HasSwitch
        ///</summary>
        [TestMethod()]
        public void HasSwitchTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            // Do not create a Switch
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.HasSwitch = expected;
            actual = target.HasSwitch;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HasTransponder
        ///</summary>
        [TestMethod()]
        public void HasTransponderTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            target.Transponder = new Transponder("Test", 1);
            bool actual;
            actual = target.HasTransponder;
            Assert.AreEqual(true, actual);
            
        }

        /// <summary>
        ///A test for HasTunnel
        ///</summary>
        [TestMethod()]
        public void HasTunnelTest()
        {
            // Test For no tunnle
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.HasTunnel = expected;
            actual = target.HasTunnel;
            Assert.AreEqual(expected, actual);
            target.HasTunnel = true;
            Assert.AreEqual(true, target.HasTunnel);

        }

        /// <summary>
        ///A test for LengthMeters
        ///</summary>
        [TestMethod()]
        public void LengthMetersTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            double expected = 0; // TODO: Initialize to an appropriate value
            double actual;
            target.LengthMeters = expected;
            actual = target.LengthMeters;
            Assert.AreEqual(expected, actual);
            target.LengthMeters = 55;
            Assert.AreEqual(55, target.LengthMeters);
            target.LengthMeters = -1;
            Assert.AreEqual(-1, target.LengthMeters);
            
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            string expected = "BlockName"; // TODO: Initialize to an appropriate value
            target.Name = expected;
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NextBlock
        ///</summary>
        [TestMethod()]
        public void NextBlockTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            TrackBlock expected = null; // TODO: Initialize to an appropriate value
            TrackBlock actual;
            target.NextBlock = expected;
            actual = target.NextBlock;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NextBockId
        ///</summary>
        [TestMethod()]
        public void NextBockIdTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            string expected = "NextBlock"; // TODO: Initialize to an appropriate value
            target.NextBockId = expected;
            string actual;
            target.NextBockId = expected;
            actual = target.NextBockId;
            Assert.AreEqual(expected, actual);
            target.NextBockId = null;
            Assert.IsNull(target.NextBockId);
        }

        /// <summary>
        ///A test for Orientation
        ///</summary>
        [TestMethod()]
        public void OrientationTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            TrackOrientation expected = TrackOrientation.NorthSouth; ; // TODO: Initialize to an appropriate value
            target.Orientation = expected;
            TrackOrientation actual;
            target.Orientation = expected;
            actual = target.Orientation;
            Assert.AreEqual(expected, actual);
            expected = TrackOrientation.NorthWestSouthEast; ; // TODO: Initialize to an appropriate value
            target.Orientation = expected;
            Assert.AreEqual(expected, target.Orientation);
        }

        /// <summary>
        ///A test for PreviousBlock
        ///</summary>
        [TestMethod()]
        public void PreviousBlockTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            TrackBlock expected = null; // TODO: Initialize to an appropriate value
            TrackBlock actual;
            target.PreviousBlock = expected;
            actual = target.PreviousBlock;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PreviousBockId
        ///</summary>
        [TestMethod()]
        public void PreviousBockIdTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            string expected = "prevTest"; // TODO: Initialize to an appropriate value
            target.PreviousBockId = expected;
            string actual;
            target.PreviousBockId = expected;
            actual = target.PreviousBockId;
            Assert.AreEqual(expected, actual);
            target.PreviousBockId = null;
            Assert.IsNull(target.PreviousBockId);
        }

        /// <summary>
        ///A test for RailroadCrossing
        ///</summary>
        [TestMethod()]
        public void RailroadCrossingTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.RailroadCrossing = expected;
            actual = target.RailroadCrossing;
            Assert.AreEqual(expected, actual);
            target.RailroadCrossing = true;
            Assert.IsTrue(target.RailroadCrossing);
        }

        /// <summary>
        ///A test for SecondaryControllerId
        ///</summary>
        [TestMethod()]
        public void SecondaryControllerIdTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            string expected = "SecondaryController"; // TODO: Initialize to an appropriate value
            string actual;
            target.SecondaryControllerId = expected;
            actual = target.SecondaryControllerId;
            Assert.AreEqual(expected, actual);
            target.SecondaryControllerId = null;
            Assert.IsNull(target.SecondaryControllerId);
        }

        /// <summary>
        ///A test for StartElevationMeters
        ///</summary>
        [TestMethod()]
        public void StartElevationMetersTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            double expected = 0.001; // TODO: Initialize to an appropriate value
            double actual;
            target.StartElevationMeters = expected;
            actual = target.StartElevationMeters;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for StartPoint
        ///</summary>
        [TestMethod()]
        public void StartPointTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            Point expected = new Point(0,0); // TODO: Initialize to an appropriate value
            Point actual;
            target.StartPoint = expected;
            actual = target.StartPoint;
            Assert.AreEqual(expected, actual);
            target.StartPoint = new Point(6, 11);
            Assert.AreEqual(new Point(6, 11), target.StartPoint);
        }

        /// <summary>
        ///A test for StaticSpeedLimit
        ///</summary>
        [TestMethod()]
        public void StaticSpeedLimitTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            double expected = 55; // TODO: Initialize to an appropriate value
            target.StaticSpeedLimit = expected;
            double actual;
            target.StaticSpeedLimit = expected;
            actual = target.StaticSpeedLimit;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Transponder
        ///</summary>
        [TestMethod()]
        public void TransponderTest()
        {
            TrackBlock target = new TrackBlock(); // TODO: Initialize to an appropriate value
            Transponder expected = new Transponder("Test", 1);  // TODO: Initialize to an appropriate value
            target.Transponder = expected;
            Transponder actual;
            target.Transponder = expected;
            actual = target.Transponder;
            Assert.AreEqual(expected, actual);
        }
    }
}
