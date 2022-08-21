using ShowdownGame.Enums;

namespace ShowdownGame.Models
{
    public class Card
    {
        private readonly int _number;

        public RankType Rank { get; set; }

        public SuitType Suit { get; set; }

        public Card(int number)
        {
            this._number = number;
            this.Rank = (RankType)((number - 1) % 13);
            this.Suit = (SuitType)((number - 1) / 13);
        }

        public override string ToString()
        {
            return $"{Suit.GetDisplay()} {Rank.GetDisplay()}";
        }

        public bool Compare(Card card)
        {
            return this._number > card._number;
        }
    }
}