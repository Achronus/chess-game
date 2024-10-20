using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Bishop(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Bishop;
        public override int ScoreValue => 3;
        public override Vector2D[] Directions => Direction.Diagonal();

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