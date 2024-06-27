namespace CheckersHafifa
{
    //TODO: Change board from string[,] --> Piece[,].
    public class Board // : IBoard
    {
        // TODO: magic number to user variable
        public Player[] players = new Player[2];
        private int _boardSize;
        private Piece[,] _board;
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
        private void CreateBoard()
        {
            _board = new Piece[_boardSize,_boardSize];
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

        private void PopulateBoard()
        {
            foreach (Player player in players)
            {
                ChooseRowsToPopulate(player);
            }

            // TODO: Remove print to console its testy
            PrintToConsole printToConsole = new();
            printToConsole.PrintBoardToConsole(_board);
        }

        private void ChooseRowsToPopulate(Player player)
        {
            if (player == players[0])
            {
                AlternateRowPopulating(player, 0);
            }
            else
            {
                AlternateRowPopulating(player, _board.GetLength(1) - 3);
            }
        }
        private void AlternateRowPopulating(Player player, int colIndex)
        {
            // TODO: length (3) extract to constants file as NUMBER_OF_ROWS_TO_POPULATE
            int maxColIndex = colIndex + 3;
            for (; colIndex < maxColIndex; colIndex++)
            {
                if (colIndex % 2 == 0)
                {
                    PopulateEvenRows(colIndex, player);
                }
                else
                {
                    PopulateNegativeRows(colIndex, player);
                }
            }
        }

        private void PopulateEvenRows(int currentCol, Player player)
        {
            for (int i = 1; i < _board.GetLength(0); i = i + 2)
            {
                _board[currentCol, i] = player.pieces[currentCol];
            }
        }

        private void PopulateNegativeRows(int currentCol, Player player)
        {
            for (int i = 0; i < _board.GetLength(1); i = i + 2)
            {
                _board[currentCol, i] = player.pieces[currentCol];
            }
        }

        private void InitializeGame()
        {
            CreateBoard();
            GeneratePlayers();
            PopulateBoard();
        }

        public void StartGame()
        {
            Gameplay gameplay = new();
            InitializeGame();
            gameplay.StartGame(players, _board);
        }
    }
}