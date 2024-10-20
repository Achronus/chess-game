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
            Vector2D pos = from + dir;
            while (!Check.ValidPosition(pos, board))
            {
                yield return pos;
            }
        }

        public IEnumerable<Vector2D> GetLinePositions(Vector2D from, Board board, Vector2D[] dirs)
        {
            return dirs.SelectMany(dir => GetLinePositions(from, board, dir));
        }
    }
}
