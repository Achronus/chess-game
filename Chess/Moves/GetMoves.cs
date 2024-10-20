using Chess.Core;
using Chess.Pieces;

namespace Chess.Moves
{
    public class GetMoves
    {
        private Piece Piece { get; }
        public CheckMoves Check { get; }

        public GetMoves(Piece piece)
        {
            Piece = piece;
            Check = new CheckMoves(piece);
        }

        public Vector2D? GetSinglePosition(Vector2D pos, Board board)
        {
            if (Check.ValidPosition(pos, board))
            {
                return pos;
            }

            return null;
        }

        public IEnumerable<Vector2D> GetLinePositions(Vector2D from, Board board, Vector2D dir)
        {
            for (Vector2D pos = from + dir; Board.InBounds(pos); pos += dir)
            {
                if (Check.CanMoveTo(pos, board))
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
