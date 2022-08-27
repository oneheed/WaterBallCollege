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
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].NameHimself($"player {i}");
                _players[i].SetCradGame(this);
            }
        }

        private void ShuffleStage()
        {
            _deck.Shuffle();
        }

        private void DrawStage()
        {
            for (int i = 0; i < _drawNumber * _players.Count; i++)
            {
                if (_deck.Any())
                {
                    var index = i % _players.Count;
                    _players[index].Hand.AddCard(_deck.DrawCard());
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
