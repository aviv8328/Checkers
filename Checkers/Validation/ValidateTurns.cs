namespace CheckersHafifa
{
    public class ValidateTurns()
    {
        private int ParseRowPlayerMove(string playerMove)
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
        private int ParseColPlayerMove(string playerMove)
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

        public bool ValidateChosenPiece(string playerMove, string[,] board, string currentPlayerColor)
        {
            return ValidateString(playerMove) && board[ParseColPlayerMove(playerMove), ParseRowPlayerMove(playerMove)] == currentPlayerColor;
        }

        private bool ValidateString(string playerMove)
        {
            string[] playerMoveSplitted = playerMove.Split(",");
            return int.TryParse(playerMoveSplitted[0], out _) && int.TryParse(playerMoveSplitted[0], out _);
        }
        // public bool ValidatePlayerMove(string playerMove, string[,] board)
        // {
        //     return ValidateMoveForward(ParseColPlayerMove(playerMove), ParseRowPlayerMove(playerMove), board);
        // }

        // private bool ValidateMoveForward(int col, int row, string[,] board)
        // {
        //     if ()
        // }
    }
}