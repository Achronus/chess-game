using Chess.Core;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player white = new Player(Colour.White);
            Player black = new Player(Colour.Black);
            Board chessBoard = Board.Setup();

            GameState match = new GameState(white, chessBoard);

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