namespace CheckersHafifa
{
    public class Piece : IPiece
    {
        public string PieceColor { get; }
        public bool IsAlive {get; set;}
        public Piece(string color)
        {
            IsAlive = true;
            PieceColor = color;
        }
    }
}