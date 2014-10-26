using System;

namespace LCDSnake
{
	public sealed class GameEngine
	{
		public readonly int FieldWidth;
		public readonly int FieldHeight;

		public int AppleX { get; private set; }
		public int AppleY { get; private set; }

		private int _notUsed;
		private readonly bool[,] _used;

		private readonly Random _random = new Random();

		public GameEngine(int sectionSize, int fieldPixelsWidth, int fieldPixelsHeight)
		{
			FieldWidth = fieldPixelsWidth / sectionSize;
			FieldHeight = fieldPixelsHeight / sectionSize;
			_notUsed = FieldWidth * FieldHeight;
			_used = new bool[FieldWidth, FieldHeight];

			int newPostion = _random.Next(_notUsed);
			AppleX = newPostion % FieldWidth;
			AppleY = newPostion / FieldWidth;
			_used[AppleX, AppleY] = true;
			_notUsed--;
		}

		public void AddSection(SnakeSection snakeSection)
		{
			_used[snakeSection.X, snakeSection.Y] = true;
			_notUsed--;
		}

		public void DeleteSection(SnakeSection snakeSection)
		{
			_used[snakeSection.X, snakeSection.Y] = false;
			_notUsed++;
		}

		public void MoveApple()
		{
			int newPosition = _random.Next(_notUsed);
			int pos = 0;
			for (int i = 0; i < FieldWidth; i++)
			{
				for (int j = 0; j < FieldHeight; j++)
				{
					if (!_used[i, j])
					{
						if (++pos == newPosition)
						{
							_used[AppleX, AppleY] = false;
							AppleX = i;
							AppleY = j;
							_used[AppleX, AppleY] = true;
						}
					}
				}
			}
		}

		public CellStatus ValidateSection(SnakeSection snakeSection)
		{
			if (snakeSection.X < 0 || snakeSection.Y < 0 || snakeSection.X >= FieldWidth || snakeSection.Y >= FieldHeight)
			{
				return CellStatus.Border;
			}
			if (snakeSection.X == AppleX && snakeSection.Y == AppleY)
			{
				return CellStatus.Apple;
			}
			if (_used[snakeSection.X, snakeSection.Y])
			{
				return CellStatus.Border;
			}
			return CellStatus.Empty;
		}
	}
}