using Chess.Core;
using Chess.Moves;

namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        public override Colour Colour { get; }
        public override PieceType Type { get; }
        public override int ScoreValue { get; }
        public override Vector2D[] Directions { get; }

        public Vector2D StartPosition { get; }

        public Pawn(Colour colour, Vector2D startPos)
        {
            Colour = colour;
            Type = PieceType.Pawn;
            ScoreValue = 1;
            StartPosition = startPos;

            Directions = Colour == Colour.White ?
                [
                    Direction.North,
                    Direction.NorthEast,
                    Direction.NorthWest,
                ]
            :
                [
                    Direction.South,
                    Direction.SouthEast,
                    Direction.SouthWest,
                ];
        }

        public override IEnumerable<Move> GetMoves(Vector2D from, Board board)
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Take()
        {
            throw new NotImplementedException();
        }
    }
}