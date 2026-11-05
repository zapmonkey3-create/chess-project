using Chess.Core.Pieces;

namespace Chess.Core
{
    
    public class DrawDetector
    {
        private bool DrawByInsufficientMaterial(Piece[,] pieces)
        {
            int whiteLightBishops = 0;
            int whiteDarkBishops = 0;
            int blackLightBishops = 0;
            int blackDarkBishops = 0;
            int totalKnights = 0;
            int totalBishops = 0;

            for(int row = 0; row < 8; row++)
            {
                for(int col = 0; col < 8; col++)
                {
                    if(pieces[row,col] is Rook)
                    return false;

                    if(pieces[row,col] is Queen)
                    return false;

                    if(pieces[row,col] is Pawn)
                    return false;

                    if(pieces[row,col] is Bishop)
                    {
                        totalBishops++;
                        if(pieces[row,col].Color == PieceColor.White)
                        {

                            if((row + col) % 2 == 0)
                            {
                                whiteLightBishops++;
                            }

                            if((row + col) % 2 == 1)
                            {
                                whiteDarkBishops++;
                            }
                        }

                        if(pieces[row,col].Color == PieceColor.Black)
                        {

                            if((row + col) % 2 == 0)
                            {
                                blackLightBishops++;
                            }

                            if((row + col) % 2 == 1)
                            {
                                blackDarkBishops++;
                            }
                        }
                    }

                    if(pieces[row,col] is Knight)
                    {
                        totalKnights++;
                    }

                }
            }

             if(totalBishops < 2 && totalKnights == 0)
             {
             return true;
             }

             if(totalKnights < 2 && totalBishops == 0)
             {
              return true;
             }

             if(totalBishops == 2 && totalKnights == 0 && (whiteLightBishops == 2 || blackLightBishops == 2 || whiteDarkBishops == 2 || blackDarkBishops == 2))
             {
             return true;
             }

             return false;
        }

        private bool DrawByThreefoldRepetition(Piece[,] pieces)
        {
            return true;
        }
    }
}