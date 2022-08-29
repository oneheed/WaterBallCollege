namespace Big2.Models
{
    public class AIPlayer : Player
    {
        //private readonly AIStrategy strategy;

        //public AIPlayer(AIStrategy strategy = null)
        //{
        //    this.strategy = strategy ?? new RandomAIStrategy();
        //    this.strategy.SetAIPlayer(this);
        //}

        public override IList<Card> Play()
        {
            return this.strategy.ShowCard();
        }
    }
}
