namespace CardGame.Models
{
    public class UnoAIPlayer : Player
    {
        public override Card ShowCard(Card card = null)
        {
            var showCard = this.Hand.ContainsHomogeneity(card);
            var index = new Random().Next(0, this.Hand.Count - 1);

            return showCard ?? this.Hand.ShowCard(index);
        }
    }
}
