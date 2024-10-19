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
