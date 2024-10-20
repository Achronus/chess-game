using Chess.Core;
using Chess.Pieces;

namespace Chess.Moves
{
    public class CheckMoves(Piece piece)
    {
        private Piece Piece { get; } = piece;

        public bool IsOpponent(Piece otherPiece)
        {
            return Piece.Colour != otherPiece.Colour ? true : false;
        }

        public bool CanCaptureAt(Vector2D pos, Board board)
        {
            if (!Board.InBounds(pos) || board.IsEmpty(pos))
            {
                return false;
            }

            return IsOpponent(board[pos]);
        }

        public bool CanMoveTo(Vector2D pos, Board board)
        {
            return Board.InBounds(pos) && board.IsEmpty(pos);
        }

        public bool ValidPosition(Vector2D pos, Board board)
        {
            if (CanMoveTo(pos, board) || CanCaptureAt(pos, board))
            {
                return true;
            }

            return false;
        }
    }
}
