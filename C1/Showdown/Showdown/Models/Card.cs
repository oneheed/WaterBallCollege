using Showdown.Enums;
using Showdown.Extensions;

namespace Showdown.Models
{
    public class Card : IComparable<Card>
    {
        public Suit Suit { get; private set; }

        public Rank Rank { get; private set; }

        public Card(int order)
        {
            if (order > 52)
                throw new ArgumentOutOfRangeException(nameof(order));

            Suit = (Suit)(order / 13);
            Rank = (Rank)(order % 13);
        }

        public override string ToString()
        {
            return $"{Suit.GetDisplayName()}{Rank.GetDisplayName()}";
        }

        public int CompareTo(Card other)
        {
            if (Rank == other.Rank)
            {
                return Suit - other.Suit;
            }

            return Rank - other.Rank;
        }
    }
}
