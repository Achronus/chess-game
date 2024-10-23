using Chess.Core;
using Chess.Pieces;

namespace Chess.Moves
{
    public class NormalMove(Vector2D fromPosition, Vector2D toPosition) : IMove
    {
        public MoveType Type => MoveType.Normal;
        public Vector2D FromPosition => fromPosition;
        public Vector2D ToPosition => toPosition;

        public void Perform(Board board)
        {
            Piece piece = board[FromPosition];
            board[ToPosition] = piece;
            board[FromPosition] = NoPiece.Instance;
            piece.HasMoved = true;
        }
    }
}
