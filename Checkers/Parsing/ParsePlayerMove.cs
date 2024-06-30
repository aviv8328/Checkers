namespace CheckersHafifa
{
    public class ParsePlayerMoves
    {
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
    }
}