using Chess.Core;
using Chess.Core.Pieces;
namespace Chess.Tests;

public class QueenTests
{
    [Fact]
    public void Queen_CanMoveDiagonally()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,7] = new King(PieceColor.White);
        pieces[0,7] = new King(PieceColor.Black);
        pieces[7,5] = new Queen(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,5), new Position(6,4));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Queen>(board.GetPiece(6,4));
        Assert.Null(board.GetPiece(7,5));
    }

    [Fact]

     public void Queen_CanMoveVertically()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Queen(PieceColor.White);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(6,0));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Queen>(board.GetPiece(6,0));
        Assert.Null(board.GetPiece(7,0));
        
    }

    [Fact]

     public void Queen_CanMoveHorizontally()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Queen(PieceColor.White);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(7,1));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Queen>(board.GetPiece(7,1));
        Assert.Null(board.GetPiece(7,0));
    }

    [Fact]

    public void Queen_CannotJumpOverPieces()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Queen(PieceColor.White);
        pieces[6,0] = new Pawn(PieceColor.White);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(5,0));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Queen>(board.GetPiece(7,0));
        Assert.IsType<Pawn>(board.GetPiece(6,0));
        Assert.Null(board.GetPiece(5,0));
    }

    [Fact]

    public void Queen_CanCaptureEnemyPiece()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Queen(PieceColor.White);
        pieces[6,0] = new Pawn(PieceColor.Black);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(6,0));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Queen>(board.GetPiece(6,0));
        Assert.Null(board.GetPiece(7,0));
    }
    
    [Fact]

    public void Queen_CannotCaptureObstructedEnemyPiece()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,7] = new King(PieceColor.White);
        pieces[4,2] = new Pawn(PieceColor.Black);
        pieces[5,3] = new Pawn(PieceColor.White);
        pieces[0,7] = new King(PieceColor.Black);
        pieces[7,5] = new Queen(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,5), new Position(4,2));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Queen>(board.GetPiece(7,5));
        Assert.IsType<Pawn>(board.GetPiece(5,3));
        Assert.IsType<Pawn>(board.GetPiece(4,2));
    }
}