using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for SchedulingScreen_ScheduleGroupTest and is intended
    ///to contain all SchedulingScreen_ScheduleGroupTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulingScreen_ScheduleGroupTest
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
        ///A test for ScheduleGroup Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void SchedulingScreen_ScheduleGroupConstructorTest()
        {
            ComboBox stationDropdown = null; // TODO: Initialize to an appropriate value
            TextBox arrivalTextBox = null; // TODO: Initialize to an appropriate value
            Button editButton = null; // TODO: Initialize to an appropriate value
            Button deleteButton = null; // TODO: Initialize to an appropriate value
            SchedulingScreen_Accessor.ScheduleGroup target = new SchedulingScreen_Accessor.ScheduleGroup(stationDropdown, arrivalTextBox, editButton, deleteButton);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ArrivalTextBox
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void ArrivalTextBoxTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SchedulingScreen_Accessor.ScheduleGroup target = new SchedulingScreen_Accessor.ScheduleGroup(param0); // TODO: Initialize to an appropriate value
            TextBox actual;
            actual = target.ArrivalTextBox;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteButton
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DeleteButtonTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SchedulingScreen_Accessor.ScheduleGroup target = new SchedulingScreen_Accessor.ScheduleGroup(param0); // TODO: Initialize to an appropriate value
            Button actual;
            actual = target.DeleteButton;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EditButton
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void EditButtonTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SchedulingScreen_Accessor.ScheduleGroup target = new SchedulingScreen_Accessor.ScheduleGroup(param0); // TODO: Initialize to an appropriate value
            Button actual;
            actual = target.EditButton;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StationDropdown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void StationDropdownTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SchedulingScreen_Accessor.ScheduleGroup target = new SchedulingScreen_Accessor.ScheduleGroup(param0); // TODO: Initialize to an appropriate value
            ComboBox actual;
            actual = target.StationDropdown;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
