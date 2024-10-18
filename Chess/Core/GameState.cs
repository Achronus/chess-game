namespace Chess.Core
{
		public class GameState(Player player, Board board)
		{
				public Player CurrentPlayer { get; private set; } = player;
				public Board Board { get; } = board;

				public bool IsGameOver()
				{
						return true;
				}
		}
}