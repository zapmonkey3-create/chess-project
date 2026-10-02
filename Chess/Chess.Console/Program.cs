using Chess.Core;
using System;
namespace Chess.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = board.GetPiece(row, col);

                    if (piece == null)
                    {
                        System.Console.Write(".");
                    }
                    else
                    {
                        System.Console.Write(GetPieceSymbol(piece));
                    }
                }

                System.Console.WriteLine();
            }
        }

        static char GetPieceSymbol(Piece piece)
        {
            char symbol = piece.Type switch
            {
                PieceType.Rook => 'R',
                PieceType.Knight => 'N',
                PieceType.Bishop => 'B',
                PieceType.Queen => 'Q',
                PieceType.King => 'K',
                PieceType.Pawn => 'P',
            };

            if (piece.Color == PieceColor.Black)
            {
                symbol = char.ToLower(symbol);
            }

            return symbol;
        }
    }
}
