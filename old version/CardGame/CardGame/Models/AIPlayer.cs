using CardGame.Base;

namespace CardGame.Models
{
    public class AIPlayer : Player
    {
        public override Card Play()
        {
            var random = new Random();
            var index = random.Next(this.Hand.Cards.Count);

            return this.Hand.Cards[index];
        }
    }
}
