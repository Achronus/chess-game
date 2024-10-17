using Chess.Core;

namespace Chess.Pieces
{
  public class Rook(Colour colour) : Piece(colour, type: PieceType.Rook, scoreValue: 5)
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