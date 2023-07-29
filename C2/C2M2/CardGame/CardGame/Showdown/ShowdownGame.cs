using CardGame.Models;

namespace CardGame.Showdown
{
    public class ShowdownGame : CardGameApp
    {
        public ShowdownGame(Deck deck, IList<Player> players) : base(deck, players)
        {
            _drawNumber = 13;
        }
        protected sealed override bool NextRound()
        {
            return Round <= 13;
        }

        protected override void TakeRound()
        {
            var showCards = new List<(int Order, Card Card)>();

            foreach (var player in _players)
            {
                var card = player.Showdown();
                player.Hand.RemoveCard(card);

                showCards.Add((player.Order, card));

                Console.WriteLine($"{player.Name} 出 {card}");
            }

            var winnerData = showCards.MaxBy(x => x.Card);
            var winner = _players.Single(p => p.Order == winnerData.Order);
            winner.GainPoint();
        }

        protected override Player WinnerPlayer()
        {
            return _players.MaxBy(p => p.Point);
        }
    }
}
