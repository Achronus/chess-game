using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Rook(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Rook;
        public override int ScoreValue => 5;
        public override Vector2D[] Directions => Direction.Basic();

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            return MoveLogic.GetLinePositions(from, board, Directions).Select(to => new NormalMove(from, to));
        }
    }
}