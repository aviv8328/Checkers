using System.Reflection.Metadata;

namespace CheckersHafifa
{
    internal class Constants
    {
        Dictionary<Func<Piece[,], Player, bool>, string> pieceActions = new();
        public readonly int NUMBER_OF_USERS = 2;
        public readonly int NUMBER_OF_ROWS_TO_POPULATE = 3;
        public readonly int MINIMUM_BOARD_SIZE = 8;
        public readonly bool STARTING_PIECE_STATUS = true;
        public readonly bool DEAD_PIECE = false;
        public readonly string BLANK_PIECE_COLOR = "D";
        public readonly string WHITE = "W";
        public readonly string BLACK = "B";
    }
}