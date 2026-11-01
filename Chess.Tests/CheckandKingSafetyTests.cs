using Chess.Core;
using Chess.Core.Pieces;

public class CheckandKingSafetyTests()
{
    [Fact]
    public void IsInCheck_DetectsRookCheck()
    {
        //arrange & act
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[1,4] = new Rook(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);

        //assert
        Assert.True(board.IsInCheck(PieceColor.White));
    }

    [Fact]
     public void IsInCheck_DetectsBishopCheck()
    {
        //arrange & act
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[3,0] = new Bishop(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);

        //assert
        Assert.True(board.IsInCheck(PieceColor.White));
    }

    [Fact]
    public void IsInCheck_DetectsQueenCheck()
    {
        //arrange & act
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[3,0] = new Queen(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);

        //assert
        Assert.True(board.IsInCheck(PieceColor.White));
    }

    [Fact]
    public void IsInCheck_DetectsKnightCheck()
    {
        //arrange & act
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[5,3] = new Knight(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);

        //assert
        Assert.True(board.IsInCheck(PieceColor.White));
    }

    [Fact]
    public void IsInCheck_DetectsPawnCheck()
    {
         //arrange & act
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[6,3] = new Pawn(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);

        //assert
        Assert.True(board.IsInCheck(PieceColor.White));
    }

    [Fact]
    public void IsInCheck_DetectsAttackFromPinnedPiece()
    {
        //arrange & act
        Piece[,] pieces = new Piece[8,8];
        pieces[0,0] = new King(PieceColor.White);
        pieces[1,1] = new Rook(PieceColor.White);
        pieces[4,4] = new Bishop(PieceColor.Black);
        pieces[1,4] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.Black);

        //assert
        Assert.True(board.IsInCheck(PieceColor.Black));
    }

    [Fact] 
    public void IsInCheck_ReturnsFalseWhenKingIsNotAttacked()
    {
        //arrange & act
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[7,4] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);

        //assert
        Assert.False(board.IsInCheck(PieceColor.White));
    }

    [Fact]

    public void IsInCheck_ReturnsFalseWhenRookAttackIsBlocked()
    {
       //arrange & act
        Piece[,] pieces = new Piece[8,8];
        pieces[0,4] = new King(PieceColor.Black);
        pieces[1,4] = new Rook(PieceColor.Black);
        pieces[2,4] = new Rook(PieceColor.White);
        pieces[7,4] = new King(PieceColor.White);
        Board board = new Board(pieces, PieceColor.White);

        //assert
        Assert.False(board.IsInCheck(PieceColor.White));
    }

    [Fact]

    public void IsInCheck_DetectsDiscoveredCheckAfterBlockingPieceMoves()
    {
       //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[0,0] = new King(PieceColor.White);
        pieces[1,1] = new Rook(PieceColor.Black);
        pieces[4,4] = new Bishop(PieceColor.Black);
        pieces[1,4] = new King(PieceColor.Black);
        Board board = new Board(pieces, PieceColor.Black);
        Move move = new Move(new Position(1,1), new Position(2,1));

        //act
        board.MovePiece(move);

        //assert
        Assert.True(board.IsInCheck(PieceColor.White));
    }
}