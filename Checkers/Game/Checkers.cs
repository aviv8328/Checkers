namespace CheckersHafifa
{
    public class Checkers
    {
        public void StartGame()
        {
            Gameplay gameplay = new();
            Board board = new();
            Piece[,] gameBoard = board.InitializeGameBoard();   

            gameplay.StartGame(board.players, gameBoard);
        }
    }

}