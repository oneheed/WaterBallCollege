using ShowdownGame.Models;

namespace ShowdownGame.Base
{
    public abstract class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Point { get; set; }

        public bool IsExchanged { get; set; }

        public int CardId { get; set; }

        public List<Card> Cards { get; set; } = new List<Card>();

        public Showdown Game { get; set; }

        public PlayerExchangeHands PlayerExchangeHands { get; set; }

        public override string ToString() => $"[{Id}] {Name}";

        public abstract void Command();


        public void Namehimself(string name)
        {
            Name = name;
        }

        protected void ExchangeHands(int playerId)
        {
            if (!IsExchanged)
            {
                var player = this.Game.Players.Find(p => p.Id == playerId);
                Console.WriteLine($"{this} 跟 {player} 換牌");

                IsExchanged = true;

                (player.Cards, Cards) = (Cards, player.Cards);

                this.PlayerExchangeHands = new PlayerExchangeHands
                {
                    Player = this,
                    ExchangePlayer = player,
                };
            }
            else
            {
                Console.WriteLine($"已經跟 {this.PlayerExchangeHands.ExchangePlayer} 換牌過");
            }
        }

        public Card Show()
        {
            var card = this.Cards[this.CardId];

            this.Cards.RemoveAt(this.CardId);

            return card;
        }
    }
}
