namespace CardGame.Models
{
    public abstract class Player : IComparable<Player>
    {
        public string Name { get; private set; }

        public int Point { get; private set; }

        public Hand Hand { get; private set; } = new();

        public void NameHimself(string name)
        {
            this.Name = name;
        }

        public void GainPoint()
        {
            this.Point++;
        }

        public void SetHand(Hand hand)
        {
            Hand = hand;
        }

        public abstract Card ShowCard(Card card = null);

        public int CompareTo(Player other)
        {
            return Point - other.Point;
        }
    }
}
