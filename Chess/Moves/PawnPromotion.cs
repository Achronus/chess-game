using Chess.Core;
using Chess.Pieces;

namespace Chess.Moves
{
    public class PawnPromotion(Vector2D from, Vector2D to, PieceType newType) : IMove
    {
        public MoveType Type => MoveType.PawnPromotion;
        public Vector2D FromPosition => from;
        public Vector2D ToPosition => to;
        private PieceType NewType { get; } = newType;

        public void Perform(Board board)
        {
            Piece pawn = board[FromPosition];
            board[FromPosition] = NoPiece.Instance;

            Piece promotionPiece = CreatePromotionPiece(pawn.Colour);
            promotionPiece.HasMoved = true;
            board[ToPosition] = promotionPiece;
        }

        private Piece CreatePromotionPiece(Colour colour)
        {
            return NewType switch
            {
                PieceType.Knight => new Knight(colour),
                PieceType.Bishop => new Bishop(colour),
                PieceType.Rook => new Rook(colour),
                _ => new Queen(colour)
            };
        }
    }
}
