using MatchmakingSystem.Models;

namespace MatchmakingSystem.Strategies
{
    internal class ReverseStrategy : IMatchStrategy
    {
        private readonly IMatchStrategy _mathStrategy;


        public ReverseStrategy(IMatchStrategy mathStrategy)
        {
            _mathStrategy = mathStrategy;
        }

        public IEnumerable<Individual> Match(Individual individual, IEnumerable<Individual> paired)
        {
            return _mathStrategy.Match(individual, paired).Reverse().ToList();
        }
    }
}
