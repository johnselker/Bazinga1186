using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for LoginWindowTest and is intended
    ///to contain all LoginWindowTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoginWindowTest
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
        ///A test for LoginWindow Constructor
        ///</summary>
        [TestMethod()]
        public void LoginWindowConstructorTest()
        {
            LoginWindow target = new LoginWindow();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest()
        {
            LoginWindow_Accessor target = new LoginWindow_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest()
        {
            LoginWindow_Accessor target = new LoginWindow_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnCancelClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnCancelClickedTest()
        {
            LoginWindow_Accessor target = new LoginWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnCancelClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnLoginClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnLoginClickedTest()
        {
            LoginWindow_Accessor target = new LoginWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnLoginClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoginWindow Constructor
        ///</summary>
        [TestMethod()]
        public void LoginWindowConstructorTest1()
        {
            LoginWindow target = new LoginWindow();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest1()
        {
            LoginWindow_Accessor target = new LoginWindow_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest1()
        {
            LoginWindow_Accessor target = new LoginWindow_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnCancelClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnCancelClickedTest1()
        {
            LoginWindow_Accessor target = new LoginWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnCancelClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnLoginClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnLoginClickedTest1()
        {
            LoginWindow_Accessor target = new LoginWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnLoginClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
