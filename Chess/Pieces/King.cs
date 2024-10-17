using Chess.Core;

namespace Chess.Pieces
{
  public class King(Colour colour) : Piece(colour, type: PieceType.King, scoreValue: 0)
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