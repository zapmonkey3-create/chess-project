using Chess.Core;
using Chess.Core.Pieces;

public class SpecialMoves
{
    [Fact]
    public void King_CanCastleKingside()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[7,7] = new Rook(PieceColor.White);
        Move move = new Move(new Position(7,4), new Position(7,6));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(7,6));
        Assert.IsType<Rook>(board.GetPiece(7,5));
    }

    [Fact]
    public void King_CanCastleQueenside()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,0] = new Rook(PieceColor.Black);
        Move move = new Move(new Position(0,4), new Position(0,2));
        Board board = new Board(pieces, PieceColor.Black);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(0,2));
        Assert.IsType<Rook>(board.GetPiece(0,3));
    }

    [Fact]
    public void Castling_FailsWhenKingHasMoved()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[6,4] = new King(PieceColor.White);
        pieces[7,7] = new Rook(PieceColor.White);
        Move move1 = new Move(new Position(6,4), new Position(7,4));
        Move move2 = new Move(new Position(7,4), new Position(7,6));
        Move move3 = new Move(new Position(0,4), new Position(1,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move1);
        board.MovePiece(move3);
        board.MovePiece(move2);

        //assert
        Assert.IsType<King>(board.GetPiece(7,4));
        Assert.IsType<Rook>(board.GetPiece(7,7));
    }

    [Fact]
    public void Castling_FailsWhenRookHasMoved()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[1,0] = new Rook(PieceColor.Black);
        Move move1 = new Move(new Position(1,0), new Position(0,0));
        Move move2 = new Move(new Position(0,4), new Position(0,2));
        Move move3 = new Move(new Position(7,4), new Position(6,4));
        Board board = new Board(pieces, PieceColor.Black);

        //act
        board.MovePiece(move1);
        board.MovePiece(move3);
        board.MovePiece(move2);

        //assert
        Assert.IsType<King>(board.GetPiece(0,4));
        Assert.IsType<Rook>(board.GetPiece(0,0));
    }

    [Fact]

    public void Castling_FailsThroughAttackedSquare()
    {
          //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[7,7] = new Rook(PieceColor.White);
        pieces[0,5] = new Rook(PieceColor.Black);
        Move move = new Move(new Position(7,4), new Position(7,6));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(7,4));
        Assert.IsType<Rook>(board.GetPiece(7,7));
    }

    [Fact]
    public void Castling_FailsWhenKingIsInCheck()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,0] = new Rook(PieceColor.Black);
        pieces[6,4] = new Rook(PieceColor.White);
        Move move = new Move(new Position(0,4), new Position(0,2));
        Board board = new Board(pieces, PieceColor.Black);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(0,4));
        Assert.IsType<Rook>(board.GetPiece(0,0));
    }

    [Fact]
    public void Castling_FailsWhenPathIsBlocked()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[7,5] = new Knight(PieceColor.White);
        pieces[7,7] = new Rook(PieceColor.White);
        Move move = new Move(new Position(7,4), new Position(7,6));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(7,4));
        Assert.IsType<Rook>(board.GetPiece(7,7));
    }

    [Fact]
    public void Castling_FailsWhenCastlingIntoCheck()
    {
          //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,0] = new Rook(PieceColor.Black);
        pieces[7,2] = new Rook(PieceColor.White);
        Move move = new Move(new Position(0,4), new Position(0,2));
        Board board = new Board(pieces, PieceColor.Black);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(0,4));
        Assert.IsType<Rook>(board.GetPiece(0,0));
    }

    [Fact]
    public void Castling_KingSideAndQueenSideRightsAreIndependent()
    {
           //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[1,0] = new Rook(PieceColor.Black);
        pieces[0,7] = new Rook(PieceColor.Black);
        Move move1 = new Move(new Position(1,0), new Position(0,0));
        Move move2 = new Move(new Position(0,4), new Position(0,2));
        Move move3 = new Move(new Position(7,4), new Position(6,4));
        Move move4 = new Move(new Position(0,4), new Position(0,6));
        Board board = new Board(pieces, PieceColor.Black);

        //act
        board.MovePiece(move1);
        board.MovePiece(move2);
        board.MovePiece(move3);
        board.MovePiece(move4);

        //assert
        Assert.IsType<King>(board.GetPiece(0,6));
        Assert.IsType<Rook>(board.GetPiece(0,5));
    }

     [Fact]
    public void EnPassant_CanCaptureCorrectPawn()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[1,5] = new Pawn(PieceColor.Black);
        pieces[3,4] = new Pawn(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        Move move1 = new Move(new Position(1,5),new Position(3,5));
        Move move2 = new Move(new Position(3,4),new Position(2,5));

        //act
        board.MovePiece(move1);
        board.MovePiece(move2);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(2,5));
        Assert.Null(board.GetPiece(3,4));
    }

    [Fact]
    public void EnPassant_OnlyAvailableImmediately()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[1,5] = new Pawn(PieceColor.Black);
        pieces[3,4] = new Pawn(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        Move move1 = new Move(new Position(1,5),new Position(3,5));
        Move move2 = new Move(new Position(7,4), new Position(6,4));
        Move move3 = new Move(new Position(0,4), new Position(1,4));
        Move move4 = new Move(new Position(3,4),new Position(2,5));

        //act
        board.MovePiece(move1);
        board.MovePiece(move2);
        board.MovePiece(move3);
        board.MovePiece(move4);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(3,5));
        Assert.Equal(PieceColor.Black, board.GetPiece(3,5).Color);
        Assert.IsType<Pawn>(board.GetPiece(3,4));
        Assert.Equal(PieceColor.White, board.GetPiece(3,4).Color);    
    }

    [Fact]
    public void EnPassant_RequiresCorrectTargetPosition()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[1,5] = new Pawn(PieceColor.Black);
        pieces[3,4] = new Pawn(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        Move move1 = new Move(new Position(1,5),new Position(3,5));
        Move move2 = new Move(new Position(3,4),new Position(1,5));

        //act
        board.MovePiece(move1);
        board.MovePiece(move2);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(3,5));
        Assert.Equal(PieceColor.Black, board.GetPiece(3,5).Color);
        Assert.IsType<Pawn>(board.GetPiece(3,4));
        Assert.Equal(PieceColor.White, board.GetPiece(3,4).Color);    
    }

    [Fact]
    public void EnPassant_RequiresCorrectPawnPosition()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[1,5] = new Pawn(PieceColor.Black);
        pieces[2,4] = new Pawn(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        Move move1 = new Move(new Position(1,5),new Position(3,5));
        Move move2 = new Move(new Position(2,4),new Position(2,5));

        //act
        board.MovePiece(move1);
        board.MovePiece(move2);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(3,5));
        Assert.Equal(PieceColor.Black, board.GetPiece(3,5).Color);
        Assert.IsType<Pawn>(board.GetPiece(2,4));
        Assert.Equal(PieceColor.White, board.GetPiece(2,4).Color);
        Assert.Null(board.GetPiece(2,5));
    }

    [Fact]
    public void EnPassant_CannotExposeOwnKing()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[1,5] = new Pawn(PieceColor.Black);
        pieces[1,4] = new Rook(PieceColor.Black);
        pieces[3,4] = new Pawn(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        Move move1 = new Move(new Position(1,5),new Position(3,5));
        Move move2 = new Move(new Position(3,4),new Position(2,5));

        //act
        board.MovePiece(move1);
        board.MovePiece(move2);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(3,5));
        Assert.Equal(PieceColor.Black, board.GetPiece(3,5).Color);
        Assert.IsType<Pawn>(board.GetPiece(3,4));
        Assert.Equal(PieceColor.White, board.GetPiece(3,4).Color);
        Assert.Null(board.GetPiece(2,5));
    }

}
