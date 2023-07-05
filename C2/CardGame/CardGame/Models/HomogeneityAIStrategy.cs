namespace CardGame.Models
{
    public class HomogeneityAIStrategy : AIStrategy
    {
        public override Card Showdown()
        {
            var topCard = this.aiPlayer.CardGame.TopCard;
            var showCard = this.aiPlayer.Hand.ContainsHomogeneity(topCard);
            var index = new Random().Next(0, this.aiPlayer.Hand.Count - 1);

            return showCard ?? this.aiPlayer.Hand.Showdown(index);
        }
    }
}