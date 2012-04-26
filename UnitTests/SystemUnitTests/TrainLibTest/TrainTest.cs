using TrainLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using System.Drawing;

namespace TrainLibTests
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
			string trainID = string.Empty;
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.West;
			int cars = 0;
			int crew = 0;
			int passengers = 0;
			Train target = new Train(trainID, block, direction, cars, crew, passengers);
			Assert.AreEqual(trainID, target.GetState().TrainID);
			Assert.AreEqual(block, target.GetState().CurrentBlock);
			Assert.AreEqual(direction, target.GetState().Direction);
			Assert.AreEqual(1, target.GetState().Cars);
			Assert.AreEqual(crew, target.GetState().Crew);
			Assert.AreEqual(passengers, target.GetState().Passengers);
			Assert.AreEqual(TrainState.Door.Open, target.GetState().Doors);
			Assert.AreEqual(TrainState.Light.Off, target.GetState().Lights);
		}

		/// <summary>
		///A test for GetAcceleration
		///</summary>
		[TestMethod()]
		public void GetAccelerationTest()
		{
			string trainID = "AccelerationTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			double expected = 0;
			double actual = target.GetAcceleration();
			Assert.AreEqual(expected, actual);
			target.SetPower(1000, 0.1);
			expected = 1000 / (0.1 * target.GetState().Mass);
			actual = target.GetAcceleration();
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for GetBrake
		///</summary>
		[TestMethod()]
		public void BrakeTest()
		{
			string trainID = "BrakeTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			target.SetPower(10000, 0.1);
			target.SetBrake(true, 1);
			Assert.AreEqual(true, target.GetBrake());
			Assert.AreEqual(0, target.GetSpeed());
		}

		/// <summary>
		///A test for GetDirection
		///</summary>
		[TestMethod()]
		public void GetDirectionTest()
		{
			string trainID = "DirectionTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.West;
			Train target = new Train(trainID, block, direction);
			Assert.AreEqual(target.GetDirection(), direction);
			target.SetPower(10000, 10);
			Assert.AreEqual(target.GetDirection(), direction);
		}

		/// <summary>
		///A test for GetEmergencyBrake
		///</summary>
		[TestMethod()]
		public void EmergencyBrakeTest()
		{
			string trainID = "EmergencyBrakeTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			target.SetPower(10000, 0.1);
			target.SetEmergencyBrake(true, 1);
			Assert.AreEqual(true, target.GetEmergencyBrake());
			Assert.AreEqual(0, target.GetSpeed());
		}

		/// <summary>
		///A test for GetPosition
		///</summary>
		[TestMethod()]
		public void GetPositionTest()
		{
			string trainID = "UpdatePositionTestTrain";
			int x = 35;
			int y = 0;
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(x, y), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			Assert.AreEqual(x, target.GetPosition().X);
			Assert.AreEqual(y, target.GetPosition().Y);
		}

		/// <summary>
		///A test for GetPower
		///</summary>
		[TestMethod()]
		public void GetPowerTest()
		{
			string trainID = "PowerTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			double expected = 10000;
			target.SetPower(10000, 0.1);
			double actual = target.GetPower();
			Assert.AreEqual(expected, actual);
			expected = 1000;
			target.SetPower(1000, 0.1);
			actual = target.GetPower();
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for GetSpeed
		///</summary>
		[TestMethod()]
		public void GetSpeedTest()
		{
			string trainID = "SpeedTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			target.SetPower(10000, 0.1);
			Assert.AreNotEqual(0, target.GetSpeed());
		}

		/// <summary>
		///A test for GetState
		///</summary>
		[TestMethod()]
		public void GetStateTest()
		{
			string trainID = "StateTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			TrainState state = target.GetState();
			Assert.AreEqual(null, state.Announcement);
			Assert.AreEqual(0, state.BlockProgress);
			Assert.AreEqual(false, state.BrakeFailure);
			Assert.AreEqual(1, state.Cars);
			Assert.AreEqual(0, state.Crew);
			Assert.AreEqual(block, state.CurrentBlock);
			Assert.AreEqual(direction, state.Direction);
			Assert.AreEqual(TrainState.Door.Open, state.Doors);
			Assert.AreEqual(false, state.EngineFailure);
			Assert.AreEqual(TrainState.Light.Off, state.Lights);
			Assert.AreEqual(40900, state.Mass);
			Assert.AreEqual(0, state.Passengers);
			Assert.AreEqual(false, state.SignalPickupFailure);
			Assert.AreEqual(0, state.Speed);
			Assert.AreEqual(0, state.Temperature);
			Assert.AreEqual(trainID, state.TrainID);
			Assert.AreEqual(35, state.X);
			Assert.AreEqual(0, state.Y);
		}

		/// <summary>
		///A test for SetAnnouncement
		///</summary>
		[TestMethod()]
		public void SetAnnouncementTest()
		{
			string trainID = "AnnouncementTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			string annoucement = "A bomb threat has been received for the train. Please evacuate the train. If safe to do so, tell others of this message.";
			target.SetAnnouncement(annoucement);
			Assert.AreEqual(annoucement, target.GetState().Announcement);
		}

		/// <summary>
		///A test for SetBrakeFailure
		///</summary>
		[TestMethod()]
		public void SetBrakeFailureTest()
		{
			string trainID = "BrakeFailureTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			target.SetPower(10000, 0.5);
			target.SetBrakeFailure(true);
			target.SetBrake(true, 0.5);
			Assert.AreEqual(true, target.GetBrake());
			Assert.AreEqual(true, target.GetState().BrakeFailure);
			Assert.IsTrue(target.GetSpeed() > 0);
		}

		/// <summary>
		///A test for SetDoors
		///</summary>
		[TestMethod()]
		public void SetDoorsTest()
		{
			string trainID = "BrakeTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			Assert.AreEqual(TrainState.Door.Open, target.GetState().Doors);
			target.SetDoors(TrainState.Door.Closed);
			Assert.AreEqual(TrainState.Door.Closed, target.GetState().Doors);
		}

		/// <summary>
		///A test for SetEngineFailure
		///</summary>
		[TestMethod()]
		public void SetEngineFailureTest()
		{
			string trainID = "EngineFailureTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			target.SetPower(10000, 5);
			double previousSpeed = target.GetSpeed();
			target.SetEngineFailure(true);
			target.Update(1);
			double newSpeed = target.GetSpeed();
			Assert.AreEqual(true, target.GetState().EngineFailure);
			Assert.IsTrue(previousSpeed > newSpeed);
		}

		/// <summary>
		///A test for SetFriction
		///</summary>
		[TestMethod()]
		public void SetFrictionTest()
		{
			string trainID = "FrictionTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			target.SetPower(10000, 5);
			target.SetEngineFailure(true);
			double previousSpeed = target.GetSpeed();
			target.Update(1);
			double newSpeed = target.GetSpeed();
			double previousChange = previousSpeed - newSpeed;
			previousSpeed = newSpeed;
			target.SetFriction(0.5);
			target.Update(1);
			newSpeed = target.GetSpeed();
			double newChange = previousSpeed - newSpeed;
			Assert.IsTrue(newChange > previousChange);
		}

		/// <summary>
		///A test for SetLights
		///</summary>
		[TestMethod()]
		public void SetLightsTest()
		{
			string trainID = "LightsTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			Assert.AreEqual(TrainState.Light.Off, target.GetState().Lights);
			target.SetLights(TrainState.Light.Low);
			Assert.AreEqual(TrainState.Light.Low, target.GetState().Lights);
			target.SetLights(TrainState.Light.High);
			Assert.AreEqual(TrainState.Light.High, target.GetState().Lights);
		}

		/// <summary>
		///A test for SetPower
		///</summary>
		[TestMethod()]
		public void SetPowerTest()
		{
			string trainID = "PowerTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			target.SetPower(10000, 1);
			Assert.IsTrue(target.GetSpeed() > 0);
		}

		/// <summary>
		///A test for SetSignalPickupFailure
		///</summary>
		[TestMethod()]
		public void SetSignalPickupFailureTest()
		{
			string trainID = "SignalPickupFailureTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			Assert.AreEqual(false, target.GetState().SignalPickupFailure);
			target.SetSignalPickupFailure(true);
			Assert.AreEqual(true, target.GetState().SignalPickupFailure);
		}

		/// <summary>
		///A test for Update
		///</summary>
		[TestMethod()]
		public void UpdateTest()
		{
			string trainID = "UpdateTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train target = new Train(trainID, block, direction);
			target.SetPower(10000, 0.5);
			double previousX = target.GetState().X;
			double previousY = target.GetState().Y;
			double previousSpeed = target.GetSpeed();
			target.Update(10);
			Assert.IsTrue(target.GetState().X > previousX);
			Assert.IsTrue(target.GetState().Y == previousY);
			Assert.IsTrue(target.GetSpeed() >= previousSpeed);
		}
		
		/// <summary>
		///A test for UpdatePosition
		///</summary>
		[TestMethod()]
		[DeploymentItem("Train.dll")]
		public void UpdatePositionTest()
		{
			string trainID = "UpdatePositionTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train t = new Train(trainID, block, direction);
			PrivateObject param0 = new PrivateObject(t);
			Train_Accessor target = new Train_Accessor(param0);
			target.SetPower(10000, 1);
			double previousX = target.GetState().X;
			double previousY = target.GetState().Y;
			double previousSpeed = target.GetSpeed();
			target.UpdatePosition(4);
			Assert.IsTrue(target.GetState().X > previousX);
			Assert.IsTrue(target.GetState().Y == previousY);
			Assert.IsTrue(target.GetSpeed() == previousSpeed);
		}

		/// <summary>
		///A test for UpdateSpeed
		///</summary>
		[TestMethod()]
		[DeploymentItem("Train.dll")]
		public void UpdateSpeedTest()
		{
			string trainID = "UpdateSpeedTestTrain";
			TrackBlock block = new TrackBlock("block", TrackOrientation.EastWest, new Point(35, 0), 50.0, 0, 0,
							false, false, 40, TrackAllowedDirection.Both, false, null, null, "block", "block");
			block.NextBlock = block;
			Direction direction = Direction.East;
			Train t = new Train(trainID, block, direction);
			PrivateObject param0 = new PrivateObject(t);
			Train_Accessor target = new Train_Accessor(param0);
			target.SetPower(10000, 0.5);
			double previousX = target.GetState().X;
			double previousY = target.GetState().Y;
			double previousSpeed = target.GetSpeed();
			target.UpdateSpeed(10);
			Assert.IsTrue(target.GetState().X == previousX);
			Assert.IsTrue(target.GetState().Y == previousY);
			Assert.IsTrue(target.GetSpeed() > previousSpeed);
		}
		
	}
}
