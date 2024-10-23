using Chess.Core;

namespace Chess.Moves
{
    public class DoublePawnMove(Vector2D from, Vector2D to) : IMove
    {
        public MoveType Type => MoveType.DoublePawn;
        public Vector2D FromPosition { get; } = from;
        public Vector2D ToPosition { get; } = to;
        private Vector2D EnPassantPosition { get; } = new Vector2D((from.X + to.X) / 2, from.Y);

        public void Perform(Board board)
        {
            Colour colour = board[FromPosition].Colour;
            board.PawnEnPassantPositions[colour] = EnPassantPosition;
            new NormalMove(FromPosition, ToPosition).Perform(board);
        }
    }
}
