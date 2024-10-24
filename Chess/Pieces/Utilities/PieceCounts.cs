using Chess.Core;

namespace Chess.Pieces
{
    public class PieceCounts
    {
        public Dictionary<PieceType, int> WhitePieces { get; private set; } = [];
        public Dictionary<PieceType, int> BlackPieces { get; private set; } = [];
        public int TotalPieces { get; private set; } = 0;

        public PieceCounts()
        {
            foreach (PieceType type in Enum.GetValues(typeof(PieceType)))
            {
                if (type != PieceType.Empty)
                {
                    WhitePieces[type] = 0;
                    BlackPieces[type] = 0;
                }
            }
        }

        public void Increase(Colour colour, PieceType type)
        {
            if (colour == Colour.White)
            {
                WhitePieces[type]++;
            }
            else if (colour == Colour.Black)
            {
                BlackPieces[type]++;
            }
            else
            {
                throw new ArgumentException("Invalid colour.");
            }

            TotalPieces++;
        }

        public Tuple<int, int> GetWhiteBlackPieceCount(PieceType type)
        {
            return Tuple.Create(WhitePieces[type], BlackPieces[type]);
        }
    }
}
