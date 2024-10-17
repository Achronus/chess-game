namespace Chess.Core
{
  public class Game
  {
    public Player White { get; }
    public Player Black { get; }

    public Game(Player white, Player black) {
      White = white;
      Black = black;
    }

    public bool IsGameOver()
    {
      return true;
    }
  }
}