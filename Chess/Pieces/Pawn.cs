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
            List<Vector2D> moves = [
                from + Directions[0]
            ];
            List<Vector2D> captures = [
                from + Directions[1],
                from + Directions[2]
            ];

            if (from == StartPosition)
            {
                moves.Add(from + Directions[3]);
            }

            foreach (Vector2D move in moves)
            {
                Vector2D? newPos = MoveLogic.GetSinglePosition(move, board);
                if (newPos != null)
                {
                    yield return new NormalMove(from, newPos);
                }
            }

            foreach (Vector2D capPos in captures)
            {
                if (MoveLogic.Check.IsOpponent(board[capPos]))
                {
                    yield return new NormalMove(from, capPos);
                }
            }
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