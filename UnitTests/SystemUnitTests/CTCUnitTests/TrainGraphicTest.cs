using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainLib;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for TrainGraphicTest and is intended
    ///to contain all TrainGraphicTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TrainGraphicTest
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
        ///A test for TrainGraphic Constructor
        ///</summary>
        [TestMethod()]
        public void TrainGraphicConstructorTest()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Blink
        ///</summary>
        [TestMethod()]
        public void BlinkTest()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train); // TODO: Initialize to an appropriate value
            target.Blink();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainGraphic_Accessor target = new TrainGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainGraphic_Accessor target = new TrainGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnPictureBoxClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnPictureBoxClickedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainGraphic_Accessor target = new TrainGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnPictureBoxClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetScale
        ///</summary>
        [TestMethod()]
        public void SetScaleTest()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train); // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetScale(scale);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StopBlinking
        ///</summary>
        [TestMethod()]
        public void StopBlinkingTest()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train); // TODO: Initialize to an appropriate value
            target.StopBlinking();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Train
        ///</summary>
        [TestMethod()]
        public void TrainTest()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train); // TODO: Initialize to an appropriate value
            ITrain expected = null; // TODO: Initialize to an appropriate value
            ITrain actual;
            target.Train = expected;
            actual = target.Train;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TrainGraphic Constructor
        ///</summary>
        [TestMethod()]
        public void TrainGraphicConstructorTest1()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Blink
        ///</summary>
        [TestMethod()]
        public void BlinkTest1()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train); // TODO: Initialize to an appropriate value
            target.Blink();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DisposeTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainGraphic_Accessor target = new TrainGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainGraphic_Accessor target = new TrainGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnPictureBoxClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnPictureBoxClickedTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrainGraphic_Accessor target = new TrainGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnPictureBoxClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetScale
        ///</summary>
        [TestMethod()]
        public void SetScaleTest1()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train); // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetScale(scale);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StopBlinking
        ///</summary>
        [TestMethod()]
        public void StopBlinkingTest1()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train); // TODO: Initialize to an appropriate value
            target.StopBlinking();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Train
        ///</summary>
        [TestMethod()]
        public void TrainTest1()
        {
            ITrain train = null; // TODO: Initialize to an appropriate value
            TrainGraphic target = new TrainGraphic(train); // TODO: Initialize to an appropriate value
            ITrain expected = null; // TODO: Initialize to an appropriate value
            ITrain actual;
            target.Train = expected;
            actual = target.Train;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
