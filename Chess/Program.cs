using Chess.Core;

namespace Chess
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Board chessBoard = new Board();
      chessBoard.Init();

      while (true)
      {
        if (chessBoard.IsGameOver())
        {
          break;
        }
      }
    }
  }
}