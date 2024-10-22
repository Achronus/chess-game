using Chess.Core;

namespace Chess.Moves
{
    public interface IMove
    {
        public MoveType Type { get; }
        public Vector2D FromPosition { get; }
        public Vector2D ToPosition { get; }

        public void Perform(Board board);
    }
}
