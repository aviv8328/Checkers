using System.Dynamic;

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
            //TODO :
            // Get user input in different ways rather than console.readline
            // Place parse row + col in different file

            PrintToConsole printToConsole = new();
            ValidateTurns validateTurns = new();

            printToConsole.PrintCurrentPlayerTurnToConsole(currentPlayer);
            printToConsole.PromptPieceToMove();

            string playerMoveChoice = Console.ReadLine();
            int col = validateTurns.ParseColPlayerMove(playerMoveChoice);
            int row = validateTurns.ParseRowPlayerMove(playerMoveChoice);

            try
            {
                if (!validateTurns.ValidateChosenPiece(playerMoveChoice, board, currentPlayer.pieces[0].pieceColor));
                if (validateTurns.ValidateMoveForward(playerMoveChoice, board))
                {
                    MoveForward(currentPlayer, board, printToConsole, col, row);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        private void MoveForward(Player currentPlayer, string[,] board, PrintToConsole printToConsole, int col, int row)
        {
            printToConsole.PromptMoveForward();
            {
                board[col, row] = "";
                board[col + 1, row] = currentPlayer.pieces[0].pieceColor;
                printToConsole.PrintBoardToConsole(board);
            }
        }
    }
}