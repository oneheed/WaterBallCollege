using CardGame.Base;
using CardGame.Enums;

namespace CardGame.Models
{
    public class UnoCard : Card
    {
        public ColorType Color { get; set; }

        public NumberType Number { get; set; }

        public UnoCard(int number)
        {
            Number = (NumberType)(number % 10);
            Color = (ColorType)(number / 10);
        }

        public override string ToString()
        {
            return $"{Color.GetDisplay()} {Number.GetDisplay()}";
        }


        public override bool Compare(Card card)
        {
            var target = (UnoCard)card;

            return this.Color == target.Color || this.Number == target.Number;
        }
    }
}
