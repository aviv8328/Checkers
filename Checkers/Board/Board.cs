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
            return new string[_boardSize,_boardSize];
        }


        // TODO: Create 2 equal boards one for the black and one for the white side

        // private string[,] CreateBlackBoard()
        // {
        //     return new string[_boardSize,_boardSize];
        // }
        // private string[,] CreateWhiteBoard()
        // {
        //     return new string[_boardSize,_boardSize];
        // }
        
        public void GeneratePlayers()
        {
            // TODO: make it dynamic
            players[0] = new Player("ju", _boardSize, "W");
            players[1] = new Player("bb", _boardSize, "B");
        }

        private string[,] PopulateBoard()
        {
            // TODO: make current col dynamic
            string[,] board = CreateBoard();

            foreach (Player player in players)
            {
                ChooseRowsToPopulate(board, player);
            }

            // TODO: Remove print to console its testy
            PrintToConsole printToConsole = new();
            printToConsole.PrintBoardToConsole(board);

            return board;       
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
            for (int i = 1; i < board.GetLength(0); i = i + 2)
            {
                board[currentCol, i] = player.pieces[currentCol].pieceColor;
            }
        }

        private void PopulateNegativeRows(int currentCol, Player player, string[,] board)
        {
            for (int i = 0; i < board.GetLength(1); i = i + 2)
            {
                board[currentCol, i] = player.pieces[currentCol].pieceColor;
            }
        }

        private string[,] InitializeGame()
        {
            CreateBoard();
            GeneratePlayers();
            return PopulateBoard();
        }

        public void StartGame()
        {
            Gameplay gameplay = new();
            gameplay.StartGame(players, InitializeGame());
        }
    }
}