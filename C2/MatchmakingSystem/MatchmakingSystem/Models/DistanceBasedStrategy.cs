namespace MatchmakingSystem.Models
{
    public class DistanceBasedStrategy : IMatchStrategy
    {
        public IEnumerable<Individual> Match(Individual individual, IEnumerable<Individual> paired)
        {
            return paired
                .OrderBy(p => individual.Coordinate.Distance(p.Coordinate))
                .ThenBy(p => p.Id)
                .ToList();
        }
    }
}
