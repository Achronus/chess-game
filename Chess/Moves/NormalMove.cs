using Chess.Core;
using Chess.Pieces;

namespace Chess.Moves
{
    public class NormalMove(Vector2D fromPosition, Vector2D toPosition) : IMove
    {
        public MoveType Type => MoveType.Normal;
        public Vector2D FromPosition { get; } = fromPosition;
        public Vector2D ToPosition { get; } = toPosition;

        public void Perform(Board board)
        {
            Piece piece = board[FromPosition];
            board[ToPosition] = piece;
            board[FromPosition] = NoPiece.Instance;
            piece.HasMoved = true;
        }
    }
}
