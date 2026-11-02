using Chess.Core;
using Chess.Core.Pieces;

public class CheckMateAndStalemateTests
{
    [Fact]

    public void Checkmate_DetectedForBasicPosition()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,0] = new King(PieceColor.Black);
        pieces[1,1] = new Queen(PieceColor.White);
        pieces[2,2] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        
        //assert
        Assert.True(board.IsInCheck(PieceColor.Black));
        Assert.True(board.IsCheckmate(PieceColor.Black));
    }

    [Fact]

    public void Checkmate_NotDetectedWhenEscapeExists()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,0] = new King(PieceColor.White);
        pieces[1,2] = new Rook(PieceColor.Black);
        pieces[2,2] = new King(PieceColor.Black);
        pieces[1,0] = new Rook(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.White);
        
        //assert
        Assert.True(board.IsInCheck(PieceColor.White));
        Assert.False(board.IsCheckmate(PieceColor.White));
    }

    [Fact]

    public void Checkmate_NotDetectedWhenAttackerCanBeCaptured()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,0] = new King(PieceColor.Black);
        pieces[1,1] = new Queen(PieceColor.White);
        pieces[3,2] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        
        //assert
        Assert.True(board.IsInCheck(PieceColor.Black));
        Assert.False(board.IsCheckmate(PieceColor.Black));
    }

    [Fact]

    public void Checkmate_NotDetectedWhenCheckCanBeBlocked()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,0] = new King(PieceColor.White);
        pieces[0,7] = new Rook(PieceColor.Black);
        pieces[1,7] = new Rook(PieceColor.Black);
        pieces[7,1] = new Rook(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);

        //assert
        Assert.True(board.IsInCheck(PieceColor.White));
        Assert.False(board.IsCheckmate(PieceColor.White));
    }

    [Fact]

    public void Stalemate_DetectedForBasicPosition()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,0] = new King(PieceColor.Black);
        pieces[1,2] = new Queen(PieceColor.White);
        pieces[2,2] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        
        //assert
        Assert.False(board.IsInCheck(PieceColor.Black));
        Assert.True(board.IsStalemate(PieceColor.Black));
    }

    [Fact]

    public void Stalemate_NotDetectedWhenLegalMoveExists()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,0] = new King(PieceColor.Black);
        pieces[1,3] = new Queen(PieceColor.White);
        pieces[2,2] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);
        
        //assert
        Assert.False(board.IsInCheck(PieceColor.Black));
        Assert.False(board.IsStalemate(PieceColor.Black));
    }

    [Fact]

    public void  Checkmate_NotDetectedWhenPawnCanCaptureCheckingPieceAndPromote()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,0] = new King(PieceColor.Black);
        pieces[5,1] = new King(PieceColor.White);
        pieces[6,3] = new Pawn(PieceColor.Black);
        pieces[7,4] = new Rook(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);

        //assert
        Assert.True(board.IsInCheck(PieceColor.Black));
        Assert.False(board.IsCheckmate(PieceColor.Black));
    }

    [Fact]
    public void  Stalemate_NotDetectedWhenPawnCanPromote()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[6,0] = new King(PieceColor.Black);
        pieces[4,1] = new King(PieceColor.White);
        pieces[6,5] = new Pawn(PieceColor.Black);
        pieces[7,2] = new Queen(PieceColor.White);
        Board board = new Board(pieces, PieceColor.Black);

        //assert
        Assert.False(board.IsInCheck(PieceColor.Black));
        Assert.False(board.IsStalemate(PieceColor.Black));
    }
}