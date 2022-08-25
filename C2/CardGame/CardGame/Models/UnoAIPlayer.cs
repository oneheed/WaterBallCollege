namespace CardGame.Models
{
    public class UnoAIPlayer : Player
    {
        public override Card ShowCard(Card card = null)
        {
            if (this.Hand.GetCards().FirstOrDefault(c => c.CompareTo(card) == 0) != null)
            {
                return this.Hand.GetCards().FirstOrDefault(c => c.CompareTo(card) == 0);
            }
            else
            {
                var index = new Random().Next(0, this.Hand.Count - 1);

                return this.Hand.ShowCard(index);
            }
        }
    }
}
