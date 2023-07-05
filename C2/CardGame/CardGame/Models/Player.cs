namespace CardGame.Models
{
    public abstract class Player : IComparable<Player>
    {
        public int Order { get; private set; }

        public string Name { get; protected set; }

        public CardGameApp CardGame { get; private set; }

        public int Point { get; private set; }

        public Hand Hand { get; private set; } = new();

        public void SetOrder(int order)
        {
            this.Order = order;
        }

        public abstract void NameHimself();

        public void SetCardGame(CardGameApp cardGame)
        {
            this.CardGame = cardGame;
        }

        public void GainPoint()
        {
            this.Point++;
        }

        public void SetHand(Hand hand)
        {
            Hand = hand;
        }

        public abstract Card Showdown();

        public int CompareTo(Player other)
        {
            return Point - other.Point;
        }
    }
}
