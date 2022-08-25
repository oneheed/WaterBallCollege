namespace CardGame.Models
{
    public class AIPlayer : Player
    {
        public override Card ShowCard(Card card = null)
        {
            var index = new Random().Next(0, this.Hand.Count - 1);

            return this.Hand.ShowCard(index);
        }
    }
}
