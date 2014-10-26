using System;
using System.Drawing;
using Logitech;

namespace LCDSnake
{
	public abstract class GameScreen : IDisposable
	{
		protected readonly Font FontBi = new Font("Arial", 17, FontStyle.Bold | FontStyle.Italic);
		protected readonly Font FontB = new Font("Tahoma", 17, FontStyle.Bold);
		protected readonly Font Font = new Font("Tahoma", 12, FontStyle.Bold);
		protected readonly Brush Brush = Brushes.Black;

		public abstract void Draw(LcdGraphics graphics);

		public virtual void ButtonPressed(LCDButtons button)
		{
		}

		public abstract GameStatus Step();

		public virtual void Dispose()
		{
			FontB.Dispose();
			FontBi.Dispose();
		}
	}
}