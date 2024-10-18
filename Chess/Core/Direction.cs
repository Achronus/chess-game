namespace Chess.Core
{
    public static class Direction
    {
        public readonly static Vector2D North = new Vector2D(-1, 0);
        public readonly static Vector2D East = new Vector2D(0, 1);
        public readonly static Vector2D South = new Vector2D(1, 0);
        public readonly static Vector2D West = new Vector2D(0, -1);

        public readonly static Vector2D NorthEast = North + East;
        public readonly static Vector2D NorthWest = North + West;
        public readonly static Vector2D SouthWest = South + West;
        public readonly static Vector2D SouthEast = South + East;

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
