using TrainLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using System.Drawing;

namespace CommonLibTests
{
    
    
    /// <summary>
    ///This is a test class for TrainTest and is intended
    ///to contain all TrainTest Unit Tests
    ///</summary>
	[TestClass()]
	public class TrainTest
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
		///A test for Train Constructor
		///</summary>
		[TestMethod()]
		public void TrainConstructorTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers);
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for GetAcceleration
		///</summary>
		[TestMethod()]
		public void GetAccelerationTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			double expected = 0F; // TODO: Initialize to an appropriate value
			double actual;
			actual = target.GetAcceleration();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetBrake
		///</summary>
		[TestMethod()]
		public void GetBrakeTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.GetBrake();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetDirection
		///</summary>
		[TestMethod()]
		public void GetDirectionTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			Direction expected = new Direction(); // TODO: Initialize to an appropriate value
			Direction actual;
			actual = target.GetDirection();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetEmergencyBrake
		///</summary>
		[TestMethod()]
		public void GetEmergencyBrakeTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.GetEmergencyBrake();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetPosition
		///</summary>
		[TestMethod()]
		public void GetPositionTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			Point expected = new Point(); // TODO: Initialize to an appropriate value
			Point actual;
			actual = target.GetPosition();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetPower
		///</summary>
		[TestMethod()]
		public void GetPowerTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			double expected = 0F; // TODO: Initialize to an appropriate value
			double actual;
			actual = target.GetPower();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetSpeed
		///</summary>
		[TestMethod()]
		public void GetSpeedTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			double expected = 0F; // TODO: Initialize to an appropriate value
			double actual;
			actual = target.GetSpeed();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetState
		///</summary>
		[TestMethod()]
		public void GetStateTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			TrainState expected = null; // TODO: Initialize to an appropriate value
			TrainState actual;
			actual = target.GetState();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for SetAnnouncement
		///</summary>
		[TestMethod()]
		public void SetAnnouncementTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			string announcement = string.Empty; // TODO: Initialize to an appropriate value
			target.SetAnnouncement(announcement);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SetBrake
		///</summary>
		[TestMethod()]
		public void SetBrakeTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			bool brake = false; // TODO: Initialize to an appropriate value
			double deltaTime = 0F; // TODO: Initialize to an appropriate value
			target.SetBrake(brake, deltaTime);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SetBrakeFailure
		///</summary>
		[TestMethod()]
		public void SetBrakeFailureTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			bool failure = false; // TODO: Initialize to an appropriate value
			target.SetBrakeFailure(failure);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SetDoors
		///</summary>
		[TestMethod()]
		public void SetDoorsTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			TrainState.Door doors = new TrainState.Door(); // TODO: Initialize to an appropriate value
			target.SetDoors(doors);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SetEmergencyBrake
		///</summary>
		[TestMethod()]
		public void SetEmergencyBrakeTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			bool brake = false; // TODO: Initialize to an appropriate value
			double deltaTime = 0F; // TODO: Initialize to an appropriate value
			target.SetEmergencyBrake(brake, deltaTime);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SetEngineFailure
		///</summary>
		[TestMethod()]
		public void SetEngineFailureTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			bool failure = false; // TODO: Initialize to an appropriate value
			target.SetEngineFailure(failure);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SetFriction
		///</summary>
		[TestMethod()]
		public void SetFrictionTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			double friction = 0F; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.SetFriction(friction);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for SetLights
		///</summary>
		[TestMethod()]
		public void SetLightsTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			TrainState.Light lights = new TrainState.Light(); // TODO: Initialize to an appropriate value
			target.SetLights(lights);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SetPower
		///</summary>
		[TestMethod()]
		public void SetPowerTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			double power = 0F; // TODO: Initialize to an appropriate value
			double deltaTime = 0F; // TODO: Initialize to an appropriate value
			target.SetPower(power, deltaTime);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SetSignalPickupFailure
		///</summary>
		[TestMethod()]
		public void SetSignalPickupFailureTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			bool failure = false; // TODO: Initialize to an appropriate value
			target.SetSignalPickupFailure(failure);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SetSlope
		///</summary>
		[TestMethod()]
		public void SetSlopeTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			double slope = 0F; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.SetSlope(slope);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Update
		///</summary>
		[TestMethod()]
		public void UpdateTest()
		{
			string trainID = string.Empty; // TODO: Initialize to an appropriate value
			TrackBlock block = null; // TODO: Initialize to an appropriate value
			Direction direction = new Direction(); // TODO: Initialize to an appropriate value
			int cars = 0; // TODO: Initialize to an appropriate value
			int crew = 0; // TODO: Initialize to an appropriate value
			int passengers = 0; // TODO: Initialize to an appropriate value
			Train target = new Train(trainID, block, direction, cars, crew, passengers); // TODO: Initialize to an appropriate value
			double deltaTime = 0F; // TODO: Initialize to an appropriate value
			target.Update(deltaTime);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for UpdatePosition
		///</summary>
		[TestMethod()]
		[DeploymentItem("Train.dll")]
		public void UpdatePositionTest()
		{
			PrivateObject param0 = null; // TODO: Initialize to an appropriate value
			Train_Accessor target = new Train_Accessor(param0); // TODO: Initialize to an appropriate value
			double deltaTime = 0F; // TODO: Initialize to an appropriate value
			target.UpdatePosition(deltaTime);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for UpdateSpeed
		///</summary>
		[TestMethod()]
		[DeploymentItem("Train.dll")]
		public void UpdateSpeedTest()
		{
			PrivateObject param0 = null; // TODO: Initialize to an appropriate value
			Train_Accessor target = new Train_Accessor(param0); // TODO: Initialize to an appropriate value
			double deltaTime = 0F; // TODO: Initialize to an appropriate value
			target.UpdateSpeed(deltaTime);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}
	}
}
