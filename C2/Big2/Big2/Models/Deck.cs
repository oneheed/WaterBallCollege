namespace Big2.Models
{
    public class Deck
    {
        private readonly Stack<Card> _cards = new();

        public static Deck Standard52ProkerCards()
        {
            var deck = new Deck();
            var cards = Enumerable.Range(0, 52).Select(i => new Card(i)).ToList();
            cards.ForEach(card => deck.Push(card));

            return deck;
        }
        public void SetCards(Deck deck)
        {
            foreach (var card in deck._cards)
            {
                _cards.Push(card);
            }

            deck._cards.Clear();
        }

        public void Shuffle()
        {
            var rand = new Random();
            var cards = _cards.AsEnumerable().OrderBy(c => rand.Next()).ToList();
            _cards.Clear();

            cards.ForEach(card => _cards.Push(card));
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

        public int Count => this._cards.Count;

        public bool Any() => _cards.Any();
    }
}
