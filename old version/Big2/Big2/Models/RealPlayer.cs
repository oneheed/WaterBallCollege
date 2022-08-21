using Big2.Base;

namespace Big2.Models
{
    public class RealPlayer : Player
    {
        public Queue<int> Commands { get; set; } = new Queue<int>();

        public RealPlayer()
        {
        }


        public override Card Play()
        {
            return this.Hand.Cards[Commands.Dequeue()];
        }
    }
}
