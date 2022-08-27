namespace CardGame.Models
{
    public abstract class AIStrategy
    {
        protected AIPlayer aiPlayer;

        public void SetAIPlayer(AIPlayer aiPlayer)
        {
            this.aiPlayer = aiPlayer;
        }

        public abstract Card ShowCard();
    }
}