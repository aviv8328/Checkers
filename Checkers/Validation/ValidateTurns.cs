namespace CheckersHafifa
{
    public class ValidateTurns()
    {
        private int ParseRowPlayerMove(string playerMove)
        {
            string[] playerMoveSplitted = playerMove.Split(',');
            return int.Parse(playerMoveSplitted[0]);
        }
        private int ParseColPlayerMove(string playerMove)
        {
            string[] playerMoveSplitted = playerMove.Split(',');
            return int.Parse(playerMoveSplitted[1]);
        }

        public bool ValidateChosenPiece(int row, int col, string pieceColor, string[,] board)
        {
            return board[row, col] == pieceColor;
        }
        public bool ValidatePlayerMove(string playerMove, string[,] board)
        {
            return ValidateMoveForward(ParseColPlayerMove(playerMove), ParseRowPlayerMove(playerMove), board);
        }

        private bool ValidateMoveForward(int col, int row, string[,] board)
        {
            if ()
        }
    }
}