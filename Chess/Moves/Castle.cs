using Chess.Core;

namespace Chess.Moves
{
    public class Castle : IMove
    {
        public MoveType Type { get; }
        public Vector2D FromPosition { get; }
        public Vector2D ToPosition { get; }
        private Vector2D KingMoveDirection { get; }
        private Tuple<Vector2D, Vector2D>? RookPositions { get; set; } = null;  // <from, to>

        public Castle(MoveType type, Vector2D kingPos)
        {
            if (type != MoveType.CastleShort || type != MoveType.CastleLong)
            {
                throw new ArgumentException($"Invalid MoveType '{type}'. Should be 'CastleShort' or 'CastleLong'.");
            }

            Type = type;
            FromPosition = kingPos;

            if (type == MoveType.CastleShort)
            {
                KingMoveDirection = Direction.East;
                ToPosition = new Vector2D(kingPos.X, Board.RowSize - 2);
                RookPositions = Tuple.Create(
                    new Vector2D(kingPos.X, Board.RowSize - 1), 
                    new Vector2D(kingPos.X, Board.RowSize - 3)
                );

            }
            else if (type == MoveType.CastleLong)
            {
                KingMoveDirection = Direction.West;
                ToPosition = new Vector2D(kingPos.X, 2);
                RookPositions = Tuple.Create(
                    new Vector2D(kingPos.X, 0),
                    new Vector2D(kingPos.X, 3)
                );
            }
        }

        public void Perform(Board board)
        {
            new NormalMove(FromPosition, ToPosition).Perform(board);
            new NormalMove(RookPositions!.Item1, RookPositions.Item2).Perform(board);
        }
    }
}
