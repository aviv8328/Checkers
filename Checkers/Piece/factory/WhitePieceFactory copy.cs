namespace CheckersHafifa
{
    public class WhitePieceFactory : IPieceFactory
    {
        public Piece CreatePiece()
        {
            return new WhitePiece();
        }
    }
}