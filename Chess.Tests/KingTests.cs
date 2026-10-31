using Chess.Core;
using Chess.Core.Pieces;

public class KingTests
{
  
    [Fact]

    public void  King_CannotMoveMultipleSquaresNormally()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Move move = new Move(new Position(7,4), new Position(5,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(7,4));
        Assert.Null(board.GetPiece(5,4));
    }
    
    [Fact]

    public void King_CannotMoveIntoCheck()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,3] = new Queen(PieceColor.Black);
        Move move = new Move(new Position(7,4), new Position(7,3));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(7,4));
        Assert.Null(board.GetPiece(7,3));
    }

    [Fact]

    public void King_CannotCaptureProtectedPiece()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,3] = new Queen(PieceColor.Black);
        pieces[7,3] = new Knight(PieceColor.Black);
        Move move = new Move(new Position(7,4), new Position(7,3));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(7,4));
        Assert.IsType<Knight>(board.GetPiece(7,3));
    }

    [Fact]
    public void King_CanCaptureUnprotectedPiece()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[7,3] = new Knight(PieceColor.Black);
        Move move = new Move(new Position(7,4), new Position(7,3));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(7,3));
        Assert.Null(board.GetPiece(7,4));
    }

    [Fact]

    public void King_CanMoveDiagonally()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Move move = new Move(new Position(7,4), new Position(6,3));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(6,3));
        Assert.Null(board.GetPiece(7,4));
    }
    
    [Fact]
    public void King_CanMoveHorizontally()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Move move = new Move(new Position(7,4), new Position(7,3));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(7,3));
        Assert.Null(board.GetPiece(7,4));
    }

    [Fact]
    public void King_CannotMoveNextToEnemyKing()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[5,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Move move = new Move(new Position(7,4), new Position(6,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(7,4));
        Assert.Null(board.GetPiece(6,4));
    }

    [Fact]
    public void King_CanMoveVertically()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Move move = new Move(new Position(7,4), new Position(6,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<King>(board.GetPiece(6,4));
        Assert.Null(board.GetPiece(7,4));
    }

}