using MatchmakingSystem.Interfaces;

namespace MatchmakingSystem.Models
{
    public class HabitMatchStrategy : IMatchStrategy
    {
        public Individual Match(Individual individual, IList<Individual> individuals)
        {
            var pair = default(Individual);

            Func<int, int, bool> matchFunc = individual.IsReverse ? ReverseMatch : Match;
            var matchCount = individual.IsReverse ? individual.Habits.Count : 0;

            foreach (var item in individuals.OrderBy(i => i.Id))
            {
                var count = individual.Habits
                    .Count(x => item.Habits.Select(t => t.Name).Contains(x.Name));

                if (matchFunc(matchCount, count))
                {
                    matchCount = count;
                    pair = item;
                }
            }

            return pair;
        }

        private bool Match(int matchCount, int count) => count > matchCount;

        private bool ReverseMatch(int matchCount, int count) => count < matchCount;
    }
}
