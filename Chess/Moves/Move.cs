using Chess.Core;

namespace Chess.Moves
{
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Vector2D FromPosition { get; }
        public abstract Vector2D ToPosition { get; }

        public abstract void Step(Board board);
    }
}
