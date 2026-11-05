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
            StringBuilder positionKey = new StringBuilder("");
            int nullSquareTracker = 0;
            for(int row = 0; row < 8; row++)
            {
                for(int col = 0; col < 8; col++)
                {
                    if(board.GetPiece(row,col) == null)
                    {
                        nullSquareTracker++;
                    }

                    if(board.GetPiece(row,col) != null)
                    {
                       positionKey.Append(GetPieceSymbol(board.GetPiece(row,col)));
                    }

                    if((col + 1) < 8 && board.GetPiece(row,col+1) != null && nullSquareTracker != 0)
                    {
                       positionKey.Append(nullSquareTracker.ToString());
                       nullSquareTracker = 0;
                    }
                    
                    if(nullSquareTracker == 8)
                    {
                        positionKey.Append(nullSquareTracker.ToString());
                        nullSquareTracker = 0;
                    }
                }
                if(row < 7)
                positionKey.Append('/');
            }

            if(board.currentTurn == PieceColor.White)
            positionKey.Append(" w ");

            else
            positionKey.Append(" b ");
            
            if(board.WhiteCanCastleKingside)
            positionKey.Append("K");

            if(board.WhiteCanCastleQueenside)
            positionKey.Append("Q");

            if(board.BlackCanCastleKingside)
            positionKey.Append("k");

            if(board.BlackCanCastleQueenside)
            positionKey.Append("q");

            return positionKey.ToString();
        }
    }
}