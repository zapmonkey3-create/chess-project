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
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        pieces[7,5] = new Bishop(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
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
        pieces[7, 7] = new King(PieceColor.White);
        pieces[6,4] = new Pawn(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        pieces[7,5] = new Bishop(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        Move move = new Move(new Position(7,5), new Position(5,3));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(6,4));
        Assert.IsType<Bishop>(board.GetPiece(7,5));
        Assert.Null(board.GetPiece(5,3));
    }
}