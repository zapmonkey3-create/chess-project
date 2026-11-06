using System.Text;
using Chess.Core.Pieces;

namespace Chess.Core
{
    public class GameExporter()
    {
        private char GetPieceSymbol(Piece piece)
       {
            char symbol = piece switch
            {
                Rook => 'R',
                Knight => 'N',
                Bishop => 'B',
                Queen => 'Q',
                King => 'K',
                Pawn => 'P',
            };

            if (piece.Color == PieceColor.Black)
            {
                symbol = char.ToLower(symbol);
            }

            return symbol;
        }
       public string ExportFen(Board board)
        {   
            StringBuilder fen = new StringBuilder("");
            for(int row = 0; row < 8; row++)
            {
                int nullSquareTracker = 0;
                for(int col = 0; col < 8; col++)
                {
                      Piece? piece = board.GetPiece(row, col);

                      if (piece == null)
                      {
                      nullSquareTracker++;
                      }
                      else
                      {
                      if (nullSquareTracker > 0)
                      {
                      fen.Append(nullSquareTracker);
                      nullSquareTracker = 0;
                      }
                      
                      fen.Append(GetPieceSymbol(piece));
                      }
                }

                if (nullSquareTracker > 0)
                fen.Append(nullSquareTracker);

                if (row < 7)
                fen.Append('/');
            }

            if(board.currentTurn == PieceColor.White)
            fen.Append(" w ");

            else
            fen.Append(" b ");
            
            if(board.WhiteCanCastleKingside)
            fen.Append("K");

            if(board.WhiteCanCastleQueenside)
            fen.Append("Q");

            if(board.BlackCanCastleKingside)
            fen.Append("k");

            if(board.BlackCanCastleQueenside)
            fen.Append("q");

            if(!board.WhiteCanCastleKingside && !board.WhiteCanCastleQueenside && !board.BlackCanCastleKingside && !board.BlackCanCastleQueenside)
            fen.Append("-");
            
            fen.Append(' ');
            if(board.EnPassantTarget is Position target)
            {
                fen.Append((char)('a' + target.Col));
                fen.Append(8-target.Row);
            }
            else
            {
                fen.Append(" -");
            }

            fen.Append($" {board.HalfMoveClock} {board.MoveClock}");

            return fen.ToString();
        }
    }
}