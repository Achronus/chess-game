namespace Chess.Core
{
    public static class Direction
    {
        public static Vector2D North { get; } = new Vector2D(-1, 0);
        public static Vector2D East { get; } = new Vector2D(0, 1);
        public static Vector2D South { get; } = new Vector2D(1, 0);
        public static Vector2D West { get; } = new Vector2D(0, -1);

        public static Vector2D NorthEast { get; } = North + East;
        public static Vector2D NorthWest { get; } = North + West;
        public static Vector2D SouthWest { get; } = South + West;
        public static Vector2D SouthEast { get; } = South + East;

        public static Vector2D GetDirection(DirectionType direction)
        {
            return direction switch
            {
            DirectionType.North => North,
            DirectionType.East => East,
            DirectionType.South => South,
            DirectionType.West => West,
            DirectionType.NorthEast => NorthEast,
            DirectionType.NorthWest => NorthWest,
            DirectionType.SouthWest => SouthWest,
            DirectionType.SouthEast => SouthEast,
            _ => throw new ArgumentException("Invalid direction type")
            };
        }
    }
}
