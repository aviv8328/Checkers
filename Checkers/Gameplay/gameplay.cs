namespace CheckersHafifa
{
    public class Gameplay()
    {
        bool firstPlayer = true;
        ValidateTurns validateTurns = new();
        PrintToConsole printToConsole = new();
        ParsePlayerMoves parsePlayerMoves = new();
        Piece[,] _board;
        ValidateGameAttributes validateGameAttributes = new();
        Dictionary<int, Action> pieceActionsUponPlayerInput = new Dictionary<int, Action>();

        public void StartGame(Player[] players, Piece[,] board)
        {
            _board = board;
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
                printToConsole.PrintBoardToConsole(_board);
            }
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
        private string GetPlayerPiece(Player currentPlayer)
        {
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
                {() => MoveForward(currentPlayer, row, col)},
                {() => MoveDiagnalLeft(currentPlayer, row, col)},
                {() => MoveDiagnalRight(currentPlayer, row, col)}
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

        private void MoveForward(Player currentPlayer, int row, int col)
        {            
            _board[row, col] = null;
            _board[row + 2, col] = currentPlayer.pieces[0];
            printToConsole.PrintBoardToConsole(_board);
        }

        private void MoveDiagnalLeft(Player currentPlayer, int row, int col)
        {
            _board[row, col] = null;
            _board[row + 1, col - 1] = currentPlayer.pieces[0];
            printToConsole.PrintBoardToConsole(_board);
            firstPlayer = false;
        }

        private void MoveDiagnalRight(Player currentPlayer, int row, int col)
        {
            _board[row, col] = null;
            _board[row + 1, col + 1] = currentPlayer.pieces[0];
            printToConsole.PrintBoardToConsole(_board);
            firstPlayer = false;
        }
    }
}