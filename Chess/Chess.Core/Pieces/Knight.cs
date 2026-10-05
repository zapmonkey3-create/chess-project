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
                return true;
            }
            return false;
        }
    }
}
