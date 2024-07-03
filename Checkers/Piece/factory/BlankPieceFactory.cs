namespace CheckersHafifa
{
    public class BlankPieceFactory : IPieceFactory
    {
        public Piece CreatePiece()
        {
            return new BlankPiece();
        }
    }
}