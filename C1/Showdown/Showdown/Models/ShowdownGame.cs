// Ignore Spelling: exchangee

namespace Showdown.Models
{
    public class ShowdownGame
    {
        public int Round { get; private set; } = 1;

        private readonly Deck _deck;

        private readonly IEnumerable<Player> _players;

        public ShowdownGame(Deck deck, IEnumerable<Player> players)
        {
            this._deck = deck;

            foreach (var (player, i) in players.Select((p, i) => (p, i)))
            {
                player.SetOrder(i + 1);
            }

            this._players = players;
        }

        public void Start()
        {
            NameHimselfStage();

            ShuffleStage();

            DrawStage();

            TakesATurnStage();

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
            while (_deck.Any())
            {
                foreach (var player in _players)
                {
                    player.Hand.AddCard(_deck.DrawCard());
                }
            }
        }

        private bool NextRound()
        {
            return Round <= 13;
        }

        private void TakesATurnStage()
        {
            while (NextRound())
            {
                Console.WriteLine($"==== 回合 {Round} ====");

                ExchangeHandStage();

                var showCards = new List<(int Order, Card Card)>();

                foreach (var player in _players)
                {
                    var card = player.Showdown();

                    showCards.Add((player.Order, card));

                    Console.WriteLine($"{player.Name} 出 {card}");
                }

                var winnerData = showCards.MaxBy(x => x.Card);
                var winner = _players.Single(p => p.Order == winnerData.Order);
                winner.GainPoint();

                Console.WriteLine($"回合 {Round} : {winner.Name} 為勝者");

                Round++;
            }
        }

        private void ExchangeHandStage()
        {
            // Check Exchange Hand
            foreach (var exchangeHands in _players.Where(player => player.ExchangeHands != null).Select(p => p.ExchangeHands))
            {
                var isFinish = exchangeHands.Countdown();
                if (isFinish)
                {
                    var exchanger = exchangeHands.Exchanger;
                    var exchangee = exchangeHands.Exchangee;

                    Console.WriteLine($"將 {exchanger.Name} 跟 {exchangee.Name} 交換回來");
                }
            }

            // Exchange Hand
            foreach (var player in _players.Where(player => player.ExchangeHands == null))
            {
                player.Exchange(_players.Where(p => p != player).ToList());
            }
        }

        private void GameOver()
        {
            var finishWinner = _players.MaxBy(p => p.Point);

            Console.WriteLine($"==== 最終 ====");
            Console.WriteLine($"最終勝利者 : {finishWinner.Name}");
        }
    }
}
