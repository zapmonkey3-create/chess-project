
using Chess.Core.Pieces;
using System.Runtime.CompilerServices;

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

        public bool IsLegalMove(Move move)
        {
            Piece piece = GetPiece(move.From.Row, move.From.Col);
            Piece capturedPiece = GetPiece(move.To.Row, move.To.Col);
            //does a piece exist
            if (piece == null)
            {
                Console.WriteLine("Please move an existing piece");
                return false;
            }

            //is the piece ours
            if (piece.Color != currentTurn)
            {
                Console.WriteLine("Move your own piece!");
                return false;
            }

            //friendly fire prevention
            if (capturedPiece != null && capturedPiece.Color == currentTurn)
            {
                Console.WriteLine("You can't capture your own piece!");
                return false;
            }

            //can the piece move there
            if (!piece.CanMove(move.From, move.To, this))
            {
                Console.WriteLine("Please make a legal move!");
                return false;
            }

            //temporary move
            pieces[move.From.Row, move.From.Col] = null;
            pieces[move.To.Row, move.To.Col] = piece;

            //check validity
            bool leavesKingInCheck = IsInCheck(piece.Color);

            //undo temporary move
            pieces[move.From.Row, move.From.Col] = piece;
            pieces[move.To.Row, move.To.Col] = capturedPiece;

            if(leavesKingInCheck)
            {
                Console.WriteLine("That move would leave your king in check!");
                return false;
            }

            return true;
        }
        public void MovePiece(Move move)
        {
            if (IsLegalMove(move))
            {
                Piece piece = GetPiece(move.From.Row, move.From.Col);
                pieces[move.From.Row, move.From.Col] = null;
                pieces[move.To.Row, move.To.Col] = piece;
                SwitchTurn();
            }    
        }
        public Position FindKing(PieceColor color)
        {
           
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = GetPiece(row, col);
                    if (piece != null && piece is King && piece.Color == color)
                    {
                        Position position = new Position(row, col);
                        return position;
                    }
                }
            }
            throw new InvalidOperationException("There is no king!");
        }
        public bool IsInCheck(PieceColor color)
        {
            Position kingPosition = FindKing(color);
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = GetPiece(row, col);
                    Position from = new Position(row, col);
                    if (piece != null && color != piece.Color)
                    {
                        if (piece.CanMove(from, kingPosition, this))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool IsCheckmate(PieceColor color)
        {
            
            return false;
        }

    }
}