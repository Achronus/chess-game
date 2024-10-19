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

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            return [];
        }

        public override void Move() { }

        public override void Take() { }
    }
}
