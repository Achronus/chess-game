using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Pawn(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Pawn;
        public override int ScoreValue => 1;
        public override Vector2D[] Directions => [
            Colour == Colour.White ? Direction.North : Direction.South,
        ];

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