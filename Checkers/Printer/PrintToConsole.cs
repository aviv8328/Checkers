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
        public void PrintBoard()
        {
            throw new NotImplementedException();
        }
    }
}