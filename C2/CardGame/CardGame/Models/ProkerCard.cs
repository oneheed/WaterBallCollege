using CardGame.Enums;
using CardGame.Extensions;

namespace CardGame.Models
{
    public class ProkerCard : Card
    {
        public Suit Suit { get; private set; }

        public Rank Rank { get; private set; }

        public ProkerCard(int order)
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

        public override int CompareTo(Card other)
        {
            var card = other as ProkerCard;

            if (Rank == card.Rank)
            {
                return Suit - card.Suit;
            }

            return Rank - card.Rank;
        }
    }
}
