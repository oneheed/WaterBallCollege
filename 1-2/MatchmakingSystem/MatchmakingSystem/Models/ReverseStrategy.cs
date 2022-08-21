namespace MatchmakingSystem.Models
{
    public class ReverseStrategy : IMathStrategy
    {
        private readonly IMathStrategy _mathStrategy;


        public ReverseStrategy(IMathStrategy mathStrategy)
        {
            this._mathStrategy = mathStrategy;
        }

        public IList<Individual> Math(Individual individual, IList<Individual> paired)
        {
            return _mathStrategy.Math(individual, paired).Reverse().ToList();
        }
    }
}
