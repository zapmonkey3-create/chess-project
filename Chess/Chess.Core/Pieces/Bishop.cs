using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color): base(color)
        {
        }
        public override bool CanMove(Position from, Position to, Board board)
        {
            int rowDifference = Math.Abs(from.Row - to.Row);
            int colDifference = Math.Abs(from.Col - to.Col);
            if (rowDifference == colDifference)
            {
                int rowStep = to.Row > from.Row ? 1 : -1;
                int colStep = to.Col > from.Col ? 1 : -1;

                for (int i = from.Row + rowStep,  j = from.Col + colStep; i != to.Row || j != to.Col; i += rowStep, j += colStep)
                {
                    if (board.GetPiece(i, j) != null)
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
