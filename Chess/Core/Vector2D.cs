namespace Chess.Core
{
    public readonly struct Vector2D(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2D operator *(int scalar, Vector2D v)
        {
            return new Vector2D(scalar * v.X, scalar * v.Y);
        }

        public static bool operator ==(Vector2D left, Vector2D right)
        {
            return EqualityComparer<Vector2D>.Default.Equals(left, right);
        }

        public static bool operator !=(Vector2D left, Vector2D right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector2D vector &&
                   X == vector.X &&
                   Y == vector.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
