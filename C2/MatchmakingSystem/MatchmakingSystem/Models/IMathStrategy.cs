namespace MatchmakingSystem.Models
{
    public interface IMathStrategy
    {
        IList<Individual> Math(Individual individual, IList<Individual> paired);
    }
}