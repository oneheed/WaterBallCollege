namespace CardGame.Models
{
    public class Deck
    {
        private readonly Stack<Card> _cards = new();

        public Deck()
        {
        }

        public Deck(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                _cards.Push(card);
            }
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
