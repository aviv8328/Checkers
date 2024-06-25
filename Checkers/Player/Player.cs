namespace CheckersHafifa
{
    public class Player
    {
        public string playerName { get; }

        public List<Piece> pieces { get; }

        public Player(string name, int boardSize, string pieceColor)
        {
            playerName = name;

            for (int i = 0; i < ReturnNumberOfPiecesInRow(boardSize); i++)
            {
                GeneratePiecesBasedOnColor(pieceColor);
            }            

        }

        private void GeneratePiecesBasedOnColor(string pieceColor)
        {
            if (pieceColor == "B")
            {
                BlackPieceFactory blackPieceFactory = new();
                pieces.Add(blackPieceFactory.CreatePiece());
            }
            else
            {
                WhitePieceFactory whitePieceFactory = new();
                whitePieceFactory.CreatePiece();
            }
        }

        private int ReturnNumberOfPiecesInRow(int boardSize)
        {
            return (boardSize / 2) * 3;
        }
    }
}