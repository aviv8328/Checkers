namespace CheckersHafifa
{
    public class ValidateTurns()
    {
        int playerCol;
        int playerRow;

        public bool ValidateChosenPiece(string playerMove, Piece[,] board, string pieceColor)
        {
            if (ValidateString(playerMove) && ValidateCurrentPlayerPiece(playerMove, board, pieceColor))
            {

                return true;
            }
            return false;
        }
        private bool ValidateString(string playerMove)
        {
            if (!playerMove.Contains(','))
            {
                return false;
            }

            ParsePlayerMoves parsePlayerMoves = new();
            playerCol = parsePlayerMoves.ParseColPlayerMove(playerMove);
            playerRow = parsePlayerMoves.ParseRowPlayerMove(playerMove);
            
            string[] playerMoveSplitted = playerMove.Split(",");
            return int.TryParse(playerMoveSplitted[0], out _) && int.TryParse(playerMoveSplitted[0], out _);
        }

        private bool ValidateCurrentPlayerPiece(string playerMove, Piece[,] board, string pieceColor)
        {
            return board[playerCol, playerRow].pieceColor == pieceColor;
        }

        public bool ValidateMoveForward(string playerMove, Piece[,] board)
        {
            return board[playerCol, playerRow + 1] == null && playerRow + 1 < board.GetLength(0);
        }

        public bool ValidateEatLeftDiagonal(string playerMove, Piece[,] board, Player currentPlayer)
        {
            return CheckDiagonalLeftPiece(playerCol, playerRow, board, currentPlayer) && ValidateDiagonalLeftRanges(board, playerCol, playerRow);
        }

        private static bool ValidateDiagonalLeftRanges(Piece[,] board, int col, int row)
        {
            return col - 1 <= board.GetLength(1) && row + 1 <= board.GetLength(0);
        }

        private bool CheckDiagonalLeftPiece(int col, int row, Piece[,] board, Player currentPlayer)
        {
            return board[col - 1, row + 1] != null || board[col - 1, row + 1].pieceColor != currentPlayer.pieces[0].pieceColor;
        }

        public bool ValidateEatRightDiagonal(string playerMove, Piece[,] board, Player currentPlayer)
        {
            return CheckDiagonalRightPiece(playerCol, playerRow, board, currentPlayer) && ValidateDiagonalRightRanges(board, playerCol, playerRow);
        }

        private static bool ValidateDiagonalRightRanges(Piece[,] board, int col, int row)
        {
            return col + 1 <= board.GetLength(1) && row + 1 <= board.GetLength(0);
        }

        private bool CheckDiagonalRightPiece(int col, int row, Piece[,] board, Player currentPlayer)
        {
            return board[col + 1, row + 1] != null || board[col + 1, row + 1].pieceColor != currentPlayer.pieces[0].pieceColor;
        }
    }
}