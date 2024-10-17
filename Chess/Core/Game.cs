namespace Chess.Core
{
  public class Game(Player white, Player black)
  {
    public Player White { get; } = white;
    public Player Black { get; } = black;

    public bool IsGameOver()
    {
      return true;
    }
  }
}