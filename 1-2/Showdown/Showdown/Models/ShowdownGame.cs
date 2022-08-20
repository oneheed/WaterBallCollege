namespace Showdown.Models
{
    public class ShowdownGame
    {
        public int Round { get; private set; } = 1;

        private readonly Deck _deck;

        private readonly IList<Player> _players;

        public ShowdownGame(Deck deck, IList<Player> players)
        {
            this._deck = deck;
            this._players = players;
        }

        public void Start()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].Namehimself($"player {i}");
            }

            _deck.Shuffle();

            var index = 0;
            while (_deck.Any())
            {
                index %= _players.Count;
                _players[index].Hand.AddCard(_deck.DrawCard());
                index++;
            }

            while (Round <= 13)
            {
                Console.WriteLine($"==== 回合 {Round} ====");

                for (int i = 0; i < _players.Count; i++)
                {
                    var player = _players[i];

                    if (player.ExchangeHands != null)
                    {
                        var exchangeEvnt = player.ExchangeHands.Countdown();

                        if (exchangeEvnt.isFinish)
                        {
                            var exchanger = exchangeEvnt.Exchanger;
                            var exchangee = exchangeEvnt.Exchangee;

                            Console.WriteLine($"將 {exchanger.Name} 跟 {exchangee.Name} 交換回來");
                        }
                    }
                }

                for (int i = 0; i < _players.Count; i++)
                {
                    var player = _players[i];
                    if (player.ExchangeHands == null)
                    {
                        player.Exchange(_players.Where(p => p != player).ToList());
                    }
                }

                var showCards = new List<(int, Card)>();
                for (int i = 0; i < _players.Count; i++)
                {
                    var player = _players[i];
                    var card = player.ShowCard();

                    showCards.Add((i, card));

                    Console.WriteLine($"{player.Name} 出 {card}");
                }

                var winnerData = showCards.MaxBy(x => x.Item2);
                var winner = _players[winnerData.Item1];
                winner.GainPoint();

                Console.WriteLine($"回合 {Round} : {winner.Name} 為勝者");

                Round++;
            }

            GameOver();
        }

        public void GameOver()
        {
            var finishWinner = _players.Max();

            Console.WriteLine($"==== 最終 ====");
            Console.WriteLine($"最終勝利者 : {finishWinner.Name}");
        }
    }
}
