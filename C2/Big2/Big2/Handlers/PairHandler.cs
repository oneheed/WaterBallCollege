using Big2.Enums;
using Big2.Strategies;

namespace Big2.Handlers
{
    public class PairHandler : CardHandler
    {
        public PairHandler(CompareStrategy compareStrategy, CardHandler next) : base(compareStrategy, next)
        {
        }

        protected override sealed Pattern MacthPattern => Pattern.Pair;

        protected override bool PatternMatch()
        {
            return this._playcards.Count() == 2 &&
                GetCardsArray(this._playcards).Any(c => c == 2);

        }
    }
}
