using Chess.Pieces;

namespace Chess.Core
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[8, 8];
    
        public Piece this[int row, int col]
        { 
            get => pieces[row, col];
            set => pieces[row, col] = value;
        }

        public Piece this[Vector2D pos]
        {
            get => this[pos.X, pos.Y];
            set => this[pos.X, pos.Y] = value;
        }

        public static Board Setup()
        {
            Board board = new Board();
            board.AddStartingPieces();
            return board;
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
                pieces[0, i] = CreatePiece(backRow[i], Colour.Black);
                pieces[pieces.GetLength(0) - 1, i] = CreatePiece(backRow[i], Colour.White);
            }

            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                pieces[1, i] = CreatePiece(PieceType.Pawn, Colour.Black);
                pieces[pieces.GetLength(0) - 2, i] = CreatePiece(PieceType.Pawn, Colour.White);
            }
        }

        private static Piece CreatePiece(PieceType type, Colour colour)
        {
            return type switch
            {
                PieceType.Pawn => new Pawn(colour),
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
            return this[pos] == null;
        }
    }
}
