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
        ///A test for CloseLogin
        ///</summary>
        [TestMethod()]
        public void CloseLoginTest()
        {
            LoginChecker_Accessor target = new LoginChecker_Accessor(); 
            target.CloseLogin();
            Assert.IsNull(target.m_window);
        }

        /// <summary>
        ///A test for OnLoginAttempt
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnLoginAttemptTest()
        {
            LoginChecker_Accessor target = new LoginChecker_Accessor(); 
            string username = "admin";
            string password = "Bazinga!";
            target.OnLoginAttempt(username, password);
            Assert.IsNull(target.m_okPopup); 
            //Probably a bad way of checking this. Checking that events were raised is complicated
        }

        /// <summary>
        ///A test for OnLoginAttempt
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnLoginAttemptTest_badUser()
        {
            LoginChecker_Accessor target = new LoginChecker_Accessor();
            string username = "badusername";
            string password = "Bazinga!";
            target.OnLoginAttempt(username, password);
            Assert.IsNotNull(target.m_okPopup);
            //Probably a bad way of checking this. Checking that events were raised is complicated
        }

        /// <summary>
        ///A test for OnLoginAttempt
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnLoginAttemptTest_badPassword()
        {
            LoginChecker_Accessor target = new LoginChecker_Accessor();
            string username = "admin";
            string password = "badpassword";
            target.OnLoginAttempt(username, password);
            Assert.IsNotNull(target.m_okPopup);
            //Probably a bad way of checking this. Checking that events were raised is complicated
        }

        /// <summary>
        ///A test for OnPopupAcknowledged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnPopupAcknowledgedTest()
        {
            LoginChecker_Accessor target = new LoginChecker_Accessor();
            object sender = null; 
            EventArgs e = null; 
            target.OnPopupAcknowledged(sender, e);
            Assert.IsNull(target.m_okPopup);
        }
    }
}
