using TrackControlLib.Sean;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using System.Collections.Generic;
using System.Drawing;

namespace TrackControlLib_SeanTest
{
    
    
    /// <summary>
    ///This is a test class for TrackControllerTest and is intended
    ///to contain all TrackControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TrackControllerTest
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
        ///A test for TrackController Constructor
        ///</summary>
        [TestMethod()]
        public void TrackControllerConstructorTest()
        {
            TrackController target = new TrackController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddTrackBlock
        ///</summary>
        [TestMethod()]
        public void AddTrackBlockTest()
        {
            TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddTrackBlock(block);
            Assert.IsFalse(actual);

            block = new TrackBlock();
            actual = target.AddTrackBlock(block);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for CloseTrack
        ///</summary>
        [TestMethod()]
        public void CloseTrackTest()
        {
            TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
            string trackId = string.Empty; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CloseTrack(trackId);
            Assert.IsFalse(actual);

            // can't close a track that isn't owned
            trackId = "akljkjcbao";
            actual = target.CloseTrack(trackId);
            Assert.IsFalse(actual);

            // assert true if controller owns track and is able to close it
            TrackBlock block = new TrackBlock(); 
            block.Name = trackId = "TestName";
            target.AddTrackBlock(block);
            actual = target.CloseTrack(trackId);
            Assert.IsTrue(actual);

            // assert false if track is already closed
            actual = target.CloseTrack(trackId);
            Assert.IsFalse(actual);

            // shouldn't be able to close a track with a train on it
            block.Status.IsOpen = true;
            block.Status.TrainPresent = true;
            actual = target.CloseTrack(trackId);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsTrainApproaching
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrackControlLib.dll")]
        public void IsTrainApproachingTest()
        {
            TrackController_Accessor target = new TrackController_Accessor(); // TODO: Initialize to an appropriate value
			TrackBlock dest = new TrackBlock("dest", TrackOrientation.EastWest, new Point(), 0.0, 0.0, 0.0, false, false, 0, TrackAllowedDirection.Both, true, "controller", "", "", "");
			TrackBlock b1 = new TrackBlock("track1", TrackOrientation.EastWest, new Point(), 0.0, 0.0, 0.0, false, false, 0, TrackAllowedDirection.Both, false, "controller", "", "", "");
			TrackBlock b2 = new TrackBlock("track2", TrackOrientation.EastWest, new Point(), 0.0, 0.0, 0.0, false, false, 0, TrackAllowedDirection.Both, false, "controller", "", "", "");
			TrackBlock b3 = new TrackBlock("track3", TrackOrientation.EastWest, new Point(), 0.0, 0.0, 0.0, false, false, 0, TrackAllowedDirection.Both, false, "controller", "", "", "");
			
			b1.Orientation = TrackOrientation.EastWest;
			b1.Status.TrainDirection = Direction.East;
			b1.Status.TrainPresent = true;
			b1.NextBlock = b2;
			b2.Orientation = TrackOrientation.EastWest;
			b2.Status.TrainDirection = Direction.East;
			b2.NextBlock = b3;
			b3.Orientation = TrackOrientation.EastWest;
			b3.Status.TrainDirection = Direction.East;
			b3.NextBlock = dest;
			target.AddTrackBlock(b1);
			target.AddTrackBlock(b2);
			target.AddTrackBlock(b3);
			target.AddTrackBlock(dest);
            bool actual;
            actual = target.IsTrainApproaching(dest);
            Assert.IsTrue(actual);

			b1.Orientation = TrackOrientation.EastWest;
			b1.Status.TrainDirection = Direction.West;
			b1.Status.TrainPresent = true;
			b1.PreviousBlock = b2;
			b2.Orientation = TrackOrientation.EastWest;
			b2.Status.TrainDirection = Direction.West;
			b2.PreviousBlock = b3;
			b3.Orientation = TrackOrientation.EastWest;
			b3.Status.TrainDirection = Direction.West;
			b3.PreviousBlock = dest;
			target.AddTrackBlock(b1);
			target.AddTrackBlock(b2);
			target.AddTrackBlock(b3);
			target.AddTrackBlock(dest);
			actual = target.IsTrainApproaching(dest);
			Assert.IsTrue(actual);

			b1.Orientation = TrackOrientation.EastWest;
			b1.Status.TrainDirection = Direction.West;
			b1.PreviousBlock = b2;
			b2.Orientation = TrackOrientation.EastWest;
			b2.Status.TrainDirection = Direction.West;
			b2.PreviousBlock = b3;
			b3.Orientation = TrackOrientation.EastWest;
			b3.Status.TrainDirection = Direction.West;
			b3.PreviousBlock = dest;
			target.AddTrackBlock(b1);
			target.AddTrackBlock(b2);
			target.AddTrackBlock(b3);
			target.AddTrackBlock(dest);
			actual = target.IsTrainApproaching(dest);
			Assert.IsFalse(actual);

			b1.Orientation = TrackOrientation.NorthSouth;
			b1.Status.TrainDirection = Direction.South;
			b1.PreviousBlock = b2;
			b2.Orientation = TrackOrientation.NorthSouth;
			b2.Status.TrainDirection = Direction.South;
			b2.PreviousBlock = b3;
			b3.Orientation = TrackOrientation.NorthSouth;
			b3.Status.TrainDirection = Direction.South;
			b3.PreviousBlock = dest;
			target.AddTrackBlock(b1);
			target.AddTrackBlock(b2);
			target.AddTrackBlock(b3);
			target.AddTrackBlock(dest);
			actual = target.IsTrainApproaching(dest);
			Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for OpenTrack
        ///</summary>
        [TestMethod()]
        public void OpenTrackTest()
        {
            TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
            string trackId = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.OpenTrack(trackId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetSwitch
        ///</summary>
        [TestMethod()]
        public void SetSwitchTest()
        {
            TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
            TrackSwitch s = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetSwitch(s);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SuggestAuthority
        ///</summary>
		[TestMethod()]
		public void SuggestAuthorityTest()
		{
			TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
			string trackId = string.Empty; // TODO: Initialize to an appropriate value
			BlockAuthority auth = null; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.SuggestAuthority(trackId, auth);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

        /// <summary>
        ///A test for UpdateAuthoritySignal
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrackControlLib.dll")]
        public void UpdateAuthoritySignalTest()
        {
            TrackController_Accessor target = new TrackController_Accessor(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            int authority = 0; // TODO: Initialize to an appropriate value
            target.UpdateAuthoritySignal(block, authority);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

		/// <summary>
		///A test for UpdateAuthority
		///</summary>
		[TestMethod()]
		[DeploymentItem("TrackControlLib.dll")]
		public void UpdateAuthorityTest()
		{
			TrackController_Accessor target = new TrackController_Accessor(); // TODO: Initialize to an appropriate value
			List<TrackBlock> blocks = null; // TODO: Initialize to an appropriate value
			target.UpdateAuthority(blocks);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for UpdateSwitch
		///</summary>
		[TestMethod()]
		[DeploymentItem("TrackControlLib.dll")]
		public void UpdateSwitchTest()
		{
			TrackController_Accessor target = new TrackController_Accessor(); // TODO: Initialize to an appropriate value
			target.UpdateSwitch();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for CheckFailModes
		///</summary>
		[TestMethod()]
		[DeploymentItem("TrackControlLib.dll")]
		public void CheckFailModesTest()
		{
			TrackController_Accessor target = new TrackController_Accessor(); // TODO: Initialize to an appropriate value
			target.CheckFailModes();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for IsTrainApproaching
		///</summary>
		[TestMethod()]
		[DeploymentItem("TrackControlLib.dll")]
		public void IsTrainApproachingTest1()
		{
			TrackController_Accessor target = new TrackController_Accessor(); // TODO: Initialize to an appropriate value
			TrackBlock dest = null; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.IsTrainApproaching(dest);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for UpdateAuthoritySignal
		///</summary>
		[TestMethod()]
		[DeploymentItem("TrackControlLib.dll")]
		public void UpdateAuthoritySignalTest1()
		{
			TrackController_Accessor target = new TrackController_Accessor(); // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			int authority = 0; // TODO: Initialize to an appropriate value
			target.UpdateAuthoritySignal(block, authority);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}
    }
}
