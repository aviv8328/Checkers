namespace CheckersHafifa
{
    public class Player
    {
        public string playerName { get; }

        public List<Piece> pieces { get; }

        public Player(string name, int boardSize)
        {
            playerName = name;

            for (int i = 0; i < ReturnNumberOfPiecesInRow(boardSize); i++)
            {
                // create piece based on color
            }            

        }

        private int ReturnNumberOfPiecesInRow(int boardSize)
        {
            return (boardSize / 2) * 3;
        }
    }
}