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
                // Not in check -> in checkmate = win
                Result = !Board.IsInCheck(CurrentPlayer) ? Result.Win(Opponent()) : Result.Draw(GameOverStatus.Stalemate);
            }

            return Result != null;
				}

        public void MakeMove(IMove move)
        {
            move.Perform(Board);
            CurrentPlayer = Opponent();
        }

        public bool IsMoveSafeForNormalPiece(IMove move)
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

        public bool IsMoveSafeForKing(IMove move)
        {
            if (move is not Castle)
            {
                return IsMoveSafeForNormalPiece(move);
            }

            if (Board.IsInCheck(Opponent()))
            {
                return false;
            }

            Castle castleMove = (Castle)move;
            Vector2D kingPosition = move.FromPosition;

            Vector2D[] castleSquares = King.GetCastleSquarePositions(kingPosition, castleMove.Type).Item2;

            foreach (Vector2D square in castleSquares.Append(castleMove.ToPosition))
            {
                if (IsSquareAttacked(square))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsSquareAttacked(Vector2D square)
        {
            IEnumerable<Vector2D> opPiecePositions = Opponent().MyPiecePositions(Board);

            foreach (Vector2D opPos in opPiecePositions)
            {
                Piece opponentPiece = Board[opPos];
                IEnumerable<IMove> possibleMoves = opponentPiece.GetMoves(opPos, Board);

                if (possibleMoves.Any(move => move.ToPosition == square))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<IMove> AllLegalMovesFor(Player player)
        {
            IEnumerable<IMove> possibleMoves = player.MyPiecePositions(Board).SelectMany(pos =>
            {
                Piece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            });

            return possibleMoves.Where(move => IsMoveSafeForKing(move));
        }
    }
}