using System.Collections.Generic;

namespace LCDSnake
{
	public sealed class Snake
	{
		private readonly GameEngine _engine;
		private readonly LinkedList<SnakeSection> _sections;
		private SnakeDirection _direction;

		public Snake(GameEngine engine)
		{
			_engine = engine;
			_sections = new LinkedList<SnakeSection>();
			int cX = engine.FieldWidth / 2;
			int cY = engine.FieldHeight / 2;
			_sections.AddFirst(new SnakeSection(cX-2, cY));
			_sections.AddFirst(new SnakeSection(cX-1, cY));
			_sections.AddFirst(new SnakeSection(cX, cY));

			_direction = SnakeDirection.Right;
		}

		public IEnumerable<SnakeSection> Sections
		{
			get { return _sections; }
		}

		public bool Move()
		{
			SnakeSection newSection = _sections.First.Value.GetNeighbor(_direction);
			CellStatus status = _engine.ValidateSection(newSection);
			if (status == CellStatus.Border)
			{
				return false;
			}
			if (status == CellStatus.Apple)
			{
				_engine.MoveApple();
			}
			else
			{
				_engine.DeleteSection(_sections.Last.Value);
				_sections.RemoveLast();
			}
			_engine.AddSection(newSection);
			_sections.AddFirst(newSection);
			return true;
		}

		public void Rotate(SnakeRotation direction)
		{
			const int numOfDirections = (int)SnakeDirection.Total;
			int ch = direction == SnakeRotation.Clockwise ? 1 : numOfDirections - 1;
			_direction = (SnakeDirection)((int)(_direction + ch) % numOfDirections);
		}
	}
}