using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class King(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.King;
        public override int ScoreValue => 0;
        public override DirectionMap Directions => new DirectionMap(Direction.AllDirections());

        private static bool IsUnmovedRook(Vector2D pos, Board board)
        {
            if (board.IsEmpty(pos))
            {
                return false;
            }

            Piece piece = board[pos];
            return piece.Type == PieceType.Rook && !piece.HasMoved;
        }

        private static bool IsCastleSquaresEmpty(IEnumerable<Vector2D> positions, Board board)
        {
            return positions.All(pos => board.IsEmpty(pos));
        }

        public static Tuple<Vector2D, Vector2D[]> GetCastleSquarePositions(Vector2D from, MoveType type)
        {
            return type switch
            {
                MoveType.CastleShort => Tuple.Create<Vector2D, Vector2D[]>(
                    new Vector2D(from.X, Board.RowSize - 1),
                    [
                        new Vector2D(from.X, Board.RowSize - 3),
                        new Vector2D(from.X, Board.RowSize - 2)
                    ]
                ),
                MoveType.CastleLong => Tuple.Create<Vector2D, Vector2D[]>(
                    new Vector2D(from.X, 0),
                    [
                        new Vector2D(from.X, 1),
                        new Vector2D(from.X, 2),
                        new Vector2D(from.X, 3)
                    ]
                ),
                _ => throw new ArgumentException($"Invalid MoveType '{type}'. Should be 'CastleShort' or 'CastleLong'.")
            };
        }

        private bool CanCastleKingSide(Vector2D from, Board board)
        {
            if (HasMoved)
            {
                return false;
            }

            // <rookPos, betweenPositions>
            Tuple<Vector2D, Vector2D[]> positions = GetCastleSquarePositions(from, MoveType.CastleShort);
            return IsUnmovedRook(positions.Item1, board) && IsCastleSquaresEmpty(positions.Item2, board);
        }

        private bool CanCastleQueenSide(Vector2D from, Board board)
        {
            if (HasMoved)
            {
                return false;
            }

            // <rookPos, betweenPositions>
            Tuple<Vector2D, Vector2D[]> positions = GetCastleSquarePositions(from, MoveType.CastleLong);
            return IsUnmovedRook(positions.Item1, board) && IsCastleSquaresEmpty(positions.Item2, board);
        }

        public override IEnumerable<IMove> GetMoves(Vector2D from, Board board)
        {
            foreach (Vector2D dir in Directions.GetArray())
            {
                Vector2D? newPos = GetSinglePosition(from + dir, board);
                if (newPos.HasValue)
                {
                    yield return new NormalMove(from, newPos.Value);
                }

                if (CanCastleKingSide(from, board))
                {
                    yield return new Castle(MoveType.CastleShort, from);
                }

                if (CanCastleQueenSide(from, board))
                {
                    yield return new Castle(MoveType.CastleLong, from);
                }
            }
        }

        public override bool IsKingInCheck(Vector2D from, Board board)
        {
            return GetMoves(from, board).Any(to => AttackingKing(to, board));
        }
    }
}