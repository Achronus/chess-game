using System.Windows;
using System.Windows.Controls;

using Chess.Core;
using Chess.Pieces;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Image[,] Pieces { get; } = new Image[8, 8];
        private GameState Match { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SetupBoard();

            Player white = new Player(Colour.White);
            Player black = new Player(Colour.Black);

            Match = new GameState(white, Board.Setup());
            DrawBoard(Match.Board);

            while (true)
            {
                if (Match.IsGameOver())
                {
                    break;
                }
            }
        }

        private void SetupBoard()
        {
            for (int r = 0; r < Pieces.GetLength(0); r++)
            {
                for (int c = 0; c < Pieces.GetLength(1); c++)
                {
                    Image image = new Image();
                    Pieces[r, c] = image;
                    PieceGrid.Children.Add(image);
                }
            }
        }

        private void DrawBoard(Board board)
        {
            for (int r = 0; r < Pieces.GetLength(0); r++)
            {
                for (int c = 0; c < Pieces.GetLength(1); c++)
                {
                    Piece piece = board[r, c];
                    Pieces[r, c].Source = Images.GetImage(piece);
                }
            }
        }
    }
}