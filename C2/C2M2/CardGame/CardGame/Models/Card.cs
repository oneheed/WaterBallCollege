namespace CardGame.Models
{
    public abstract class Card : IComparable<Card>
    {
        public abstract int CompareTo(Card other);
    }
}
