using CardGame.Extensions;
using CardGame.Models;
using CardGame.Showdown.Enums;

namespace CardGame.Showdown
{
    public class PokerCard : Card
    {
        public Suit Suit { get; private set; }

        public Rank Rank { get; private set; }

        public PokerCard(int order)
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
            if (other is PokerCard card)
            {
                if (Rank == card.Rank)
                {
                    return Suit - card.Suit;
                }

                return Rank - card.Rank;

            }

            return 1;
        }

        public static IEnumerable<PokerCard> Standard52PokerCards()
        {
            return Enumerable.Range(0, 52).Select(i => new PokerCard(i)).ToList();
        }
    }
}
