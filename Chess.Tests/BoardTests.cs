using Chess.Core;
using Chess.Core.Pieces;
namespace Chess.Tests;

public class BoardTests
{
    [Fact]
    public void NewBoard_HasWhitePawnsOnRow6()
    {
        //arrange
        Board board = new Board();
        for(int col = 0; col < 8; col++)
        {
            //act
            Piece whitePawn = board.GetPiece(6, col);
           
            //assert
            Assert.IsType<Pawn>(whitePawn);
            Assert.Equal(PieceColor.White, whitePawn.Color);
        }
    }

    [Fact]
     public void NewBoard_HasBlackPawnsOnRow1()
    {
        //arrange
        Board board = new Board();
        for(int col = 0; col < 8; col++)
        {
            //act
            Piece blackPawn = board.GetPiece(1, col);

            //assert
            Assert.IsType<Pawn>(blackPawn);
            Assert.Equal(PieceColor.Black, blackPawn.Color);
        }
    }

    [Fact]
    public void NewBoard_HasEmptySquaresOnMiddleRows()
    {
        //arrange
        Board board = new Board();

        for(int row = 2; row < 6; row++)
        {
           for(int col = 0; col < 8; col++)
            {
                //act
                Piece nullSquare = board.GetPiece(row,col);

                //assert
                Assert.Null(nullSquare);
            }
        }
    }

    [Fact]
    public void NewBoard_HasCorrectBackRankPieces()
    {
        //arrange
        Board board = new Board();

        Type[] expectedPieces =
        {
          typeof(Rook),
          typeof(Knight),
          typeof(Bishop),
          typeof(Queen),
          typeof(King),
          typeof(Bishop),
          typeof(Knight),
          typeof(Rook)
        };

        for(int row = 0; row < 8; row += 7)
        {
            for(int col = 0; col < 8; col++)
            {
                //act
                Piece piece = board.GetPiece(row,col);
                
                //assert
                if(row == 0)
                {
                    Assert.IsType(expectedPieces[col], piece);
                    Assert.Equal(PieceColor.Black, piece.Color);
                }

                 if(row == 7)
                {
                    Assert.IsType(expectedPieces[col], piece);
                    Assert.Equal(PieceColor.White, piece.Color);
                }
            }
        }
    }

    [Fact]
    public void NewBoard_StartsWithWhiteTurn()
    {
        //arrange and act
        Board board = new Board();


        //assert
        Assert.Equal(PieceColor.White, board.currentTurn);
    }
    
    [Fact]

    public void NewBoard_HasCorrectCastlingRights()
    {
        //arrange and act
        Board board = new Board();

        //assert
        Assert.True(board.WhiteCanCastleKingside);
        Assert.True(board.BlackCanCastleKingside);
        Assert.True(board.WhiteCanCastleQueenside);
        Assert.True(board.BlackCanCastleQueenside);
    }
}
