namespace Chess.Core.Pieces
{
    public abstract class Piece
    {
        
        public PieceColor Color { get; private set; }

        public Piece(PieceColor color)
        {
            Color = color;
        }

        internal abstract bool CanMove(Position from, Position to, Board board);
    }
}
