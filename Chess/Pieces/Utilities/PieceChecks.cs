using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public partial class Piece
    {
        public Colour Opponent()
        {
            return Colour == Colour.White ? Colour.Black : Colour.White;
        }

        public bool IsOpponent(Piece otherPiece)
        {
            return Colour != otherPiece.Colour;
        }

        public bool CanCaptureAt(Vector2D pos, Board board)
        {
            if (!Board.InBounds(pos) || board.IsEmpty(pos))
            {
                return false;
            }

            return IsOpponent(board[pos]);
        }

        public static bool CanMoveTo(Vector2D pos, Board board)
        {
            return Board.InBounds(pos) && board.IsEmpty(pos);
        }

        public bool ValidPosition(Vector2D pos, Board board)
        {
            return CanMoveTo(pos, board) || CanCaptureAt(pos, board);
        }

        public virtual bool IsKingInCheck(Vector2D from, Board board)
        {
            return GetMoves(from, board).Any(move => AttackingKing(move, board));
        }

        public static bool AttackingKing(IMove move, Board board)
        {
            // NoPiece check needed for invalid moves during check
            Piece piece = board[move.ToPosition];
            return piece != NoPiece.Instance && piece.Type == PieceType.King;
        }
    }
}
