namespace CardGame.Models
{
    public class Hand
    {
        private readonly IList<Card> _cards = new List<Card>();


        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public string ShowAllCard()
        {
            return string.Join(", ", _cards.Select((c, i) => $"[{i}]{c}"));
        }

        public Card Showdown(int index)
        {
            var card = _cards[index];

            return card;
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }

        public Card ContainsHomogeneity(Card card)
        {
            return _cards.FirstOrDefault(c => c.CompareTo(card) == 0);
        }

        public int Count => _cards.Count;

        public bool Any() => _cards.Any();
    }
}