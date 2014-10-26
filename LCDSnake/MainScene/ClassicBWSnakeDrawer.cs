using System.Drawing;
using Logitech;

namespace LCDSnake
{
	internal class ClassicBWSnakeDrawer : SnakeDrawer
	{
		private const int ConstSectionSize = 3;
		private const int ConstBorderWidth = 3;
		private const int ConstFieldWidth = ((LogitechBWLCD.Width - ConstBorderWidth * 2) / ConstSectionSize) * ConstSectionSize;
		private const int ConstFieldHeight = ((LogitechBWLCD.Height - ConstBorderWidth * 2) / ConstSectionSize) * ConstSectionSize;

		public override int SectionSize
		{
			get { return ConstSectionSize; }
		}

		public override int FieldWidth
		{
			get { return ConstFieldWidth; }
		}

		public override int FieldHeight
		{
			get { return ConstFieldHeight; }
		}

		public override void DrawField(LcdGraphics graphics)
		{
			graphics.Clear(Color.White);
			graphics.DrawRectangle(Pen, ConstBorderWidth / 2, ConstBorderWidth / 2, ConstBorderWidth + ConstFieldWidth, ConstBorderWidth + ConstFieldHeight);
		}

		public override void DrawSectionAt(LcdGraphics graphics, int x, int y)
		{
			graphics.DrawEllipse(Pen, ConstBorderWidth + x * SectionSize, ConstBorderWidth + y * SectionSize, SectionSize - 1, SectionSize - 1);
		}

		public override void DrawApple(LcdGraphics graphics, int x, int y)
		{
			int cX = ConstBorderWidth + x * SectionSize;
			int cY = ConstBorderWidth + y * SectionSize;
			graphics.DrawLine(Pen, cX, cY, cX + SectionSize - 1, cY + SectionSize - 1);
			graphics.DrawLine(Pen, cX + SectionSize - 1, cY, cX, cY + SectionSize - 1);
		}
	}
}