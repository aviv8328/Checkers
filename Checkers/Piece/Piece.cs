namespace CheckersHafifa
{
    public class Piece
    {
        public string pieceColor;
        public bool isAlive;

        public Piece(string color)
        {
            pieceColor = color;
            isAlive = true;   
        }
    }
}