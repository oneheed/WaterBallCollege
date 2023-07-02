namespace Showdown.Models
{
    public abstract class Player
    {
        public string Name { get; private set; }

        public int Point { get; private set; }

        public ExchangeHands ExchangeHands { get; private set; }

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

        public void SetExchangeHands(ExchangeHands exchangeHands)
        {
            ExchangeHands = exchangeHands;
        }

        public abstract void Exchange(IList<Player> players);

        public abstract Card Play();
    }
}
