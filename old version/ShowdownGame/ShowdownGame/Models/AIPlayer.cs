using ShowdownGame.Base;

namespace ShowdownGame.Models
{
    public class AIPlayer : Player
    {
        public override void Command()
        {
            // 預設都出第一張
            this.CardId = 0;

            Console.WriteLine($"{this} 已出牌");
        }
    }
}
