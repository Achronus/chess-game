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

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            return ForwardMoves(from, board).Concat(CaptureMoves(from, board));
        }

        public override bool IsKingInCheck(Vector2D from, Board board)
        {
            return CaptureMoves(from, board).Any(move => AttackingKing(move, board));
        }

        private IEnumerable<Move> ForwardMoves(Vector2D from, Board board)
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
                Vector2D? newPos = MoveLogic.GetSinglePosition(move, board);
                if (newPos != null && board.IsEmpty(newPos))
                {
                    yield return new NormalMove(from, newPos);
                }
            }
        }

        private IEnumerable<Move> CaptureMoves(Vector2D from, Board board)
        {
            Dictionary<string, Vector2D> dirs = Directions.GetDict();

            List<Vector2D> captures = [
                from + dirs[PawnMoves.ForwardLeft.ToString()],
                from + dirs[PawnMoves.ForwardRight.ToString()]
            ];

            foreach (Vector2D capPos in captures)
            {
                if (MoveLogic.Check.CanCaptureAt(capPos, board))
                {
                    yield return new NormalMove(from, capPos);
                }
            }
        }
    }
}