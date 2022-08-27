using CardGame.Enums;

namespace CardGame.Models
{
    public class UnoGame : CardGameApp
    {
        private readonly Deck _topDeck = new();

        private bool _nextRound = true;

        public UnoGame(Deck deck, IList<Player> players) : base(deck, players)
        {
            this._drawNumber = 5;
        }

        protected sealed override bool NextRound()
        {
            return _nextRound;
        }

        protected override void TakeRound()
        {
            if (Round == 1)
                _topDeck.Push(_deck.DrawCard());

            this.TopCard = _topDeck.ShowCard();

            Console.WriteLine($"Top: {_topDeck.Count}, Deck: {_deck.Count}, Pl: {_players[0].Hand.Count}, P2: {_players[1].Hand.Count}, P3: {_players[2].Hand.Count}, P4: {_players[3].Hand.Count}");
            Console.WriteLine($"{_topDeck.Count + _deck.Count + _players[0].Hand.Count + _players[1].Hand.Count + _players[2].Hand.Count + _players[3].Hand.Count}");

            ShowCard("頂牌為", this.TopCard);

            var showCards = new List<(int, Card)>();
            for (int i = 0; i < _players.Count; i++)
            {
                var player = _players[i];
                var card = player.ShowCard();

                if (this.TopCard.CompareTo(card) == 0)
                {
                    player.Hand.RemoveCard(card);
                    _topDeck.Push(card);

                    showCards.Add((i, card));

                    this.TopCard = card;

                    ShowCard($"{player.Name} 出 ", (UnoCard)card);
                }
                else
                {
                    Console.WriteLine($"{player.Name} 抽牌");
                    player.Hand.AddCard(_deck.DrawCard());

                    if (!_deck.Any() && _topDeck.Count > 1)
                    {
                        Reshuffle();
                    }
                }

                if (player.Hand.Count == 0 || (!_deck.Any() && _topDeck.Count == 1))
                {
                    _nextRound = false;
                    break;
                }
            }
        }

        protected override Player WinnerPlayer()
        {
            return this._players.SingleOrDefault(p => p.Hand.Count == 0);
        }

        private void ShowCard(string context, Card card)
        {
            Console.Write($"{context}");

            switch ((card as UnoCard).Color)
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

        private void Reshuffle()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"重新洗牌");
            Console.ResetColor();

            var card = _topDeck.DrawCard();
            _deck.SetCards(_topDeck);
            _topDeck.Push(card);
        }
    }
}
