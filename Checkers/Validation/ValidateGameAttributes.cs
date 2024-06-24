namespace CheckersHafifa
{
    public class ValidateGameAttributes : IValidate
    {
        public bool ValidateBoardSize(int boardSize)
        {
            return boardSize % 2 == 0 && boardSize > 8;
        }

        public bool ValidatePlayerName(string playerName)
        {
            throw new NotImplementedException();
        }
    }
}