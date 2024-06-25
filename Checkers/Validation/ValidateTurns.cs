namespace CheckersHafifa
{
    public class ValidateTurns()
    {

        public bool ValidateChosenPiece(string playerMove, string[,] board, string currentPlayerColor)
        {
            return ValidateString(playerMove) && board[ParseColPlayerMove(playerMove), ParseRowPlayerMove(playerMove)] == currentPlayerColor;
        }
        private bool ValidateString(string playerMove)
        {
            string[] playerMoveSplitted = playerMove.Split(",");
            return int.TryParse(playerMoveSplitted[0], out _) && int.TryParse(playerMoveSplitted[0], out _);
        }
        // TODO: Parse row/col dynamically instead of redundant code
        public int ParseRowPlayerMove(string playerMove)
        {
            PrintToConsole printToConsole = new();
            string[] playerMoveSplitted = playerMove.Split(',');
            
            if (int.TryParse(playerMoveSplitted[0], out int row))
            {
                return row;
            }
            else
            {
                printToConsole.PromptInvalidInput();    
                return -1;
            }
        }
        public int ParseColPlayerMove(string playerMove)
        {
            PrintToConsole printToConsole = new();
            string[] playerMoveSplitted = playerMove.Split(',');
            
            if (int.TryParse(playerMoveSplitted[1], out int col))
            {
                return col;
            }
            else
            {
                printToConsole.PromptInvalidInput();    
                return -1;
            }
        }

        public bool ValidateMoveForward(string playerMove, string[,] board)
        {
            int col = ParseColPlayerMove(playerMove);
            int row = ParseRowPlayerMove(playerMove);

            return board[col + 1, row] == null && col + 1 < board.GetLength(1);
        }

    }
}