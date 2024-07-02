namespace CheckersHafifa
{
    public class Player
    {
        public string playerName { get; }
        public readonly string teamColor;

        public Player(string name, int boardSize, string pieceColor)
        {
            playerName = name;
            teamColor = pieceColor;
        }
    }
}