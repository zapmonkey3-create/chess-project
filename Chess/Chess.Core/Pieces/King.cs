using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Pieces
{
    public class King : Piece
    {
        public King(PieceColor color) : base(color)
        {

        }
        public override bool CanMove(Position from, Position to, Board board)
        {
            int rowDifference = Math.Abs(from.Row - to.Row);
            int colDifference = Math.Abs(from.Col - to.Col);
            Piece target = board.GetPiece(to.Row, to.Col);
            if (rowDifference== 1 && colDifference == 1 || rowDifference == 0 && colDifference == 1 || rowDifference == 1 && colDifference == 0)
            {   
                    return true;
            }
            return false;
        }
    }
}
