namespace Chess.Core.Pieces
{
    public abstract class Piece
    {
        
        public PieceColor Color { get; private set; }

        public Piece(PieceColor color)
        {
            Color = color;
        }

        public abstract bool CanMove(Position from, Position to, Board board);
    }
}
