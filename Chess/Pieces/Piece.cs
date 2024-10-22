using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public abstract partial class Piece
    {
        public abstract Colour Colour { get; }
        public abstract PieceType Type { get; }
        public abstract int ScoreValue { get; }
        public abstract DirectionMap Directions { get; }

        public bool HasMoved { get; set; } = false;

        public abstract IEnumerable<Move> GetMoves(Vector2D from, Board board);
    }
}