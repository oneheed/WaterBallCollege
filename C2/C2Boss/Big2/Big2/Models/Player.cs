namespace Big2.Models
{
    public abstract class Player
    {
        public int Index { get; private set; }

        public string? Name { get; protected set; }

        public Big2Game? Game { get; private set; }

        public Hand Hand { get; private set; } = new();

        public void SetIndex(int index)
        {
            this.Index = index;
        }

        public void NameHimself(string name)
        {
            this.Name = this.Name ?? name;
        }

        public void SetGame(Big2Game game)
        {
            this.Game = game;
        }

        public void SetHand(Hand hand)
        {
            Hand = hand;
        }

        public abstract IList<Card> Play();
    }
}
