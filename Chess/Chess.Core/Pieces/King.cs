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

            if (rowDifference== 1 && colDifference == 1 || rowDifference == 0 && colDifference == 1 || rowDifference == 1 && colDifference == 0)
            {   
                    return true;
            }

            if (board.WhiteCanCastleKingside && to.Row == 7 && to.Col == 6 && from.Row == 7 && from.Col == 4 && board.GetPiece(7,7) is Rook && board.GetPiece(7,7).Color == PieceColor.White)
            {
                if (board.GetPiece(7,5) != null || board.GetPiece(7, 6) != null)
                {
                    return false;
                }
                return true;
            }

            if (board.BlackCanCastleKingside && to.Row == 0 && to.Col == 6 && from.Row == 0 && from.Col == 4 && board.GetPiece(0,7) is Rook && board.GetPiece(0,7).Color == PieceColor.Black)
            {
                if (board.GetPiece(0,5) != null || board.GetPiece(0, 6) != null)
                {
                    return false;
                }
                return true;
            }

            if (board.WhiteCanCastleQueenside && to.Row == 7 && to.Col == 2 && from.Row == 7 && from.Col == 4 && board.GetPiece(7,0) is Rook && board.GetPiece(7,0).Color == PieceColor.White)
            {
                if (board.GetPiece(7, 1) != null || board.GetPiece(7, 2) != null || board.GetPiece(7, 3) != null)
                {
                    return false;
                }
                return true;
            }

            if (board.BlackCanCastleQueenside && to.Row == 0 && to.Col == 2 && from.Row == 0 && from.Col == 4 && board.GetPiece(0,0) is Rook && board.GetPiece(0,0).Color == PieceColor.Black)
            {
                if (board.GetPiece(0, 1) != null || board.GetPiece(0, 2) != null || board.GetPiece(0, 3) != null)
                {
                    return false;
                }
                return true;
            }

            return false;
        }
    }
}
