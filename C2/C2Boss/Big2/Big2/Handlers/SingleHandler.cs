using Big2.Enums;
using Big2.Strategies.CardCompare;

namespace Big2.Handlers
{
    public class SingleHandler : CardHandler
    {
        public SingleHandler(CompareStrategy compareStrategy, CardHandler? next) : base(compareStrategy, next)
        {
        }

        protected override Pattern MacthPattern => Pattern.Single;

        protected override bool PatternMatch()
        {
            return this._playcards.Count() == 1;
        }
    }
}
