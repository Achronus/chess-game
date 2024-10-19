using Chess.Core;

namespace Chess.Pieces
{
    public class Queen(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Queen;
        public override int ScoreValue => 10;

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