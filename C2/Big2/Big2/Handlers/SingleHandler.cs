using Big2.Enums;

namespace Big2.Handlers
{
    public class SingleHandler : CardHandler
    {
        public SingleHandler(CardHandler next) : base(next)
        {
        }

        protected override Pattern DoHandling()
        {
            return Pattern.Single;
        }

        protected override bool Match()
        {
            return this._playcards.Count() == 1;
        }
    }
}
