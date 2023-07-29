using Big2.Enums;
using Big2.Strategies.CardCompare;

namespace Big2.Handlers
{
    public class StraightHandler : CardHandler
    {
        public StraightHandler(CompareStrategy compareStrategy, CardHandler? next) : base(compareStrategy, next)
        {
        }

        protected override sealed Pattern MacthPattern => Pattern.Straight;

        protected override bool PatternMatch()
        {
            var cradsArray = GetCardsArray(this._playcards);
            var firstIndex = Array.FindIndex(cradsArray, c => c == 1);


            if (firstIndex >= 0)
            {
                // forward
                var forwardSum = 0;
                for (var i = firstIndex; i < firstIndex + 5; i++)
                {
                    var index = i % cradsArray.Length;
                    forwardSum += cradsArray[index];
                }

                // reverse
                var reverseSum = 0;
                for (var i = firstIndex + 13; i > firstIndex + 13 - 5; i--)
                {
                    var index = i % cradsArray.Length;
                    reverseSum += cradsArray[index];
                }

                return forwardSum == 5 || reverseSum == 5;
            }
            else
            {
                return false;
            }
        }
    }
}
