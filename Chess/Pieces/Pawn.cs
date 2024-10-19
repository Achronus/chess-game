using Chess.Core;

namespace Chess.Pieces
{
    public class Pawn(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Pawn;
        public override int ScoreValue => 1;

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