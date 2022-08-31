using Big2.Models;

namespace Big2.Strategies.AI
{
    public class ConsoleInAIStrategy : AIStrategy
    {
        public ConsoleInAIStrategy()
        {
        }

        public override IList<Card> Play()
        {
            var command = Console.In.ReadLine() ?? string.Empty;

            var indexs = command.Trim().Split(" ").Select(c => int.Parse(c)).ToList();

            return aiPlayer.Hand.Play(indexs);
        }
    }
}
