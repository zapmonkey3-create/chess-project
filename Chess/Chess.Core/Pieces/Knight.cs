using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Pieces
{
    public class Knight : Piece
    {
        public Knight(PieceColor color) : base(color)
        {

        }
        public override bool CanMove(Position from, Position to, Board board)
        {
            int rowDifference = Math.Abs(from.Row - to.Row);
            int colDifference = Math.Abs(from.Col - to.Col);
            if (rowDifference == 2 && colDifference == 1 || rowDifference == 1 && colDifference == 2)
            {
                Piece piece = board.GetPiece(to.Row, to.Col);
                if (piece != null)
                {
                    if (piece.Color == board.currentTurn)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
