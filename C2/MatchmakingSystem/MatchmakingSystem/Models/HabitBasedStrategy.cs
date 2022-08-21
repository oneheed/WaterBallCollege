namespace MatchmakingSystem.Models
{
    public class HabitBasedStrategy : IMathStrategy
    {
        public IList<Individual> Math(Individual individual, IList<Individual> paired)
        {
            return paired.OrderBy(p => individual.Habits.Count(h => p.Habits.Contains(h))).ThenBy(p => p.Id).ToList();
        }
    }
}
