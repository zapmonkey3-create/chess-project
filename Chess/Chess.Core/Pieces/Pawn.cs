using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor color) : base(color)
        {

        }
        public override bool CanMove(Position from, Position to, Board board)
        {
            return true;
        }
    }
}
