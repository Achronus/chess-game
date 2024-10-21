using Chess.Moves;
using Chess.Pieces;

namespace Chess.Core
{
    public class Player(Colour colour)
    {
        public Colour Colour { get; } = colour;
        public int Score { get; private set; } = 0;

        public IEnumerable<Move> LegalMoves(Vector2D pos, Board board)
        {
            // Prevent opponent piece selection
            if (IsOpponentPiece(pos, board))
            {
                return [];
            }

            Piece piece = board[pos];
            return piece.GetMoves(pos, board);
        }

        private bool IsOpponentPiece(Vector2D pos, Board board)
        {
            return board[pos].Colour != Colour;
        }
    }
}