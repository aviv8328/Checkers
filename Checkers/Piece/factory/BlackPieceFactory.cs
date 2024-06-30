namespace CheckersHafifa
{
    public class BlackPieceFactory : IPieceFactory
    {
        public Piece CreatePiece()
        {
            return new BlackPiece();
        }
    }
}