namespace CheckersHafifa
{
    public interface IPiece
    {
        string PieceColor { get; }
        bool IsAlive { get; set; }
    }
}