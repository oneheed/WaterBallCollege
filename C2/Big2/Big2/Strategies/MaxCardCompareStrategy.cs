using Big2.Models;

namespace Big2.Strategies
{
    public class MaxCardCompareStrategy : CompareStrategy
    {
        public override int Compare(IEnumerable<Card> topPlayCards, IEnumerable<Card> playCards)
        {
            return playCards.Max().CompareTo(topPlayCards.Max());
        }
    }
}
