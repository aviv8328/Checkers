namespace CheckersHafifa
{
    public class Checkers : IGame
    {
        private IBoard _board;
        private Player[] _players;

        public Checkers(IBoard board, Player[] players)
        {
            _board = board;
            _players = players;
        }

        public void Start()
        {
            _board.InitializeBoard(_players);
            _board.Display();

            bool isGameRunning = true;
            int currentPlayerIndex = 0;

            while (isGameRunning)
            {
                Player currentPlayer = _players[currentPlayerIndex];
                Console.WriteLine($"It's {currentPlayer.Name}'s turn.");

                // Get and process player move
                // ...

                _board.Display();
                currentPlayerIndex = (currentPlayerIndex + 1) % 2;

                // Check for end of game
                // ...
            }
        }
    }
}
