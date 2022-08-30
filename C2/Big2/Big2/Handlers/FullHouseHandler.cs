using Big2.Enums;
using Big2.Strategies;

namespace Big2.Handlers
{
    public class FullHouseHandler : CardHandler
    {
        public FullHouseHandler(CompareStrategy compareStrategy, CardHandler next) : base(compareStrategy, next)
        {
        }

        protected override sealed Pattern MacthPattern => Pattern.FullHouse;

        protected override bool PatternMatch()
        {
            var cradsArray = GetCardsArray(this._playcards);

            return cradsArray.Any(c => c == 2) &&
                cradsArray.Any(c => c == 3);
        }
    }
}
