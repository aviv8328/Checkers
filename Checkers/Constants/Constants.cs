using System.Reflection.Metadata;

namespace CheckersHafifa
{
    internal class Constants
    {
        ValidateTurns validateTurns = new();
        Dictionary<Func<Piece[,], Player, bool>, string> pieceActions = new();
        public readonly int NUMBER_OF_USERS = 2;
        public readonly int NUMBER_OF_ROWS_TO_POPULATE = 3;
        public readonly int MINIMUM_BOARD_SIZE = 8;
        internal Constants()
        {
            // pieceActions = new Dictionary<Func<Piece[,], Player, bool>, string>
            // {
            //     { validateTurns.ValidateMoveLeftDiagonal, "To move left press 1" },
            //     { validateTurns.ValidateMoveRightDiagonal, "To move right press 2" },
            //     { validateTurns.ValidateEatLeftDiagonal, "To move right press 3" },
            //     { validateTurns.ValidateEatRightDiagonal, "To eat right press 4"},
            // };

            // List<Action> actions = new List<Action>
            // {
            //     {() => MoveDiagonalLeft(row, col, currentPlayer)},
            //     {() => MoveDiagonalRight(row, col, currentPlayer)},
            //     {() => EatDiagonalLeft(row, col, currentPlayer)},
            //     {() => EatDiagonalRight(row, col, currentPlayer)}
            // };

        }
    }
}