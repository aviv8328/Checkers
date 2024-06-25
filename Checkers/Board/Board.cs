using System.IO.Compression;

namespace CheckersHafifa
{
    public class Board : IBoard
    {
        // TODO: magic number to user variable
        public Player[] players = new Player[2];
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
            _boardSize = validateGameAttributes.ReturnValidBoardSizeConsole();
        }
        public string[,] CreateBoard()
        {
            string[,] board = new string[_boardSize,_boardSize];
            return board;
        }

        public void GeneratePlayers()
        {
            // TODO: make it dynamic
            players[0] = new Player("ju", _boardSize, "W");
            players[1] = new Player("bb", _boardSize, "B");
        }

        private void PopulateBoard()
        {
            
        }
    }
}