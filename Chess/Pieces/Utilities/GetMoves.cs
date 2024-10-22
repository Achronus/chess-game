using Chess.Core;

namespace Chess.Pieces
{
    public partial class Piece
    {
        public Vector2D? GetSinglePosition(Vector2D pos, Board board)
        {
            return ValidPosition(pos, board) ? pos : null;
        }

        public IEnumerable<Vector2D> GetLinePositions(Vector2D from, Board board, Vector2D dir)
        {
            for (Vector2D pos = from + dir; Board.InBounds(pos); pos += dir)
            {
                if (CanMoveTo(pos, board))
                {
                    yield return pos;
                    continue;
                }

                // Only first opponent piece
                if (CanCaptureAt(pos, board))
                {
                    yield return pos;
                }
                
                yield break;
            }
        }

        public IEnumerable<Vector2D> GetLinePositions(Vector2D from, Board board, Vector2D[] dirs)
        {
            return dirs.SelectMany(dir => GetLinePositions(from, board, dir));
        }
    }
}
