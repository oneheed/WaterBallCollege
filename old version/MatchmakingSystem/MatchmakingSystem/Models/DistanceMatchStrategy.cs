using MatchmakingSystem.Interfaces;

namespace MatchmakingSystem.Models
{
    public class DistanceMatchStrategy : IMatchStrategy
    {
        public Individual Match(Individual individual, IList<Individual> individuals)
        {
            var pair = default(Individual);

            Func<double, double, bool> matchFunc = individual.IsReverse ? ReverseMatch : Match;
            var matchDistance = individual.IsReverse ? 0 : double.MaxValue;

            foreach (var item in individuals.OrderBy(i => i.Id))
            {
                var distance = individual.Coord.GetDistance(item.Coord);

                if (matchFunc(matchDistance, distance))
                {
                    matchDistance = distance;
                    pair = item;
                }
            }

            return pair;
        }

        private bool Match(double matchDistance, double distance) => distance < matchDistance;

        private bool ReverseMatch(double matchDistance, double distance) => distance > matchDistance;
    }
}
