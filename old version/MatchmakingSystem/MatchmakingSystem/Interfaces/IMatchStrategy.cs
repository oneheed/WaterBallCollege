using MatchmakingSystem.Models;

namespace MatchmakingSystem.Interfaces
{
    public interface IMatchStrategy
    {
        Individual Match(Individual individual, IList<Individual> individuals);
    }
}