using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public abstract Colour Colour { get; }
        public abstract PieceType Type { get; }
        public abstract int ScoreValue { get; }
        public bool HasMoved { get; set; } = false;
        public abstract Vector2D[] Directions { get; }

        public abstract void Move();

        public abstract IEnumerable<Move> GetMoves(Vector2D from, Board board);

        public abstract void Take();

        public bool IsOpponent(Piece piece)
        {
            return piece.Colour != Colour ? true : false;
        }

        protected IEnumerable<Vector2D> GetPositions(Vector2D from, Board board, Vector2D dir)
        {
            for (Vector2D pos = from + dir; Board.InBounds(pos); pos += dir)
            {
                if (board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = board[pos];

                if (IsOpponent(piece))
                {
                    yield return pos;
                }

                yield break;
            }
        }

        protected IEnumerable<Vector2D> GetPositions(Vector2D from, Board board, Vector2D[] dirs)
        {
            return dirs.SelectMany(dir => GetPositions(from, board, dir));
        }
    }
}