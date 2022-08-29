namespace Big2.Models
{
    public class TopPlay
    {
        public Player Player { get; private set; } = new AIPlayer();

        public IList<Card> Cards { get; private set; } = new List<Card>();

        public void SetTopPlay(Player player, IList<Card> cards)
        {
            this.Player = player;
            this.Cards = cards;
        }

        public void ResetTopPlay()
        {
            this.Player = new AIPlayer();
            this.Cards = new List<Card>();
        }
    }
}
