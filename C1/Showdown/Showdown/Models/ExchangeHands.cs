// Ignore Spelling: exchangee

namespace Showdown.Models
{
    public class ExchangeHands
    {
        private int _round = 3;

        public Player Exchanger { get; private set; }

        public Player Exchangee { get; private set; }

        public ExchangeHands(Player exchanger, Player exchangee)
        {
            Exchanger = exchanger;
            Exchangee = exchangee;

            Exchange();
        }

        private void Exchange()
        {
            var tempHand = Exchanger.Hand;

            Exchanger.SetHand(Exchangee.Hand);
            Exchangee.SetHand(tempHand);
        }

        public bool Countdown()
        {
            _round--;

            if (_round == 0)
            {
                Exchange();

                return true;
            }

            return false;
        }
    }
}
