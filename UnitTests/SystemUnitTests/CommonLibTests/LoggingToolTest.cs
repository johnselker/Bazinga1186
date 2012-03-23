using CommonLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace CommonLibTests
{
    
    
    /// <summary>
    ///This is a test class for LoggingToolTest and is intended
    ///to contain all LoggingToolTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoggingToolTest
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
        ///A test for LogInfoFormat
        ///</summary>
        [TestMethod()]
        public void LogInfoFormatTest()
        {
            MethodBase callingMethod = null; // TODO: Initialize to an appropriate value
            LoggingTool target = new LoggingTool(callingMethod); // TODO: Initialize to an appropriate value
            string format = string.Empty; // TODO: Initialize to an appropriate value
            object[] args = null; // TODO: Initialize to an appropriate value
            target.LogInfoFormat(format, args);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogInfo
        ///</summary>
        [TestMethod()]
        public void LogInfoTest()
        {
            MethodBase callingMethod = null; // TODO: Initialize to an appropriate value
            LoggingTool target = new LoggingTool(callingMethod); // TODO: Initialize to an appropriate value
            object message = null; // TODO: Initialize to an appropriate value
            target.LogInfo(message);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogErrorFormat
        ///</summary>
        [TestMethod()]
        public void LogErrorFormatTest()
        {
            MethodBase callingMethod = null; // TODO: Initialize to an appropriate value
            LoggingTool target = new LoggingTool(callingMethod); // TODO: Initialize to an appropriate value
            string format = string.Empty; // TODO: Initialize to an appropriate value
            object[] args = null; // TODO: Initialize to an appropriate value
            target.LogErrorFormat(format, args);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogError
        ///</summary>
        [TestMethod()]
        public void LogErrorTest()
        {
            MethodBase callingMethod = null; // TODO: Initialize to an appropriate value
            LoggingTool target = new LoggingTool(callingMethod); // TODO: Initialize to an appropriate value
            object message = null; // TODO: Initialize to an appropriate value
            Exception exception = null; // TODO: Initialize to an appropriate value
            target.LogError(message, exception);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogError
        ///</summary>
        [TestMethod()]
        public void LogErrorTest1()
        {
            MethodBase callingMethod = null; // TODO: Initialize to an appropriate value
            LoggingTool target = new LoggingTool(callingMethod); // TODO: Initialize to an appropriate value
            object message = null; // TODO: Initialize to an appropriate value
            target.LogError(message);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogDebugFormat
        ///</summary>
        [TestMethod()]
        public void LogDebugFormatTest()
        {
            MethodBase callingMethod = null; // TODO: Initialize to an appropriate value
            LoggingTool target = new LoggingTool(callingMethod); // TODO: Initialize to an appropriate value
            string format = string.Empty; // TODO: Initialize to an appropriate value
            object[] args = null; // TODO: Initialize to an appropriate value
            target.LogDebugFormat(format, args);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogDebug
        ///</summary>
        [TestMethod()]
        public void LogDebugTest()
        {
            MethodBase callingMethod = null; // TODO: Initialize to an appropriate value
            LoggingTool target = new LoggingTool(callingMethod); // TODO: Initialize to an appropriate value
            object message = null; // TODO: Initialize to an appropriate value
            target.LogDebug(message);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoggingTool Constructor
        ///</summary>
        [TestMethod()]
        public void LoggingToolConstructorTest()
        {
            MethodBase callingMethod = null; // TODO: Initialize to an appropriate value
            LoggingTool target = new LoggingTool(callingMethod);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
