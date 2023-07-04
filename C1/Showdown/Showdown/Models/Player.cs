namespace Showdown.Models
{
    public abstract class Player
    {
        public int Order { get; private set; }

        public string Name { get; protected set; }

        public int Point { get; private set; }

        public ExchangeHands ExchangeHands { get; private set; }

        public Hand Hand { get; private set; } = new();

        public void SetOrder(int order)
        {
            this.Order = order;
        }

        public abstract void NameHimself();

        public void GainPoint()
        {
            this.Point++;
        }

        public void SetHand(Hand hand)
        {
            Hand = hand;
        }

        public void SetExchangeHands(ExchangeHands exchangeHands)
        {
            ExchangeHands = exchangeHands;
        }

        public abstract void Exchange(IList<Player> players);

        public abstract Card Showdown();
    }
}
