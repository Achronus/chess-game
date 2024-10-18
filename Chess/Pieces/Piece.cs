using Chess.Core;

namespace Chess.Pieces
{
  public abstract class Piece(Colour colour, PieceType type, int scoreValue)
  {
    public Colour Colour { get; } = colour;
    public PieceType Type { get; } = type;
    public int ScoreValue { get; } = scoreValue;
    public bool HasMoved { get; set; } = false;

    public abstract void Move();

    public abstract void Take();
  }
}