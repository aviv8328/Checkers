namespace CheckersHafifa
{
    public class Checkers
    {
        public void StartGame()
        {
            Gameplay gameplay = new();
            Board board = new();
            board.InitializeGameBoard();   

            gameplay.StartGame(board.players, board.board);
        }
    }

}