namespace LCDSnake
{
	public class GameStatus
	{
		public GameStatus(GameState state, int score)
		{
			State = state;
			Score = score;
		}

		public GameState State { get; private set; }
		public int Score { get; private set; }
	}
}