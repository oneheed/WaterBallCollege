namespace Showdown.Models
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

            _cards.RemoveAt(index);

            return card;
        }

        public int Count => _cards.Count;

        public bool Any() => _cards.Any();
    }
}