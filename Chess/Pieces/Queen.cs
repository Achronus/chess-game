using Chess.Core;

namespace Chess.Pieces
{
  public class Queen(Colour colour) : Piece(colour, type: PieceType.Queen, scoreValue: 10)
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