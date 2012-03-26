using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Drawing.Text;
using System.Reflection;
using System.IO;

namespace CTCOfficeGUI
   {

   /// <summary>
   /// Public static class that contains miscellaneous drawing utilities not provided by .NET, such
   /// as drawing complex shapes.
   /// </summary>
   public static class DrawingUtils
      {
      /// <summary>
      /// Public static method that retrieves a bitmap from the current project that is an embedded resource.
      /// </summary>
      /// <param name="resourceName">The name of the resource prefixed with the namespace of the project 
      /// that contains it, you must specify the extension as well i.e. 'SSXPControls.mybitmap.bmp'.</param>
      /// <returns>An initialized bitmap with transparent background.</returns>
      public static Bitmap GetBitmapFromResources(string resourceName)
         {
         Assembly assmb = Assembly.GetExecutingAssembly();
         Bitmap temp = null;

         Stream strm = assmb.GetManifestResourceStream(resourceName);
         using (Bitmap bmp = new Bitmap(strm))
            {
            bmp.MakeTransparent(Color.FromArgb(255, 255, 255));
            temp = bmp.Clone() as Bitmap;
            bmp.Dispose();
            }
         strm.Close();

         return temp;
         }

      // METHOD: ResizeImage
      //------------------------------------------------------------------------
      /// <summary>
      /// Resize an image.
      /// </summary>
      /// 
      /// <returns>
      /// A resized verison of the image keeping the height and width
      /// proportional.  Returns "null" on error.
      /// </returns>
      ///
      /// <remarks>
      /// Resizes an image proportionally.
      /// </remarks>
      ///
      /// <!-- PARAMETERS -->
      /// <param name="imgToResize">The original image to be resized.</param>
      /// <param name="newSize">The new desired size to scale to.</param>
      //------------------------------------------------------------------------
      public static Image ResizeImage(Image imgToResize, Size newSize)
      {
          int sourceWidth = imgToResize.Width;
          int sourceHeight = imgToResize.Height;

          float nPercent = 0;
          float nPercentW = 0;
          float nPercentH = 0;

          // Calculate the percentages of the new size compared to the original...
          nPercentW = ((float)newSize.Width / (float)sourceWidth);
          nPercentH = ((float)newSize.Height / (float)sourceHeight);

          // Decide which percentage is smaller because this is the percent 
          // of the original image we will use for both height and width.
          if (nPercentH < nPercentW)
          {
              nPercent = nPercentH;
          }
          else
          {
              nPercent = nPercentW;
          }

          // Now calculate the number of height and width pixels for the destination image.
          int destWidth = (int)(sourceWidth * nPercent);
          int destHeight = (int)(sourceHeight * nPercent);

          // Create the bitmap on which will be drawn the resized image.
          // Set the interpolation mode, which is the algorithm used to resize the image.
          // 'HighQualityBicubic' seems to return the highest quality results.
          Bitmap b = new Bitmap(destWidth, destHeight);
          using (Graphics g = Graphics.FromImage((Image)b))
          {
              g.InterpolationMode = InterpolationMode.HighQualityBicubic;
              g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
          }
          return (Image)b;
      }

      // METHOD: ResizeImage
      //------------------------------------------------------------------------
      /// <summary>
      /// Resize an image.
      /// </summary>
      /// 
      /// <returns>
      /// A resized verison of the image keeping the height and width
      /// proportional.  Returns "null" on error.
      /// </returns>
      ///
      /// <remarks>
      /// Resizes an image proportionally.
      /// </remarks>
      ///
      /// <!-- PARAMETERS -->
      /// <param name="imgToResize">The original image to be resized.</param>
      /// <param name="newSize">The new desired size to scale to.</param>
      //------------------------------------------------------------------------
      public static Image ResizeImageStretch(Image imgToResize, Size newSize)
      {
          int sourceWidth = imgToResize.Width;
          int sourceHeight = imgToResize.Height;

          // Now calculate the number of height and width pixels for the destination image.
          int destWidth = newSize.Width;
          int destHeight = newSize.Height;

          // Create the bitmap on which will be drawn the resized image.
          // Set the interpolation mode, which is the algorithm used to resize the image.
          // 'HighQualityBicubic' seems to return the highest quality results.
          Bitmap b = new Bitmap(destWidth, destHeight);
          using (Graphics g = Graphics.FromImage((Image)b))
          {
              g.InterpolationMode = InterpolationMode.HighQualityBicubic;
              g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
          }
          return (Image)b;
      }

      // METHOD: CropImage
      //------------------------------------------------------------------------
      /// <summary>
      /// Crops an image.
      /// </summary>
      /// 
      /// <returns>
      /// A croppped portion of the original image.
      /// </returns>
      ///
      /// <remarks>
      /// Provides a croppped portion of the original image.
      /// </remarks>
      ///
      /// <!-- PARAMETERS -->
      /// <param name="img">Image from which to derive the cropped image.</param>
      /// <param name="cropArea">The desired crop area.</param>
      //------------------------------------------------------------------------
      public static Image CropImage(Image img, Rectangle cropArea)
      {
          Bitmap bmpImage = new Bitmap(img);
          Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
          return (Image)(bmpCrop);
      }

      /// <summary>
      /// Overloaded public static method that draws a button widget / bitmap taken from an embedded project resource via its name.  This
      /// method allows the distance from the right of its bounding area to be drawn, it is centered vertically.
      /// </summary>
      /// <param name="boundingBox">The containing rectangle to draw the widget in.</param>
      /// <param name="offsetFromLeft">The distance from the containing rectangles left x coordinate.</param>
      /// <param name="resourceName">The name of the resource prefixed with the namespace of the project 
      /// that contains it, you must specify the extension as well i.e. 'SSXPControls.mybitmap.bmp'.</param>
      /// <param name="graphics">The graphics object used to do the drawing passed in from client code.</param>
      public static void DrawButtonWidgetFromResourceH(Rectangle boundingBox, int offsetFromLeft,
                                                       string resourceName, Graphics graphics)
         {

         Assembly assmb = Assembly.GetExecutingAssembly();
         Stream strm = assmb.GetManifestResourceStream(resourceName);
         using (Bitmap bmp = new Bitmap(strm))
            {
            bmp.MakeTransparent(Color.FromArgb(255, 255, 255));

            SmoothingMode originalMode = graphics.SmoothingMode;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphics.DrawImage(bmp, new Rectangle(boundingBox.Left + offsetFromLeft, boundingBox.Top + (boundingBox.Height / 2) - (bmp.Height / 2),
                               bmp.Width, bmp.Height));

            graphics.SmoothingMode = originalMode;
            bmp.Dispose();
            }
         strm.Close();
         }

      /// <summary>
      /// Overloaded public static method that draws a button widget / bitmap.
      /// </summary>
      /// <param name="boundingBox">The bounding area to draw the bitmap / widget in.</param>
      /// <param name="offsetFromLeft">The distance from the containing rectangles left x coordinate.</param>
      /// <param name="graphics">The graphics object used to do the drawing passed in from client code.</param>
      /// <param name="widget">The bitmap to be drawn in the button area.</param>
      public static void DrawButtonWidgetH(Rectangle boundingBox, int offsetFromLeft, Graphics graphics, Bitmap widget)
         {

         SmoothingMode originalMode = graphics.SmoothingMode;

         graphics.SmoothingMode = SmoothingMode.AntiAlias;


         graphics.DrawImage(widget, new Rectangle(boundingBox.Left + offsetFromLeft,
            boundingBox.Top + (boundingBox.Height / 2) - (widget.Height / 2), widget.Width, widget.Height));

         graphics.SmoothingMode = originalMode;
         }

      /// <summary>
      /// Overloaded public static method that draws a bitmap/widget on a button. The resource is stored as part of the project
      /// as a embedded resource.
      /// </summary>
      /// <param name="boundingBox">The region that defines the button and that the widget will be drawn in.</param>
      /// <param name="resourceName">The name of the resource prefixed with the namespace of the project 
      /// that contains it, you must specify the extension as well i.e. 'SSXPControls.mybitmap.bmp'.</param>
      /// <param name="offsetFromTop">The distance from the top of it's bounding area (the button rectangle).</param>
      /// <param name="graphics">The graphics object used to do the drawing passed in from client code.</param>
      public static void DrawButtonWidgetFromResourceV(Rectangle boundingBox, string resourceName, int offsetFromTop, Graphics graphics)
         {

         Assembly assmb = Assembly.GetExecutingAssembly();
         Stream strm = assmb.GetManifestResourceStream(resourceName);
         using (Bitmap bmp = new Bitmap(strm))
            {
            bmp.MakeTransparent(Color.FromArgb(255, 255, 255));

            SmoothingMode originalMode = graphics.SmoothingMode;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphics.DrawImage(bmp, new Rectangle(boundingBox.Left + (boundingBox.Width / 2) - (bmp.Width / 2),
               boundingBox.Top + offsetFromTop, bmp.Width, bmp.Height));

            graphics.SmoothingMode = originalMode;
            bmp.Dispose();
            }
         strm.Close();
         }

      /// <summary>
      /// Public method that draws a button widget inside a button.
      /// </summary>
      /// <param name="boundingBox">The bounding area to draw the bitmap / widget in.</param>
      /// <param name="offsetFromTop">The distance from the top of the bounding rectangle to start drawing.</param>
      /// <param name="graphics">The graphics object used to do the drawing passed in from client code.</param>
      /// <param name="widget">The widget/bitmap to be drawn.</param>
      public static void DrawButtonWidgetV(Rectangle boundingBox, int offsetFromTop, Graphics graphics, Bitmap widget)
         {

         SmoothingMode originalMode = graphics.SmoothingMode;

         graphics.SmoothingMode = SmoothingMode.AntiAlias;

         graphics.DrawImage(widget, new Rectangle(boundingBox.Left + (boundingBox.Width / 2) - (widget.Width / 2),
            boundingBox.Top + offsetFromTop, widget.Width, widget.Height));

         graphics.SmoothingMode = originalMode;

         }

      /// <summary>
      /// Public static method that allows a bitmap to be drawn on a button and the exact location within the button to be specified.
      /// </summary>
      /// <param name="boundingBox">The bounding area to draw the bitmap / widget in.</param>
      /// <param name="offsetFromLeft">The distance from the containing rectangles left x coordinate.</param>
      /// <param name="offsetFromTop">The distance from the top of the bounding rectangle to start drawing.</param>
      /// <param name="resourceName">The name of the resource prefixed with the namespace of the project 
      /// that contains it, you must specify the extension as well i.e. 'SSXPControls.mybitmap.bmp'.</param>
      /// <param name="graphics">The graphics object used to do the drawing passed in from client code.</param>
      public static void DrawButtonWidgetFromResource(Rectangle boundingBox, int offsetFromLeft, int offsetFromTop,
                                         string resourceName, Graphics graphics)
         {

         Assembly assmb = Assembly.GetExecutingAssembly();
         Stream strm = assmb.GetManifestResourceStream(resourceName);
         using (Bitmap bmp = new Bitmap(strm))
            {
            bmp.MakeTransparent(Color.FromArgb(255, 255, 255));

            SmoothingMode originalMode = graphics.SmoothingMode;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int x;
            int y;

            if (offsetFromLeft == 0)
               x = boundingBox.Left;
            else
               x = boundingBox.Left + offsetFromLeft;

            if (offsetFromTop == 0)
               y = boundingBox.Top;
            else
               y = boundingBox.Top + offsetFromTop;

            graphics.DrawImage(bmp, new Rectangle(x, y, bmp.Width, bmp.Height));

            graphics.SmoothingMode = originalMode;
            bmp.Dispose();
            }
         strm.Close();
         }

      /// <summary>
      /// Public static method that draws a bitmap/widget on a button and allows the location inside the button to draw the bitmap
      /// to be specified.
      /// </summary>
      /// <param name="boundingBox">The bounding area to draw the bitmap / widget in.</param>
      /// <param name="offsetFromLeft">The distance from the containing rectangles left x coordinate.</param>
      /// <param name="offsetFromTop">The distance from the top of the bounding rectangle to start drawing.</param>
      /// <param name="graphics">The graphics object used to do the drawing passed in from client code.</param>
      /// <param name="widget">The widget/bitmap to be drawn.</param>
      public static void DrawButtonWidgetByLocation(Rectangle boundingBox, int offsetFromLeft, int offsetFromTop, Graphics graphics, Bitmap widget)
         {

         SmoothingMode originalMode = graphics.SmoothingMode;

         graphics.SmoothingMode = SmoothingMode.AntiAlias;

         int x;
         int y;

         if (offsetFromLeft == 0)
            x = boundingBox.Left;
         else
            x = boundingBox.Left + offsetFromLeft;

         if (offsetFromTop == 0)
            y = boundingBox.Top;
         else
            y = boundingBox.Top + offsetFromTop;


         graphics.DrawImage(widget, new Rectangle(x, y, widget.Width, widget.Height));

         graphics.SmoothingMode = originalMode;

         }

      /// <summary>
      /// Public static method that draws a widget / bitmap centered within it's bounding rectangle.
      /// </summary>
      /// <param name="boundingBox">The bounding area to draw the bitmap / widget in.</param>
      /// <param name="graphics">The graphics object used to do the drawing passed in from client code.</param>
      /// <param name="widget">The widget/bitmap to be drawn.</param>
      public static void DrawButtonWidgetCentered(Rectangle boundingBox, Graphics graphics, Bitmap widget)
         {
         SmoothingMode originalMode = graphics.SmoothingMode;

         graphics.SmoothingMode = SmoothingMode.AntiAlias;

         int x = boundingBox.Left + (boundingBox.Width / 2) - (widget.Width / 2);
         int y = (boundingBox.Height / 2) - (widget.Height / 2);

         graphics.DrawImage(widget, new Rectangle(x, y, widget.Width, widget.Height));

         graphics.SmoothingMode = originalMode;

         }

      /// <summary>
      /// Public static method that draws a widget / bitmap by specifying a location.
      /// </summary>
      /// <param name="boundingBox">The bounding area to draw the bitmap / widget in.</param>
      /// <param name="location">The X and Y coordinates to start drawing at.</param>
      /// <param name="graphics">The graphics object used to do the drawing passed in from client code.</param>
      /// <param name="widget">The widget/bitmap to be drawn.</param>
      public static void DrawWidgetByLocation(Rectangle boundingBox, Point location, Graphics graphics, Bitmap widget)
         {
         SmoothingMode originalMode = graphics.SmoothingMode;

         graphics.SmoothingMode = SmoothingMode.AntiAlias;

         graphics.DrawImage(widget, location.X, location.Y);

         graphics.SmoothingMode = originalMode;

         }

      /// <summary>
      /// Public static method that draw a bitmap / widget centered in a button/rectangle. The bitmap is obtained
      /// from the project resources, it is not passed in.
      /// </summary>
      /// <param name="boundingBox">The bounding area to draw the bitmap / widget in.</param>
      /// <param name="resourceName">The name of the resource prefixed with the namespace of the project 
      /// that contains it, you must specify the extension as well i.e. 'SSXPControls.mybitmap.bmp'.</param>
      /// <param name="graphics">The graphics object used to do the drawing passed in from client code.</param>
      public static void DrawButtonWidgetCentered(Rectangle boundingBox, string resourceName, Graphics graphics)
         {
         Assembly assmb = Assembly.GetExecutingAssembly();
         Stream strm = assmb.GetManifestResourceStream(resourceName);
         using (Bitmap bmp = new Bitmap(strm))
            {
            bmp.MakeTransparent(Color.FromArgb(255, 255, 255));

            SmoothingMode originalMode = graphics.SmoothingMode;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int x = boundingBox.Left + (boundingBox.Width / 2) - (bmp.Width / 2);
            int y = (boundingBox.Height / 2) - (bmp.Height / 2);

            graphics.DrawImage(bmp, new Rectangle(x, y, bmp.Width, bmp.Height));

            graphics.SmoothingMode = originalMode;
            bmp.Dispose();
            }
         strm.Close();
         }

      /// <summary>
      /// Accepts a graphics path that defines some region to be painted using gradiants to simulate 3D.
      /// </summary>
      /// <param name="pen">The pen used to draw the border around path.</param>
      /// <param name="boundingRectangle">The rectangle that defines the area to draw the path in.</param>
      /// <param name="path">The graphics path to be drawn.</param>
      /// <param name="faceColor">The fill color.</param>
      /// <param name="highLightColor">The gradient that starts at the top left corner.</param>
      /// <param name="lowLightColor">The gradient that starts at the bottom right corner.</param>
      public static void DrawGraphicsPath(Pen pen, Rectangle boundingRectangle, GraphicsPath path,
                                          Color highLightColor, Color lowLightColor, Graphics graphics)
         {
         // Enable anti-alias on the outline but not the fill.  Restore the
         // original smoothing mode when done.  NOTE: the fill must be done
         // FIRST for the border to be drawn right.  Just a weird .NET-ism.
         SmoothingMode originalMode = graphics.SmoothingMode;
         graphics.SmoothingMode = SmoothingMode.AntiAlias;

         pen.Alignment = PenAlignment.Center;

         LinearGradientBrush brush = new LinearGradientBrush(boundingRectangle, highLightColor, lowLightColor,
                                                            LinearGradientMode.ForwardDiagonal);

         graphics.FillPath(brush, path);
         graphics.DrawPath(pen, path);

         graphics.SmoothingMode = originalMode;

         brush.Dispose();
         }

      public static void Draw3DButton(Rectangle rectangle, Color highlightColor, Color lowlightColor, Color faceColor, int bevelWidth,
                                      string caption, Font captionFont, Color captionColor, Graphics graphics)
         {
         Draw3DBox(rectangle, highlightColor, lowlightColor, faceColor, bevelWidth, graphics);
         DrawTextInCenter(rectangle, caption, captionFont, captionColor, graphics);
         }

      public static void DrawFlatRectangleButton(Rectangle buttonArea, string buttonText, Font buttonFont, Color buttonTextColor,
         Color fillColor, Color borderColor, Graphics graphics)
         {
         SolidBrush brush = new SolidBrush(fillColor);
         Pen pen = new Pen(borderColor);

         graphics.FillRectangle(brush, buttonArea);
         graphics.DrawRectangle(pen, buttonArea);
         DrawTextInCenter(buttonArea, buttonText, buttonFont, buttonTextColor, graphics);

         brush.Dispose();
         pen.Dispose();

         }

       // METHOD: Draw3DBox
      //------------------------------------------------------------------------
      /// <summary>
      /// Draws a 3D (beveled) box.
      /// </summary>
      /// 
      /// <returns>
      /// None
      /// </returns>
      ///
      /// <!-- PARAMETERS -->
      /// <param name="rectangle">
      /// The rectangle in which to draw the box.
      /// </param>
      /// 
      /// <param name="highlightColor">
      /// Color for the bevel highlight.
      /// </param>
      /// 
      /// <param name="lowlightColor">
      /// Color for the bevel lowlight.
      /// </param>
      /// 
      /// <param name="faceColor">
      /// Color for the box's interior face color.
      /// </param>
      /// 
      /// <param name="bevelWidth">
      /// Width of the bevel.
      /// </param>
      //------------------------------------------------------------------------

      public static Rectangle Draw3DBox(Rectangle rectangle, Color highlightColor, Color lowlightColor,
         Color faceColor, int bevelWidth, Graphics graphics)
         {
         SolidBrush brush = new SolidBrush(faceColor);
         Point[] highlightPts = new Point[6];
         Rectangle innerRect = new Rectangle();

         // Enable anti-alias on the outline but not the fill.  Restore the
         // original smoothing mode when done.  NOTE: the fill must be done
         // FIRST for the border to be drawn right.  Just a weird .NET-ism.
         //SmoothingMode originalMode = graphics.SmoothingMode;
         //graphics.SmoothingMode = SmoothingMode.AntiAlias;
         // ********************************************
         // LOWLIGHT
         // Drawn by filling in the background
         // ********************************************

         brush.Color = lowlightColor;
         graphics.FillRectangle(brush, rectangle);

         // ********************************************
         // HIGHLIGHT
         // The highlight is drawn around the top/left sides of the bitmap, in a
         // six-point polygon.  The six points are indicated below with numbers.
         // The other *'s are drawn by filling the polygon formed by those six points.
         //
         // Note: this is just an example - in reality the position of the points
         // will vary depending on the bevel width.
         //
         //   0 * * * * * * 1
         //   * 3 * * * * 2 -
         //   * * - - - - - -
         //   * 4 - - - - - -
         //   5 - - - - - - -
         // ********************************************
         highlightPts[0].X = rectangle.Left;
         highlightPts[0].Y = rectangle.Top;

         highlightPts[1].X = rectangle.Right;
         highlightPts[1].Y = rectangle.Top;

         highlightPts[2].X = rectangle.Right - bevelWidth;
         highlightPts[2].Y = rectangle.Top + bevelWidth;

         highlightPts[3].X = rectangle.Left + bevelWidth;
         highlightPts[3].Y = rectangle.Top + bevelWidth;

         highlightPts[4].X = rectangle.Left + bevelWidth;
         highlightPts[4].Y = rectangle.Bottom - bevelWidth;

         highlightPts[5].X = rectangle.Left;
         highlightPts[5].Y = rectangle.Bottom;

         brush.Color = highlightColor;
         graphics.FillPolygon(brush, highlightPts);

         // ******************************************
         // FACE
         // Drawn by filling in an inner rectangle, which is the 'raised' portion of the 3D box.
         // ******************************************

         innerRect.X = rectangle.Left + bevelWidth;
         innerRect.Y = rectangle.Top + bevelWidth;
         innerRect.Height = rectangle.Height - (bevelWidth * 2);
         innerRect.Width = rectangle.Width - (bevelWidth * 2);

         brush.Color = faceColor;
         graphics.FillRectangle(brush, innerRect);

         // Dispose drawing objects because they may contain references to unmanged objects.
         //graphics.SmoothingMode = originalMode;

         brush.Dispose();
         return innerRect;//button face
         }
      // METHOD: Draw3DBox
      //------------------------------------------------------------------------
      /// <summary>
      /// Draws a 3D (beveled) box with a border.
      /// </summary>
      /// 
      /// <returns>
      /// The rectangle of the button's face area.
      /// </returns>
      /// 
      /// <remarks>
      /// Draws a box with a 3D appearance and bordered.
      /// </remarks>
      ///
      /// <!-- PARAMETERS -->
      /// <param name="borderPen">The pen used to draw the border.</param>
      /// <param name="rectangle">The rectangle in which to draw the box.</param>
      /// <param name="highlightColor">Color for the bevel highlight.</param>
      /// <param name="lowlightColor">Color for the bevel lowlight.</param>
      /// <param name="faceColor">Color for the box's interior face color.</param>
      /// <param name="bevelWidth">Width of the bevel.</param>
      /// <param name="graphics">The graphics object to draw on.</param>
      //------------------------------------------------------------------------
      public static Rectangle Draw3DBox(Pen borderPen, Rectangle rectangle, Color highlightColor, Color lowlightColor,
         Color faceColor, int bevelWidth, Graphics graphics)
      {
          SolidBrush brush = new SolidBrush(faceColor);
          Point[] highlightPts = new Point[6];
          Rectangle innerRect = new Rectangle();

          // Enable anti-alias on the outline but not the fill.  Restore the
          // original smoothing mode when done.  NOTE: the fill must be done
          // FIRST for the border to be drawn right.  
          SmoothingMode originalMode = graphics.SmoothingMode;
          graphics.SmoothingMode = SmoothingMode.AntiAlias;
          // ********************************************
          // LOWLIGHT
          // Drawn by filling in the background
          // ********************************************
          brush.Color = lowlightColor;
          graphics.FillRectangle(brush, rectangle);

          // ********************************************
          // HIGHLIGHT
          // The highlight is drawn around the top/left sides of the bitmap, in a
          // six-point polygon.  The six points are indicated below with numbers.
          // The other *'s are drawn by filling the polygon formed by those six points.
          //
          // Note: this is just an example - in reality the position of the points
          // will vary depending on the bevel width.
          //
          //   0 * * * * * * 1
          //   * 3 * * * * 2 -
          //   * * - - - - - -
          //   * 4 - - - - - -
          //   5 - - - - - - -
          // ********************************************
          highlightPts[0].X = rectangle.Left;
          highlightPts[0].Y = rectangle.Top;

          highlightPts[1].X = rectangle.Right;
          highlightPts[1].Y = rectangle.Top;

          highlightPts[2].X = rectangle.Right - bevelWidth;
          highlightPts[2].Y = rectangle.Top + bevelWidth;

          highlightPts[3].X = rectangle.Left + bevelWidth;
          highlightPts[3].Y = rectangle.Top + bevelWidth;

          highlightPts[4].X = rectangle.Left + bevelWidth;
          highlightPts[4].Y = rectangle.Bottom - bevelWidth;

          highlightPts[5].X = rectangle.Left;
          highlightPts[5].Y = rectangle.Bottom;

          brush.Color = highlightColor;
          graphics.FillPolygon(brush, highlightPts);

          // ******************************************
          // FACE
          // Drawn by filling in an inner rectangle, which is the 'raised' portion of the 3D box.
          // ******************************************
          innerRect.X = rectangle.Left + bevelWidth;
          innerRect.Y = rectangle.Top + bevelWidth;
          innerRect.Height = rectangle.Height - (bevelWidth * 2);
          innerRect.Width = rectangle.Width - (bevelWidth * 2);

          brush.Color = faceColor;
          graphics.FillRectangle(brush, innerRect);

          // Draw the border
          graphics.DrawRectangle(borderPen, rectangle);

          // Dispose drawing objects because they may contain references to unmanged objects.
          graphics.SmoothingMode = originalMode;

          brush.Dispose();
          // Return the button face area.
          return innerRect;
      }

      public static void DrawTextInCenter(Rectangle area, string text, Font textFont, Color textColor, Graphics graphics)
         {

         TextRenderingHint origHint = graphics.TextRenderingHint;
         
         if (textFont != null && textFont.Size > 10)
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;


         StringFormat style = new StringFormat();

         style.Alignment = StringAlignment.Center;
         style.LineAlignment = StringAlignment.Center;

         // Call the DrawString method of the System.Drawing class to write   
         // the translated text.

         graphics.DrawString(text, textFont, new SolidBrush(textColor), area, style);
         }

      public static void DrawTextH(Rectangle boundingRectangle, string text, Font textFont, Color textColor, float offsetFromLeft,
                                   Graphics graphics)
         {
         TextRenderingHint originalHint = graphics.TextRenderingHint;

         float x1 = boundingRectangle.Left + offsetFromLeft;
         float y1 = boundingRectangle.Top + (boundingRectangle.Height / 2) + 1;
         if (textFont.Size > 10)
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

         SizeF idTextSize = graphics.MeasureString(text, textFont);

         //get starting position for text
         PointF idTextPos = new PointF(x1, y1 - (idTextSize.Height / 2.0f));

         graphics.DrawString(text, textFont, new SolidBrush(textColor), idTextPos);

         graphics.TextRenderingHint = originalHint;
         }


      public static void DrawTextByLocation(Rectangle boundingRectangle, string text, Font textFont, Color textColor,
         float offsetFromLeft, float offsetFromTop, Graphics graphics)
         {
         TextRenderingHint originalHint = graphics.TextRenderingHint;

         float x1 = boundingRectangle.Left + offsetFromLeft;
         float y1 = boundingRectangle.Top + offsetFromTop;

         if (textFont.Size > 10)
             graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

         //get starting position for text
         PointF idTextPos = new PointF(x1, y1);

         graphics.DrawString(text, textFont, new SolidBrush(textColor), idTextPos);

         graphics.TextRenderingHint = originalHint;
         }

      public static void DrawTextV(Rectangle boundingRectangle, string text, Font textFont, Color textColor, float offsetFromTop,
                                   Graphics graphics)
         {
         TextRenderingHint originalHint = graphics.TextRenderingHint;

         float x1 = boundingRectangle.Right - (boundingRectangle.Width / 2);
         float y1 = boundingRectangle.Top + offsetFromTop;

         if (textFont.Size > 10)
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

         SizeF idTextSize = graphics.MeasureString(text, textFont);

         //get starting position for text
         PointF idTextPos = new PointF(x1 - (idTextSize.Width / 2.0f), y1);

         graphics.DrawString(text, textFont, new SolidBrush(textColor), idTextPos);

         graphics.TextRenderingHint = originalHint;
         }

        // METHOD: DrawArc
        //------------------------------------------------------------------------
        /// <summary>
        /// Draws an arc in a rectanglular area.
        /// </summary>
        /// 
        /// <returns>
        /// None.
        /// </returns>
        ///
        /// <remarks>
        /// Draws an arc in the specified recangle
        /// </remarks>
        /// 
        /// <!-- PARAMETERS -->
        /// <param name="graphics">The target graphics object to use.</param>
        /// <param name="pen">The pen object to use</param>
        /// <param name="Radius">The radius of the arc</param>
        /// <param name="Line1Start">The start location</param>
        /// <param name="Line1End">The end location</param>
        /// <param name="Line2Start">The start location</param>
        /// <param name="Line2End">The end location</param>
        /// <param name="StartAngle">The start angle</param>
        /// <param name="EndAngle">The end angle</param>
        //------------------------------------------------------------------------
        public static void DrawArc(Graphics graphics, Pen pen, int Radius, Point Line1Start, Point Line1End, Point Line2Start, Point Line2End, float StartAngle, float EndAngle)
        {
            int doubleRadius = 2 * Radius;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddArc(Line1End.X, Line1End.Y - Radius, doubleRadius, doubleRadius, StartAngle, EndAngle);
            graphics.DrawPath(pen, gp);
        }
    }
}
