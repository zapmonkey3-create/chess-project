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
            Piece pawn = board.GetPiece(from.Row, from.Col);
            Piece target = board.GetPiece(to.Row, to.Col);
            int direction = pawn.Color == PieceColor.White ? -1 : 1;
            int startingRow = pawn.Color == PieceColor.White ? 6 : 1;

            if (to.Row == from.Row + direction && to.Col == from.Col && target == null)
            {
                return true;
            }

            if (to.Row == from.Row + (direction * 2) && board.GetPiece(from.Row + direction, from.Col) == null && to.Col == from.Col && from.Row == startingRow && target == null)
            {
                return true;
            }

            if (to.Row == from.Row + direction && Math.Abs(to.Col - from.Col) == 1 && target != null)
            {
                    return true;
            }
            return false;
        }
    }
}
