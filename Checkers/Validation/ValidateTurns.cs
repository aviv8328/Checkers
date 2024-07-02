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

        public void UpdateColAndRow(string playerMove)
        {
            ValidateString(playerMove);
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
            if (board[playerRow, playerCol].isAlive == false)
            {
                return false;
            }
            return board[playerRow, playerCol].pieceColor == pieceColor;
        }

        public bool ValidateMoveLeftDiagonal(Piece[,] board, Player currentPlayer)
        {
            if (!ValidateDiagonalLeftRanges(board, 1))
            {
                return false;
            }
            else
            {
                return CheckDiagonalLeftPiece(board, 1);
            }
        }
        public bool ValidateEatLeftDiagonal(Piece[,] board, Player currentPlayer)
        {
            return ValidateDiagonalLeftRanges(board, 2) && CheckEatDiagonalLeft(board, 2, currentPlayer) && CheckDiagonalLeftPiece(board, 2);
        }
        private bool CheckEatDiagonalLeft(Piece[,] board, int rowAndColOffset, Player currentPlayer)
        {   
            if (board[playerRow + rowAndColOffset - 1, playerCol - rowAndColOffset + 1].isAlive == false)
            {
                return false;
            }
            if (board[playerRow + rowAndColOffset - 1, playerCol - rowAndColOffset + 1].pieceColor == currentPlayer.teamColor)
            {
                return false;
            }

            return true;
        }

        private bool ValidateDiagonalLeftRanges(Piece[,] board, int rowAndColOffset)
        {
            return playerRow + rowAndColOffset < board.GetLength(0) && playerCol - rowAndColOffset >= 0;
        }

        private bool CheckDiagonalLeftPiece(Piece[,] board, int rowAndColOffset )
        {
            return board[playerRow + rowAndColOffset, playerCol - rowAndColOffset].isAlive == false;
        }

        public bool ValidateMoveRightDiagonal(Piece[,] board, Player currentPlayer)
        {
            if (!ValidateDiagonalRightRanges(board, 1))
            {
                return false;
            }
            else 
            {
                return CheckDiagonalRightPiece(board, 1);
            }
        }
        public bool ValidateEatRightDiagonal(Piece[,] board, Player currentPlayer)
        {
            return ValidateDiagonalRightRanges(board, 2) && CheckEatDiagonalRight(board, 2, currentPlayer) && CheckDiagonalRightPiece(board, 2);
        }

        private bool ValidateDiagonalRightRanges(Piece[,] board, int rowAndColOffset)
        {
            return playerRow + rowAndColOffset < board.GetLength(0) && playerCol + rowAndColOffset < board.GetLength(1);
        }

        private bool CheckDiagonalRightPiece(Piece[,] board, int rowAndColOffset)
        {
            return board[playerRow + rowAndColOffset, playerCol + rowAndColOffset].isAlive == false;
        }

        private bool CheckEatDiagonalRight(Piece[,] board, int rowAndColOffset, Player currentPlayer)
        {   
            if (board[playerRow + rowAndColOffset - 1, playerCol + rowAndColOffset - 1].isAlive == false)
            {
                return false;
            }
            if (board[playerRow + rowAndColOffset - 1, playerCol + rowAndColOffset - 1].pieceColor == currentPlayer.teamColor)
            {
                return false;
            }

            return true;
        }

        public bool ValidateActionList(Dictionary<int, Action> pieceActionsUponPlayerInput)
        {
            return pieceActionsUponPlayerInput.Count > 0;
        }

        // public bool ValidatePieceAction

        // public bool ValidateIfQueen(Piece[,] board)
        // {

        // }

        public bool ValidateWinningPlayer(Piece[,] board, string teamColor)
        {
            int rowLength = board.GetLength(0);
            int colLength = board.GetLength(1);

            return ValidateWinningPlayer(board, rowLength, colLength, teamColor);
        }

        private bool ValidateWinningPlayer(Piece[,] board, int rowLength, int colLength, string teamColor)
        {
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    if (board[row, col].pieceColor != teamColor)
                    {
                        return false;
                    }

                    else if (board[row, col].isAlive == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool ValidateExit(PrintToConsole printToConsole)
        {
            printToConsole.PromptExit();
            
            int.TryParse(Console.ReadLine(), out int keepPlaying);
            if (keepPlaying == 1)
            {
                return true;
            }

            return false;
        }
    }
}