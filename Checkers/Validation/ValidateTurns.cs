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
            if (board[playerRow + 1, playerCol] is null)
            {
                return false;
            }

            return  board[playerRow + 1, playerCol].pieceColor != currentPlayer.pieces[0].pieceColor && ValidateMoveForwardRanges(board);
        }

        private bool ValidateMoveForwardRanges(Piece[,] board)
        {
            return playerRow + 2 < board.GetLength(0);
        }

        public bool ValidateEatLeftDiagonal(Piece[,] board, Player currentPlayer)
        {
            return ValidateDiagonalLeftRanges(board) && CheckDiagonalLeftPiece(board);
        }

        public bool ValidateEatRightDiagonal(Piece[,] board, Player currentPlayer)
        {
            return ValidateDiagonalRightRanges(board) && CheckDiagonalRightPiece(board) ;
        }

        private bool ValidateDiagonalLeftRanges(Piece[,] board)
        {
            return playerRow + 1 <= board.GetLength(0) && playerCol - 1 >= 0;
        }

        private bool CheckDiagonalLeftPiece(Piece[,] board)
        {
            return board[playerRow + 1, playerCol - 1] is null;
        }


        private bool ValidateDiagonalRightRanges(Piece[,] board)
        {
            return playerRow + 1 <= board.GetLength(0) && playerCol + 1 <= board.GetLength(1);
        }

        private bool CheckDiagonalRightPiece(Piece[,] board)
        {
            return board[playerRow + 1, playerCol + 1] is null;
        }
    }
}