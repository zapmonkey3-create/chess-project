
using Chess.Core.Pieces;
using System.Runtime.CompilerServices;

namespace Chess.Core
{
    public class Board
    {
        private Piece[,] pieces = new Piece[8, 8];
        public PieceColor currentTurn { get; private set; } = PieceColor.White;

        private bool whiteCanCastleKingside = true;
        private bool whiteCanCastleQueenside = true;
        private bool blackCanCastleKingside = true;
        private bool blackCanCastleQueenside = true;

        public bool WhiteCanCastleKingside => whiteCanCastleKingside;
        public bool WhiteCanCastleQueenside => whiteCanCastleQueenside;
        public bool BlackCanCastleKingside => blackCanCastleKingside;
        public bool BlackCanCastleQueenside => blackCanCastleQueenside;

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

        public bool IsLegalMove(Move move, bool showMessage)
        {
            Piece piece = GetPiece(move.From.Row, move.From.Col);
            Piece capturedPiece = GetPiece(move.To.Row, move.To.Col);

            //does a piece exist
            if (piece == null)
            {
                if (showMessage == true)
                {
                    Console.WriteLine("Please move an existing piece");
                }
                return false;
            }

            //is the piece ours
            if (piece.Color != currentTurn)
            {
                if (showMessage == true)
                {
                    Console.WriteLine("Move your own piece!");
                }
                return false;
            }

            //friendly fire prevention
            if (capturedPiece != null && capturedPiece.Color == currentTurn)
            {
                if (showMessage == true)
                {
                    Console.WriteLine("You can't capture your own piece!");
                }
                return false;
            }

            //can the piece move there
            if (!piece.CanMove(move.From, move.To, this))
            {
                if (showMessage == true)
                {
                    Console.WriteLine("Please make a legal move!");
                }
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
                if (showMessage == true)
                {
                    Console.WriteLine("That move would leave your king in check!");
                }
                return false;
            }

            if(piece is King && Math.Abs(move.From.Col - move.To.Col) == 2)
            {
        
               Position crossingPosition = new Position(move.From.Row,(move.From.Col + move.To.Col) / 2);
               pieces[move.From.Row, move.From.Col] = null;
               pieces[crossingPosition.Row, crossingPosition.Col] = piece;
               bool crossesCheck = IsInCheck(piece.Color);

              pieces[move.From.Row, move.From.Col] = piece;
              pieces[crossingPosition.Row, crossingPosition.Col] = null; 

                if(crossesCheck)
                {
                    return false;
                }
            }

            return true;
        }
        public void MovePiece(Move move)
        {
            if (IsLegalMove(move, false))
            {
                Piece piece = GetPiece(move.From.Row, move.From.Col);
                pieces[move.From.Row, move.From.Col] = null;
                pieces[move.To.Row, move.To.Col] = piece;
                int colDifference = Math.Abs(move.From.Col - move.To.Col);
                if (piece is King && colDifference == 2)
                {
                    if(move.From.Row == 7 && move.From.Col == 4)
                    {
                        if (move.From.Col > move.To.Col)
                        {
                           Piece rook = pieces[7 , 0];
                           pieces[7, 0] = null;
                           pieces[7, 3] = rook;
                        }
                        else
                        {
                           Piece rook = pieces[7 , 7];
                           pieces[7, 7] = null;
                           pieces[7, 5] = rook;
                        }
                    }
                    
                    if(move.From.Row == 0 && move.From.Col == 4)
                    {
                        if (move.From.Col > move.To.Col)
                        {
                           Piece rook = pieces[0 , 0];
                           pieces[0, 0] = null;
                           pieces[0, 3] = rook;
                        }
                        else
                        {
                           Piece rook = pieces[0 , 7];
                           pieces[0, 7] = null;
                           pieces[0, 5] = rook;
                        }
                    }
                }

                if (piece is King)
                {
                    if (piece.Color == PieceColor.White)
                    {
                        whiteCanCastleKingside = false;
                        whiteCanCastleQueenside = false;
                    }
                    else
                    {
                        blackCanCastleKingside = false;
                        blackCanCastleQueenside = false;
                    }
                }

                if (move.From.Row == 0 && move.From.Col == 0 || move.To.Row == 0 && move.To.Col == 0)
                {
                    blackCanCastleQueenside = false;
                }

                if (move.From.Row == 0 && move.From.Col == 7 || move.To.Row == 0 && move.To.Col == 7)
                {
                    blackCanCastleKingside = false;
                }

                if (move.From.Row == 7 && move.From.Col == 0 || move.To.Row == 7 && move.To.Col == 0)
                {
                    whiteCanCastleQueenside = false;
                }

                if (move.From.Row == 7 && move.From.Col == 7 || move.To.Row == 7 && move.To.Col == 7)
                {
                    whiteCanCastleKingside = false;
                }

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
            
            if (!IsInCheck(color))
            {
                return false;
            }

            //check if there is a legal move, if yes == no checkmate
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = GetPiece(row, col);
                    if (piece != null && piece.Color == color)
                    {
                        for (int destinationRow = 0; destinationRow < 8; destinationRow++)
                        {
                            for (int destinationCol = 0; destinationCol < 8; destinationCol++)
                            {
                                Move move = new Move(new Position(row, col), new Position(destinationRow, destinationCol));
                                if (IsLegalMove(move, false))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        public bool IsStalemate(PieceColor color)
        {
            if (IsInCheck(color))
            {
                return false;
            }

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = GetPiece(row, col);
                    if (piece != null && piece.Color == color)
                    {
                        for (int destinationRow = 0; destinationRow < 8; destinationRow++)
                        {
                            for (int destinationCol = 0; destinationCol < 8; destinationCol++)
                            {
                                Move move = new Move(new Position(row, col), new Position(destinationRow, destinationCol));
                                if (IsLegalMove(move, false))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}