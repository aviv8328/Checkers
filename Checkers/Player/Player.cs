namespace CheckersHafifa
{
    public class Player
    {
        public string playerName { get; }

        public List<Piece> pieces { get; }

        public Player(string name)
        {
            playerName = name;   
        }
    }
}