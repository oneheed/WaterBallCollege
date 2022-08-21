namespace MatchmakingSystem.Models
{
    public class MatchmakingGame
    {
        readonly IList<Individual> individuals;

        public MatchmakingGame(IList<Individual> individuals)
        {
            this.individuals = individuals;
        }

        public void Match()
        {
            foreach (var individual in individuals)
            {
                var temp = individuals.Where(i => i.Id != individual.Id).ToList();
                if (temp.Any())
                {
                    var pair = individual.Match(temp);

                    if (pair != null)
                    {
                        Console.WriteLine($"{individual} 與 {pair} 配對成功");
                    }
                    else
                    {
                        Console.WriteLine($"{individual} 沒有配對成功");
                    }
                }
                else
                {
                    Console.WriteLine($"{individual} 沒有配對成功");
                }
            }
        }
    }
}
