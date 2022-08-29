using Big2.Models;

namespace Big2.Strategies
{
    public class FirstAIStrategy : AIStrategy
    {
        public override IList<Card> Play()
        {
            var indexs = new List<int>
            {
                 0,
            };

            return this.aiPlayer.Hand.Play(indexs);
        }
    }
}
