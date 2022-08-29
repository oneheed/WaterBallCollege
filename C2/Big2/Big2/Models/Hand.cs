namespace Big2.Models
{
    public class Hand
    {
        private readonly IList<Card> _cards = new List<Card>();

        public string ShowAllCard()
        {
            return string.Join(", ", _cards.Select((c, i) => $"[{i}]{c}"));
        }

        public Card ShowCard(int index)
        {
            var card = _cards[index];

            return card;
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void AddCard(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                _cards.Add(card);
            }
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }

        public void RemoveCard(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                _cards.Remove(card);
            }
        }

        public int Count => _cards.Count;

        public bool Any() => _cards.Any();
    }
}
