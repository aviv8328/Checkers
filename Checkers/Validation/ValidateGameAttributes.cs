using System;
using System.Runtime.InteropServices;

namespace CheckersHafifa
{
    public class ValidateGameAttributes : IValidate
    {
        PrintToConsole printToConsole = new();
        private int GetBoardSize()
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

        public int ReturnValidBoardSize()
        {
            int boardSize;
            
            do
            {
                boardSize = GetBoardSize();
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