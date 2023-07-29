namespace CardGame.Models
{
    public class RandomAIStrategy : AIStrategy
    {
        public override Card Showdown()
        {
            var index = new Random().Next(0, this.aiPlayer.Hand.Count - 1);

            return this.aiPlayer.Hand.Showdown(index);
        }
    }
}