using Chess.Core;
using Chess.Core.Pieces;
namespace Chess.Tests;

public class KnightTests
{
    [Fact]

    public void Knight_CanMoveInLShape()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[7,6] = new Knight(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,6), new Position(5,5));
        
        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Knight>(board.GetPiece(5,5));
        Assert.Null(board.GetPiece(7,6));
    }
    [Fact]
    public void Knight_CanJumpOverPieces()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[7,6] = new Knight(PieceColor.White);
        pieces[6,6] = new Pawn(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,6), new Position(5,5));
        
        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Knight>(board.GetPiece(5,5));
         Assert.IsType<Pawn>(board.GetPiece(6,6));
        Assert.Null(board.GetPiece(7,6));
    }

    [Fact]
    public void Knight_CannotMakeInvalidMoves()
    {
          //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[7,6] = new Knight(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,6), new Position(4,5));
        
        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Knight>(board.GetPiece(7,6));
        Assert.Null(board.GetPiece(4,5));
    }
    
    [Fact]
    public void Knight_CanCaptureEnemyPiece()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        pieces[7,6] = new Knight(PieceColor.White);
        pieces[5,5] = new Pawn(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,6), new Position(5,5));
        
        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Knight>(board.GetPiece(5,5));
        Assert.Null(board.GetPiece(7,6));
    }
}