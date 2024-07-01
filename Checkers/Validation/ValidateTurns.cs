namespace CheckersHafifa
{
    public class ValidateTurns()
    {
        int playerCol;
        int playerRow;

        public bool ValidateChosenPiece(string playerMove, Piece[,] board, string pieceColor)
        {
            if (ValidateString(playerMove) && ValidateCurrentPlayerPiece(board, pieceColor))
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

        private bool ValidateCurrentPlayerPiece(Piece[,] board, string pieceColor)
        {
            if (board[playerRow, playerCol] is null)
            {
                return false;
            }
            return board[playerRow, playerCol].pieceColor == pieceColor;
        }

        public bool ValidateMoveForward(Piece[,] board, Player currentPlayer)
        {
            return board[playerRow + 1, playerCol] == null && playerRow + 1 < board.GetLength(0);
        }

        public bool ValidateEatLeftDiagonal(Piece[,] board, Player currentPlayer)
        {
            return ValidateDiagonalLeftRanges(board) && CheckDiagonalLeftPiece(board, currentPlayer);
        }
        
        public bool ValidateEatRightDiagonal(Piece[,] board, Player currentPlayer)
        {
            return ValidateDiagonalRightRanges(board) && CheckDiagonalRightPiece(board, currentPlayer) ;
        }

        private bool ValidateDiagonalLeftRanges(Piece[,] board)
        {
            return playerRow + 1 <= board.GetLength(0) && playerCol - 1 >= 0;
        }

        private bool CheckDiagonalLeftPiece(Piece[,] board, Player currentPlayer)
        {
            return board[playerRow + 1, playerCol - 1] != null && board[playerRow + 1, playerCol - 1].pieceColor != currentPlayer.pieces[0].pieceColor;
        }


        private bool ValidateDiagonalRightRanges(Piece[,] board)
        {
            return playerRow + 1 <= board.GetLength(0) && playerCol + 1 <= board.GetLength(1);
        }

        private bool CheckDiagonalRightPiece(Piece[,] board, Player currentPlayer)
        {
            return board[playerRow + 1, playerCol + 1] != null && board[playerRow + 1, playerCol + 1].pieceColor != currentPlayer.pieces[0].pieceColor;
        }
    }
}