using Big2.Enums;
using Big2.Extensions;

namespace Big2.Models
{
    public class Card : IComparable<Card>, IEquatable<Card>
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

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Suit.GetDisplayName()}[{Rank.GetDisplayName()}]";
        }

        public int CompareTo(Card? other)
        {
            if (other != null)
            {
                if (Rank == other.Rank)
                {
                    return Suit - other.Suit;
                }

                return Rank - other.Rank;
            }

            return 1;
        }

        public bool Equals(Card? other)
        {
            if (other != null)
            {
                return Rank == other.Rank && Suit == other.Suit;
            }

            return false;
        }
    }
}
