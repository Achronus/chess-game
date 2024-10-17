using Chess.Core;

namespace Chess.Pieces
{
  public class Pawn(Colour colour) : Piece(colour, type: PieceType.Pawn, scoreValue: 1)
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