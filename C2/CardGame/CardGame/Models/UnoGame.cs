using CardGame.Enums;

namespace CardGame.Models
{
    public class UnoGame : CardGameApp
    {
        private readonly Deck _topDeck = new Deck();

        public UnoGame(Deck deck, IList<Player> players) : base(deck, players)
        {
            this._drawNumber = 5;
        }

        protected sealed override bool NextRound()
        {
            return !this._players.Any(p => p.Hand.Count == 0);
        }

        protected override void TakeRound()
        {
            if (Round == 1)
                _topDeck.Push(_deck.DrawCard());

            var topCard = _topDeck.ShowCard();
            Console.WriteLine($"Top: {_topDeck.GetCards().Count()}, Deck: {_deck.GetCards().Count()}, Pl: {_players[0].Hand.Count}, P2: {_players[1].Hand.Count}, P3: {_players[2].Hand.Count}, P4: {_players[3].Hand.Count}");
            Console.WriteLine($"{_topDeck.GetCards().Count() + _deck.GetCards().Count() + _players[0].Hand.Count + _players[1].Hand.Count + _players[2].Hand.Count + _players[3].Hand.Count}");

            ShowCard("頂牌為", (UnoCard)topCard);

            var showCards = new List<(int, Card)>();
            for (int i = 0; i < _players.Count; i++)
            {
                var player = _players[i];
                var card = player.ShowCard(topCard);

                if (topCard.CompareTo(card) == 0)
                {
                    player.Hand.RemoveCard(card);
                    _topDeck.Push(card);

                    showCards.Add((i, card));

                    ShowCard($"{player.Name} 出 ", (UnoCard)card);
                }
                else
                {
                    player.Hand.AddCard(_deck.DrawCard());

                    if (!_deck.Any())
                    {
                        Console.WriteLine($"重新洗牌");

                        topCard = _topDeck.DrawCard();
                        _deck.SetCards(_topDeck.GetCards());
                        _topDeck.Clear();
                        _topDeck.Push(topCard);
                    }
                }

                if (player.Hand.Count == 0)
                    break;
            }
        }

        private void ShowCard(string context, UnoCard card)
        {
            Console.Write($"{context}");

            switch (card.Color)
            {
                case Color.BLUE:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Color.RED:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Color.GREEN:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Color.YELLOW:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            Console.WriteLine($"{card}");

            Console.ResetColor();
        }

        protected override Player WinerPlayer()
        {
            return this._players.SingleOrDefault(p => p.Hand.Count == 0);
        }
    }
}
