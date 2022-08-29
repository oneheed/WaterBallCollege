using Big2.Enums;

namespace Big2.Models
{
    public class Hand
    {
        private readonly IList<Card> _cards = new List<Card>();

        private IEnumerable<Card> _orderCards => _cards.OrderBy(c => c);

        public string ShowAllCard()
        {
            var indexContent = string.Join(" ", _orderCards.Select((c, i) => $"{i.ToString().PadRight(c.ToString().Length)}"));
            var cardContent = string.Join(" ", _orderCards.Select((c, i) => $"{c}"));

            return $"{indexContent}\n{cardContent}";
        }

        public IList<Card> Play(IList<int> indexs)
        {
            if (indexs.Contains(-1))
            {
                return new List<Card>();
            }
            else
            {
                return _orderCards.Where((c, i) => indexs.Contains(i)).ToList();
            }
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

        public bool ContainClubsThree()
        {
            return _cards.Any(c => c.Suit == Suit.Club && c.Rank == Rank.Three);
        }

        public int Count => _cards.Count;

        public bool Any() => _cards.Any();
    }
}
