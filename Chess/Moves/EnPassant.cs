using Chess.Core;
using Chess.Pieces;

namespace Chess.Moves
{
    public class EnPassant(Vector2D from, Vector2D to) : IMove
    {
        public MoveType Type => MoveType.EnPassant;
        public Vector2D FromPosition { get; } = from;
        public Vector2D ToPosition { get; } = to;
        public Vector2D CapturePosition { get; } = new Vector2D(from.X, to.Y);

        public void Perform(Board board)
        {
            new NormalMove(FromPosition, ToPosition).Perform(board);
            board[CapturePosition] = NoPiece.Instance;
        }
    }
}
