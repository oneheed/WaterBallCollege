using Big2.Models;

namespace Big2.Strategies
{
    public abstract class AIStrategy
    {
        protected AIPlayer aiPlayer;

        public void SetAIPlayer(AIPlayer aiPlayer)
        {
            this.aiPlayer = aiPlayer;
        }

        public abstract IList<Card> Play();
    }
}
