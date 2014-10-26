using System.Drawing;
using Logitech;

namespace LCDSnake
{
	public abstract class SnakeDrawer
	{
		protected readonly Pen Pen = Pens.Black;

		public abstract int SectionSize { get; }
		public abstract int FieldWidth { get; }
		public abstract int FieldHeight { get; }
		public abstract void DrawField(LcdGraphics graphics);
		public abstract void DrawSectionAt(LcdGraphics graphics, int x, int y);
		public abstract void DrawApple(LcdGraphics graphics, int x, int y);
	}
}