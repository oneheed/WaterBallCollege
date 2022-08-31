using Big2.Models;

namespace Big2.Strategies.CardCompare
{
    public class FullHouseCompareStrategy : CompareStrategy
    {
        public override int Compare(IEnumerable<Card> topPlayCards, IEnumerable<Card> playCards)
        {
            var topRankGroups = topPlayCards.GroupBy(c => c.Rank).Single(g => g.Count() == 3);
            var playRankGroups = playCards.GroupBy(g => g.Rank).Single(g => g.Count() == 3);

            var topMxCard = topPlayCards.Where(c => c.Rank == topRankGroups.Key).Max();
            var playMaxCard = playCards.Where(c => c.Rank == playRankGroups.Key).Max();

            return playMaxCard.CompareTo(topMxCard);
        }
    }
}
