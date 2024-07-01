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
                var pieceActions = GetActions(currentPlayer, playerMoveChoice);

                PromptPlayerUponPieceValidActions(currentPlayer);
                int playerAction = validateGameAttributes.ReturnConsolePlayerAction();

                pieceActions[playerAction].Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

        private Dictionary<int, Action> GetActions(Player currentPlayer, string playerMoveChoice)
        {
            int col;
            int row;

            col = parsePlayerMoves.ParseColPlayerMove(playerMoveChoice);
            row = parsePlayerMoves.ParseRowPlayerMove(playerMoveChoice);

            var pieceActionsUponPlayerInput = new Dictionary<int, Action>
            {
                { 1, () => MoveForward(currentPlayer, col, row) },
                { 2, () => EatDiagnalLeft(currentPlayer, col, row)  },
                { 3, () => EatDiagnalRight(currentPlayer, col, row) }
            };

            return pieceActionsUponPlayerInput;
        }

        private void PromptPlayerUponPieceValidActions(Player currentPlayer)
        {
            // TODO: MOVE PIECE ACTIONS TO A CONST FILE

            var pieceActions = new Dictionary<Func<Piece[,], Player, bool>, string>
            {
                { validateTurns.ValidateMoveForward, "To move forward press 1" },
                { validateTurns.ValidateEatLeftDiagonal, "To eat left press 2" },
                { validateTurns.ValidateEatRightDiagonal, "To eat right press 3" },
            };

            List<String> pieceValidActions = new List<string>();

            foreach (var action in pieceActions)
            {
                if (action.Key(_board, currentPlayer))
                {
                    pieceValidActions.Add(action.Value);
                }
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

        private void MoveForward(Player currentPlayer, int col, int row)
        {            
            _board[col, row] = null;
            _board[col + 1, row] = currentPlayer.pieces[0];
            printToConsole.PrintBoardToConsole(_board);
        }

        private void EatDiagnalLeft(Player currentPlayer, int col, int row)
        {
            _board[col, row] = null;
            _board[col + 2, row - 2] = currentPlayer.pieces[0];
            printToConsole.PrintBoardToConsole(_board);
        }

        private void EatDiagnalRight(Player currentPlayer, int col, int row)
        {
            _board[col, row] = null;
            _board[col + 2, row + 2] = currentPlayer.pieces[0];
            printToConsole.PrintBoardToConsole(_board);
        }
    }
}