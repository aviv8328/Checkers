namespace CheckersHafifa
{
    public class PieceCreator
    {
        WhitePieceFactory whitePieceFactory = new();
        BlackPieceFactory blackPieceFactory = new();
        BlankPieceFactory blankPieceFactory = new();
        public Piece GeneratePiece(string playerColor)
        {
            switch (playerColor)
            {
                case "B":
                    return blackPieceFactory.CreatePiece();
                case "W":
                    return whitePieceFactory.CreatePiece();
                default:
                    return blankPieceFactory.CreatePiece();
            }
        }
    }
}