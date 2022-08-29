using Big2.Enums;

namespace Big2.Handlers
{
    public class StraightHandler : CardHandler
    {
        public StraightHandler(CardHandler next) : base(next)
        {
        }

        protected override Pattern DoHandling()
        {
            return Pattern.Straight;
        }

        protected override bool Match()
        {
            return this._playcards.Count() == 5;
        }
    }
}
