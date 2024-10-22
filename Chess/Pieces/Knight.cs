using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Knight(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.Knight;
        public override int ScoreValue => 3;
        public override DirectionMap Directions => new DirectionMap(Direction.Knight());

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            foreach (Vector2D dir in Directions.GetArray())
            {
                Vector2D? newPos = MoveLogic.GetSinglePosition(from + dir, board);
                if (newPos.HasValue)
                {
                    yield return new NormalMove(from, newPos.Value);
                }
            }
        }
    }
}