using Big2.Models;

namespace Big2
{
    public class Big2Game
    {
        private int _drawNumber = 13;

        private Deck _deck;

        private IList<Player> _players;

        private bool _nextRound = true;


        public int Round { get; private set; } = 1;

        public Card TopCard { get; protected set; }

        public Big2Game(Deck deck, IList<Player> players)
        {
            this._deck = deck;
            this._players = players;
        }

        public void Start()
        {
            NameHimselfStage();

            ShuffleStage();

            DrawStage();

            while (this._nextRound)
            {
                Console.WriteLine($"新的回合開始了。");

                TakeRound();

                Round++;
            }

            GameOver();
        }

        private void NameHimselfStage()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].SetIndex(i);
                _players[i].NameHimself("test");
                _players[i].SetGame(this);
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

        private void TakeRound()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                var player = _players[i];

                Console.WriteLine($"輪到{player.Name}了");

                var cards = player.Play();
                player.Hand.RemoveCard(cards);

                Console.WriteLine($"玩家 {player.Name} 打出了 {cards}");
            }
        }

        private Player? WinnerPlayer()
        {
            return this._players.SingleOrDefault(p => p.Hand.Count == 0);
        }

        private void GameOver()
        {
            Console.WriteLine($"遊戲結束，遊戲的勝利者為 : {this.WinnerPlayer()?.Name}");
        }
    }
}