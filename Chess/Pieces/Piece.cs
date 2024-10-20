using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public abstract Colour Colour { get; }
        public abstract PieceType Type { get; }
        public abstract int ScoreValue { get; }
        public abstract Vector2D[] Directions { get; }

        public bool HasMoved { get; set; } = false;
        public GetMoves MoveLogic { get; }

        public Piece()
        {
            MoveLogic = new GetMoves(this);
        }

        public abstract void Move();

        public abstract IEnumerable<Move> GetMoves(Vector2D from, Board board);

        public abstract void Take();
    }
}