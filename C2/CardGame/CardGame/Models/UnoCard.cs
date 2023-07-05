using CardGame.Enums;
using CardGame.Extensions;

namespace CardGame.Models
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
            if (other is UNoCard unoCard &&
                (Color == unoCard.Color || Number == unoCard.Number))
            {
                return 0;
            }

            return 1;
        }
    }
}
