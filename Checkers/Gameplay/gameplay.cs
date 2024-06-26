using System.Dynamic;

namespace CheckersHafifa
{
    public class Gameplay()
    {
        public void StartGame(Player[] players, string[,] board)
        {
            PrintToConsole printToConsole = new();
            while (true)
            {
                PromptCurrentPlayer(players[0], board);
                printToConsole.PromptExit();

                int.TryParse(Console.ReadLine(), out int keepPlaying);
                if (keepPlaying == 1)
                {
                    break;   
                }
            }
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

            try
            {
                if (!validateTurns.ValidateChosenPiece(playerMoveChoice, board, currentPlayer.pieces[0].pieceColor))
                {
                    printToConsole.PromptInvalidInput();   
                }
                else if (validateTurns.ValidateMoveForward(playerMoveChoice, board))
                {
                    int col = validateTurns.ParseColPlayerMove(playerMoveChoice);
                    int row = validateTurns.ParseRowPlayerMove(playerMoveChoice);
                    // TODO: move forward validation
                    // EatDiagnalLeft(currentPlayer, board, printToConsole, col, row);
                    // EatDiagnalRight(currentPlayer, board, printToConsole, col, row);
                    // MoveForward(currentPlayer, board, printToConsole, col, row);
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
            
            board[col, row] = "";
            board[col + 1, row] = currentPlayer.pieces[0].pieceColor;
            printToConsole.PrintBoardToConsole(board);            
        }

        private void EatDiagnalLeft(Player currentPlayer, string[,] board, PrintToConsole printToConsole, int col, int row)
        {
            printToConsole.PromptEatPiece();

            board[col, row] = "";
            board[col + 2, row - 2] = currentPlayer.pieces[0].pieceColor;
            printToConsole.PrintBoardToConsole(board);
        }

        private void EatDiagnalRight(Player currentPlayer, string[,] board, PrintToConsole printToConsole, int col, int row)
        {
            printToConsole.PromptEatPiece();

            board[col, row] = "";
            board[col + 2, row + 2] = currentPlayer.pieces[0].pieceColor;
            printToConsole.PrintBoardToConsole(board);
        }
    }
}