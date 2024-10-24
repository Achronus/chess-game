using System.Windows.Controls;
using System.Windows.Input;

using Chess.Core;

namespace UI
{
    public class PromotionEventArgs(PieceType newType, Vector2D from, Vector2D to) : EventArgs
    {
        public PieceType NewType { get; } = newType;
        public Vector2D From { get; } = from;
        public Vector2D To { get; } = to;
    }

    /// <summary>
    /// Interaction logic for PromotionMenu.xaml
    /// </summary>
    public partial class PromotionMenu : UserControl
    {
        public event Action<PromotionEventArgs>? OnPieceSelected = null;
        private Vector2D From { get; }
        private Vector2D To { get; }

        public PromotionMenu(Colour pieceColour, Vector2D from, Vector2D to)
        {
            InitializeComponent();

            From = from;
            To = to;

            QueenImg.Source = Images.GetImage(pieceColour, PieceType.Queen);
            RookImg.Source = Images.GetImage(pieceColour, PieceType.Rook);
            KnightImg.Source = Images.GetImage(pieceColour, PieceType.Knight);
            BishopImg.Source = Images.GetImage(pieceColour, PieceType.Bishop);
        }

        private void QueenImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnPieceSelected?.Invoke(new PromotionEventArgs(PieceType.Queen, From, To));
        }

        private void BishopImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnPieceSelected?.Invoke(new PromotionEventArgs(PieceType.Bishop, From, To));
        }

        private void KnightImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnPieceSelected?.Invoke(new PromotionEventArgs(PieceType.Knight, From, To));
        }

        private void RookImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnPieceSelected?.Invoke(new PromotionEventArgs(PieceType.Rook, From, To));
        }
    }
}
