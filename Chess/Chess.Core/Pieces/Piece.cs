namespace Chess.Core.Pieces
{
    public class Piece
    {
        
        public PieceColor Color { get; private set; }

        public Piece(PieceColor color)
        {
            Color = color;
        }
    }
}
