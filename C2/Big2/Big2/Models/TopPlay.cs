using Big2.Enums;

namespace Big2.Models
{
    public class TopPlay
    {
        public Player Player { get; private set; } = new AIPlayer();

        public IList<Card> Cards { get; private set; } = new List<Card>();

        public Pattern? Pattern { get; private set; }

        public void SetTopPlay(Player player, IList<Card> cards, Pattern Pattern)
        {
            this.Player = player;
            this.Cards = cards;
            this.Pattern = Pattern;
        }

        public void ResetTopPlay()
        {
            this.Player = new AIPlayer();
            this.Cards = new List<Card>();
            this.Pattern = default;
        }
    }
}
