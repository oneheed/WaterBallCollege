using MatchmakingSystem.Models;

namespace MatchmakingSystem.Strategies
{
    internal interface IMatchStrategy
    {
        IEnumerable<Individual> Match(Individual individual, IEnumerable<Individual> paired);
    }
}