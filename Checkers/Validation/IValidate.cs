namespace CheckersHafifa
{
    interface IValidate
    {
        public bool ValidateBoardSize(int boardSize);
        public bool ValidatePlayerName(string playerName);  
    }
}