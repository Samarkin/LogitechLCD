using System.Drawing;
using Logitech;

namespace LCDSnake
{
	internal class GameOver : GameScreen
	{
		private readonly int _score;
		private int _ticks;

		public GameOver(int score)
		{
			_score = score;
		}

		public override void Draw(LcdGraphics graphics)
		{
			graphics.Clear(Color.White);
			graphics.DrawString("GAME OVER", FontBi, Brushes.Black, 5, 10);
		}

		public override GameStatus Step()
		{
			if (++_ticks > (int.MaxValue - 1))
			{
				_ticks = 21;
			}
			return _ticks > 20 ? new GameStatus(GameState.Score, _score) : null;
		}
	}
}