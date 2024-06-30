namespace CheckersHafifa
{
    public class ValidateTurns()
    {

        public bool ValidateChosenPiece(string playerMove, Piece[,] board, string pieceColor)
        {
            return ValidateString(playerMove) && ValidateCurrentPlayerPiece(playerMove, board, pieceColor);
        }
        private bool ValidateString(string playerMove)
        {
            if (!playerMove.Contains(','))
            {
                return false;
            }
            string[] playerMoveSplitted = playerMove.Split(",");
            return int.TryParse(playerMoveSplitted[0], out _) && int.TryParse(playerMoveSplitted[0], out _);
        }

        private bool ValidateCurrentPlayerPiece(string playerMove, Piece[,] board, string pieceColor)
        {
            return board[ParseColPlayerMove(playerMove), ParseRowPlayerMove(playerMove)].pieceColor == pieceColor;
        }

        public bool ValidateMoveForward(string playerMove, Piece[,] board)
        {
            int col = ParseColPlayerMove(playerMove);
            int row = ParseRowPlayerMove(playerMove);

            return board[col + 1, row] == null && col + 1 < board.GetLength(1);
        }

        public bool ValidateEatLeftDiagonal(string playerMove, Piece[,] board, Player currentPlayer)
        {
            int col = ParseColPlayerMove(playerMove);
            int row = ParseRowPlayerMove(playerMove);

            return CheckDiagonalLeftPiece(col, row, board, currentPlayer) && ValidateRanges(board, col, row);
        }

        private static bool ValidateRanges(Piece[,] board, int col, int row)
        {
            return col - 1 <= board.GetLength(1) && row + 1 <= board.GetLength(0);
        }

        private bool CheckDiagonalLeftPiece(int col, int row, Piece[,] board, Player currentPlayer)
        {
            return board[col - 1, row + 1] != null || board[col - 1, row + 1].pieceColor != currentPlayer.pieces[0].pieceColor;
        }

        // public bool ValidateEatRightDiagonal(string playerMove, Piece[,] board)
        // {
        //     int col = ParseColPlayerMove(playerMove);
        //     int row = ParseRowPlayerMove(playerMove);

        //     return board[col + 1, row] == null && col + 1 < board.GetLength(1);
        // }


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


    }
}