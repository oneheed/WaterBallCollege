// Ignore Spelling: exchangee

namespace Showdown.Models
{
    public class AIPlayer : Player
    {
        public override void NameHimself()
        {
            this.Name = $"Player {Order}";
        }

        public override void Exchange(IList<Player> players)
        {
            if (this.ExchangeHands == null)
            {
                var enable = new Random().Next(0, 10);

                if (enable == 1)
                {
                    var index = new Random().Next(0, players.Count - 1);

                    var exchanger = this;
                    var exchangee = players.ElementAt(index);

                    this.SetExchangeHands(new ExchangeHands(exchanger, exchangee));

                    Console.WriteLine($"將 {exchanger.Name} 跟 {exchangee.Name} 交換");
                }
            }
        }

        public override Card Showdown()
        {
            var index = new Random().Next(0, this.Hand.Count - 1);

            return this.Hand.Showdown(index);
        }
    }
}
