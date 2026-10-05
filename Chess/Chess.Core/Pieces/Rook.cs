using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Pieces
{
    public class Rook : Piece
    {
        public Rook(PieceColor color): base(color)
        {

        }

        public override bool CanMove(Position from, Position to, Board board)
        {
            //vertical
            if (from.Col == to.Col)
            {
                int step = to.Row > from.Row ? 1 : -1;

                for (int i = from.Row + step; i != to.Row; i += step)
                {
                    if (board.GetPiece(i, to.Col) != null)
                    {
                        return false;
                    }
                }
                return true;
            }

            //horizontal
            else if (from.Row == to.Row)
            {
                int step = to.Col > from.Col ? 1 : -1;

                for (int i = from.Col + step; i != to.Col; i += step)
                {
                    if (board.GetPiece(to.Row, i) != null)
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
