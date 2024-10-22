namespace Chess.Core
{
    public enum Colour
    {
        White,
        Black,
        None
    }

    public enum PieceType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        King,
        Queen,
        Empty
    }

    public enum PawnMoves
    { 
        Forward,
        ForwardLeft,
        ForwardRight,
        ForwardDouble
    }

    public enum MoveType
    { 
        Normal,
        CastleShort,
        CastleLong,
        EnPassant,
        PawnPromotion
    }

    public enum GameOverStatus
    {
        Checkmate,
        Stalemate,
        InsufficientMaterial
    }
}
