using Chess.Core;

namespace Chess.Pieces
{
    public class Rook(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Rook;
        public override int ScoreValue => 5;

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Take()
        {
            throw new NotImplementedException();
        }
    }
}