using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class King(Colour colour) : Piece
    {
        public override Colour Colour => colour;
        public override PieceType Type => PieceType.King;
        public override int ScoreValue => 0;
        public override DirectionMap Directions => new DirectionMap(Direction.AllDirections());

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            foreach (Vector2D dir in Directions.GetArray())
            {
                Vector2D? newPos = GetSinglePosition(from + dir, board);
                if (newPos.HasValue)
                {
                    yield return new NormalMove(from, newPos.Value);
                }
            }
        }

        public override bool IsKingInCheck(Vector2D from, Board board)
        {
            return GetMoves(from, board).Any(to => AttackingKing(to, board));
        }
    }
}