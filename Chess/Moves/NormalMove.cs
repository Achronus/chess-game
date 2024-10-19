using Chess.Core;
using Chess.Pieces;

namespace Chess.Moves
{
    public class NormalMove : Move
    {
        public override MoveType Type => MoveType.Normal;
        public override Vector2D FromPosition { get; }
        public override Vector2D ToPosition { get; }

        public NormalMove(Vector2D fromPosition, Vector2D toPosition)
        {
            FromPosition = fromPosition;
            ToPosition = toPosition;
        }

        public override void Perform(Board board)
        {
            Piece piece = board[FromPosition];
            board[ToPosition] = piece;
            board[FromPosition] = NoPiece.Instance;
            piece.HasMoved = true;
        }
    }
}
