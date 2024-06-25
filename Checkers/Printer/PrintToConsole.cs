namespace CheckersHafifa
{
    public class PrintToConsole : IPrinter
    {
        public void GetBoardSize()
        {
            Console.WriteLine("Enter your desired board size, size must be a positive number >= 8!");
        }

        public void InvalidSize()
        {
            Console.WriteLine("Invalid Size! Size must be a valid positive number higher than 8!");
        }
        public void PrintBoardToConsole(string[,] board)
        {
            Console.WriteLine("Matrix:");
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    Console.WriteLine($"cell: {r},{c}: {board[r,c]}");
                }
                Console.WriteLine();
            }
        }
    }
}