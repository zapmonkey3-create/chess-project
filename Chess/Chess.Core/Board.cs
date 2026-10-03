
using Chess.Core.Pieces;

namespace Chess.Core
{
    public class Board
    {
        private Piece[,] pieces = new Piece[8, 8];
        public PieceColor currentTurn { get; private set; } = PieceColor.White;
        private void SetupBackRank(int row, PieceColor color)
        {
            pieces[row, 0] = new Rook(color);
            pieces[row, 1] = new Knight(color);
            pieces[row, 2] = new Bishop(color);
            pieces[row, 3] = new Queen(color);
            pieces[row, 4] = new King(color);
            pieces[row, 5] = new Bishop(color);
            pieces[row, 6] = new Knight(color);
            pieces[row, 7] = new Rook(color);
        }

        private void SetupPawns(int row, PieceColor color)
        {
            for (int i = 0; i < 8; i++)
            {
                pieces[row, i] = new Pawn(color);
            }
        }
        public Board()
        {
            SetupBackRank(0, PieceColor.Black);
            SetupPawns(1, PieceColor.Black);
            SetupPawns(6, PieceColor.White);
            SetupBackRank(7, PieceColor.White);

        }
        public Piece GetPiece(int row, int col)
        {
            return pieces[row, col];
        }
        private Piece GetCapturedPiece(Position position)
        {
            Piece piece = GetPiece(position.Row, position.Col);
            if (piece != null)
            {
                if (piece.Color != currentTurn)
                {
                    return piece;
                }
              
            }

           piece = null;
           return piece;
    
        }
        private void SwitchTurn()
        {
            if (currentTurn == PieceColor.White)
            {
                currentTurn = PieceColor.Black;
            }
            else
            {
                currentTurn = PieceColor.White;
            }
        }
        public void MovePiece(Move move)
        {
            Piece piece = GetPiece(move.From.Row, move.From.Col);
            
            if (piece == null)
            {
                Console.WriteLine("Please move an existing piece");
            }
            else
            {
                if (piece.Color == currentTurn)
                {
                    Piece capturedPiece = GetCapturedPiece(move.To);
                   
                    if (piece.CanMove(move.From, move.To, this))
                    {
                        if (capturedPiece != null)
                        {
                            Console.WriteLine($"Captured piece: {capturedPiece.Color} {capturedPiece.GetType().Name}");
                        }
                        pieces[move.From.Row, move.From.Col] = null;
                        pieces[move.To.Row, move.To.Col] = piece;
                        SwitchTurn();
                    }
                    else
                    {
                        Console.WriteLine("Please make a legal move!");
                    }
                    
                }
                else
                {
                    Console.WriteLine("It's the opponent's turn!");
                }
            }      
        }
    }
}