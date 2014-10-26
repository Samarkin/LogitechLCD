using System.Drawing;
using Logitech;

namespace LCDSnake
{
	internal class SplashScreen : GameScreen
	{
		private readonly Font _fontBi = new Font("Arial", 17, FontStyle.Bold | FontStyle.Italic);
		private readonly Font _fontB = new Font("Tahoma", 17, FontStyle.Bold);

		private bool _startRequested;

		public override void Draw(LcdGraphics graphics)
		{
			graphics.Clear(Color.White);
			graphics.DrawString("Samara's", _fontBi, Brushes.Black, 0, 0);
			graphics.DrawString("SNAKE", _fontB, Brushes.Black, 75, 20);
		}

		public override void ButtonPressed(LCDButtons button)
		{
			_startRequested = true;
		}

		public override GameStatus Step()
		{
			return _startRequested ? new GameStatus(GameState.MainScene, 0) : null;
		}

		public override void Dispose()
		{
			_fontB.Dispose();
			_fontBi.Dispose();
		}
	}
}