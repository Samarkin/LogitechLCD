using System.Linq;
using Logitech;

namespace LCDSnake
{
	internal class MainScreen : GameScreen
	{
		private readonly Snake _snake;
		private readonly SnakeDrawer _drawer;
		private readonly GameEngine _engine;

		public MainScreen()
		{
			_drawer = new ClassicBWSnakeDrawer();
			_engine = new GameEngine(_drawer.SectionSize, _drawer.FieldWidth, _drawer.FieldHeight);
			_snake = new Snake(_engine);
		}

		public override void Draw(LcdGraphics graphics)
		{
			_drawer.DrawField(graphics);
			foreach (var section in _snake.Sections)
			{
				_drawer.DrawSectionAt(graphics, section.X, section.Y);
			}
			_drawer.DrawApple(graphics, _engine.AppleX, _engine.AppleY);
		}

		public override void ButtonPressed(LCDButtons button)
		{
			if (button.HasFlag(LCDButtons.Button1) && !button.HasFlag(LCDButtons.Button2))
			{
				_snake.Rotate(SnakeRotation.CounterClockwise);
			}
			if (button.HasFlag(LCDButtons.Button2) && !button.HasFlag(LCDButtons.Button1))
			{
				_snake.Rotate(SnakeRotation.Clockwise);
			}
		}

		public override GameStatus Step()
		{
			return _snake.Move() ? null : new GameStatus(GameState.GameOver, _snake.Sections.Count() - 3);
		}
	}
}