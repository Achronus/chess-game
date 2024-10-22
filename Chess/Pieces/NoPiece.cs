using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class NoPiece : Piece
    {
        public static readonly NoPiece Instance = new NoPiece();
        public override Colour Colour => Colour.None;
        public override PieceType Type => PieceType.Empty;
        public override int ScoreValue => 0;
        public override DirectionMap Directions => new DirectionMap();

        public override IEnumerable<IMove> GetMoves(Vector2D from, Board board)
        {
            return [];
        }
    }
}
