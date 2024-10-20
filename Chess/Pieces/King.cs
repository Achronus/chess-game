using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class King(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.King;
        public override int ScoreValue => 0;
        public override Vector2D[] Directions => Direction.AllDirections();

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            throw new NotImplementedException();
        }

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