

namespace Chess.Core
{
    public class Piece
    {
        public PieceType Type { get; private set; }
        public PieceColor Color { get; private set; }

        public Piece(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
        }
    }
}
