using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media;

using Chess.Core;
using Chess.Pieces;
using Chess.Moves;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Image[,] PieceImages { get; }
        private Rectangle[,] HighlightedMoves { get; }
        private Dictionary<Vector2D, Move> PossibleMoves { get; } = [];
        private GameState Match { get; set; }
        private Vector2D? SelectedPosition { get; set; } = null;

        public MainWindow()
        {
            PieceImages = new Image[Board.RowSize, Board.ColSize];
            HighlightedMoves = new Rectangle[Board.RowSize, Board.ColSize];

            InitializeComponent();
            SetupBoard();

            Player white = new Player(Colour.White);
            Player black = new Player(Colour.Black);

            Match = new GameState(white, black, Board.Setup());
            DrawBoard(Match.Board);
            SetCursor(Match.CurrentPlayer);
        }

        private void SetupBoard()
        {
            for (int r = 0; r < PieceImages.GetLength(0); r++)
            {
                for (int c = 0; c < PieceImages.GetLength(1); c++)
                {
                    Image image = new Image();
                    PieceImages[r, c] = image;
                    PieceGrid.Children.Add(image);

                    Rectangle highlight = new Rectangle();
                    HighlightedMoves[r, c] = highlight;
                    HighlightGrid.Children.Add(highlight);
                }
            }
        }

        private void DrawBoard(Board board)
        {
            for (int r = 0; r < PieceImages.GetLength(0); r++)
            {
                for (int c = 0; c < PieceImages.GetLength(1); c++)
                {
                    Piece piece = board[r, c];
                    PieceImages[r, c].Source = Images.GetImage(piece);
                }
            }
        }

        private void ChessBoard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(ChessBoard);
            Vector2D pos = PointToBoardVector2D(point);

            if (SelectedPosition == null)
            {
                ShowPossibleMoves(pos);
            }
            else
            {
                PerformAndHideMoves(pos);
            }
        }

        private void ShowPossibleMoves(Vector2D pos)
        {
            IEnumerable<Move> pieceMoves = Match.CurrentPlayer.PossibleMoves(pos, Match.Board);

            if (pieceMoves.Any())
            {
                pieceMoves = pieceMoves.Where(move => Match.IsMoveSafeForKing(move));
                SelectedPosition = pos;
                StoreMoves(pieceMoves);
                ShowHighlights();
            }
        }

        private void PerformAndHideMoves(Vector2D pos)
        {
            SelectedPosition = null;
            HideHighlights();

            if (PossibleMoves.TryGetValue(pos, out Move move))
            {
                HandleMove(move);
            }
        }

        private void HandleMove(Move move)
        {
            Match.MakeMove(move);
            DrawBoard(Match.Board);
            SetCursor(Match.CurrentPlayer);
        }

        private Vector2D PointToBoardVector2D(Point point)
        {
            double squareSize = ChessBoard.ActualWidth / Board.ColSize;
            int row = (int)(point.Y / squareSize);
            int col = (int)(point.X / squareSize);
            return new Vector2D(row, col);
        }

        private void StoreMoves(IEnumerable<Move> moves)
        {
            PossibleMoves.Clear();

            foreach (Move move in moves)
            {
                PossibleMoves[move.ToPosition] = move;
            }
        }

        private void ShowHighlights()
        {
            Color colour = Color.FromArgb(150, 125, 255, 125);

            foreach (Vector2D to in PossibleMoves.Keys)
            {
                HighlightedMoves[to.X, to.Y].Fill = new SolidColorBrush(colour);
            }
        }

        private void HideHighlights()
        {
            foreach (Vector2D to in PossibleMoves.Keys)
            {
                HighlightedMoves[to.X, to.Y].Fill = Brushes.Transparent;
            }
        }

        private void SetCursor(Player player)
        {
            Cursor = player.Colour == Colour.White ? Cursors.WhiteCursor : Cursors.BlackCursor;
        }
    }
}