using Big2.Models;

namespace Big2.Base
{
    public abstract class Player
    {
        public int Order { get; set; }

        public string Name { get; set; }

        public int Point { get; set; }

        public Hand Hand { get; set; } = new Hand();

        public void Namehimself(string name)
        {
            Name = name;
        }

        public abstract Card Play();

        public IList<Card> Play(string commandText)
        {
            var cards = new List<Card>();

            if (commandText != "-1")
            {
                var commands = commandText.TrimEnd(' ').Split(" ");

                foreach (var command in commands)
                {
                    var index = int.Parse(command);
                    cards.Add(this.Hand.Cards[index]);
                }
            }

            return cards.OrderBy(c => ((PokerCard)c).Rank.Number).ThenBy(c => ((PokerCard)c).Suit.Number).ToList();
        }
    }
}
