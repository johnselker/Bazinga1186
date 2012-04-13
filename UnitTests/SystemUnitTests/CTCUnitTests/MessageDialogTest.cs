using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for MessageDialogTest and is intended
    ///to contain all MessageDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MessageDialogTest
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
        ///A test for TitleBarText
        ///</summary>
        [TestMethod()]
        public void TitleBarTextTest()
        {
            MessageDialog target = new MessageDialog(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.TitleBarText = expected;
            actual = target.TitleBarText;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PromptText
        ///</summary>
        [TestMethod()]
        public void PromptTextTest()
        {
            MessageDialog target = new MessageDialog(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.PromptText = expected;
            actual = target.PromptText;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ButtonTwoText
        ///</summary>
        [TestMethod()]
        public void ButtonTwoTextTest()
        {
            MessageDialog target = new MessageDialog(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ButtonTwoText = expected;
            actual = target.ButtonTwoText;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ButtonSpacing
        ///</summary>
        [TestMethod()]
        public void ButtonSpacingTest()
        {
            MessageDialog target = new MessageDialog(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ButtonSpacing = expected;
            actual = target.ButtonSpacing;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ButtonOneText
        ///</summary>
        [TestMethod()]
        public void ButtonOneTextTest()
        {
            MessageDialog target = new MessageDialog(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ButtonOneText = expected;
            actual = target.ButtonOneText;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ButtonCount
        ///</summary>
        [TestMethod()]
        public void ButtonCountTest()
        {
            MessageDialog target = new MessageDialog(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ButtonCount = expected;
            actual = target.ButtonCount;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OnButtonTwoClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnButtonTwoClickedTest()
        {
            MessageDialog_Accessor target = new MessageDialog_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnButtonTwoClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnButtonOneClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnButtonOneClickedTest()
        {
            MessageDialog_Accessor target = new MessageDialog_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnButtonOneClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest()
        {
            MessageDialog_Accessor target = new MessageDialog_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest()
        {
            MessageDialog_Accessor target = new MessageDialog_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AdjustButtonLocations
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void AdjustButtonLocationsTest()
        {
            MessageDialog_Accessor target = new MessageDialog_Accessor(); // TODO: Initialize to an appropriate value
            target.AdjustButtonLocations();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MessageDialog Constructor
        ///</summary>
        [TestMethod()]
        public void MessageDialogConstructorTest()
        {
            MessageDialog target = new MessageDialog();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for MessageDialog Constructor
        ///</summary>
        [TestMethod()]
        public void MessageDialogConstructorTest1()
        {
            string prompt = string.Empty; // TODO: Initialize to an appropriate value
            string buttonOneText = string.Empty; // TODO: Initialize to an appropriate value
            MessageDialog target = new MessageDialog(prompt, buttonOneText);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for MessageDialog Constructor
        ///</summary>
        [TestMethod()]
        public void MessageDialogConstructorTest2()
        {
            string prompt = string.Empty; // TODO: Initialize to an appropriate value
            string buttonOneText = string.Empty; // TODO: Initialize to an appropriate value
            string buttonTwoText = string.Empty; // TODO: Initialize to an appropriate value
            EventHandler buttonOneClickHandler = null; // TODO: Initialize to an appropriate value
            EventHandler buttonTwoClickHandler = null; // TODO: Initialize to an appropriate value
            MessageDialog target = new MessageDialog(prompt, buttonOneText, buttonTwoText, buttonOneClickHandler, buttonTwoClickHandler);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for MessageDialog Constructor
        ///</summary>
        [TestMethod()]
        public void MessageDialogConstructorTest3()
        {
            string prompt = string.Empty; // TODO: Initialize to an appropriate value
            string buttonOneText = string.Empty; // TODO: Initialize to an appropriate value
            EventHandler buttonOneClickHandler = null; // TODO: Initialize to an appropriate value
            MessageDialog target = new MessageDialog(prompt, buttonOneText, buttonOneClickHandler);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for MessageDialog Constructor
        ///</summary>
        [TestMethod()]
        public void MessageDialogConstructorTest4()
        {
            string prompt = string.Empty; // TODO: Initialize to an appropriate value
            string buttonOneText = string.Empty; // TODO: Initialize to an appropriate value
            string buttonTwoText = string.Empty; // TODO: Initialize to an appropriate value
            MessageDialog target = new MessageDialog(prompt, buttonOneText, buttonTwoText);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
