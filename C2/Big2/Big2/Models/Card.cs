using Big2.Enums;
using Big2.Extensions;

namespace Big2.Models
{
    public class Card : IComparable<Card>
    {
        public Suit Suit { get; private set; }

        public Rank Rank { get; private set; }

        public Card(int number)
        {
            if (number > 52)
                throw new ArgumentOutOfRangeException(nameof(number));

            Suit = (Suit)(number / 13);
            Rank = (Rank)(number % 13);
        }

        public override string ToString()
        {
            return $"{Suit.GetDisplayName()}[{Rank.GetDisplayName()}]";
        }

        public int CompareTo(Card? card)
        {
            if (card != null)
            {
                if (Rank == card.Rank)
                {
                    return Suit - card.Suit;
                }

                return Rank - card.Rank;
            }

            return 1;
        }
    }
}
