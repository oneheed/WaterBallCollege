using ShowdownGame.Base;

namespace ShowdownGame.Models
{
    public class RealPlayer : Player
    {
        public override void Command()
        {
            Console.WriteLine(string.Join(", ", this.Cards.Select((c, i) => $"[{i}] {c}")));
            Console.WriteLine("請輸入要出的牌號: (-1: 換牌)");
            this.CardId = int.TryParse(Console.ReadLine(), out int cardId) ? cardId : 0;

            if (this.CardId == -1)
            {
                Console.WriteLine("要跟誰換牌: ");
                var playerId = int.TryParse(Console.ReadLine(), out int index) ? index : 0;

                if (playerId == this.Id)
                {
                    Console.WriteLine("不可以換牌給自己");
                }
                else
                {
                    this.ExchangeHands(playerId);
                }

                this.Command();
            }
            else
            {
                if (this.CardId < 0 || this.CardId >= this.Cards.Count)
                {
                    Console.WriteLine("輸入錯誤，請重新輸入");
                    this.Command();
                }
                else
                {
                    Console.WriteLine($"{this} 已出牌");
                }
            }
        }
    }
}
