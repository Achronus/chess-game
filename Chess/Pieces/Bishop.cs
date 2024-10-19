using Chess.Core;

namespace Chess.Pieces
{
    public class Bishop(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Bishop;
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