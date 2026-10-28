using Chess.Core;
using Chess.Core.Pieces;
namespace Chess.Tests;

public class RookTests
{
    [Fact]
    public void Rook_CanMoveVertically()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Rook(PieceColor.White);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(6,0));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Rook>(board.GetPiece(6,0));
        Assert.Null(board.GetPiece(7,0));
        
    }

    [Fact]

    public void Rook_CanMoveHorizontally()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Rook(PieceColor.White);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(7,1));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Rook>(board.GetPiece(7,1));
        Assert.Null(board.GetPiece(7,0));
    }

    [Fact]

    public void Rook_CannotMoveDiagonally()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Rook(PieceColor.White);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(6,1));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Rook>(board.GetPiece(7,0));
        Assert.Null(board.GetPiece(6,1));
    }

    [Fact]

    public void Rook_CannotJumpOverPieces()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Rook(PieceColor.White);
        pieces[6,0] = new Pawn(PieceColor.White);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(5,0));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Rook>(board.GetPiece(7,0));
        Assert.IsType<Pawn>(board.GetPiece(6,0));
        Assert.Null(board.GetPiece(5,0));
    }

    [Fact]
    public void Rook_CanCaptureEnemyPiece()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Rook(PieceColor.White);
        pieces[6,0] = new Pawn(PieceColor.Black);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(6,0));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Rook>(board.GetPiece(6,0));
        Assert.Null(board.GetPiece(7,0));
    }

    [Fact]

    public void Rook_CannotCaptureObstructedEnemyPiece()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new Rook(PieceColor.White);
        pieces[5,0] = new Pawn(PieceColor.Black);
        pieces[6,0] = new Pawn(PieceColor.White);
        pieces[7, 7] = new King(PieceColor.White);
        pieces[0, 7] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(7,0), new Position(5,0));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Rook>(board.GetPiece(7,0));
        Assert.IsType<Pawn>(board.GetPiece(6,0));
        Assert.Equal(PieceColor.White, board.GetPiece(6,0).Color);
        Assert.IsType<Pawn>(board.GetPiece(5,0));
        Assert.Equal(PieceColor.Black, board.GetPiece(5,0).Color);
        
    }
}
