using Big2.Models;

namespace Big2.Base
{
    public abstract class BaseGame<T> where T : Card
    {
        protected int round;

        protected Deck<T> deck;

        protected IList<Player> players;

        protected IDictionary<Player, Card> playCards = new Dictionary<Player, Card>();

        protected BaseGame()
        {

        }

        public void JoinPlayers(IList<Player> players)
        {
            this.players = players;

            for (var i = 0; i < players.Count; i++)
            {
                players[i].Order = i;
                players[i].Hand.Cards.Clear();
            }
        }

        public void Start()
        {
            //Console.WriteLine(string.Join(", ", Enumerable.Range(0, 10)));
            //Console.WriteLine(deck.Cards.Count + " " + players.Count + " " + (deck.Cards.Count / players.Count));
            //Console.WriteLine(string.Join("", deck.Cards.Select((c, i) => c.ToString() + ((i + 1) % (deck.Cards.Count / players.Count) == 0 ? "\n" : ", "))));

            this.DrawCard();

            //foreach (var player in players)
            //{
            //    Console.WriteLine(string.Join(", ", player.Hand.Cards.Select(c => c.ToString())));
            //}


            while (this.TakesATurn()) ;

            Finish();
        }

        public abstract void DrawCard();


        public abstract bool TakesATurn();


        public abstract void Finish();
    }
}
