using Big2.Base;

namespace Big2.Models
{
    public abstract class BaseGame
    {
        protected int round;

        protected Deck deck;

        protected IList<Player> players = new List<Player>();

        protected IEnumerable<Player> winners;

        protected virtual int DrawCardNumber => 13;

        protected virtual bool NextTakes => true;

        protected BaseGame()
        {
            var cards = Enumerable.Range(0, 52).Select(i => new PokerCard(i));

            this.deck = new Deck(cards);
        }

        public void JoinPlayers(IList<Player> players)
        {
            foreach (var player in players)
            {
                player.Hand.Cards.Clear();

                this.players.Add(player);
            }
        }

        public void Start()
        {
            this.Shuffle();

            this.DrawCard();

            while (this.NextTakes)
            {
                this.TakesATurn();

                this.CalculatePoint();
            }

            this.Finish();
        }

        public virtual void Shuffle()
        {
            this.deck.Shuffle();
        }

        public void DrawCard()
        {
            for (int i = 0; i < this.DrawCardNumber; i++)
            {
                foreach (var hand in this.players.Select(p => p.Hand))
                {
                    hand.Cards.Add(this.deck.Cards.Pop());
                }
            }
        }

        public abstract void TakesATurn();

        public abstract void CalculatePoint();

        public abstract void Finish();
    }
}
