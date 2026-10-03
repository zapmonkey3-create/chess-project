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
            return true;
        }
    }
}
