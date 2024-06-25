namespace CheckersHafifa
{
    public class Gameplay()
    {
        public void StartGame(Player[] players, string[,] board)
        {
            PromptCurrentPlayer(players[0], board);
        }
        public void PromptCurrentPlayer(Player currentPlayer, string[,] board)
        {
            PrintToConsole printToConsole = new();
            ValidateTurns validateTurns = new();

            printToConsole.PrintCurrentPlayerTurnToConsole(currentPlayer);
            printToConsole.PromptPieceToMove();

            string playerMoveChoice = Console.ReadLine();

            if (validateTurns.ValidateChosenPiece(playerMoveChoice, board, currentPlayer.pieces[0].pieceColor))
            {
                printToConsole.PromptMoveForward();
                validateTurns.ValidateMoveForward(playerMoveChoice, board);
            }


        }
    }
}