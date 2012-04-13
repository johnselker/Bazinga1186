using CTCOfficeGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CTCUnitTests
{
    
    
    /// <summary>
    ///This is a test class for DrawingUtilsTest and is intended
    ///to contain all DrawingUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DrawingUtilsTest
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
        ///A test for ResizeImageStretch
        ///</summary>
        [TestMethod()]
        public void ResizeImageStretchTest()
        {
            Image imgToResize = null; // TODO: Initialize to an appropriate value
            Size newSize = new Size(); // TODO: Initialize to an appropriate value
            Image expected = null; // TODO: Initialize to an appropriate value
            Image actual;
            actual = DrawingUtils.ResizeImageStretch(imgToResize, newSize);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResizeImage
        ///</summary>
        [TestMethod()]
        public void ResizeImageTest()
        {
            Image imgToResize = null; // TODO: Initialize to an appropriate value
            Size newSize = new Size(); // TODO: Initialize to an appropriate value
            Image expected = null; // TODO: Initialize to an appropriate value
            Image actual;
            actual = DrawingUtils.ResizeImage(imgToResize, newSize);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBitmapFromResources
        ///</summary>
        [TestMethod()]
        public void GetBitmapFromResourcesTest()
        {
            string resourceName = string.Empty; // TODO: Initialize to an appropriate value
            Bitmap expected = null; // TODO: Initialize to an appropriate value
            Bitmap actual;
            actual = DrawingUtils.GetBitmapFromResources(resourceName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DrawWidgetByLocation
        ///</summary>
        [TestMethod()]
        public void DrawWidgetByLocationTest()
        {
            Rectangle boundingBox = new Rectangle(); // TODO: Initialize to an appropriate value
            Point location = new Point(); // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            Bitmap widget = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawWidgetByLocation(boundingBox, location, graphics, widget);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawTextV
        ///</summary>
        [TestMethod()]
        public void DrawTextVTest()
        {
            Rectangle boundingRectangle = new Rectangle(); // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            Font textFont = null; // TODO: Initialize to an appropriate value
            Color textColor = new Color(); // TODO: Initialize to an appropriate value
            float offsetFromTop = 0F; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawTextV(boundingRectangle, text, textFont, textColor, offsetFromTop, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawTextInCenter
        ///</summary>
        [TestMethod()]
        public void DrawTextInCenterTest()
        {
            Rectangle area = new Rectangle(); // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            Font textFont = null; // TODO: Initialize to an appropriate value
            Color textColor = new Color(); // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawTextInCenter(area, text, textFont, textColor, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawTextH
        ///</summary>
        [TestMethod()]
        public void DrawTextHTest()
        {
            Rectangle boundingRectangle = new Rectangle(); // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            Font textFont = null; // TODO: Initialize to an appropriate value
            Color textColor = new Color(); // TODO: Initialize to an appropriate value
            float offsetFromLeft = 0F; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawTextH(boundingRectangle, text, textFont, textColor, offsetFromLeft, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawTextByLocation
        ///</summary>
        [TestMethod()]
        public void DrawTextByLocationTest()
        {
            Rectangle boundingRectangle = new Rectangle(); // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            Font textFont = null; // TODO: Initialize to an appropriate value
            Color textColor = new Color(); // TODO: Initialize to an appropriate value
            float offsetFromLeft = 0F; // TODO: Initialize to an appropriate value
            float offsetFromTop = 0F; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawTextByLocation(boundingRectangle, text, textFont, textColor, offsetFromLeft, offsetFromTop, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawGraphicsPath
        ///</summary>
        [TestMethod()]
        public void DrawGraphicsPathTest()
        {
            Pen pen = null; // TODO: Initialize to an appropriate value
            Rectangle boundingRectangle = new Rectangle(); // TODO: Initialize to an appropriate value
            GraphicsPath path = null; // TODO: Initialize to an appropriate value
            Color highLightColor = new Color(); // TODO: Initialize to an appropriate value
            Color lowLightColor = new Color(); // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawGraphicsPath(pen, boundingRectangle, path, highLightColor, lowLightColor, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawFlatRectangleButton
        ///</summary>
        [TestMethod()]
        public void DrawFlatRectangleButtonTest()
        {
            Rectangle buttonArea = new Rectangle(); // TODO: Initialize to an appropriate value
            string buttonText = string.Empty; // TODO: Initialize to an appropriate value
            Font buttonFont = null; // TODO: Initialize to an appropriate value
            Color buttonTextColor = new Color(); // TODO: Initialize to an appropriate value
            Color fillColor = new Color(); // TODO: Initialize to an appropriate value
            Color borderColor = new Color(); // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawFlatRectangleButton(buttonArea, buttonText, buttonFont, buttonTextColor, fillColor, borderColor, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawButtonWidgetV
        ///</summary>
        [TestMethod()]
        public void DrawButtonWidgetVTest()
        {
            Rectangle boundingBox = new Rectangle(); // TODO: Initialize to an appropriate value
            int offsetFromTop = 0; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            Bitmap widget = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawButtonWidgetV(boundingBox, offsetFromTop, graphics, widget);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawButtonWidgetH
        ///</summary>
        [TestMethod()]
        public void DrawButtonWidgetHTest()
        {
            Rectangle boundingBox = new Rectangle(); // TODO: Initialize to an appropriate value
            int offsetFromLeft = 0; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            Bitmap widget = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawButtonWidgetH(boundingBox, offsetFromLeft, graphics, widget);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawButtonWidgetFromResourceV
        ///</summary>
        [TestMethod()]
        public void DrawButtonWidgetFromResourceVTest()
        {
            Rectangle boundingBox = new Rectangle(); // TODO: Initialize to an appropriate value
            string resourceName = string.Empty; // TODO: Initialize to an appropriate value
            int offsetFromTop = 0; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawButtonWidgetFromResourceV(boundingBox, resourceName, offsetFromTop, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawButtonWidgetFromResourceH
        ///</summary>
        [TestMethod()]
        public void DrawButtonWidgetFromResourceHTest()
        {
            Rectangle boundingBox = new Rectangle(); // TODO: Initialize to an appropriate value
            int offsetFromLeft = 0; // TODO: Initialize to an appropriate value
            string resourceName = string.Empty; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawButtonWidgetFromResourceH(boundingBox, offsetFromLeft, resourceName, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawButtonWidgetFromResource
        ///</summary>
        [TestMethod()]
        public void DrawButtonWidgetFromResourceTest()
        {
            Rectangle boundingBox = new Rectangle(); // TODO: Initialize to an appropriate value
            int offsetFromLeft = 0; // TODO: Initialize to an appropriate value
            int offsetFromTop = 0; // TODO: Initialize to an appropriate value
            string resourceName = string.Empty; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawButtonWidgetFromResource(boundingBox, offsetFromLeft, offsetFromTop, resourceName, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawButtonWidgetCentered
        ///</summary>
        [TestMethod()]
        public void DrawButtonWidgetCenteredTest()
        {
            Rectangle boundingBox = new Rectangle(); // TODO: Initialize to an appropriate value
            string resourceName = string.Empty; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawButtonWidgetCentered(boundingBox, resourceName, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawButtonWidgetCentered
        ///</summary>
        [TestMethod()]
        public void DrawButtonWidgetCenteredTest1()
        {
            Rectangle boundingBox = new Rectangle(); // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            Bitmap widget = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawButtonWidgetCentered(boundingBox, graphics, widget);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawButtonWidgetByLocation
        ///</summary>
        [TestMethod()]
        public void DrawButtonWidgetByLocationTest()
        {
            Rectangle boundingBox = new Rectangle(); // TODO: Initialize to an appropriate value
            int offsetFromLeft = 0; // TODO: Initialize to an appropriate value
            int offsetFromTop = 0; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            Bitmap widget = null; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawButtonWidgetByLocation(boundingBox, offsetFromLeft, offsetFromTop, graphics, widget);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawArc
        ///</summary>
        [TestMethod()]
        public void DrawArcTest()
        {
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            Pen pen = null; // TODO: Initialize to an appropriate value
            int Radius = 0; // TODO: Initialize to an appropriate value
            Point Line1Start = new Point(); // TODO: Initialize to an appropriate value
            Point Line1End = new Point(); // TODO: Initialize to an appropriate value
            Point Line2Start = new Point(); // TODO: Initialize to an appropriate value
            Point Line2End = new Point(); // TODO: Initialize to an appropriate value
            float StartAngle = 0F; // TODO: Initialize to an appropriate value
            float EndAngle = 0F; // TODO: Initialize to an appropriate value
            DrawingUtils.DrawArc(graphics, pen, Radius, Line1Start, Line1End, Line2Start, Line2End, StartAngle, EndAngle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Draw3DButton
        ///</summary>
        [TestMethod()]
        public void Draw3DButtonTest()
        {
            Rectangle rectangle = new Rectangle(); // TODO: Initialize to an appropriate value
            Color highlightColor = new Color(); // TODO: Initialize to an appropriate value
            Color lowlightColor = new Color(); // TODO: Initialize to an appropriate value
            Color faceColor = new Color(); // TODO: Initialize to an appropriate value
            int bevelWidth = 0; // TODO: Initialize to an appropriate value
            string caption = string.Empty; // TODO: Initialize to an appropriate value
            Font captionFont = null; // TODO: Initialize to an appropriate value
            Color captionColor = new Color(); // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            DrawingUtils.Draw3DButton(rectangle, highlightColor, lowlightColor, faceColor, bevelWidth, caption, captionFont, captionColor, graphics);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Draw3DBox
        ///</summary>
        [TestMethod()]
        public void Draw3DBoxTest()
        {
            Pen borderPen = null; // TODO: Initialize to an appropriate value
            Rectangle rectangle = new Rectangle(); // TODO: Initialize to an appropriate value
            Color highlightColor = new Color(); // TODO: Initialize to an appropriate value
            Color lowlightColor = new Color(); // TODO: Initialize to an appropriate value
            Color faceColor = new Color(); // TODO: Initialize to an appropriate value
            int bevelWidth = 0; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            Rectangle expected = new Rectangle(); // TODO: Initialize to an appropriate value
            Rectangle actual;
            actual = DrawingUtils.Draw3DBox(borderPen, rectangle, highlightColor, lowlightColor, faceColor, bevelWidth, graphics);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Draw3DBox
        ///</summary>
        [TestMethod()]
        public void Draw3DBoxTest1()
        {
            Rectangle rectangle = new Rectangle(); // TODO: Initialize to an appropriate value
            Color highlightColor = new Color(); // TODO: Initialize to an appropriate value
            Color lowlightColor = new Color(); // TODO: Initialize to an appropriate value
            Color faceColor = new Color(); // TODO: Initialize to an appropriate value
            int bevelWidth = 0; // TODO: Initialize to an appropriate value
            Graphics graphics = null; // TODO: Initialize to an appropriate value
            Rectangle expected = new Rectangle(); // TODO: Initialize to an appropriate value
            Rectangle actual;
            actual = DrawingUtils.Draw3DBox(rectangle, highlightColor, lowlightColor, faceColor, bevelWidth, graphics);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CropImage
        ///</summary>
        [TestMethod()]
        public void CropImageTest()
        {
            Image img = null; // TODO: Initialize to an appropriate value
            Rectangle cropArea = new Rectangle(); // TODO: Initialize to an appropriate value
            Image expected = null; // TODO: Initialize to an appropriate value
            Image actual;
            actual = DrawingUtils.CropImage(img, cropArea);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
