namespace CardGame.Models
{
    public class ShowdownGame : CardGameApp
    {
        public ShowdownGame(Deck deck, IList<Player> players) : base(deck, players)
        {
            this._drawNumber = 13;
        }
        protected sealed override bool NextRound()
        {
            return Round <= 13;
        }

        protected override void TakeRound()
        {
            var showCards = new List<(int Index, Card Card)>();
            for (int i = 0; i < _players.Count; i++)
            {
                var player = _players[i];
                var card = player.ShowCard();
                player.Hand.RemoveCard(card);

                showCards.Add((i, card));

                Console.WriteLine($"{player.Name} 出 {card}");
            }

            var winnerData = showCards.MaxBy(x => x.Card);
            var winner = _players[winnerData.Index];
            winner.GainPoint();
        }

        protected override Player WinnerPlayer()
        {
            return this._players.MaxBy(p => p.Point);
        }
    }
}
