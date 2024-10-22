using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Queen(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Queen;
        public override int ScoreValue => 10;
        public override DirectionMap Directions => new DirectionMap(Direction.AllDirections());

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            return MoveLogic.GetLinePositions(from, board, Directions.GetArray()).Select(to => new NormalMove(from, to));
        }
    }
}