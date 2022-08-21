using CardGame.Base;

namespace CardGame.Models
{
    public class ShowdownGame : BaseGame<PokerCard>
    {
        public ShowdownGame(IList<Player> players) : base(players)
        {
            this.deck = new Deck<PokerCard>(52);
        }

        public override void DrawCard()
        {
            while ((this.deck.Cards.Count / players.Count) > 0)
            {
                foreach (var hand in players.Select(p => p.Hand))
                {
                    hand.Cards.Add(this.deck.Cards.Pop());
                }
            }

            foreach (var hand in players.Select(p => p.Hand))
            {
                hand.Cards = hand.Cards.OrderBy(c => ((PokerCard)c).Suit).ThenBy(c => ((PokerCard)c).Rank).ToList();
            }
        }

        public override bool TakesATurn()
        {
            this.round++;

            foreach (var player in this.players)
            {
                var card = player.Play();

                if (this.playCards.ContainsKey(player))
                {
                    this.playCards[player] = card;
                }
                else
                {
                    this.playCards.Add(player, card);
                }

                player.Hand.Cards.Remove(card);
            }
            var winner = this.playCards.Aggregate((s1, s2) => s1.Value.Compare(s2.Value) ? s1 : s2);
            winner.Key.Point++;

            Console.WriteLine($"回合{this.round} {string.Join(", ", this.playCards.Select(c => $"{c.Key.Name} : {c.Value}"))} 贏家:{winner.Key.Name}");

            return this.round < 13;
        }

        public override void Finish()
        {
            var winner = this.players.Aggregate((s1, s2) => s1.Point > s2.Point ? s1 : s2);

            Console.WriteLine($"最終贏家: {winner.Name}");
        }
    }
}
