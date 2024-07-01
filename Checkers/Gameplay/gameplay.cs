namespace CheckersHafifa
{
    public class Gameplay()
    {
        bool firstPlayer = true;
        ValidateTurns validateTurns = new();
        PrintToConsole printToConsole = new();
        ParsePlayerMoves parsePlayerMoves = new();
        private Piece[,] _firstPlayerBoard;
        private Piece[,] _secondPlayerBoard;
        private Piece[,] _board;
        ValidateGameAttributes validateGameAttributes = new();
        Dictionary<int, Action> pieceActionsUponPlayerInput = new Dictionary<int, Action>();


        public void StartGame(Player[] players, Piece[,] board)
        {
            _firstPlayerBoard = board;
            CreateSecondInvertedBoard();

            PrintToConsole printToConsole = new();
            while (true)
            {
                Player currentPlayer = ReturnCurrentPlayer(players);
                printToConsole.PromptCurrentPlayerToConsole(currentPlayer);

                PromptCurrentPlayer(currentPlayer);

                printToConsole.PromptExit();
                int.TryParse(Console.ReadLine(), out int keepPlaying);
                if (keepPlaying == 1)
                {
                    break;   
                }
            }
        }

        private void CreateSecondInvertedBoard()
        {
            int numberOfRows = _firstPlayerBoard.GetLength(0);
            int numberOfColumns = _firstPlayerBoard.GetLength(1);
            Piece[,] secondBoard = new Piece[numberOfRows, numberOfColumns];

            for (int r = 0; r < numberOfRows; r++)
            {
                for (int c = 0; c < numberOfColumns; c++)
                {
                    secondBoard[numberOfRows - 1 - r, numberOfColumns - 1 - c] = _firstPlayerBoard[r, c];
                }
            }

            _secondPlayerBoard = secondBoard;
        }

        private Player ReturnCurrentPlayer(Player[] players)
        {
            if (firstPlayer)
            {
                return players[0];
            }
            else
            {
                return players[1];
            }
        }
  
        public void PromptCurrentPlayer(Player currentPlayer)
        {
            //TODO :
            // Get user input in different ways rather than console.readline
            // Place parse row + col in different file

            try
            {
                string playerMoveChoice = GetPlayerPiece(currentPlayer);
                
                PromptPlayerUponPieceValidActions(currentPlayer, playerMoveChoice);

                if (validateTurns.ValidateActionList(pieceActionsUponPlayerInput))
                {
                    int playerAction = validateGameAttributes.ReturnConsolePlayerAction();
                    invokeActionUponPlayerInput(playerAction);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void invokeActionUponPlayerInput(int playerAction)
        {
            if (pieceActionsUponPlayerInput.ContainsKey(playerAction - 1))
            {
                pieceActionsUponPlayerInput[playerAction - 1].Invoke();
            }
            else
            {
                printToConsole.PromptNoValidMovesAvailable();
            }
        }

        private void SetCurrentPlayerBoard()
        {
            _board = firstPlayer == true
            ? _board = _firstPlayerBoard
            : _board = _secondPlayerBoard;
        }
        private string GetPlayerPiece(Player currentPlayer)
        {
            if (_board is null)
            {
                SetCurrentPlayerBoard();
            }

            printToConsole.PromptPieceToMove();
            string playerMoveChoice = Console.ReadLine();

            while (!validateTurns.ValidateChosenPiece(playerMoveChoice, _board, currentPlayer.pieces[0].pieceColor))
            {
                printToConsole.InvalidPiece();
                playerMoveChoice = Console.ReadLine();
            }

            return playerMoveChoice;
        }

        private void GetActions(int actionIndex, Action action)
        {
            pieceActionsUponPlayerInput.Add(actionIndex, action);
        }

        private void PromptPlayerUponPieceValidActions(Player currentPlayer, string playerMoveChoice)
        {
            // TODO: MOVE PIECE ACTIONS TO A CONST FILE
            // FIND A MORE DYNAMIC WAY TO CREATE THE LIST AND DICTIONARIES
            pieceActionsUponPlayerInput.Clear();

            int row;
            int col;

            row = parsePlayerMoves.ParseRowPlayerMove(playerMoveChoice);
            col = parsePlayerMoves.ParseColPlayerMove(playerMoveChoice);

            var pieceActions = new Dictionary<Func<Piece[,], Player, bool>, string>
            {
                { validateTurns.ValidateMoveForward, "To eat press 1" },
                { validateTurns.ValidateEatLeftDiagonal, "To move left press 2" },
                { validateTurns.ValidateEatRightDiagonal, "To move right press 3" },
            };

            List<Action> actions = new List<Action>
            {
                {() => MoveForward(row, col)},
                {() => MoveDiagnalLeft(row, col)},
                {() => MoveDiagnalRight(row, col)}
            };

            List<String> pieceValidActions = new List<string>();

            int actionIndex = 0;
            foreach (var action in pieceActions)
            {
                if (action.Key(_board, currentPlayer))
                {
                    GetActions(actionIndex, actions[actionIndex]);
                    pieceValidActions.Add(action.Value);
                }
                actionIndex++;
            }

            if (pieceValidActions.Count == 0)
            {
                printToConsole.PromptNoValidMovesAvailable();
            }
            else
            {
                foreach (var action in pieceValidActions)
                {
                    printToConsole.PrintCurrentAction(action);
                }
            }
        }

        private (int, int) InvertCoordinates(int row, int col)
        {
            return (_board.GetLength(0) - 1 - row, _board.GetLength(1) - 1 - col);
        }
        private void MoveForward(int row, int col)
        {            

            var (invertedRow, invertedCol) = InvertCoordinates(row, col);
            var (newInvertedRow, newInvertedCol) = InvertCoordinates(row + 2, col);

            _firstPlayerBoard[row + 2, col] = _firstPlayerBoard[row, col];
            _firstPlayerBoard[row, col] = null;

            _secondPlayerBoard[newInvertedRow, newInvertedCol] = _secondPlayerBoard[row, col];
            _secondPlayerBoard[invertedRow, invertedCol] = null;

            UpdateCurrentBoard();
            printToConsole.PrintBoardToConsole(_board);
        }

        private void MoveDiagnalRight(int row, int col)
        {
            var (invertedRow, invertedCol) = InvertCoordinates(row, col);

            int placeHolder;

            if (!firstPlayer)
            {
                placeHolder = invertedRow;
                invertedRow = row;
                row = placeHolder;

                placeHolder = invertedCol;
                invertedCol = col;
                col = placeHolder;   
            }

            _firstPlayerBoard[row + 1, col + 1] = _firstPlayerBoard[row, col];
            _firstPlayerBoard[row, col] = null;

            _secondPlayerBoard[invertedRow - 1, invertedCol - 1] = _secondPlayerBoard[invertedRow, invertedCol];
            _secondPlayerBoard[invertedRow, invertedCol] = null;

            UpdateCurrentBoard();
            printToConsole.PrintBoardToConsole(_board);
        }

        private void MoveDiagnalLeft(int row, int col)
        {
            Console.WriteLine("we here");
            // TODO: SRP TO REMOVE REDUNDANT CODE
            var (invertedRow, invertedCol) = InvertCoordinates(row, col);

            int placeHolder;
            
            if (!firstPlayer)
            {
                placeHolder = invertedRow;
                invertedRow = row;
                row = placeHolder;

                placeHolder = invertedCol;
                invertedCol = col;
                col = placeHolder;   
            }

            _firstPlayerBoard[row + 1, col - 1] = _firstPlayerBoard[row, col];
            _firstPlayerBoard[row, col] = null;

            _secondPlayerBoard[invertedRow - 1, invertedCol + 1] = _secondPlayerBoard[invertedRow, invertedCol];
            _secondPlayerBoard[invertedRow, invertedCol] = null;
            
            UpdateCurrentBoard();

            printToConsole.PrintBoardToConsole(_board);
        }

        private void AlternatePlayerTurns()
        {
            firstPlayer = firstPlayer == true
            ? firstPlayer = false
            : firstPlayer = true;
        }

        private void UpdateCurrentBoard()
        {
            AlternatePlayerTurns();
            SetCurrentPlayerBoard();
        }
    }
}