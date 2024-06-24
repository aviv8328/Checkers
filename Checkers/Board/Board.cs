namespace CheckersHafifa
{
    public class Board : IBoard
    {
        private int _boardSize;
        public Board(int boardSize)
        {
            _boardSize = boardSize;   
        }
        public Board()
        {
            ValidateGameAttributes validateGameAttributes = new();
            PrintToConsole printToConsole = new();

            printToConsole.GetBoardSize();
            _boardSize = validateGameAttributes.ReturnValidBoardSize();
        }
        public string[,] CreateBoard()
        {
            string[,] board = new string[_boardSize,_boardSize];
            return board;
        }
    }
}