using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace Logitech
{
	public sealed class LcdGraphics : IDisposable
	{
		private readonly Graphics _graphics;
		public event EventHandler Disposed;

		internal LcdGraphics(Graphics graphics, int width, int height)
		{
			graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
			_graphics = graphics;
			Size = new Size(width, height);
		}

		public Size Size { get; private set; }

		public void Dispose()
		{
			_graphics.Dispose();
			var ev = Disposed;
			if (ev != null)
			{
				ev(this, EventArgs.Empty);
			}
		}

		#region Delegating methods

		public void Flush()
		{
			_graphics.Flush();
		}

		public void Flush(FlushIntention intention)
		{
			_graphics.Flush(intention);
		}

		public void CopyFromScreen(Point upperLeftSource, Point upperLeftDestination, Size blockRegionSize)
		{
			_graphics.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize);
		}

		public void CopyFromScreen(int sourceX, int sourceY, int destinationX, int destinationY, Size blockRegionSize)
		{
			_graphics.CopyFromScreen(sourceX, sourceY, destinationX, destinationY, blockRegionSize);
		}

		public void CopyFromScreen(Point upperLeftSource, Point upperLeftDestination, Size blockRegionSize,
			CopyPixelOperation copyPixelOperation)
		{
			_graphics.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize, copyPixelOperation);
		}

		public void CopyFromScreen(int sourceX, int sourceY, int destinationX, int destinationY, Size blockRegionSize,
			CopyPixelOperation copyPixelOperation)
		{
			_graphics.CopyFromScreen(sourceX, sourceY, destinationX, destinationY, blockRegionSize, copyPixelOperation);
		}

		public void ResetTransform()
		{
			_graphics.ResetTransform();
		}

		public void MultiplyTransform(Matrix matrix)
		{
			_graphics.MultiplyTransform(matrix);
		}

		public void MultiplyTransform(Matrix matrix, MatrixOrder order)
		{
			_graphics.MultiplyTransform(matrix, order);
		}

		public void TranslateTransform(float dx, float dy)
		{
			_graphics.TranslateTransform(dx, dy);
		}

		public void TranslateTransform(float dx, float dy, MatrixOrder order)
		{
			_graphics.TranslateTransform(dx, dy, order);
		}

		public void ScaleTransform(float sx, float sy)
		{
			_graphics.ScaleTransform(sx, sy);
		}

		public void ScaleTransform(float sx, float sy, MatrixOrder order)
		{
			_graphics.ScaleTransform(sx, sy, order);
		}

		public void RotateTransform(float angle)
		{
			_graphics.RotateTransform(angle);
		}

		public void RotateTransform(float angle, MatrixOrder order)
		{
			_graphics.RotateTransform(angle, order);
		}

		public void TransformPoints(CoordinateSpace destSpace, CoordinateSpace srcSpace, PointF[] pts)
		{
			_graphics.TransformPoints(destSpace, srcSpace, pts);
		}

		public void TransformPoints(CoordinateSpace destSpace, CoordinateSpace srcSpace, Point[] pts)
		{
			_graphics.TransformPoints(destSpace, srcSpace, pts);
		}

		public Color GetNearestColor(Color color)
		{
			return _graphics.GetNearestColor(color);
		}

		public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
		{
			_graphics.DrawLine(pen, x1, y1, x2, y2);
		}

		public void DrawLine(Pen pen, PointF pt1, PointF pt2)
		{
			_graphics.DrawLine(pen, pt1, pt2);
		}

		public void DrawLines(Pen pen, PointF[] points)
		{
			_graphics.DrawLines(pen, points);
		}

		public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
		{
			_graphics.DrawLine(pen, x1, y1, x2, y2);
		}

		public void DrawLine(Pen pen, Point pt1, Point pt2)
		{
			_graphics.DrawLine(pen, pt1, pt2);
		}

		public void DrawLines(Pen pen, Point[] points)
		{
			_graphics.DrawLines(pen, points);
		}

		public void DrawArc(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
		{
			_graphics.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
		}

		public void DrawArc(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
		{
			_graphics.DrawArc(pen, rect, startAngle, sweepAngle);
		}

		public void DrawArc(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
		{
			_graphics.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
		}

		public void DrawArc(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
		{
			_graphics.DrawArc(pen, rect, startAngle, sweepAngle);
		}

		public void DrawBezier(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
		{
			_graphics.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
		}

		public void DrawBezier(Pen pen, PointF pt1, PointF pt2, PointF pt3, PointF pt4)
		{
			_graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);
		}

		public void DrawBeziers(Pen pen, PointF[] points)
		{
			_graphics.DrawBeziers(pen, points);
		}

		public void DrawBezier(Pen pen, Point pt1, Point pt2, Point pt3, Point pt4)
		{
			_graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);
		}

		public void DrawBeziers(Pen pen, Point[] points)
		{
			_graphics.DrawBeziers(pen, points);
		}

		public void DrawRectangle(Pen pen, Rectangle rect)
		{
			_graphics.DrawRectangle(pen, rect);
		}

		public void DrawRectangle(Pen pen, float x, float y, float width, float height)
		{
			_graphics.DrawRectangle(pen, x, y, width, height);
		}

		public void DrawRectangle(Pen pen, int x, int y, int width, int height)
		{
			_graphics.DrawRectangle(pen, x, y, width, height);
		}

		public void DrawRectangles(Pen pen, RectangleF[] rects)
		{
			_graphics.DrawRectangles(pen, rects);
		}

		public void DrawRectangles(Pen pen, Rectangle[] rects)
		{
			_graphics.DrawRectangles(pen, rects);
		}

		public void DrawEllipse(Pen pen, RectangleF rect)
		{
			_graphics.DrawEllipse(pen, rect);
		}

		public void DrawEllipse(Pen pen, float x, float y, float width, float height)
		{
			_graphics.DrawEllipse(pen, x, y, width, height);
		}

		public void DrawEllipse(Pen pen, Rectangle rect)
		{
			_graphics.DrawEllipse(pen, rect);
		}

		public void DrawEllipse(Pen pen, int x, int y, int width, int height)
		{
			_graphics.DrawEllipse(pen, x, y, width, height);
		}

		public void DrawPie(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
		{
			_graphics.DrawPie(pen, rect, startAngle, sweepAngle);
		}

		public void DrawPie(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
		{
			_graphics.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
		}

		public void DrawPie(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
		{
			_graphics.DrawPie(pen, rect, startAngle, sweepAngle);
		}

		public void DrawPie(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
		{
			_graphics.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
		}

		public void DrawPolygon(Pen pen, PointF[] points)
		{
			_graphics.DrawPolygon(pen, points);
		}

		public void DrawPolygon(Pen pen, Point[] points)
		{
			_graphics.DrawPolygon(pen, points);
		}

		public void DrawPath(Pen pen, GraphicsPath path)
		{
			_graphics.DrawPath(pen, path);
		}

		public void DrawCurve(Pen pen, PointF[] points)
		{
			_graphics.DrawCurve(pen, points);
		}

		public void DrawCurve(Pen pen, PointF[] points, float tension)
		{
			_graphics.DrawCurve(pen, points, tension);
		}

		public void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments)
		{
			_graphics.DrawCurve(pen, points, offset, numberOfSegments);
		}

		public void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments, float tension)
		{
			_graphics.DrawCurve(pen, points, offset, numberOfSegments, tension);
		}

		public void DrawCurve(Pen pen, Point[] points)
		{
			_graphics.DrawCurve(pen, points);
		}

		public void DrawCurve(Pen pen, Point[] points, float tension)
		{
			_graphics.DrawCurve(pen, points, tension);
		}

		public void DrawCurve(Pen pen, Point[] points, int offset, int numberOfSegments, float tension)
		{
			_graphics.DrawCurve(pen, points, offset, numberOfSegments, tension);
		}

		public void DrawClosedCurve(Pen pen, PointF[] points)
		{
			_graphics.DrawClosedCurve(pen, points);
		}

		public void DrawClosedCurve(Pen pen, PointF[] points, float tension, FillMode fillmode)
		{
			_graphics.DrawClosedCurve(pen, points, tension, fillmode);
		}

		public void DrawClosedCurve(Pen pen, Point[] points)
		{
			_graphics.DrawClosedCurve(pen, points);
		}

		public void DrawClosedCurve(Pen pen, Point[] points, float tension, FillMode fillmode)
		{
			_graphics.DrawClosedCurve(pen, points, tension, fillmode);
		}

		public void Clear(Color color)
		{
			_graphics.Clear(color);
		}

		public void FillRectangle(Brush brush, RectangleF rect)
		{
			_graphics.FillRectangle(brush, rect);
		}

		public void FillRectangle(Brush brush, float x, float y, float width, float height)
		{
			_graphics.FillRectangle(brush, x, y, width, height);
		}

		public void FillRectangle(Brush brush, Rectangle rect)
		{
			_graphics.FillRectangle(brush, rect);
		}

		public void FillRectangle(Brush brush, int x, int y, int width, int height)
		{
			_graphics.FillRectangle(brush, x, y, width, height);
		}

		public void FillRectangles(Brush brush, RectangleF[] rects)
		{
			_graphics.FillRectangles(brush, rects);
		}

		public void FillRectangles(Brush brush, Rectangle[] rects)
		{
			_graphics.FillRectangles(brush, rects);
		}

		public void FillPolygon(Brush brush, PointF[] points)
		{
			_graphics.FillPolygon(brush, points);
		}

		public void FillPolygon(Brush brush, PointF[] points, FillMode fillMode)
		{
			_graphics.FillPolygon(brush, points, fillMode);
		}

		public void FillPolygon(Brush brush, Point[] points)
		{
			_graphics.FillPolygon(brush, points);
		}

		public void FillPolygon(Brush brush, Point[] points, FillMode fillMode)
		{
			_graphics.FillPolygon(brush, points, fillMode);
		}

		public void FillEllipse(Brush brush, RectangleF rect)
		{
			_graphics.FillEllipse(brush, rect);
		}

		public void FillEllipse(Brush brush, float x, float y, float width, float height)
		{
			_graphics.FillEllipse(brush, x, y, width, height);
		}

		public void FillEllipse(Brush brush, Rectangle rect)
		{
			_graphics.FillEllipse(brush, rect);
		}

		public void FillEllipse(Brush brush, int x, int y, int width, int height)
		{
			_graphics.FillEllipse(brush, x, y, width, height);
		}

		public void FillPie(Brush brush, Rectangle rect, float startAngle, float sweepAngle)
		{
			_graphics.FillPie(brush, rect, startAngle, sweepAngle);
		}

		public void FillPie(Brush brush, float x, float y, float width, float height, float startAngle, float sweepAngle)
		{
			_graphics.FillPie(brush, x, y, width, height, startAngle, sweepAngle);
		}

		public void FillPie(Brush brush, int x, int y, int width, int height, int startAngle, int sweepAngle)
		{
			_graphics.FillPie(brush, x, y, width, height, startAngle, sweepAngle);
		}

		public void FillPath(Brush brush, GraphicsPath path)
		{
			_graphics.FillPath(brush, path);
		}

		public void FillClosedCurve(Brush brush, PointF[] points)
		{
			_graphics.FillClosedCurve(brush, points);
		}

		public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode)
		{
			_graphics.FillClosedCurve(brush, points, fillmode);
		}

		public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode, float tension)
		{
			_graphics.FillClosedCurve(brush, points, fillmode, tension);
		}

		public void FillClosedCurve(Brush brush, Point[] points)
		{
			_graphics.FillClosedCurve(brush, points);
		}

		public void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode)
		{
			_graphics.FillClosedCurve(brush, points, fillmode);
		}

		public void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode, float tension)
		{
			_graphics.FillClosedCurve(brush, points, fillmode, tension);
		}

		public void FillRegion(Brush brush, Region region)
		{
			_graphics.FillRegion(brush, region);
		}

		public void DrawString(string s, Font font, Brush brush, float x, float y)
		{
			_graphics.DrawString(s, font, brush, x, y);
		}

		public void DrawString(string s, Font font, Brush brush, PointF point)
		{
			_graphics.DrawString(s, font, brush, point);
		}

		public void DrawString(string s, Font font, Brush brush, float x, float y, StringFormat format)
		{
			_graphics.DrawString(s, font, brush, x, y, format);
		}

		public void DrawString(string s, Font font, Brush brush, PointF point, StringFormat format)
		{
			_graphics.DrawString(s, font, brush, point, format);
		}

		public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle)
		{
			_graphics.DrawString(s, font, brush, layoutRectangle);
		}

		public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format)
		{
			_graphics.DrawString(s, font, brush, layoutRectangle, format);
		}

		public SizeF MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted,
			out int linesFilled)
		{
			return _graphics.MeasureString(text, font, layoutArea, stringFormat, out charactersFitted, out linesFilled);
		}

		public SizeF MeasureString(string text, Font font, PointF origin, StringFormat stringFormat)
		{
			return _graphics.MeasureString(text, font, origin, stringFormat);
		}

		public SizeF MeasureString(string text, Font font, SizeF layoutArea)
		{
			return _graphics.MeasureString(text, font, layoutArea);
		}

		public SizeF MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat)
		{
			return _graphics.MeasureString(text, font, layoutArea, stringFormat);
		}

		public SizeF MeasureString(string text, Font font)
		{
			return _graphics.MeasureString(text, font);
		}

		public SizeF MeasureString(string text, Font font, int width)
		{
			return _graphics.MeasureString(text, font, width);
		}

		public SizeF MeasureString(string text, Font font, int width, StringFormat format)
		{
			return _graphics.MeasureString(text, font, width, format);
		}

		public Region[] MeasureCharacterRanges(string text, Font font, RectangleF layoutRect, StringFormat stringFormat)
		{
			return _graphics.MeasureCharacterRanges(text, font, layoutRect, stringFormat);
		}

		public void DrawIcon(Icon icon, int x, int y)
		{
			_graphics.DrawIcon(icon, x, y);
		}

		public void DrawIcon(Icon icon, Rectangle targetRect)
		{
			_graphics.DrawIcon(icon, targetRect);
		}

		public void DrawIconUnstretched(Icon icon, Rectangle targetRect)
		{
			_graphics.DrawIconUnstretched(icon, targetRect);
		}

		public void DrawImage(Image image, PointF point)
		{
			_graphics.DrawImage(image, point);
		}

		public void DrawImage(Image image, float x, float y)
		{
			_graphics.DrawImage(image, x, y);
		}

		public void DrawImage(Image image, RectangleF rect)
		{
			_graphics.DrawImage(image, rect);
		}

		public void DrawImage(Image image, float x, float y, float width, float height)
		{
			_graphics.DrawImage(image, x, y, width, height);
		}

		public void DrawImage(Image image, Point point)
		{
			_graphics.DrawImage(image, point);
		}

		public void DrawImage(Image image, int x, int y)
		{
			_graphics.DrawImage(image, x, y);
		}

		public void DrawImage(Image image, Rectangle rect)
		{
			_graphics.DrawImage(image, rect);
		}

		public void DrawImage(Image image, int x, int y, int width, int height)
		{
			_graphics.DrawImage(image, x, y, width, height);
		}

		public void DrawImageUnscaled(Image image, Point point)
		{
			_graphics.DrawImageUnscaled(image, point);
		}

		public void DrawImageUnscaled(Image image, int x, int y)
		{
			_graphics.DrawImageUnscaled(image, x, y);
		}

		public void DrawImageUnscaled(Image image, Rectangle rect)
		{
			_graphics.DrawImageUnscaled(image, rect);
		}

		public void DrawImageUnscaled(Image image, int x, int y, int width, int height)
		{
			_graphics.DrawImageUnscaled(image, x, y, width, height);
		}

		public void DrawImageUnscaledAndClipped(Image image, Rectangle rect)
		{
			_graphics.DrawImageUnscaledAndClipped(image, rect);
		}

		public void DrawImage(Image image, PointF[] destPoints)
		{
			_graphics.DrawImage(image, destPoints);
		}

		public void DrawImage(Image image, Point[] destPoints)
		{
			_graphics.DrawImage(image, destPoints);
		}

		public void DrawImage(Image image, float x, float y, RectangleF srcRect, GraphicsUnit srcUnit)
		{
			_graphics.DrawImage(image, x, y, srcRect, srcUnit);
		}

		public void DrawImage(Image image, int x, int y, Rectangle srcRect, GraphicsUnit srcUnit)
		{
			_graphics.DrawImage(image, x, y, srcRect, srcUnit);
		}

		public void DrawImage(Image image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit)
		{
			_graphics.DrawImage(image, destRect, srcRect, srcUnit);
		}

		public void DrawImage(Image image, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit)
		{
			_graphics.DrawImage(image, destRect, srcRect, srcUnit);
		}

		public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit)
		{
			_graphics.DrawImage(image, destPoints, srcRect, srcUnit);
		}

		public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr)
		{
			_graphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr);
		}

		public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr,
			Graphics.DrawImageAbort callback)
		{
			_graphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback);
		}

		public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr,
			Graphics.DrawImageAbort callback, int callbackData)
		{
			_graphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback, callbackData);
		}

		public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit)
		{
			_graphics.DrawImage(image, destPoints, srcRect, srcUnit);
		}

		public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr)
		{
			_graphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr);
		}

		public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr,
			Graphics.DrawImageAbort callback)
		{
			_graphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback);
		}

		public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr,
			Graphics.DrawImageAbort callback, int callbackData)
		{
			_graphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback, callbackData);
		}

		public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight,
			GraphicsUnit srcUnit)
		{
			_graphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit);
		}

		public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight,
			GraphicsUnit srcUnit, ImageAttributes imageAttrs)
		{
			_graphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs);
		}

		public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight,
			GraphicsUnit srcUnit, ImageAttributes imageAttrs, Graphics.DrawImageAbort callback)
		{
			_graphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs, callback);
		}

		public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight,
			GraphicsUnit srcUnit, ImageAttributes imageAttrs, Graphics.DrawImageAbort callback, IntPtr callbackData)
		{
			_graphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs, callback, callbackData);
		}

		public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit)
		{
			_graphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit);
		}

		public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit,
			ImageAttributes imageAttr)
		{
			_graphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttr);
		}

		public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit,
			ImageAttributes imageAttr, Graphics.DrawImageAbort callback)
		{
			_graphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttr, callback);
		}

		public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit,
			ImageAttributes imageAttrs, Graphics.DrawImageAbort callback, IntPtr callbackData)
		{
			_graphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs, callback, callbackData);
		}

		public void SetClip(Graphics g)
		{
			_graphics.SetClip(g);
		}

		public void SetClip(Graphics g, CombineMode combineMode)
		{
			_graphics.SetClip(g, combineMode);
		}

		public void SetClip(Rectangle rect)
		{
			_graphics.SetClip(rect);
		}

		public void SetClip(Rectangle rect, CombineMode combineMode)
		{
			_graphics.SetClip(rect, combineMode);
		}

		public void SetClip(RectangleF rect)
		{
			_graphics.SetClip(rect);
		}

		public void SetClip(RectangleF rect, CombineMode combineMode)
		{
			_graphics.SetClip(rect, combineMode);
		}

		public void SetClip(GraphicsPath path)
		{
			_graphics.SetClip(path);
		}

		public void SetClip(GraphicsPath path, CombineMode combineMode)
		{
			_graphics.SetClip(path, combineMode);
		}

		public void SetClip(Region region, CombineMode combineMode)
		{
			_graphics.SetClip(region, combineMode);
		}

		public void IntersectClip(Rectangle rect)
		{
			_graphics.IntersectClip(rect);
		}

		public void IntersectClip(RectangleF rect)
		{
			_graphics.IntersectClip(rect);
		}

		public void IntersectClip(Region region)
		{
			_graphics.IntersectClip(region);
		}

		public void ExcludeClip(Rectangle rect)
		{
			_graphics.ExcludeClip(rect);
		}

		public void ExcludeClip(Region region)
		{
			_graphics.ExcludeClip(region);
		}

		public void ResetClip()
		{
			_graphics.ResetClip();
		}

		public void TranslateClip(float dx, float dy)
		{
			_graphics.TranslateClip(dx, dy);
		}

		public void TranslateClip(int dx, int dy)
		{
			_graphics.TranslateClip(dx, dy);
		}

		public object GetContextInfo()
		{
			return _graphics.GetContextInfo();
		}

		public bool IsVisible(int x, int y)
		{
			return _graphics.IsVisible(x, y);
		}

		public bool IsVisible(Point point)
		{
			return _graphics.IsVisible(point);
		}

		public bool IsVisible(float x, float y)
		{
			return _graphics.IsVisible(x, y);
		}

		public bool IsVisible(PointF point)
		{
			return _graphics.IsVisible(point);
		}

		public bool IsVisible(int x, int y, int width, int height)
		{
			return _graphics.IsVisible(x, y, width, height);
		}

		public bool IsVisible(Rectangle rect)
		{
			return _graphics.IsVisible(rect);
		}

		public bool IsVisible(float x, float y, float width, float height)
		{
			return _graphics.IsVisible(x, y, width, height);
		}

		public bool IsVisible(RectangleF rect)
		{
			return _graphics.IsVisible(rect);
		}

		public GraphicsState Save()
		{
			return _graphics.Save();
		}

		public void Restore(GraphicsState gstate)
		{
			_graphics.Restore(gstate);
		}

		public GraphicsContainer BeginContainer(RectangleF dstrect, RectangleF srcrect, GraphicsUnit unit)
		{
			return _graphics.BeginContainer(dstrect, srcrect, unit);
		}

		public GraphicsContainer BeginContainer()
		{
			return _graphics.BeginContainer();
		}

		public void EndContainer(GraphicsContainer container)
		{
			_graphics.EndContainer(container);
		}

		public GraphicsContainer BeginContainer(Rectangle dstrect, Rectangle srcrect, GraphicsUnit unit)
		{
			return _graphics.BeginContainer(dstrect, srcrect, unit);
		}

		public void AddMetafileComment(byte[] data)
		{
			_graphics.AddMetafileComment(data);
		}

		public CompositingMode CompositingMode
		{
			get { return _graphics.CompositingMode; }
			set { _graphics.CompositingMode = value; }
		}

		public Point RenderingOrigin
		{
			get { return _graphics.RenderingOrigin; }
			set { _graphics.RenderingOrigin = value; }
		}

		public CompositingQuality CompositingQuality
		{
			get { return _graphics.CompositingQuality; }
			set { _graphics.CompositingQuality = value; }
		}

		public TextRenderingHint TextRenderingHint
		{
			get { return _graphics.TextRenderingHint; }
			set { _graphics.TextRenderingHint = value; }
		}

		public int TextContrast
		{
			get { return _graphics.TextContrast; }
			set { _graphics.TextContrast = value; }
		}

		public SmoothingMode SmoothingMode
		{
			get { return _graphics.SmoothingMode; }
			set { _graphics.SmoothingMode = value; }
		}

		public PixelOffsetMode PixelOffsetMode
		{
			get { return _graphics.PixelOffsetMode; }
			set { _graphics.PixelOffsetMode = value; }
		}

		public InterpolationMode InterpolationMode
		{
			get { return _graphics.InterpolationMode; }
			set { _graphics.InterpolationMode = value; }
		}

		public Matrix Transform
		{
			get { return _graphics.Transform; }
			set { _graphics.Transform = value; }
		}

		public GraphicsUnit PageUnit
		{
			get { return _graphics.PageUnit; }
			set { _graphics.PageUnit = value; }
		}

		public float PageScale
		{
			get { return _graphics.PageScale; }
			set { _graphics.PageScale = value; }
		}

		public float DpiX
		{
			get { return _graphics.DpiX; }
		}

		public float DpiY
		{
			get { return _graphics.DpiY; }
		}

		public Region Clip
		{
			get { return _graphics.Clip; }
			set { _graphics.Clip = value; }
		}

		public RectangleF ClipBounds
		{
			get { return _graphics.ClipBounds; }
		}

		public bool IsClipEmpty
		{
			get { return _graphics.IsClipEmpty; }
		}

		public RectangleF VisibleClipBounds
		{
			get { return _graphics.VisibleClipBounds; }
		}

		public bool IsVisibleClipEmpty
		{
			get { return _graphics.IsVisibleClipEmpty; }
		}

		#endregion
	}
}