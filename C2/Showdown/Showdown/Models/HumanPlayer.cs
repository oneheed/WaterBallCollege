namespace Showdown.Models
{
    public class HumanPlayer : Player
    {
        public override void Exchange(IList<Player> players)
        {
            if (this.ExchangeHands == null)
            {
                Console.WriteLine("是否使用換牌功能 [1:使用, other:不使用]");
                var command = Console.ReadLine();

                if (command == "1")
                {
                    Console.WriteLine($"跟哪位玩家交換 {string.Join(", ", players.Select((p, i) => $"[{i}]{p.Name}"))}");

                    command = Console.ReadLine();

                    if (int.TryParse(command, out int index) && index < players.Count)
                    {
                        this.SetExchangeHands(new ExchangeHands(this, players.ElementAt(index)));

                        Console.WriteLine($"將 {this.Name} 跟 {players.ElementAt(index).Name} 交換");
                    }
                }
            }
        }

        public override Card ShowCard()
        {
            Console.WriteLine(this.Hand.ShowAllCard());

            var command = Console.ReadLine();

            if (int.TryParse(command, out int index) && index < this.Hand.Count)
            {
                return this.Hand.ShowCard(index);
            }
            else
            {
                Console.WriteLine("輸入錯誤, 請重新輸入");

                return ShowCard();
            }
        }
    }
}
