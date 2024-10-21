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
        public Result? Result { get; private set; } = null;

        public Player Opponent()
        {
            return CurrentPlayer == White ? Black : White;
        }

        public bool IsGameOver()
				{
						if (!AllLegalMovesFor(CurrentPlayer).Any())
            {
                Result = Board.IsInCheck(CurrentPlayer) ? Result.Win(Opponent()) : Result.Draw(GameOverStatus.Stalemate);
            }

            return Result != null;
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

        public IEnumerable<Move> AllLegalMovesFor(Player player)
        {
            IEnumerable<Move> possibleMoves = player.MyPiecePositions(Board).SelectMany(pos =>
            {
                Piece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            });

            return possibleMoves.Where(move => IsMoveSafeForKing(move));
        }
    }
}