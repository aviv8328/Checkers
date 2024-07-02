using System.Globalization;

namespace CheckersHafifa
{
    public class Gameplay()
    {
        ValidateTurns validateTurns = new();
        PrintToConsole printToConsole = new();
        ParsePlayerMoves parsePlayerMoves = new();
        ValidateGameAttributes validateGameAttributes = new();
        Dictionary<int, Action> pieceActionsUponPlayerInput = new Dictionary<int, Action>();
        PieceCreator pieceCreator = new();
        private Piece[,] _firstPlayerBoard;
        private Piece[,] _secondPlayerBoard;
        private Piece[,] _board;
        bool firstPlayer = true;

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

                foreach (Player player in players)
                {
                    if (CheckWinningPlayer(_board, player))
                    {
                        printToConsole.Winner(player);
                        break;
                    }
                }


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
                ActOnPlayerMove();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ActOnPlayerMove()
        {
            if (validateTurns.ValidateActionList(pieceActionsUponPlayerInput))
            {
                int playerAction = validateGameAttributes.ReturnConsolePlayerAction();
                invokeActionUponPlayerInput(playerAction);
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

            while (!validateTurns.ValidateChosenPiece(playerMoveChoice, _board, currentPlayer.teamColor))
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
                { validateTurns.ValidateMoveLeftDiagonal, "To move left press 1" },
                { validateTurns.ValidateMoveRightDiagonal, "To move right press 2" },
                { validateTurns.ValidateEatLeftDiagonal, "To move right press 3" },
                { validateTurns.ValidateEatRightDiagonal, "To eat right press 4"},
            };

            List<Action> actions = new List<Action>
            {
                {() => MoveDiagonalLeft(row, col, currentPlayer)},
                {() => MoveDiagonalRight(row, col, currentPlayer)},
                {() => EatDiagonalLeft(row, col, currentPlayer)},
                {() => EatDiagonalRight(row, col, currentPlayer)}
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

        private void MovePiece(int row, int col, int rowOffset, int colOffset, Player currentPlayer)
        {   
            var (invertedRow, invertedCol) = InvertCoordinates(row, col);

            if (firstPlayer)
                {
                    _firstPlayerBoard[row + rowOffset, col + colOffset] = pieceCreator.GeneratePiece(currentPlayer.teamColor);
                    _firstPlayerBoard[row, col].isAlive = false;

                    _secondPlayerBoard[invertedRow - rowOffset, invertedCol - colOffset] = pieceCreator.GeneratePiece(currentPlayer.teamColor);
                    _secondPlayerBoard[invertedRow, invertedCol].isAlive = false;
                }
                else
                {
                    _secondPlayerBoard[row + rowOffset, col + colOffset] = pieceCreator.GeneratePiece(currentPlayer.teamColor);
                    _secondPlayerBoard[row, col].isAlive = false;

                    _firstPlayerBoard[invertedRow - rowOffset, invertedCol - colOffset] = pieceCreator.GeneratePiece(currentPlayer.teamColor);
                    _firstPlayerBoard[invertedRow, invertedCol].isAlive = false;
                }
            UpdateCurrentBoard();
        }

        private void killPiece(int row, int col, int rowOffset, int colOffset)
        {
            var (invertedRow, invertedCol) = InvertCoordinates(row, col);

            if (firstPlayer)
            {
                _firstPlayerBoard[row + rowOffset, col + colOffset].isAlive = false;
                _secondPlayerBoard[invertedRow - rowOffset, invertedCol - colOffset].isAlive = false;
            }
            else
            {
                _secondPlayerBoard[row + rowOffset, col + colOffset].isAlive = false;
                _firstPlayerBoard[invertedRow - rowOffset, invertedCol - colOffset].isAlive = false;
            }
        }

        private void MoveDiagonalRight(int row, int col, Player currentPlayer)
        {
            MovePiece(row, col, 1, 1, currentPlayer);
        }

        private void MoveDiagonalLeft(int row, int col, Player currentPlayer)
        {
            MovePiece(row, col, 1, -1, currentPlayer);
        }

        private void EatDiagonalLeft(int row, int col, Player currentPlayer)
        {
            string newPosition = $"{row + -2},{col + -2}";

            killPiece(row, col, -1, -1);
            MovePiece(row, col, -2, -2, currentPlayer);
            UpdateCurrentBoard();
            validateTurns.UpdateColAndRow(newPosition);
            PromptPlayerUponPieceValidActions(currentPlayer, newPosition);
            ActOnPlayerMove();
        }
  
        private void EatDiagonalRight(int row, int col, Player currentPlayer)
        {
            string newPosition = $"{row + 2},{col + 2}";

            killPiece(row, col, 1, 1);
            MovePiece(row, col, 2, 2, currentPlayer);
            UpdateCurrentBoard();
            validateTurns.UpdateColAndRow(newPosition);
            PromptPlayerUponPieceValidActions(currentPlayer, newPosition);
            ActOnPlayerMove();
        }

        private void AlternatePlayerTurns()
        {
            firstPlayer = firstPlayer == true
            ? firstPlayer = false
            : firstPlayer = true;
        }

        private bool CheckWinningPlayer(Piece[,] board, Player player)
        {
            return validateTurns.ValidateWinningPlayer(board, player.teamColor);
        }

        private void UpdateCurrentBoard()
        {
            AlternatePlayerTurns();
            SetCurrentPlayerBoard();
            printToConsole.ClearConsole();
            printToConsole.PrintBoardToConsole(_board);
        }
    }
}