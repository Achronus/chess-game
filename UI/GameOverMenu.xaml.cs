using System.Windows;
using System.Windows.Controls;

using Chess.Core;

namespace UI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {
        public event Action<Option>? OptionSelected = null;

        public GameOverMenu(GameState match)
        {
            InitializeComponent();

            ArgumentNullException.ThrowIfNull(match.Result, nameof(match.Result));

            Result result = match.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, match.CurrentPlayer);
        }

        private static string GetWinnerText(Player winner)
        {
            string winnerName = PlayerString(winner);
            return winner.Colour == Colour.None ? "IT'S A DRAW" : $"{winnerName} WINS!";
        }

        private static string PlayerString(Player player)
        {
            return player.Colour.ToString().ToUpper();
        }

        private static string GetReasonText(GameOverStatus reason, Player currentPlayer)
        {
            if (reason == GameOverStatus.InsufficientMaterial)
            {
                return "INSUFFICIENT MATERIAL";
            }

            string reasonUpper = reason.ToString().ToUpper();
            return $"{reasonUpper} - {PlayerString(currentPlayer)} CAN'T MOVE";
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
