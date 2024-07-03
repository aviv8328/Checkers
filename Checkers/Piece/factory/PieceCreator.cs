namespace CheckersHafifa
{
    public class PieceCreator
    {
        WhitePieceFactory whitePieceFactory = new();
        BlackPieceFactory blackPieceFactory = new();
        BlankPieceFactory blankPieceFactory = new();
        Constants constants = new();
        public Piece GeneratePiece(string playerColor)
        {
            if (playerColor == constants.BLACK)
            {
                return blackPieceFactory.CreatePiece();
            }
            else if (playerColor == constants.WHITE)
            {
                return whitePieceFactory.CreatePiece();
            }
            return blankPieceFactory.CreatePiece();
        }
    }
}