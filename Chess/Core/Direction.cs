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

        public static Vector2D DoubleNorth { get; } = 2 * North;
        public static Vector2D DoubleSouth { get; } = 2 * South;
        public static Vector2D DoubleEast { get; } = 2 * East;
        public static Vector2D DoubleWest { get; } = 2 * West;

        public static Dictionary<string, Vector2D> Pawn(Colour colour)
        {
            return colour switch
            {
                Colour.White => new Dictionary<string, Vector2D> {
                    ["Forward"] = North,
                    ["ForwardLeft"] = NorthEast,
                    ["ForwardRight"] = NorthWest,
                    ["ForwardDouble"] = DoubleNorth
                },
                Colour.Black => new Dictionary<string, Vector2D>
                {
                    ["Forward"] = South,
                    ["ForwardLeft"] = SouthEast,
                    ["ForwardRight"] = SouthWest,
                    ["ForwardDouble"] = DoubleSouth
                },
                Colour.None => [],
                _ => throw new ArgumentException("Invalid colour")
            };
        }

        public static Vector2D[] Knight()
        {
            return [
                DoubleNorth + East,
                DoubleNorth + West,
                DoubleSouth + East,
                DoubleSouth + West,
                DoubleEast + North,
                DoubleEast + South,
                DoubleWest + North,
                DoubleWest + South
            ];
        }

        public static Vector2D[] Basic()
        {
            return [
                North,
                East,
                South,
                West
            ];
        }

        public static Vector2D[] Diagonal()
        {
            return [
                NorthWest,
                NorthEast,
                SouthWest,
                SouthEast
            ];
        }

        public static Vector2D[] AllDirections()
        {
            return Basic().Concat(Diagonal()).ToArray();
        }
    }

    public readonly struct DirectionMap
    {
        public Vector2D[] Array { get; } = [];
        public Dictionary<string, Vector2D> Dict { get; } = [];

        public DirectionMap(Vector2D[] array)
        {
            Array = array;
        }

        public DirectionMap(Dictionary<string, Vector2D> dict)
        {
            Dict = dict;
        }

        public Vector2D[] GetArray()
        {
            return Array;
        }

        public Dictionary<string, Vector2D> GetDict()
        {
            return Dict;
        }
    }
}
