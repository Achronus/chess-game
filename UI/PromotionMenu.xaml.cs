using System.Windows.Controls;
using System.Windows.Input;

using Chess.Core;

namespace UI
{
    /// <summary>
    /// Interaction logic for PromotionMenu.xaml
    /// </summary>
    public partial class PromotionMenu : UserControl
    {
        public event Action<PieceType>? OnPieceSelected = null;

        public PromotionMenu(Colour pieceColour)
        {
            InitializeComponent();

            QueenImg.Source = Images.GetImage(pieceColour, PieceType.Queen);
            RookImg.Source = Images.GetImage(pieceColour, PieceType.Rook);
            KnightImg.Source = Images.GetImage(pieceColour, PieceType.Knight);
            BishopImg.Source = Images.GetImage(pieceColour, PieceType.Bishop);
        }

        private void QueenImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnPieceSelected?.Invoke(PieceType.Queen);
        }

        private void BishopImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnPieceSelected?.Invoke(PieceType.Bishop);
        }

        private void KnightImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnPieceSelected?.Invoke(PieceType.Knight);
        }

        private void RookImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnPieceSelected?.Invoke(PieceType.Rook);
        }
    }
}
