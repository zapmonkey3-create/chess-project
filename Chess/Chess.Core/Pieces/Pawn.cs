using System;
using System.Collections.Generic;
using System.Data;
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
            //black pawns
           if (board.GetPiece(from.Row, from.Col).Color == PieceColor.Black)
            {
                if (from.Row == 1)
                {
                    if (to.Row == 3 && to.Col == from.Col && board.GetPiece(3,to.Col) == null)
                    {
                        if (board.GetPiece(2, from.Col) == null)
                        {
                            return true;
                        }
                    }
                    if (to.Row == 2 && to.Col == from.Col && board.GetPiece(2, from.Col) == null)
                    {    
                       return true;
                    }
                }
                if (to.Row == from.Row + 1 && to.Col == from.Col && board.GetPiece(to.Row, to.Col) == null)
                {
                    return true;
                }

                if (to.Row == from.Row + 1 && to.Col == from.Col + 1 || to.Row == from.Row + 1 && to.Col == from.Col - 1)
                {
                    if (board.GetPiece(to.Row, to.Col) != null && board.GetPiece(to.Row,to.Col).Color != board.currentTurn)
                    {
                        return true;
                    }
                }
            }
            //white pawns
            if (board.GetPiece(from.Row, from.Col).Color == PieceColor.White)
            {
                if(from.Row == 6)
                {
                    if (to.Row == 4 && to.Col == from.Col && board.GetPiece(4,to.Col) == null)
                    {
                        if (board.GetPiece(5, from.Col) == null)
                        {
                            return true;
                        }
                    }
                    if (to.Row == 5 && to.Col == from.Col && board.GetPiece(5, from.Col) == null)
                    {
                        return true;
                    }
                }

                if (to.Row == from.Row - 1 && to.Col == from.Col && board.GetPiece(to.Row, to.Col) == null)
                {
                    return true;
                }

                if (to.Row == from.Row - 1 && to.Col == from.Col - 1 || to.Row == from.Row - 1 && to.Col == from.Col + 1)
                {
                    if (board.GetPiece(to.Row, to.Col) != null && board.GetPiece(to.Row, to.Col).Color != board.currentTurn)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
