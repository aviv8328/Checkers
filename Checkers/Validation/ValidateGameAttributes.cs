using System;
using System.Runtime.InteropServices;

namespace CheckersHafifa
{
    public class ValidateGameAttributes : IValidate
    {
        PrintToConsole printToConsole = new();
        private int GetConsoleBoardSize()
        {
            int boardSize;

            while (!int.TryParse(Console.ReadLine(), out boardSize))
            {
                printToConsole.InvalidSize();
            };

            return boardSize;
        }
        public bool ValidateBoardSize(int boardSize)
        {
            if (boardSize % 2 == 0 && boardSize >= 8)
            {
                return true;
            }
            else
            {
                printToConsole.InvalidSize();
                return false;
            }
        }

        private int GetConsolePlayerAction()
        {
            int playerAction;

            while (!int.TryParse(Console.ReadLine(), out playerAction))
            {
                printToConsole.InvalidAction();
            };

            return playerAction;
        }

        public int ReturnConsolePlayerAction()
        {
            int playerAction;
            
            do
            {
                playerAction = GetConsolePlayerAction();
            }
            while (!ValidatePlayerAction(playerAction));

            return playerAction;
        }
        public bool ValidatePlayerAction(int playerAction)
        {
            // TODO: Dynamic action validation (if he can only move forward then we need to check only on 3!)
            if (playerAction == 1 || playerAction == 2 || playerAction == 3)
            {
                return true;
            }
            else
            {
                printToConsole.InvalidAction();
                return false;
            }
        }

        public int ReturnValidBoardSizeConsole()
        {
            int boardSize;
            
            do
            {
                boardSize = GetConsoleBoardSize();
            }
            while (!ValidateBoardSize(boardSize));

            return boardSize;
        }
        public bool ValidatePlayerName(string playerName)
        {
            throw new NotImplementedException();
        }
    }
}