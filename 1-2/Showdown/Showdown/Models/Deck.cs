namespace Showdown.Models
{
    public class Deck
    {
        private readonly Stack<Card> _cards = new();

        public static Deck Standard52Cards()
        {
            var deck = new Deck();
            var cards = Enumerable.Range(0, 52).Select(i => new Card(i)).ToList();
            cards.ForEach(card => deck.Push(card));

            return deck;
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

        public Card DrawCard()
        {
            return _cards.Pop();
        }
    }
}
