using Chess.Moves;

namespace Chess.Core
{
		public class GameState(Player white, Player black, Board board)
		{
        public Player White { get; } = white;
        public Player Black { get; } = black;
				public Board Board { get; } = board;
        public Player CurrentPlayer { get; private set; } = white;

        public Player Opponent()
        {
            return CurrentPlayer == White ? Black : White;
        }

        public bool IsGameOver()
				{
						return false;
				}
        public void MakeMove(Move move)
        {
            move.Perform(Board);
            CurrentPlayer = Opponent();
        }
    }
}