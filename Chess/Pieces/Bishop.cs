using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Bishop(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Bishop;
        public override int ScoreValue => 3;
        public override DirectionMap Directions => new DirectionMap(Direction.Diagonal());

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            return GetLinePositions(from, board, Directions.GetArray()).Select(to => new NormalMove(from, to));
        }
    }
}