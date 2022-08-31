using Big2.Models;

namespace Big2.Strategies.AI
{
    public class RandomAIStrategy : AIStrategy
    {
        public override IList<Card> Play()
        {
            var indexs = new List<int>
            {
                 new Random().Next(0, aiPlayer.Hand.Count - 1),
            };

            return aiPlayer.Hand.Play(indexs);
        }
    }
}
