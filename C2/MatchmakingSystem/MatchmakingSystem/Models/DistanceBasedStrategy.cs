namespace MatchmakingSystem.Models
{
    public class DistanceBasedStrategy : IMatchStrategy
    {
        public IEnumerable<Individual> Match(Individual individual, IEnumerable<Individual> paired)
        {
            return paired.OrderBy(p => individual.Coord.Distance(p.Coord)).ThenBy(p => p.Id).ToList();
        }
    }
}
