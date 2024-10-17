using Chess.Core;

namespace Chess.Pieces
{
  public class Knight(Colour colour) : Piece(colour, type: PieceType.Knight, scoreValue: 3)
  {
    public override void Move()
    {
      throw new NotImplementedException();
    }

    public override void Take()
    {
      throw new NotImplementedException();
    }
  }
}