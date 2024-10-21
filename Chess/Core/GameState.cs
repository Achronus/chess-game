using Chess.Moves;
using Chess.Pieces;

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

        public bool IsMoveSafeForKing(Move move)
        {
            Piece currentPosition = Board[move.FromPosition];
            Piece targetPosition = Board[move.ToPosition];

            // Move the piece
            Board[move.ToPosition] = currentPosition;
            Board[move.FromPosition] = NoPiece.Instance;

            bool isInCheck = Board.IsInCheck(Opponent());

            // Revert piece
            Board[move.FromPosition] = currentPosition;
            Board[move.ToPosition] = targetPosition;

            return !isInCheck;
        }
    }
}