namespace Showdown.Models
{
    public class ExchangeHands
    {
        private int _round = 3;

        private readonly Player _exchanger;

        private readonly Player _exchangee;

        public ExchangeHands(Player exchanger, Player exchangee)
        {
            _exchanger = exchanger;
            _exchangee = exchangee;

            Exchange();
        }

        private void Exchange()
        {
            var tempHand = _exchanger.Hand;

            _exchanger.SetHand(_exchangee.Hand);
            _exchangee.SetHand(tempHand);
        }

        public (bool isFinish, Player Exchanger, Player Exchangee) Countdown()
        {
            _round--;

            if (_round == 0)
            {
                Exchange();

                return (true, _exchanger, _exchangee);
            }

            return (false, null, null);
        }
    }
}
