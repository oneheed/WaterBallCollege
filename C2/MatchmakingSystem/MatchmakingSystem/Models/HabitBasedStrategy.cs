namespace MatchmakingSystem.Models
{
    public class HabitBasedStrategy : IMatchStrategy
    {
        public IEnumerable<Individual> Match(Individual individual, IEnumerable<Individual> paired)
        {
            return paired
                .OrderBy(p => individual.Habits.Count(h => p.Habits.Contains(h)))
                .ThenBy(p => p.Id)
                .ToList();
        }
    }
}
