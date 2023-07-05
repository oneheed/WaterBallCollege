namespace CardGame.Models
{
    public class AIPlayer : Player
    {
        private readonly AIStrategy strategy;

        public AIPlayer(AIStrategy strategy = null)
        {
            this.strategy = strategy ?? new RandomAIStrategy();
            this.strategy.SetAIPlayer(this);
        }

        public override void NameHimself()
        {
            this.Name = $"Player {Order}";
        }

        public override Card Showdown()
        {
            return this.strategy.Showdown();
        }
    }
}
