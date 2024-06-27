namespace CheckersHafifa
{
    public interface IPlayer 
    {
        string Name { get; set; }
        List<IPiece> Pieces { get; set; }
    }
}