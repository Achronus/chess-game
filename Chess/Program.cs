using Chess.Core;

namespace Chess
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Game match = new Game(
        white: new Player(Colour.White), 
        black: new Player(Colour.Black)
      );
      
      Board chessBoard = new Board();
      chessBoard.Init();

      while (true)
      {
        if (match.IsGameOver())
        {
          break;
        }
      }
    }
  }
}