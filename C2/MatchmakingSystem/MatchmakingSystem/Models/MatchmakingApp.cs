namespace MatchmakingSystem.Models
{
    public class MatchmakingApp
    {
        public IEnumerable<Individual> Individuals { get; private set; }

        public MatchmakingApp(IEnumerable<Individual> individuals)
        {
            Individuals = individuals;
        }

        public void Start()
        {
            Func<int, IEnumerable<Individual>> func = id => { return Individuals.Where(t => t.Id != id).ToList(); };

            var result = Individuals.Select(s => new { Id = s.Id, MathResult = s.MathStrategy.Match(s, func(s.Id)) });

            foreach (var item in result)
            {
                Console.WriteLine($"Id: {item.Id} 配對到 {item.MathResult.FirstOrDefault().Id}");
            }
        }
    }
}
