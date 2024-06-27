namespace CheckersHafifa
{
    //TODO: Change board from string[,] --> Piece[,].
    public class Board : IBoard
    {
        // TODO: magic number to user variable
        public IPiece[,] board;
        private IPlayer[] _players;
        private int _boardSize;

        public Board(int boardSize)
        {
            _boardSize = boardSize;   
            board = new IPiece[boardSize, boardSize];
        }

        public void InitializeBoard(IPlayer[] players)
        {
            _players = players;
            PopulateBoard();
        }

        private void PopulateBoard()
        {
            int rowsToPopulate = (_boardSize / 2)  - 1;

            for (int i = 0; i < rowsToPopulate; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        board[i, j] = _players[0].Pieces[(i * _boardSize + j) / 2];
                        board[_boardSize - 1 - i, j] = _players[1].Pieces[(i * _boardSize + j) / 2];
                    }
                }
            }
        }

        public void Display()
        {
            PrintToConsole printToConsole = new();

            printToConsole.PrintBoardToConsole(board, _boardSize);
            
        }

        public bool MovePiece(IPlayer player, int startX, int startY, int endX, int endY)
        {
            if (ValidateMove(player, startX, startY, endX, endY))
            {
                board[endX, endY] = board[startX, startY];
                board[startX, startY] = null;
                return true;
            }
            return false;
        }

        private bool ValidateMove(IPlayer player, int startX, int startY, int endX, int endY)
        {
            // Implement move validation logic based on checkers rules
            return true;
        }
    }
}