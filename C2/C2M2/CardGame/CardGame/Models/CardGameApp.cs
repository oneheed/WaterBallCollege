namespace CardGame.Models
{
    public abstract class CardGameApp
    {
        protected int _drawNumber;

        protected Deck _deck;

        protected IList<Player> _players;

        public int Round { get; private set; } = 1;

        public Card TopCard { get; protected set; }

        protected CardGameApp(Deck deck, IList<Player> players)
        {
            this._deck = deck;

            foreach (var (player, i) in players.Select((p, i) => (p, i)))
            {
                player.SetOrder(i + 1);
                player.SetCardGame(this);
            }

            this._players = players;
        }

        public void Start()
        {
            NameHimselfStage();

            ShuffleStage();

            DrawStage();

            while (NextRound())
            {
                Console.WriteLine($"==== 回合 {Round} ====");

                TakeRound();

                Round++;
            }

            GameOver();
        }

        private void NameHimselfStage()
        {
            foreach (var player in _players)
            {
                player.NameHimself();
            }
        }

        private void ShuffleStage()
        {
            _deck.Shuffle();
        }

        private void DrawStage()
        {
            for (var i = 0; i < _drawNumber; i++)
            {
                foreach (var player in _players.Where(player => _deck.Any()))
                {
                    player.Hand.AddCard(_deck.DrawCard());
                }
            }
        }

        protected abstract bool NextRound();

        protected abstract void TakeRound();

        protected abstract Player WinnerPlayer();

        private void GameOver()
        {
            Console.WriteLine($"==== 最終 ====");
            Console.WriteLine($"最終勝利者 : {this.WinnerPlayer()?.Name}");
        }
    }
}
