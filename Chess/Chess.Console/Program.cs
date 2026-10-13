using Chess.Core;
using Chess.Core.Pieces;
using System;
using System.Linq;
namespace Chess.Console
{
   internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            DrawBoard(board);

            for (int i = 0; i < 99; i++)
            {
                System.Console.WriteLine("Move From:");
                int[] coordinates = System.Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
                Position from = new Position(coordinates[0], coordinates[1]);
                System.Console.WriteLine("Move To:");
                coordinates = System.Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
                Position to = new Position(coordinates[0], coordinates[1]);

                Move move = new Move(from, to);
                
                board.MovePiece(move);
                Position king = board.FindKing(board.currentTurn);
                System.Console.WriteLine($"King at: Row {king.Row}, Col {king.Col}");
                System.Console.WriteLine($"King in check: {board.IsInCheck(board.currentTurn)}");

                DrawBoard(board);

                if (board.IsCheckmate(board.currentTurn))
                {
                    System.Console.WriteLine("Checkmate!");
                    return;
                }
                
                if (board.IsStalemate(board.currentTurn))
                {
                    System.Console.WriteLine("Stalemate!");
                    return;
                }
                System.Console.WriteLine($"Current turn: {board.currentTurn}");
            }
        }

        static void DrawBoard(Board board)
        {
            ConsoleColor originalForeground = System.Console.ForegroundColor;
            ConsoleColor originalBackground = System.Console.BackgroundColor;

            try
            {
                System.Console.WriteLine("    0  1  2  3  4  5  6  7");
                for (int row = 0; row < 8; row++)
                {
                    System.Console.Write($" {0 + row} ");
                    for (int col = 0; col < 8; col++)
                    {
                        Piece piece = board.GetPiece(row, col);
                        System.Console.BackgroundColor = (row + col) % 2 == 0
                            ? ConsoleColor.DarkGreen
                            : ConsoleColor.DarkGray;
                        System.Console.ForegroundColor = piece?.Color == PieceColor.Black
                            ? ConsoleColor.Yellow
                            : ConsoleColor.White;
                        System.Console.Write($" {(piece == null ? ' ' : GetPieceSymbol(piece))} ");
                        System.Console.ResetColor();
                    }

                    System.Console.WriteLine($" {0 + row} ");
                }
                System.Console.WriteLine("    0  1  2  3  4  5  6  7");
            }
            finally
            {
                System.Console.ForegroundColor = originalForeground;
                System.Console.BackgroundColor = originalBackground;
            }
        }
           
        static char GetPieceSymbol(Piece piece)
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
    }
}