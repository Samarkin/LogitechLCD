namespace LCDSnake
{
	public struct SnakeSection
	{
		public readonly int X;
		public readonly int Y;

		public SnakeSection(int x, int y)
		{
			X = x;
			Y = y;
		}

		public SnakeSection GetNeighbor(SnakeDirection direction)
		{
			int deltaX = 0;
			int deltaY = 0;
			switch (direction)
			{
				case SnakeDirection.Up:
					deltaY = -1;
					break;
				case SnakeDirection.Down:
					deltaY = 1;
					break;
				case SnakeDirection.Left:
					deltaX = -1;
					break;
				case SnakeDirection.Right:
					deltaX = 1;
					break;
			}
			return new SnakeSection(X + deltaX, Y + deltaY);
		}
	}
}