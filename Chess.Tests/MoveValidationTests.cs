using Chess.Core;
using Chess.Core.Pieces;
namespace Chess.Tests;

public class MoveValidationTests
{
    [Fact]

    public void EmptyStartingSquare_CannotMove()
    {
        //arrange
        Board board = new Board();
        Move move = new Move(new Position(4,4), new Position(5,4));
        //act
        board.MovePiece(move);

        //assert
        Assert.Null(board.GetPiece(4,4));
        Assert.Null(board.GetPiece(5,4));
    }

    [Fact]

    public void LegalMove_UpdatesBoard()
    {
        //arrange
        Board board = new Board();
        Move move = new Move(new Position(6,4), new Position(5,4));

        //act
        board.MovePiece(move);

        //assert
        Assert.Null(board.GetPiece(6,4));
        Assert.IsType<Pawn>(board.GetPiece(5,4));
    }

    [Fact]
    public void LegalWhiteMove_SwitchesTurnToBlack()
    {
        //arrange
        Board board = new Board();
        Move move = new Move(new Position(6,4), new Position(4,4));

        //act
        board.MovePiece(move);

        //assert 
        Assert.Equal(PieceColor.Black, board.currentTurn);
    }

    [Fact]
     public void LegalBlackMove_SwitchesTurnToWhite()
    {
        //arrange
        Board board = new Board();
        Move move1 = new Move(new Position(6,4), new Position(4,4));
        Move move2 = new Move(new Position(1,4), new Position(3,4));

        //act
        board.MovePiece(move1);
        board.MovePiece(move2);

        //assert 
        Assert.Equal(PieceColor.White, board.currentTurn);
    }

    [Fact]

    public void IllegalMove_DoesNotSwitchTurn()
    {
        //arrange
        Board board = new Board();
        Move move = new Move(new Position(6,4), new Position(7,4));

        //act
        board.MovePiece(move);

        //assert
        Assert.Equal(PieceColor.White, board.currentTurn);
    }

    [Fact]

    public void IllegalMove_DoesNotUpdateBoard()
    {
        //arrange
        Board board = new Board();
        Move move = new Move(new Position(6,4), new Position(7,4));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(6,4));
        Assert.IsType<King>(board.GetPiece(7,4));
    }

    [Fact]

    public void CannotMoveOpponentsPiece()
    {
       //arrange
        Board board = new Board();
        Move move = new Move(new Position(1,4), new Position(3,4));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(1,4));
    }

    [Fact]
    public void CannotCaptureOwnPiece()
    {
        //arrange
        Board board = new Board();
        Move move = new Move(new Position(7,0), new Position(6,0));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(6,0));
        Assert.IsType<Rook>(board.GetPiece(7,0));
        Assert.Equal(PieceColor.White, board.currentTurn);
    }

    [Fact]
    public void CannotCaptureKing()
    {
        //arrange
        Piece[,] pieces = new Piece[8, 8];
        pieces[0, 7] = new King(PieceColor.Black);
        pieces[0, 0] = new Rook(PieceColor.White);
        pieces[7, 7] = new King(PieceColor.White);

        Board board = new Board(pieces, PieceColor.White);
        Move move = new Move(new Position(0, 0), new Position(0, 7));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Rook>(board.GetPiece(0, 0));
        Assert.IsType<King>(board.GetPiece(0, 7));
    }

    [Fact]
    public void OutOfBoundsMove_IsRejected()
    {
        //arrange
        Board board = new Board();
        Move move = new Move(new Position(7,0), new Position(8,0));

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Rook>(board.GetPiece(7,0));
        Assert.Equal(PieceColor.White,board.currentTurn);
    }

    [Fact]
    public void NullMove_IsRejected()
    {
        //arrange
        Board board = new Board();

        //assert
        Assert.False(board.IsLegalMove(null, showMessage: false));

    }
}