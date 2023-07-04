using MatchmakingSystem.Models;

namespace MatchmakingSystem.Strategies
{
    internal class HabitBasedStrategy : IMatchStrategy
    {
        public IEnumerable<Individual> Match(Individual individual, IEnumerable<Individual> paired)
        {
            return paired
                .OrderByDescending(p => individual.Habits.Count(h => p.Habits.Contains(h)))
                .ThenBy(p => p.Id)
                .ToList();
        }
    }
}
