using Big2.Enums;

namespace Big2.Handlers
{
    public class FullHouseHandler : CardHandler
    {
        public FullHouseHandler(CardHandler next) : base(next)
        {
        }

        protected override Pattern DoHandling()
        {
            return Pattern.FullHouse;
        }

        protected override bool Match()
        {
            return this._playcards.Count() == 5;
        }
    }
}
