namespace CheckersHafifa
{
    public class Board : IBoard
    {
        Constants constants = new();
        public Player[] players = new Player[2];
        private int _boardSize;
        public Piece[,] board;
        private PieceCreator pieceCreator = new();
        private PrintToConsole printToConsole = new();
        public Board(int boardSize, Player[] userPlayers)
        {
            _boardSize = boardSize;
            players = userPlayers;
        }
        public Board()
        {
            ValidateGameAttributes validateGameAttributes = new();
            PrintToConsole printToConsole = new();

            printToConsole.GetBoardSize();
            _boardSize = validateGameAttributes.ReturnValidBoardSizeConsole();
        }
        public void CreateBoard()
        {
            board = new Piece[_boardSize,_boardSize];
        }
        
        public void GeneratePlayers()
        {

            players[0] = new Player(GetPlayerAttributes(1), constants.WHITE);
            players[1] = new Player(GetPlayerAttributes(2), constants.BLACK);
        }

        private string GetPlayerAttributes(int currentPlayer)
        {
            printToConsole.GetPlayerName(currentPlayer);
            return Console.ReadLine();
        }

        private void PopulateBoard()
        {
            foreach (Player player in players)
            {
                ChooseRowsToPopulate(player);
            }

            PopulateBlankCells();
            printToConsole.PrintBoardToConsole(board);
        }

        private void PopulateBlankCells()
        {
            int boardRowLength = board.GetLength(0);
            int boardColLength = board.GetLength(1);

            for (int row = 0; row < boardRowLength; row++)
            {
                for (int col = 0; col < boardColLength; col++)
                {
                    if (board[row, col] == null)
                    {
                        board[row, col] = pieceCreator.GeneratePiece("");
                    }
                }
            }
        }

        private void ChooseRowsToPopulate(Player player)
        {
            if (player == players[0])
            {
                AlternateRowPopulating(player, 0);
            }
            else
            {
                AlternateRowPopulating(player, board.GetLength(1) - constants.NUMBER_OF_ROWS_TO_POPULATE);
            }
        }
        private void AlternateRowPopulating(Player player, int rowIndex)
        {
            int maxRowIndex = rowIndex + 3;
            for (; rowIndex < maxRowIndex; rowIndex++)
            {
                if (rowIndex % 2 == 0)
                {
                    PopulateEvenRows(rowIndex, player);
                }
                else
                {
                    PopulateNegativeRows(rowIndex, player);
                }
            }
        }

        private void PopulateEvenRows(int currentRow, Player player)
        {
            for (int i = 0; i < board.GetLength(0); i = i + 2)
            {
                board[currentRow, i] = pieceCreator.GeneratePiece(player.teamColor);
            }
        }

        private void PopulateNegativeRows(int currentRow, Player player)
        {
            for (int i = 1; i < board.GetLength(1); i = i + 2)
            {
                board[currentRow, i] = pieceCreator.GeneratePiece(player.teamColor);
            }
        }

        public void InitializeGameBoard()
        {
            CreateBoard();
            GeneratePlayers();
            PopulateBoard();
        }
    }
}