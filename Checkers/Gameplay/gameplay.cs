namespace CheckersHafifa
{
    public class Gameplay()
    {
        public void StartGame(Player[] players, string[,] board)
        {

        }
        public void PromptCurrentPlayer(Player currentPlayer)
        {
            PrintToConsole printToConsole = new();
            printToConsole.PrintCurrentPlayerTurnToConsole(currentPlayer);
            printToConsole.PromptMove();
        }
    }
}