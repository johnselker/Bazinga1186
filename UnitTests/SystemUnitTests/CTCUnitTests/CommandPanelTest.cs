using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CommonLib;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for CommandPanelTest and is intended
    ///to contain all CommandPanelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandPanelTest
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
        ///A test for CommandPanel Constructor
        ///</summary>
        [TestMethod()]
        public void CommandPanelConstructorTest()
        {
            CommandPanel target = new CommandPanel();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddButton
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void AddButtonTest()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            object tag = null; // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            target.AddButton(tag, text);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearButtons
        ///</summary>
        [TestMethod()]
        public void ClearButtonsTest()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            target.ClearButtons();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetNextYValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetNextYValueTest()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetNextYValue();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnButtonClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnButtonClickedTest()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnButtonClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetCommands
        ///</summary>
        [TestMethod()]
        public void SetCommandsTest()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            Dictionary<object, string> commands = null; // TODO: Initialize to an appropriate value
            target.SetCommands(commands);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowTrackBlockCommands
        ///</summary>
        [TestMethod()]
        public void ShowTrackBlockCommandsTest()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            target.ShowTrackBlockCommands(block);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowTrainCommands
        ///</summary>
        [TestMethod()]
        public void ShowTrainCommandsTest()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            target.ShowTrainCommands();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowTrainYardCommands
        ///</summary>
        [TestMethod()]
        public void ShowTrainYardCommandsTest()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            target.ShowTrainYardCommands();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CommandPanel Constructor
        ///</summary>
        [TestMethod()]
        public void CommandPanelConstructorTest1()
        {
            CommandPanel target = new CommandPanel();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddButton
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void AddButtonTest1()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            object tag = null; // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            target.AddButton(tag, text);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearButtons
        ///</summary>
        [TestMethod()]
        public void ClearButtonsTest1()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            target.ClearButtons();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest1()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetNextYValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetNextYValueTest1()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetNextYValue();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest1()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnButtonClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnButtonClickedTest1()
        {
            CommandPanel_Accessor target = new CommandPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnButtonClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetCommands
        ///</summary>
        [TestMethod()]
        public void SetCommandsTest1()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            Dictionary<object, string> commands = null; // TODO: Initialize to an appropriate value
            target.SetCommands(commands);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowTrackBlockCommands
        ///</summary>
        [TestMethod()]
        public void ShowTrackBlockCommandsTest1()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            target.ShowTrackBlockCommands(block);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowTrainCommands
        ///</summary>
        [TestMethod()]
        public void ShowTrainCommandsTest1()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            target.ShowTrainCommands();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowTrainYardCommands
        ///</summary>
        [TestMethod()]
        public void ShowTrainYardCommandsTest1()
        {
            CommandPanel target = new CommandPanel(); // TODO: Initialize to an appropriate value
            target.ShowTrainYardCommands();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
