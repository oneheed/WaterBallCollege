using CardGame.Base;

namespace CardGame.Models
{
    public class UnoGame : BaseGame<UnoCard>
    {
        private readonly Deck<UnoCard> _showDeck = new Deck<UnoCard>();

        public UnoGame(IList<Player> players) : base(players)
        {
            this.deck = new Deck<UnoCard>(40);
        }

        public override void DrawCard()
        {
            var count = 0;
            while ((this.deck.Cards.Count / players.Count) > 0 && count < 5)
            {
                foreach (var player in players)
                {
                    player.Hand.Cards.Add(this.deck.Cards.Pop());
                }

                count++;
            }
        }

        public override bool TakesATurn()
        {
            this.round++;

            if (this.round == 1)
            {
                _showDeck.Cards.Push(deck.Cards.Pop());
            }
            var showCard = _showDeck.Cards.Peek();

            Console.WriteLine($"檯面: {showCard}");

            foreach (var player in this.players)
            {
                while (!PlayerPlay(player)) ;

                if (player.Hand.Cards.Count == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override void Finish()
        {
            var winner = this.players.FirstOrDefault(p => !p.Hand.Cards.Any());

            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name} {string.Join(", ", player.Hand.Cards.Select(c => c.ToString()))}");
            }

            Console.WriteLine($"最終贏家: {winner.Name}");
        }

        private bool PlayerPlay(Player player)
        {
            var showCard = _showDeck.Cards.Peek();
            var count = player.Hand.Cards.Select(c => showCard.Compare(c)).Count(c => c);

            if (count > 0)
            {
                var playCard = (UnoCard)player.Play();

                if (playCard.Compare(showCard))
                {
                    _showDeck.Cards.Push(playCard);

                    Console.WriteLine($"{player.Name} : {playCard}");

                    player.Hand.Cards.Remove(playCard);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                player.Hand.Cards.Add(DrawDeck());
                Console.WriteLine($"沒有牌可以出, 抽一張牌!");
            }

            //Console.WriteLine(string.Join(", ", player.Hand.Cards.Select(c => c.ToString())));

            return true;
        }

        private Card DrawDeck()
        {
            if (!deck.Cards.Any())
            {
                var tempCard = _showDeck.Cards.Pop();

                deck.Shuffle(_showDeck.Cards.ToList());

                _showDeck.Cards.Clear();

                _showDeck.Cards.Push(tempCard);
            }

            return deck.Cards.Pop();
        }

        private void ConsoleWrite(Card source)
        {
            var card = (UnoCard)source;

            switch (card.Color)
            {
                case Enums.ColorType.BLUE:
                    Console.BackgroundColor = ConsoleColor.Blue; //設定背景色
                    break;
                case Enums.ColorType.RED:
                    Console.BackgroundColor = ConsoleColor.Red; //設定背景色
                    break;
                case Enums.ColorType.YELLOW:
                    Console.BackgroundColor = ConsoleColor.Yellow; //設定背景色
                    break;
                case Enums.ColorType.GREEN:
                    Console.BackgroundColor = ConsoleColor.Green; //設定背景色
                    break;
            }

            Console.Write(card);
        }
    }
}
