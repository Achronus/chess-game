using Chess.Core;

namespace Chess.Pieces
{
    public class King(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.King;
        public override int ScoreValue => 0;

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