namespace Chess.Core
{
    public enum Colour
    {
        White,
        Black
    }

    public enum PieceType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        King,
        Queen
    }

    public enum DirectionType
    {
        NorthEast,
        North,
        NorthWest,
        East,
        SouthEast,
        South,
        SouthWest,
        West
    }

    public enum MoveType
    { 
        Normal,
        CastleShort,
        CastleLong,
        PawnDoubleMove,
        EnPassant,
        PawnPromotion
    }
}
