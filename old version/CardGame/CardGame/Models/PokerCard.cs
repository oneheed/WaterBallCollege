using CardGame.Base;
using CardGame.Enums;

namespace CardGame.Models
{
    public class PokerCard : Card
    {
        public readonly int _number;

        public RankType Rank { get; set; }

        public SuitType Suit { get; set; }

        public PokerCard(int number)
        {
            this._number = number;

            Rank = (RankType)(number % 13);
            Suit = (SuitType)(number / 13);
        }

        public override string ToString()
        {
            return $"{Suit.GetDisplay()} {Rank.GetDisplay()}";
        }

        public override bool Compare(Card card)
        {
            var target = (PokerCard)card;

            return this._number > target._number;
        }
    }
}
