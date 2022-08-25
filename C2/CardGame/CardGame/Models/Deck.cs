namespace CardGame.Models
{
    public class Deck
    {
        private readonly Stack<Card> _cards = new();

        public static Deck Standard52ProkerCards()
        {
            var deck = new Deck();
            var cards = Enumerable.Range(0, 52).Select(i => new ProkerCard(i)).ToList();
            cards.ForEach(card => deck.Push(card));

            return deck;
        }

        public static Deck Standard40UnoCards()
        {
            var deck = new Deck();
            var cards = Enumerable.Range(0, 40).Select(i => new UnoCard(i)).ToList();
            cards.ForEach(card => deck.Push(card));

            return deck;
        }

        public IEnumerable<Card> GetCards()
        {
            return _cards;
        }

        public void SetCards(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                _cards.Push(card);
            }
        }

        public void Shuffle()
        {
            var rand = new Random();
            var cards = _cards.AsEnumerable().OrderBy(c => rand.Next()).ToList();
            _cards.Clear();

            cards.ForEach(card => _cards.Push(card));
        }

        public bool Any()
        {
            return _cards.Any();
        }

        public void Push(Card card)
        {
            _cards.Push(card);
        }

        public Card ShowCard()
        {
            return _cards.Peek();
        }

        public Card DrawCard()
        {
            return _cards.Pop();
        }

        public void Clear()
        {
            _cards.Clear();
        }
    }
}
