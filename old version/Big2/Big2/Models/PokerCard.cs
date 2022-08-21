using System.Text.RegularExpressions;
using Big2.Base;
using Big2.Enums;

namespace Big2.Models
{
    public class PokerCard : Card
    {
        public override int Number
        {
            get
            {
                return this.Suit.Number * 13 + this.Rank.Number;
            }
        }

        public SuitType Suit { get; set; }

        public RankType Rank { get; set; }

        public PokerCard(string card)
        {
            var regex = new Regex(@"(\w)\[(\w{1,2})\]");
            var matchs = regex.Match(card);

            this.Suit = new SuitType(matchs.Groups[1].Value);
            this.Rank = new RankType(matchs.Groups[2].Value);
        }

        public override string ToString()
        {
            return $"{Suit.Name}[{Rank.Name}]";
        }
    }
}
