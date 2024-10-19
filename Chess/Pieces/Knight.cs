using Chess.Core;

namespace Chess.Pieces
{
    public class Knight(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Knight;
        public override int ScoreValue => 3;

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