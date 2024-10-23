using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Pawn(Colour colour, Vector2D startPos) : Piece
    {
        public override Colour Colour { get; } = colour;
        public override PieceType Type { get; } = PieceType.Pawn;
        public override int ScoreValue { get; } = 1;
        public override DirectionMap Directions { get; } = new DirectionMap(Direction.Pawn(colour));
        public Vector2D StartPosition { get; } = startPos;

        public override IEnumerable<IMove> GetMoves(Vector2D from, Board board)
        {
            return ForwardMoves(from, board).Concat(CaptureMoves(from, board));
        }

        public override bool IsKingInCheck(Vector2D from, Board board)
        {
            return CaptureMoves(from, board).Any(move => AttackingKing(move, board));
        }

        public static bool IsPromotable(Vector2D to)
        {
            return to.X == 0 || to.X == Board.ColSize - 1;
        }

        private static IEnumerable<IMove> PromotionMoves(Vector2D from, Vector2D to)
        {
            List<PieceType> promotionTypes = [
                PieceType.Knight,
                PieceType.Bishop,
                PieceType.Rook,
                PieceType.Queen
            ];

            foreach (PieceType type in promotionTypes)
            {
                yield return new PawnPromotion(from, to, type);
            }   
        }

        private IEnumerable<IMove> ForwardMoves(Vector2D from, Board board)
        {
            Dictionary<string, Vector2D> dirs = Directions.GetDict();

            List<Vector2D> moves = [
                from + dirs[PawnMoves.Forward.ToString()]
            ];

            if (from == StartPosition)
            {
                moves.Add(from + dirs[PawnMoves.ForwardDouble.ToString()]);
            }

            foreach (Vector2D move in moves)
            {
                Vector2D? newPos = GetSinglePosition(move, board);

                if (newPos.HasValue && IsPromotable(newPos.Value))
                {
                    foreach (IMove promotionMove in PromotionMoves(from, newPos.Value))
                    {
                        yield return promotionMove;
                    }
                }
                else if (newPos.HasValue && board.IsEmpty(newPos.Value))
                {
                    yield return new NormalMove(from, newPos.Value);
                }
            }
        }

        private IEnumerable<IMove> CaptureMoves(Vector2D from, Board board)
        {
            Dictionary<string, Vector2D> dirs = Directions.GetDict();

            List<Vector2D> captures = [
                from + dirs[PawnMoves.ForwardLeft.ToString()],
                from + dirs[PawnMoves.ForwardRight.ToString()]
            ];

            foreach (Vector2D capPos in captures)
            {
                if (CanCaptureAt(capPos, board))
                {
                    // Promote on capture
                    if (IsPromotable(capPos))
                    {
                        foreach (IMove promotionMove in PromotionMoves(from, capPos))
                        {
                            yield return promotionMove;
                        }
                    } 
                    else
                    {
                        yield return new NormalMove(from, capPos);
                    }
                }
            }
        }
    }
}