namespace Chess.Core
{
    public class Result(Player winner, GameOverStatus reason)
    {
        public Player Winner { get; } = winner;
        public GameOverStatus Reason { get; } = reason;

        public static Result Win(Player winner)
        {
            return new Result(winner, GameOverStatus.Checkmate);
        }

        public static Result Draw(GameOverStatus reason)
        {
            return new Result(new Player(Colour.None), reason);
        }
    }
}
