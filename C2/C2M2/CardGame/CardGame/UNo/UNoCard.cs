using CardGame.Extensions;
using CardGame.Models;
using CardGame.UNo.Enums;

namespace CardGame.UNo
{
    public class UNoCard : Card
    {
        public Color Color { get; private set; }

        public Number Number { get; private set; }

        public UNoCard(int order)
        {
            if (order > 40)
                throw new ArgumentOutOfRangeException(nameof(order));

            Color = (Color)(order / 10);
            Number = (Number)(order % 10);
        }

        public override string ToString()
        {
            return $"{Color.GetDisplayName()}{Number.GetDisplayName()}";
        }

        public override int CompareTo(Card other)
        {
            if (other is UNoCard uNoCard &&
                (Color == uNoCard.Color || Number == uNoCard.Number))
            {
                return 0;
            }

            return 1;
        }

        public static IEnumerable<UNoCard> Standard40UNoCards()
        {
            return Enumerable.Range(0, 40).Select(i => new UNoCard(i)).ToList();
        }
    }
}
