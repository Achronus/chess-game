using Chess.Core;
using Chess.Pieces;

namespace Chess.Moves
{
    public class GetMoves(Piece piece)
    {
        private Piece Piece { get; } = piece;
        public CheckMoves Check { get; } = new CheckMoves(piece);

        public Vector2D? GetSinglePosition(Vector2D pos, Board board)
        {
            return Check.ValidPosition(pos, board) ? pos : null;
        }

        public IEnumerable<Vector2D> GetLinePositions(Vector2D from, Board board, Vector2D dir)
        {
            // TODO: refactor
            for (Vector2D pos = from + dir; Board.InBounds(pos); pos += dir)
            {
                if (CheckMoves.CanMoveTo(pos, board))
                {
                    yield return pos;
                }
                else if (Check.CanCaptureAt(pos, board))
                {
                    yield return pos;  // Only first opponent piece
                    yield break;
                }
                else
                {
                    yield break;
                }
            }
        }

        public IEnumerable<Vector2D> GetLinePositions(Vector2D from, Board board, Vector2D[] dirs)
        {
            return dirs.SelectMany(dir => GetLinePositions(from, board, dir));
        }
    }
}
