namespace Chess.Core
{
  public class Direction(int rowDelta, int columnDelta)
  {
    public readonly static Direction North = new Direction(-1, 0);
    public readonly static Direction East = new Direction(0, 1);
    public readonly static Direction South = new Direction(1, 0);
    public readonly static Direction West = new Direction(0, -1);

    public int RowDelta { get; } = rowDelta;
    public int ColumnDelta { get; } = columnDelta;

    public static Direction operator + (Direction dir1, Direction dir2)
    {
      return new Direction(dir1.RowDelta + dir2.RowDelta, dir1.ColumnDelta + dir2.ColumnDelta);
    }

    public static Direction operator * (int scalar, Direction dir)
    {
      return new Direction(scalar * dir.RowDelta, scalar * dir.ColumnDelta);
    }

    public static Direction GetDirection(DirectionType position)
    {
      return position switch
      {
        DirectionType.North => North,
        DirectionType.East => East,
        DirectionType.South => South,
        DirectionType.West => West,
        DirectionType.NorthEast => North + East,
        DirectionType.NorthWest => North + West,
        DirectionType.SouthWest => South + West,
        DirectionType.SouthEast => South + East,
        _ => throw new ArgumentException("Invalid direction type")
      };
    }
  }
}
