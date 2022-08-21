using ShowdownGame.Base;

namespace ShowdownGame.Models
{
    public class Showdown
    {
        private readonly List<Player> _players = new();

        private readonly Deck Deck = new();

        public List<Player> Players => _players;

        public void AddPlayer(Player player)
        {
            if (_players.Count >= 4)
            {
                Console.WriteLine("遊戲人數已滿");
            }
            else
            {
                _players.Add(player);
            }
        }

        public void Shuffle()
        {
            var randomNumber = Enumerable.Range(1, 52).ToList();
            while (randomNumber.Any())
            {
                var random = new Random();
                var index = random.Next(0, randomNumber.Count - 1);

                var number = randomNumber[index];
                this.Deck.Cards.Add(new Card(number));

                randomNumber.RemoveAt(index);
            }

            if (_players.Count <= 4)
            {
                while (_players.Count < 4)
                {
                    _players.Add(new AIPlayer { Name = "AI_" + _players.Count, Id = _players.Count, Game = this });
                }
            }
        }

        public void DrawCard()
        {
            var count = 0;
            while (Deck.Cards.Any())
            {
                var index = count % 4;
                _players[index].Cards.Add(Deck.Cards.First());

                Deck.Cards.RemoveAt(0);

                count++;
            }
        }

        public void TakesATurn()
        {
            Player winner = default;
            var winnerCard = new Card(0);

            foreach (var player in _players)
            {
                if (player.IsExchanged)
                {
                    player.PlayerExchangeHands.End();
                }
            }

            var cards = _players.Select((player, i) =>
            {
                player.Command();
                var card = player.Show();

                if (i == 0 || card.Compare(winnerCard))
                {
                    winner = player;
                    winnerCard = card;
                }

                return $"{player} 出 {card}";

            }).ToList();

            winner.Point++;
            Console.WriteLine($"{string.Join("\n", cards)}");
            Console.WriteLine($"-當局贏家 : {winner}");

            Console.WriteLine($"===================================================");
        }


        public void Finish()
        {
            var finishPoint = _players.Max(c => c.Point);
            var finishWinner = _players.Where(player => player.Point == finishPoint);

            Console.WriteLine($"最終贏家 : {string.Join(", ", finishWinner)} 點數: {finishPoint}");
        }
    }
}
