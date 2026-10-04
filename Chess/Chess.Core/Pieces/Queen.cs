using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Pieces
{
    public class Queen : Piece
    {
        public Queen(PieceColor color) : base(color)
        {

        }
        public override bool CanMove(Position from, Position to, Board board)
        {

            int rowDifference = Math.Abs(from.Row - to.Row);
            int colDifference = Math.Abs(from.Col - to.Col);
            int rowStep = to.Row > from.Row ? 1 : -1;
            int colStep = to.Col > from.Col ? 1 : -1;
            //diagonal
            if (rowDifference == colDifference)
            {
                

                for (int i = from.Row + rowStep, j = from.Col + colStep; i != to.Row || j != to.Col; i += rowStep, j += colStep)
                {
                    if (board.GetPiece(i, j) != null)
                    {
                        return false;
                    }
                }
            }
            //vertical
            else if (from.Col == to.Col)
            {

                for (int i = from.Row + rowStep; i != to.Row; i += rowStep)
                {
                    if (board.GetPiece(i, to.Col) != null)
                    {
                        return false;
                    }
                }
            }
            //horizontal
            else if (from.Row == to.Row)
            {

                for (int i = from.Col + colStep; i != to.Col; i += colStep)
                {
                    if (board.GetPiece(to.Row, i) != null)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

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
    }
}
