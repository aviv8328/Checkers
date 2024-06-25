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