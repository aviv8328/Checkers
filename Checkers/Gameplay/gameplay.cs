using System.Dynamic;

namespace CheckersHafifa
{
    public class Gameplay()
    {
        bool firstPlayer = true;
        ValidateTurns validateTurns = new();
        PrintToConsole printToConsole = new();
        ParsePlayerMoves parsePlayerMoves = new();

        ValidateGameAttributes validateGameAttributes = new();

        public void StartGame(Player[] players, Piece[,] board)
        {
            while (true)
            {
                Player currentPlayer = ReturnCurrentPlayer(players);
                PrintToConsole printToConsole = new();
                printToConsole.PromptCurrentPlayerToConsole(currentPlayer);
                printToConsole.PromptPieceToMove();

                PromptCurrentPlayer(board, currentPlayer);
                int.TryParse(Console.ReadLine(), out int keepPlaying);
                if (keepPlaying == 1)
                {
                    break;   
                }
                printToConsole.PromptExit();
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
        public void PromptCurrentPlayer(Piece[,] board, Player currentPlayer)
        {
            //TODO :
            // Get user input in different ways rather than console.readline
            // Place parse row + col in different file


            string playerMoveChoice = Console.ReadLine();

            try
            {
                if (!validateTurns.ValidateChosenPiece(playerMoveChoice, board, currentPlayer.pieces[0].pieceColor))
                {
                    printToConsole.PromptInvalidInput();
                }

                var pieceActions = GetActions(board, currentPlayer, playerMoveChoice);

                PromptPlayerUponPieceValidActions(board, currentPlayer);

                int playerAction = validateGameAttributes.ReturnConsolePlayerAction();

                pieceActions[playerAction].Invoke();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private Dictionary<int, Action> GetActions(Piece[,] board, Player currentPlayer, string playerMoveChoice)
        {
            int col;
            int row;

            col = parsePlayerMoves.ParseColPlayerMove(playerMoveChoice);
            row = parsePlayerMoves.ParseRowPlayerMove(playerMoveChoice);

            var pieceActionsUponPlayerInput = new Dictionary<int, Action>
            {
                { 1, () => MoveForward(currentPlayer, board, col, row) },
                { 2, () => EatDiagnalLeft(currentPlayer, board, col, row)  },
                { 3, () => EatDiagnalRight(currentPlayer, board, col, row) }
            };

            return pieceActionsUponPlayerInput;
        }

        private void PromptPlayerUponPieceValidActions(Piece[,] board, Player currentPlayer)
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
                if (action.Key(board, currentPlayer))
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

        private void MoveForward(Player currentPlayer, Piece[,] board, int col, int row)
        {
            printToConsole.PromptMoveForward();
            
            board[col, row] = null;
            board[col + 1, row] = currentPlayer.pieces[0];
            printToConsole.PrintBoardToConsole(board);            
        }

        private void EatDiagnalLeft(Player currentPlayer, Piece[,] board, int col, int row)
        {
            printToConsole.PromptEatPiece();

            board[col, row] = null;
            board[col + 2, row - 2] = currentPlayer.pieces[0];
            printToConsole.PrintBoardToConsole(board);
        }

        private void EatDiagnalRight(Player currentPlayer, Piece[,] board, int col, int row)
        {
            printToConsole.PromptEatPiece();

            board[col, row] = null;
            board[col + 2, row + 2] = currentPlayer.pieces[0];
            printToConsole.PrintBoardToConsole(board);
        }
    }
}