﻿using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProgramTest
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
        ///A test for Main
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void MainTest()
        {
            Program_Accessor.Main();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnUnhandledException
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnUnhandledExceptionTest()
        {
            object sender = null; // TODO: Initialize to an appropriate value
            UnhandledExceptionEventArgs e = null; // TODO: Initialize to an appropriate value
            Program_Accessor.OnUnhandledException(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Main
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void MainTest1()
        {
            Program_Accessor.Main();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnUnhandledException
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnUnhandledExceptionTest1()
        {
            object sender = null; // TODO: Initialize to an appropriate value
            UnhandledExceptionEventArgs e = null; // TODO: Initialize to an appropriate value
            Program_Accessor.OnUnhandledException(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
