using Chess.Core;

namespace Chess.Pieces
{
  public class Bishop(Colour colour) : Piece(colour, type: PieceType.Bishop, scoreValue: 3)
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