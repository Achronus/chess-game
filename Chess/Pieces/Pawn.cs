using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Pawn(Colour colour, Vector2D startPos) : Piece
    {
        public override Colour Colour { get; } = colour;
        public override PieceType Type { get; } = PieceType.Pawn;
        public override int ScoreValue { get; } = 1;
        public override Vector2D[] Directions { get; } = Direction.Pawn(colour);
        public Vector2D StartPosition { get; } = startPos;

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