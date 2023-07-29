using Big2.Strategies.AI;

namespace Big2.Models
{
    public class AIPlayer : Player
    {
        private readonly AIStrategy strategy;

        public AIPlayer(string? name = null, AIStrategy? strategy = null)
        {
            this.Name = name;
            this.strategy = strategy ?? new RandomAIStrategy();
            this.strategy.SetAIPlayer(this);
        }

        public override IList<Card> Play()
        {
            return this.strategy.Play();
        }
    }
}
