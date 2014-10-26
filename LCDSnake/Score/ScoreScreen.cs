using System.Drawing;
using Logitech;

namespace LCDSnake
{
	internal sealed class ScoreScreen : GameScreen
	{
		private readonly int _score;
		private int _ticks;

		public ScoreScreen(int score)
		{
			_score = score;
		}

		public override void Draw(LcdGraphics graphics)
		{
			graphics.Clear(Color.White);
			string s = string.Format("Your score: {0}", _score);
			SizeF size = graphics.MeasureString(s, Font);
			graphics.DrawString(s, Font, Brush, (graphics.Size.Width - size.Width) / 2, (graphics.Size.Height - size.Height) / 2);
		}

		public override GameStatus Step()
		{
			if (++_ticks > (int.MaxValue - 1))
			{
				_ticks = 21;
			}
			return _ticks > 20 ? new GameStatus(GameState.Splash, 0) : null;
		}
	}
}