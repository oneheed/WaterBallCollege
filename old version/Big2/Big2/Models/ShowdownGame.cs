namespace Big2.Models
{
    public class ShowdownGame : BaseGame
    {
        private readonly IDictionary<int, PokerCard> _showCrads = new Dictionary<int, PokerCard>();

        private readonly IDictionary<int, int> _gamePonit = new Dictionary<int, int>();

        protected override int DrawCardNumber => 13;

        protected override bool NextTakes => this.players.Any(p => p.Hand.Cards.Any());

        public override void TakesATurn()
        {
            this.round++;
            this._showCrads.Clear();

            Console.WriteLine("新的回合開始了。");

            for (var i = 0; i < this.players.Count; i++)
            {
                var player = this.players[i];

                Console.WriteLine($"輪到{player.Name}了");

                var crard = player.Play();
                _showCrads.Add(i, crard);

                Console.WriteLine($"玩家 {player.Name} 打出了 單張 {crard}");

                this.players[i].Hand.Cards.Remove(crard);
            }
        }

        public override void CalculatePoint()
        {
            var winnerData = _showCrads.MaxBy(s => s.Value, new ShowdownComparer());

            if (!_gamePonit.ContainsKey(winnerData.Key))
                _gamePonit.Add(winnerData.Key, 0);

            Console.WriteLine($"該回合 玩家 {this.players[winnerData.Key].Name} 勝利");

            _gamePonit[winnerData.Key]++;
        }

        public override void Finish()
        {
            var winnerData = _gamePonit.MaxBy(g => g.Value);

            Console.WriteLine($"遊戲結束，遊戲的勝利者為 {this.players[winnerData.Key].Name}");
        }

        private sealed class ShowdownComparer : IComparer<PokerCard>
        {
            // Ace 最大
            public int Compare(PokerCard x, PokerCard y)
            {
                Func<int, int> func = number => (number + 12) % 13;

                return func(x.Rank.Number) > func(y.Rank.Number) && x.Suit.Number > y.Suit.Number ? 1 : -1;
            }
        }
    }
}
