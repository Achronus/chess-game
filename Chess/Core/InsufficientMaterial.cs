using Chess.Pieces;

namespace Chess.Core
{
    public class InsufficientMaterial(PieceCounts counts)
    {
        private PieceCounts Counts { get; } = counts;

        public bool Is()
        {
            return IsKingVsKing()
                || IsKingBishopVsKing() 
                || IsKingKnightVsKing() 
                || IsKingBishopVsKingBishop();
        }

        private bool IsKingVsKing()
        {
            return Counts.TotalPieces == 2;
        }

        private bool IsKingBishopVsKing()
        {
            Tuple<int, int> bishopCounts = Counts.GetWhiteBlackPieceCount(PieceType.Bishop);
            
            bool bishop = bishopCounts.Item1 == 1 || bishopCounts.Item2 == 1;
            return Counts.TotalPieces == 3 && bishop;
        }

        private bool IsKingKnightVsKing()
        {
            Tuple<int, int> knightCounts = Counts.GetWhiteBlackPieceCount(PieceType.Knight);

            bool knight = knightCounts.Item1 == 1 || knightCounts.Item2 == 1;
            return Counts.TotalPieces == 3 && knight;
        }

        private bool IsKingBishopVsKingBishop()
        {
            Tuple<int, int> bishopCounts = Counts.GetWhiteBlackPieceCount(PieceType.Bishop);

            bool bishops = bishopCounts.Item1 == 1 && bishopCounts.Item2 == 1;
            return Counts.TotalPieces == 4 && bishops;
        }
    }
}
