using Chess.Pieces;

namespace Chess.Core
{
    public class Board
    {
        public static int RowSize { get; } = 8;
        public static int ColSize { get; } = 8;
        private Piece[,] Pieces { get; } = new Piece[RowSize, ColSize];
        public Dictionary<Colour, Vector2D?> PawnEnPassantPositions { get; set; } = new Dictionary<Colour, Vector2D?> {
            { Colour.White, null },
            { Colour.Black, null }
        };
    
        public Piece this[int row, int col]
        { 
            get => Pieces[row, col];
            set => Pieces[row, col] = value;
        }

        public Piece this[Vector2D pos]
        {
            get => this[pos.X, pos.Y];
            set => this[pos.X, pos.Y] = value;
        }

        public Board()
        {
            InitializeEmptyBoard();
        }

        public static Board Setup()
        {
            Board board = new Board();
            board.AddStartingPieces();
            return board;
        }

        private void InitializeEmptyBoard()
        {
            for (int row = 0; row < RowSize; row++)
            {
                for (int col = 0; col < ColSize; col++)
                {
                    Pieces[row, col] = NoPiece.Instance;
                }
            }
        }

        private void AddStartingPieces()
        {
            PieceType[] backRow = [
                PieceType.Rook,
                PieceType.Knight,
                PieceType.Bishop,
                PieceType.Queen,
                PieceType.King,
                PieceType.Bishop,
                PieceType.Knight,
                PieceType.Rook
            ];

            for (int i = 0; i < backRow.Length; i++)
            {
                Pieces[0, i] = CreatePiece(backRow[i], Colour.Black);
                Pieces[Pieces.GetLength(0) - 1, i] = CreatePiece(backRow[i], Colour.White);
            }

            for (int i = 0; i < RowSize; i++)
            {
                int whiteRowIdx = Pieces.GetLength(0) - 2;
                Pieces[1, i] = new Pawn(Colour.Black, new Vector2D(1, i));
                Pieces[whiteRowIdx, i] = new Pawn(Colour.White, new Vector2D(whiteRowIdx, i));
            }
        }

        private static Piece CreatePiece(PieceType type, Colour colour)
        {
            return type switch
            {
                PieceType.Rook => new Rook(colour),
                PieceType.Knight => new Knight(colour),
                PieceType.Bishop => new Bishop(colour),
                PieceType.Queen => new Queen(colour),
                PieceType.King => new King(colour),
                _ => throw new ArgumentException("Invalid piece type")
            };
        }

        public bool IsEmpty(Vector2D pos)
        {
            return this[pos] == NoPiece.Instance;
        }

        public static bool InBounds(Vector2D pos)
        {
            return pos.X >= 0 && pos.X < RowSize && pos.Y >= 0 && pos.Y < ColSize;
        }

        public IEnumerable<Vector2D> PiecePositions()
        {
            for (int r = 0; r < RowSize; r++)
            {
                for (int c = 0; c < ColSize; c++)
                {
                    Vector2D piecePos = new Vector2D(r, c);
                    
                    if (!IsEmpty(piecePos))
                    { 
                        yield return piecePos;
                    }
                }
            }
        }

        public bool IsInCheck(Player player)
        {
            return player.MyPiecePositions(this).Any(pos =>
            {
                Piece piece = this[pos];
                return piece.IsKingInCheck(pos, this);
            });
        }
    }
}
