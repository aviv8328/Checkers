namespace CheckersHafifa
{
    public interface IPlayer 
    {
        string Name { get; }
        List<IPiece> Pieces { get; }
    }
}