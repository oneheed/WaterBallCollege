namespace MatchmakingSystem.Models
{
    internal class MatchmakingApp
    {
        public IEnumerable<Individual> Individuals { get; private set; }

        public MatchmakingApp(IEnumerable<Individual> individuals)
        {
            Individuals = individuals;
        }

        public void Start()
        {
            foreach (var individual in Individuals)
            {
                var result = Match(individual);

                Console.WriteLine($"Id: {individual.Id} 配對到 {result.Id}");
            }
        }

        public Individual Match(Individual individual)
        {
            var filterIndividuals = Individuals.Where(i => i.Id != individual.Id);

            return individual.Math(filterIndividuals).FirstOrDefault();
        }
    }
}
