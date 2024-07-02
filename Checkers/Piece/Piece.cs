namespace CheckersHafifa
{
    public class Piece
    {
        public string pieceColor { get; }
        public bool isAlive {get; set;}
        public Piece(bool state, string color)
        {
            isAlive = state;
            pieceColor = color;
        }
    }
}