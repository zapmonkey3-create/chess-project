using Chess.Core;
using Chess.Core.Pieces;
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
            for (int i = 0; i < 99; i++)
            {
                System.Console.WriteLine("Move From:");
                int[] coordinates = System.Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
                Position from = new Position(coordinates[0], coordinates[1]);
                System.Console.WriteLine("Move To:");
                coordinates = System.Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
                Position to = new Position(coordinates[0], coordinates[1]);

                Move move = new Move(from, to);
                System.Console.WriteLine($"Current turn: {board.currentTurn}");
                board.MovePiece(move);
                Position king = board.FindKing(board.currentTurn);
                System.Console.WriteLine($"King at: Row {king.Row}, Col {king.Col}");
                System.Console.WriteLine($"King in check: {board.IsInCheck(board.currentTurn)}");
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
                System.Console.WriteLine($"Current turn: {board.currentTurn}");
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
