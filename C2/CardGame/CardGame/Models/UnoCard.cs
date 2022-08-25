﻿using CardGame.Enums;
using CardGame.Extensions;

namespace CardGame.Models
{
    internal class UnoCard : Card
    {
        public Color Color { get; private set; }

        public Number Number { get; private set; }

        public UnoCard(int order)
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
            var card = other as UnoCard;

            if (Color == card.Color || Number == card.Number)
            {
                return 0;
            }

            return -1;
        }
    }
}
