using Chess.Core;
using Chess.Core.Pieces;
namespace Chess.Tests;

public class BishopTests
{

    [Fact]
    public void Bishop_CanMoveDiagonally()
    {
       //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,7] = new King(PieceColor.White);
        pieces[0,7] = new King(PieceColor.Black);
        pieces[7,5] = new Bishop(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,5), new Position(6,4));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Bishop>(board.GetPiece(6,4));
        Assert.Null(board.GetPiece(7,5));
    }

    [Fact]
    public void Bishop_CannotJumpOverPieces()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,7] = new King(PieceColor.White);
        pieces[6,4] = new Pawn(PieceColor.White);
        pieces[0,7] = new King(PieceColor.Black);
        pieces[7,5] = new Bishop(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,5), new Position(5,3));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(6,4));
        Assert.IsType<Bishop>(board.GetPiece(7,5));
        Assert.Null(board.GetPiece(5,3));
    }

    [Fact]

    public void Bishop_CannotMoveHorizontally()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,7] = new King(PieceColor.White);
        pieces[0,7] = new King(PieceColor.Black);
        pieces[7,5] = new Bishop(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,5), new Position(7,4));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Bishop>(board.GetPiece(7,5));
        Assert.Null(board.GetPiece(7,4));
    }

    [Fact]

    public void Bishop_CannotMoveVertically()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,7] = new King(PieceColor.White);
        pieces[0,7] = new King(PieceColor.Black);
        pieces[7,5] = new Bishop(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,5), new Position(6,5));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Bishop>(board.GetPiece(7,5));
        Assert.Null(board.GetPiece(6,5));
    }

    [Fact]

    public void Bishop_CanCaptureEnemyPiece()
    {
           //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,7] = new King(PieceColor.White);
        pieces[4,2] = new Pawn(PieceColor.Black);
        pieces[0,7] = new King(PieceColor.Black);
        pieces[7,5] = new Bishop(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,5), new Position(4,2));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Bishop>(board.GetPiece(4,2));
        Assert.Null(board.GetPiece(7,5));
    }

    [Fact]

    public void Bishop_CannotCaptureObstructedEnemyPiece()
    {
            //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,7] = new King(PieceColor.White);
        pieces[4,2] = new Pawn(PieceColor.Black);
        pieces[5,3] = new Pawn(PieceColor.White);
        pieces[0,7] = new King(PieceColor.Black);
        pieces[7,5] = new Bishop(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,5), new Position(4,2));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Bishop>(board.GetPiece(7,5));
        Assert.IsType<Pawn>(board.GetPiece(5,3));
        Assert.IsType<Pawn>(board.GetPiece(4,2));
    }
}