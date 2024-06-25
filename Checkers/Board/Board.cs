using System.IO.Compression;
using System.Runtime.ConstrainedExecution;

namespace CheckersHafifa
{
    public class Board // : IBoard
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
        private string[,] CreateBoard()
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
            // TODO: make current col dynamic
            string[,] board = CreateBoard();

            foreach (Player player in players)
            {
                ChooseRowsToPopulate(board, player);
            }

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

        private void ChooseRowsToPopulate(string[,] board, Player player)
        {
            if (player == players[0])
            {
                AlternateRowPopulating(board, player, 0);
            }
            else
            {
                AlternateRowPopulating(board, player, board.GetLength(1) - 3);
            }
        }
        private void AlternateRowPopulating(string[,] board, Player player, int colIndex)
        {
            // TODO: length (3) extract to constants file as NUMBER_OF_ROWS_TO_POPULATE
            int maxColIndex = colIndex + 3;
            for (; colIndex < maxColIndex; colIndex++)
            {
                if (colIndex % 2 == 0)
                {
                    PopulateEvenRows(colIndex, player, board);
                }
                else
                {
                    PopulateNegativeRows(colIndex, player, board);
                }
            }
        }

        private void PopulateEvenRows(int currentCol, Player player, string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i = i + 2)
            {
                board[currentCol, i] = player.pieces[currentCol].pieceColor;
            }
        }

        private void PopulateNegativeRows(int currentCol, Player player, string[,] board)
        {
            for (int i = 1; i < board.GetLength(1); i = i + 2)
            {
                board[currentCol, i] = player.pieces[currentCol].pieceColor;
            }
        }

        public void StartGame()
        {
            CreateBoard();
            GeneratePlayers();
            PopulateBoard();
        }
    }
}