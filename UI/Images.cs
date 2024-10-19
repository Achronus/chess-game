using System.Windows.Media;
using System.Windows.Media.Imaging;

using Chess.Core;
using Chess.Pieces;

namespace UI
{
    public static class Images
    {
        private static Dictionary<PieceType, ImageSource> WhitePieces { get; } = new()
        {
            { PieceType.Pawn, LoadImage("assets/white/pawn.png") },
            { PieceType.Rook, LoadImage("assets/white/rook.png") },
            { PieceType.Knight, LoadImage("assets/white/knight.png") },
            { PieceType.Bishop, LoadImage("assets/white/bishop.png") },
            { PieceType.Queen, LoadImage("assets/white/queen.png") },
            { PieceType.King, LoadImage("assets/white/king.png") }
        };
        private static Dictionary<PieceType, ImageSource> BlackPieces { get; } = new()
        {
            { PieceType.Pawn, LoadImage("assets/black/pawn.png") },
            { PieceType.Rook, LoadImage("assets/black/rook.png") },
            { PieceType.Knight, LoadImage("assets/black/knight.png") },
            { PieceType.Bishop, LoadImage("assets/black/bishop.png") },
            { PieceType.Queen, LoadImage("assets/black/queen.png") },
            { PieceType.King, LoadImage("assets/black/king.png") }
        };
        private static ImageSource NoPieceImage { get; } = LoadImage("assets/empty.png");

        private static ImageSource LoadImage(string filepath)
        {
            return new BitmapImage(new Uri(filepath, UriKind.Relative));
        }

        public static ImageSource GetImage(Colour colour, PieceType type)
        {
            return colour switch
            {
                Colour.White => WhitePieces[type],
                Colour.Black => BlackPieces[type],
                Colour.None => NoPieceImage,
                _ => throw new ArgumentException("Invalid colour")
            };
        }

        public static ImageSource GetImage(Piece piece)
        {
            return piece != NoPiece.Instance ? GetImage(piece.Colour, piece.Type) : NoPieceImage;
        }
    }
}
