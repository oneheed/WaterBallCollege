using ShowdownGame.Base;

namespace ShowdownGame.Models
{
    public class PlayerExchangeHands
    {
        public int Turn { get; set; }

        public Player ExchangePlayer { get; set; }

        // 雙向
        public Player Player { get; set; }


        public void End()
        {
            this.Turn++;

            if (Turn == 3)
            {
                Console.WriteLine($"{this.Player} 跟 {this.ExchangePlayer} 已換回來");
                (this.Player.Cards, this.ExchangePlayer.Cards) = (this.ExchangePlayer.Cards, this.Player.Cards);
            }
        }
    }
}
