using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Rook(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Rook;
        public override int ScoreValue => 5;
        public override Vector2D[] Directions => [
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West
        ];

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            return GetPositions(from, board, Directions).Select(to => new NormalMove(from, to));
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