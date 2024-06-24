namespace CheckersHafifa
{
    public class Piece
    {
        public string pieceColor { get; }
        public bool isAlive; { get; set; }

        public Piece(string color)
        {
            pieceColor = color;
            isAlive = true;   
        }
    }
}