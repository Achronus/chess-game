using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Pawn(Colour colour, Vector2D startPos) : Piece
    {
        public override Colour Colour { get; } = colour;
        public override PieceType Type { get; } = PieceType.Pawn;
        public override int ScoreValue { get; } = 1;
        public override Vector2D[] Directions { get; } = Direction.Pawn(colour);
        public Vector2D StartPosition { get; } = startPos;

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            return ForwardMoves(from, board).Concat(CaptureMoves(from, board));
        }

        private IEnumerable<Move> ForwardMoves(Vector2D from, Board board)
        {
            List<Vector2D> moves = [
                from + Directions[0]
            ];

            if (from == StartPosition)
            {
                moves.Add(from + Directions[3]);
            }

            foreach (Vector2D move in moves)
            {
                Vector2D? newPos = MoveLogic.GetSinglePosition(move, board);
                if (newPos != null)
                {
                    yield return new NormalMove(from, newPos);
                }
            }
        }

        private IEnumerable<Move> CaptureMoves(Vector2D from, Board board)
        {
            List<Vector2D> captures = [
                from + Directions[1],
                from + Directions[2]
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