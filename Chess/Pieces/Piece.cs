using Chess.Core;

namespace Chess.Pieces
{
  public abstract class Piece
  {
    public abstract Colour Colour { get; }
    public abstract PieceType Type { get; }
    public abstract int ScoreValue { get; }
    public bool HasMoved { get; set; } = false;

    public abstract void Move();

    public abstract void Take();
  }
}