using Big2.Models;

namespace Big2.Strategies.AI
{
    public class AlwaysPlayFirstAIStrategy : AIStrategy
    {
        public override IList<Card> Play()
        {
            var indexs = new List<int>
            {
                 0,
            };

            return aiPlayer.Hand.Play(indexs);
        }
    }
}
