namespace MatchmakingSystem.Models
{
    public interface IMatchStrategy
    {
        IEnumerable<Individual> Match(Individual individual, IEnumerable<Individual> paired);
    }
}