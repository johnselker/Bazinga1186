using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using System.Drawing;
using System.Windows.Forms;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for TrackBlockGraphicTest and is intended
    ///to contain all TrackBlockGraphicTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TrackBlockGraphicTest
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
        ///A test for TrackBlockGraphic Constructor
        ///</summary>
        [TestMethod()]
        public void TrackBlockGraphicConstructorTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Blink
        ///</summary>
        [TestMethod()]
        public void BlinkTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            target.Blink();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CalculateArrowPoints
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CalculateArrowPointsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            target.CalculateArrowPoints();
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
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawArrows
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DrawArrowsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            Graphics g = null; // TODO: Initialize to an appropriate value
            Pen p = null; // TODO: Initialize to an appropriate value
            target.DrawArrows(g, p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetDrawColor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetDrawColorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            actual = target.GetDrawColor();
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnPaint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnPaintTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            PaintEventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnPaint(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetScale
        ///</summary>
        [TestMethod()]
        public void SetScaleTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            double scale1 = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetScale(scale1);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StopBlinking
        ///</summary>
        [TestMethod()]
        public void StopBlinkingTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            target.StopBlinking();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrowLength
        ///</summary>
        [TestMethod()]
        public void ArrowLengthTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ArrowLength = expected;
            actual = target.ArrowLength;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BlinkColor
        ///</summary>
        [TestMethod()]
        public void BlinkColorTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.BlinkColor = expected;
            actual = target.BlinkColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Block
        ///</summary>
        [TestMethod()]
        public void BlockTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            TrackBlock expected = null; // TODO: Initialize to an appropriate value
            TrackBlock actual;
            target.Block = expected;
            actual = target.Block;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateParams
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CreateParamsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            CreateParams actual;
            actual = target.CreateParams;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DotColor
        ///</summary>
        [TestMethod()]
        public void DotColorTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.DotColor = expected;
            actual = target.DotColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GreenColor
        ///</summary>
        [TestMethod()]
        public void GreenColorTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.GreenColor = expected;
            actual = target.GreenColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineThickness
        ///</summary>
        [TestMethod()]
        public void LineThicknessTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.LineThickness = expected;
            actual = target.LineThickness;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RedColor
        ///</summary>
        [TestMethod()]
        public void RedColorTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.RedColor = expected;
            actual = target.RedColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowDot
        ///</summary>
        [TestMethod()]
        public void ShowDotTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ShowDot = expected;
            actual = target.ShowDot;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SuperGreenColor
        ///</summary>
        [TestMethod()]
        public void SuperGreenColorTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.SuperGreenColor = expected;
            actual = target.SuperGreenColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for YellowColor
        ///</summary>
        [TestMethod()]
        public void YellowColorTest()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.YellowColor = expected;
            actual = target.YellowColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TrackBlockGraphic Constructor
        ///</summary>
        [TestMethod()]
        public void TrackBlockGraphicConstructorTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Blink
        ///</summary>
        [TestMethod()]
        public void BlinkTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            target.Blink();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CalculateArrowPoints
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CalculateArrowPointsTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            target.CalculateArrowPoints();
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
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawArrows
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void DrawArrowsTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            Graphics g = null; // TODO: Initialize to an appropriate value
            Pen p = null; // TODO: Initialize to an appropriate value
            target.DrawArrows(g, p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetDrawColor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void GetDrawColorTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            actual = target.GetDrawColor();
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnClickTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnPaint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void OnPaintTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            PaintEventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnPaint(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetScale
        ///</summary>
        [TestMethod()]
        public void SetScaleTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            double scale1 = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetScale(scale1);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StopBlinking
        ///</summary>
        [TestMethod()]
        public void StopBlinkingTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            target.StopBlinking();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrowLength
        ///</summary>
        [TestMethod()]
        public void ArrowLengthTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ArrowLength = expected;
            actual = target.ArrowLength;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BlinkColor
        ///</summary>
        [TestMethod()]
        public void BlinkColorTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.BlinkColor = expected;
            actual = target.BlinkColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Block
        ///</summary>
        [TestMethod()]
        public void BlockTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            TrackBlock expected = null; // TODO: Initialize to an appropriate value
            TrackBlock actual;
            target.Block = expected;
            actual = target.Block;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateParams
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CTCOfficeGUI.exe")]
        public void CreateParamsTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            TrackBlockGraphic_Accessor target = new TrackBlockGraphic_Accessor(param0); // TODO: Initialize to an appropriate value
            CreateParams actual;
            actual = target.CreateParams;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DotColor
        ///</summary>
        [TestMethod()]
        public void DotColorTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.DotColor = expected;
            actual = target.DotColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GreenColor
        ///</summary>
        [TestMethod()]
        public void GreenColorTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.GreenColor = expected;
            actual = target.GreenColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineThickness
        ///</summary>
        [TestMethod()]
        public void LineThicknessTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.LineThickness = expected;
            actual = target.LineThickness;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RedColor
        ///</summary>
        [TestMethod()]
        public void RedColorTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.RedColor = expected;
            actual = target.RedColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowDot
        ///</summary>
        [TestMethod()]
        public void ShowDotTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ShowDot = expected;
            actual = target.ShowDot;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SuperGreenColor
        ///</summary>
        [TestMethod()]
        public void SuperGreenColorTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.SuperGreenColor = expected;
            actual = target.SuperGreenColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for YellowColor
        ///</summary>
        [TestMethod()]
        public void YellowColorTest1()
        {
            TrackBlock block = null; // TODO: Initialize to an appropriate value
            double scale = 0F; // TODO: Initialize to an appropriate value
            TrackBlockGraphic target = new TrackBlockGraphic(block, scale); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.YellowColor = expected;
            actual = target.YellowColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
