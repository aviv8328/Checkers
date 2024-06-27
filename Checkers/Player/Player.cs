namespace CheckersHafifa
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public List<IPiece> Pieces { get; set; } = new List<IPiece>(); 

        public Player(string name, int numOfPieces, IPieceFactory pieceFactory )
        {
            Name = name;

            for (int i = 0; i < numOfPieces; i++)
            {
                Pieces.Add(pieceFactory.CreatePiece());
            }            

        }
    }
}