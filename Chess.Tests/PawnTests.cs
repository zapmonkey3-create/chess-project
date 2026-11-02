using Chess.Core;
using Chess.Core.Pieces;

public class PawnTests
{
    [Fact]
    public void Pawn_CanMoveOneSquareForward()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[6,4] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(6,4), new Position(5,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(5,4));
        Assert.Null(board.GetPiece(6,4));
    }
    
    [Fact]
    public void Pawn_CanMoveTwoSquaresInitially()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[6,4] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(6,4), new Position(4,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(4,4));
        Assert.Null(board.GetPiece(6,4));
    }

    [Fact]
    public void Pawn_CannotMoveTwoSquaresLaterOn()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[5,4] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(5,4), new Position(3,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(5,4));
        Assert.Null(board.GetPiece(3,4));
    }

    [Fact]

    public void Pawn_CanCaptureDiagonally()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[5,4] = new Pawn(PieceColor.White);
        pieces[4,3] = new Rook(PieceColor.Black);
        Move move = new Move(new Position(5,4), new Position(4,3));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(4,3));
        Assert.Equal(PieceColor.White, board.GetPiece(4,3).Color);
        Assert.Null(board.GetPiece(5,4));
    }

    [Fact]
    public void Pawn_CannotCaptureStraightAhead()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[5,4] = new Pawn(PieceColor.White);
        pieces[4,4] = new Rook(PieceColor.Black);
        Move move = new Move(new Position(5,4), new Position(4,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(5,4));
        Assert.Equal(PieceColor.White, board.GetPiece(5,4).Color);
        Assert.IsType<Rook>(board.GetPiece(4,4));
    }

    [Fact]

    public void Pawn_CannotJumpOverPieces()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[5,4] = new Pawn(PieceColor.White);
        pieces[4,4] = new Rook(PieceColor.Black);
        Move move = new Move(new Position(5,4), new Position(3,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(5,4));
        Assert.Equal(PieceColor.White, board.GetPiece(5,4).Color);
        Assert.IsType<Rook>(board.GetPiece(4,4));
        Assert.Null(board.GetPiece(3,4));
    }
    
    [Fact]
    public void Pawn_CannotCaptureDiagonallyIntoEmptySquare()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[5,4] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(5,4), new Position(4,3));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(5,4));
        Assert.Null(board.GetPiece(4,3));
    }

    [Fact]
    public void Pawn_CannotMoveBackward()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[5,4] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(5,4), new Position(6,4));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(5,4));
        Assert.Null(board.GetPiece(6,4));
    }
    
    [Fact]
    public void Pawn_CanPromoteToQueen()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[1,1] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(1,1), new Position(0,1), PromotionPiece.Queen);
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Queen>(board.GetPiece(0,1));
        Assert.Null(board.GetPiece(1,1));
    }

    [Fact]
    public void Pawn_CanPromoteToRook()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[1,1] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(1,1), new Position(0,1), PromotionPiece.Rook);
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Rook>(board.GetPiece(0,1));
        Assert.Null(board.GetPiece(1,1));
    }

    [Fact]
    public void Pawn_CanPromoteToBishop()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[1,1] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(1,1), new Position(0,1), PromotionPiece.Bishop);
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Bishop>(board.GetPiece(0,1));
        Assert.Null(board.GetPiece(1,1));
    }

    [Fact]
    public void Pawn_CanPromoteToKnight()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[1,1] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(1,1), new Position(0,1), PromotionPiece.Knight);
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Knight>(board.GetPiece(0,1));
        Assert.Null(board.GetPiece(1,1));
    }

    [Fact]

    public void Pawn_MustPromoteOnFinalRank()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[1,1] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(1,1), new Position(0,1));
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(1,1));
        Assert.Null(board.GetPiece(0,1));
    }
    
    [Fact]
    public void Pawn_CannotPromoteBeforeFinalRank()
    {
         //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[2,1] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(2,1), new Position(1,1), PromotionPiece.Queen);
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.IsType<Pawn>(board.GetPiece(2,1));
        Assert.Null(board.GetPiece(1,1));
    }

    [Fact]
    public void Pawn_PromotionPieceCannotBeInvalid()
    {
        //arrange
        Piece[,] pieces = new Piece[8,8];
        pieces[7,4] = new King(PieceColor.White);
        pieces[0,4] = new King(PieceColor.Black);
        pieces[1,1] = new Pawn(PieceColor.White);
        Move move = new Move(new Position(1,1), new Position(0,1), (PromotionPiece)999);
        Board board = new Board(pieces, PieceColor.White);

        //act
        board.MovePiece(move);

        //assert
        Assert.Null(board.GetPiece(0,1));
        Assert.IsType<Pawn>(board.GetPiece(1,1));
        Assert.Equal(PieceColor.White,board.currentTurn);
    }
}