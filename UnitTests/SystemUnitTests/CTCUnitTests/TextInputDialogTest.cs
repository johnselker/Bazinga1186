using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for TextInputDialogTest and is intended
    ///to contain all TextInputDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TextInputDialogTest
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
        ///A test for TextValue
        ///</summary>
        [TestMethod()]
        public void TextValueTest()
        {
            TextInputDialog target = new TextInputDialog(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.TextValue = expected;
            actual = target.TextValue;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PromptText
        ///</summary>
        [TestMethod()]
        public void PromptTextTest()
        {
            TextInputDialog target = new TextInputDialog(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.PromptText = expected;
            actual = target.PromptText;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OnOKClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnOKClickedTest()
        {
            TextInputDialog_Accessor target = new TextInputDialog_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnOKClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnCancelClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnCancelClickedTest()
        {
            TextInputDialog_Accessor target = new TextInputDialog_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnCancelClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void InitializeComponentTest()
        {
            TextInputDialog_Accessor target = new TextInputDialog_Accessor(); // TODO: Initialize to an appropriate value
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
            TextInputDialog_Accessor target = new TextInputDialog_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TextInputDialog Constructor
        ///</summary>
        [TestMethod()]
        public void TextInputDialogConstructorTest()
        {
            TextInputDialog target = new TextInputDialog();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for TextInputDialog Constructor
        ///</summary>
        [TestMethod()]
        public void TextInputDialogConstructorTest1()
        {
            string prompt = string.Empty; // TODO: Initialize to an appropriate value
            TextInputDialog target = new TextInputDialog(prompt);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
