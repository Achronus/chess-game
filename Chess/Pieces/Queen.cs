using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Queen(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Queen;
        public override int ScoreValue => 10;
        public override Vector2D[] Directions => Direction.AllDirections();

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            return MoveLogic.GetLinePositions(from, board, Directions).Select(to => new NormalMove(from, to));
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