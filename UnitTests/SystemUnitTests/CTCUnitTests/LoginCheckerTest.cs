using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for LoginCheckerTest and is intended
    ///to contain all LoginCheckerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoginCheckerTest
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
        ///A test for LoginChecker Constructor
        ///</summary>
        [TestMethod()]
        public void LoginCheckerConstructorTest()
        {
            LoginChecker target = new LoginChecker();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CloseLogin
        ///</summary>
        [TestMethod()]
        public void CloseLoginTest()
        {
            LoginChecker target = new LoginChecker(); // TODO: Initialize to an appropriate value
            target.CloseLogin();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnLoginAttempt
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnLoginAttemptTest()
        {
            LoginChecker_Accessor target = new LoginChecker_Accessor(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            target.OnLoginAttempt(username, password);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnLoginCancel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnLoginCancelTest()
        {
            LoginChecker_Accessor target = new LoginChecker_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnLoginCancel(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnPopupAcknowledged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnPopupAcknowledgedTest()
        {
            LoginChecker_Accessor target = new LoginChecker_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnPopupAcknowledged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowLogin
        ///</summary>
        [TestMethod()]
        public void ShowLoginTest()
        {
            LoginChecker target = new LoginChecker(); // TODO: Initialize to an appropriate value
            EventHandler successHandler = null; // TODO: Initialize to an appropriate value
            EventHandler cancelHandler = null; // TODO: Initialize to an appropriate value
            target.ShowLogin(successHandler, cancelHandler);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowOKPopup
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void ShowOKPopupTest()
        {
            LoginChecker_Accessor target = new LoginChecker_Accessor(); // TODO: Initialize to an appropriate value
            string title = string.Empty; // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            target.ShowOKPopup(title, text);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
