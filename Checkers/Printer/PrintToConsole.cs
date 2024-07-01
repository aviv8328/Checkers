namespace CheckersHafifa
{
    public class PrintToConsole //: IPrinter
    {
        public void GetBoardSize()
        {
            Console.WriteLine("Enter your desired board size, size must be a positive number >= 8!");
        }

        public void PromptCurrentPlayerToConsole(Player currentPlayer)
        {
            Console.WriteLine(currentPlayer.playerName);
        }

        public void InvalidSize()
        {
            Console.WriteLine("Invalid Size! Size must be a valid positive number higher than 8!");
        }

        public void InvalidAction()
        {
            Console.WriteLine("Invalid Action! Choose a number between 1-3!");
        }
        public void PrintBoardToConsole(Piece[,] board)
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    Console.BackgroundColor = GetBackgroundColorOfSquare(r, c);
                    Console.ForegroundColor = Console.BackgroundColor == ConsoleColor.White 
                        ? ConsoleColor.Black 
                        : ConsoleColor.White;
                    
                    if (board[r,c] is null)
                    {
                       Console.Write($"         " + board[r, c] + "         "); 
                    }
                    else
                    {
                       Console.Write($"         " + board[r,c].pieceColor + "         ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public ConsoleColor GetBackgroundColorOfSquare(int row, int col)
        {
            return (row + col) % 2 == 0 ? ConsoleColor.White : ConsoleColor.Black;
        }

        public void PrintCurrentPlayerTurnToConsole(Player player)
        {
            Console.WriteLine($"It's {player.playerName} turn!");
        }

        public void PromptPieceToMove()
        {
            Console.WriteLine("Choose a piece to move in the next format: ROW,COL");
        }

        public void PromptMoveForward()
        {
            Console.WriteLine("Do you wish to move forward?");
        }

        public void PromptEatPiece()
        {
            Console.WriteLine("Eat: Left/Right/Forward");           
        }

        public void PromptInvalidInput()
        {
            Console.WriteLine("INVALID input! the format must be ROW,COL, eg. 0,0");
        }

        public void PromptExit()
        {
            Console.WriteLine("1: Exit, 2: Continue playing");
        }

        public void PromptNoValidMovesAvailable()
        {
            Console.WriteLine("No valid moves available");  
        }

        public void PrintCurrentAction(string currentAction)
        {
            Console.WriteLine(currentAction);
        }

        public void InvalidPiece()
        {
            Console.WriteLine("This is not your piece! Choose a different piece");
        }
    }
}