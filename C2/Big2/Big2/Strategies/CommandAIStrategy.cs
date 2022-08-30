using Big2.Models;

namespace Big2.Strategies
{
    public class CommandAIStrategy : AIStrategy
    {
        public CommandAIStrategy()
        {
        }

        public override IList<Card> Play()
        {
            var command = Console.In.ReadLine();

            var indexs = command.Trim().Split(" ").Select(c => int.Parse(c)).ToList();

            return this.aiPlayer.Hand.Play(indexs);
        }
    }
}
