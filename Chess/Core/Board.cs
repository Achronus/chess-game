using Chess.Pieces;

namespace Chess.Core
{
  public class Board
  {
    private Piece[,] board;

    public Board() {
      board = new Piece[8, 8];
    }

    public void Init()
    {
      PieceType[] backRow = [
        PieceType.Rook,
        PieceType.Knight,
        PieceType.Bishop,
        PieceType.Queen,
        PieceType.King,
        PieceType.Bishop,
        PieceType.Knight,
        PieceType.Rook
      ];

      for (int i = 0; i < board.GetLength(0); i++)
      {
        board[1, i] = new Pawn(Colour.Black);
        board[board.GetLength(0) - 2, i] = new Pawn(Colour.White);
      }

      for (int i = 0; i < backRow.Length; i++)
      {
        board[0, i] = CreatePiece(backRow[i], Colour.Black);
        board[board.GetLength(0) - 1, i] = CreatePiece(backRow[i], Colour.White);
      }
    }

    public bool IsGameOver()
    {
      return true;
    }

    private static Piece CreatePiece(PieceType type, Colour colour)
    {
      return type switch
      {
        PieceType.Pawn => new Pawn(colour),
        PieceType.Rook => new Rook(colour),
        PieceType.Knight => new Knight(colour),
        PieceType.Bishop => new Bishop(colour),
        PieceType.Queen => new Queen(colour),
        PieceType.King => new King(colour),
        _ => throw new ArgumentException("Invalid piece type")
      };
    }
  }
}
