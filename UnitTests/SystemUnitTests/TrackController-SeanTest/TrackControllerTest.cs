using TrackControlLib.Sean;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using System.Collections.Generic;

namespace TrackController_SeanTest
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
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.AddTrackBlock(block);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for CloseTrack
		///</summary>
		[TestMethod()]
		public void CloseTrackTest()
		{
			TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
			string trackId = string.Empty; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.CloseTrack(trackId);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetAllTrackStatus
		///</summary>
		[TestMethod()]
		public void GetAllTrackStatusTest()
		{
			TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
			Dictionary<string, TrackStatus> expected = null; // TODO: Initialize to an appropriate value
			Dictionary<string, TrackStatus> actual;
			actual = target.GetAllTrackStatus();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetTrackStatus
		///</summary>
		[TestMethod()]
		public void GetTrackStatusTest()
		{
			TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
			string trackId = string.Empty; // TODO: Initialize to an appropriate value
			TrackStatus expected = null; // TODO: Initialize to an appropriate value
			TrackStatus actual;
			actual = target.GetTrackStatus(trackId);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsTrainApproaching
		///</summary>
		[TestMethod()]
		[DeploymentItem("TrackControlLib.dll")]
		public void IsTrainApproachingTest()
		{
			TrackController_Accessor target = new TrackController_Accessor(); // TODO: Initialize to an appropriate value
			TrackController from = null; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.IsTrainApproaching(from);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
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
		///A test for SetAdjTrackController
		///</summary>
		[TestMethod()]
		public void SetAdjTrackControllerTest()
		{
			TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
			TrackController controller = null; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.SetAdjTrackController(controller);
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
		///A test for Update
		///</summary>
		[TestMethod()]
		public void UpdateTest()
		{
			TrackController target = new TrackController(); // TODO: Initialize to an appropriate value
			target.Update();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for UpdateSpeedAuthoritySignal
		///</summary>
		[TestMethod()]
		[DeploymentItem("TrackControlLib.dll")]
		public void UpdateSpeedAuthoritySignalTest()
		{
			TrackController_Accessor target = new TrackController_Accessor(); // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			int authority = 0; // TODO: Initialize to an appropriate value
			target.UpdateSpeedAuthoritySignal(block, authority);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}
	}
}
