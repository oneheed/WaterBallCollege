using Big2.Base;

namespace Big2.Models
{
    public class Deck<T> where T : Card
    {
        public Stack<T> Cards { get; set; } = new Stack<T>();

        public Deck()
        {
        }

        public Deck(int cardNumber)
        {
            var cards = Enumerable.Range(0, cardNumber)
                .Select(i => (T)Activator.CreateInstance(typeof(T), i)).ToList();

            Shuffle(cards);
        }

        public void Shuffle(IList<T> cards, bool isRandom = true)
        {
            while (cards.Any())
            {
                if (isRandom)
                {
                    var random = new Random();
                    var index = random.Next(cards.Count);

                    this.Cards.Push(cards[index]);

                    cards.RemoveAt(index);
                }
                else
                {
                    this.Cards.Push(cards.First());

                    cards.Remove(cards.First());
                }
            }
        }
    }
}
