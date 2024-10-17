using Chess.Core;

namespace Chess.Pieces
{
  public abstract class Piece(Colour colour, PieceType type, int scoreValue)
  {
    public Colour Colour { get; private set; } = colour;
    public PieceType Type { get; private set; } = type;
    public int ScoreValue { get; private set; } = scoreValue;

    public abstract void Move();

    public abstract void Take();
  }
}