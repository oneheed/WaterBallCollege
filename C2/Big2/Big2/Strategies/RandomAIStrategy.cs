using Big2.Models;

namespace Big2.Strategies
{
    public class RandomAIStrategy : AIStrategy
    {
        public override IList<Card> Play()
        {
            var indexs = new List<int>
            {
                 new Random().Next(0, this.aiPlayer.Hand.Count - 1),
            };

            return this.aiPlayer.Hand.Play(indexs);
        }
    }
}
