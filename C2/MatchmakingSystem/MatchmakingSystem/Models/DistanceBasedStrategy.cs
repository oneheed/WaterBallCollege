namespace MatchmakingSystem.Models
{
    public class DistanceBasedStrategy : IMathStrategy
    {
        public IList<Individual> Math(Individual individual, IList<Individual> paired)
        {
            return paired.OrderBy(p => individual.Coord.Distance(p.Coord)).ThenBy(p => p.Id).ToList();
        }
    }
}
