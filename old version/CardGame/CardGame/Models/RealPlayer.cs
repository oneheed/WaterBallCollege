using CardGame.Base;

namespace CardGame.Models
{
    public class RealPlayer : Player
    {
        public override Card Play()
        {
            Console.WriteLine(string.Join(", ", this.Hand.Cards.Select((c, i) => $"[{i}] {c}")));
            Console.WriteLine("請輸入要出的牌號:");

            var cardId = -1;
            if (!int.TryParse(Console.ReadLine(), out cardId) || cardId < 0 || cardId > (this.Hand.Cards.Count - 1))
            {
                return this.Play();
            }
            else
            {
                return this.Hand.Cards[cardId];
            }
        }
    }
}
