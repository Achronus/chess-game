using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public abstract Colour Colour { get; }
        public abstract PieceType Type { get; }
        public abstract int ScoreValue { get; }
        public abstract Vector2D[] Directions { get; }

        public bool HasMoved { get; set; } = false;
        public GetMoves MoveLogic { get; }

        public Piece()
        {
            MoveLogic = new GetMoves(this);
        }

        public abstract IEnumerable<Move> GetMoves(Vector2D from, Board board);

        public virtual bool IsKingInCheck(Vector2D from, Board board)
        {
            return GetMoves(from, board).Any(move => AttackingKing(move, board));
        }

        public static bool AttackingKing(Move move, Board board)
        {
            // NoPiece check needed for invalid moves during check
            Piece piece = board[move.ToPosition];
            return piece != NoPiece.Instance && piece.Type == PieceType.King;
        }
    }
}