using Big2.Enums;

namespace Big2.Handlers
{
    public class PairHandler : CardHandler
    {
        public PairHandler(CardHandler next) : base(next)
        {
        }

        protected override Pattern DoHandling()
        {
            return Pattern.Pair;
        }

        protected override bool Match()
        {
            return this._playcards.Count() == 2;
        }
    }
}
