namespace MatchmakingSystem.Models
{
    public class MatchmakingApp
    {
        public IList<Individual> Individuals { get; private set; }

        public MatchmakingApp(IList<Individual> individuals)
        {
            Individuals = individuals;
        }

        public void Start()
        {
            Func<int, IList<Individual>> func = id => { return Individuals.Where(t => t.Id != id).ToList(); };

            var result = Individuals.Select(s => new { Id = s.Id, MathResult = s.MathStrategy.Math(s, func(s.Id)) });

            foreach (var item in result)
            {
                Console.WriteLine($"Id: {item.Id} 配對到 {item.MathResult.FirstOrDefault().Id}");
            }
        }
    }
}
