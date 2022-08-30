using Big2.Enums;
using Big2.Models;
using Big2.Strategies;

namespace Big2.Handlers
{
    public abstract class CardHandler
    {
        private CardHandler _next;

        protected TopPlay _topPlay;

        protected IEnumerable<Card> _playcards;

        protected CompareStrategy _compareStrategy;

        public CardHandler(CompareStrategy compareStrategy, CardHandler next)
        {
            _next = next;
            _compareStrategy = compareStrategy;
        }

        public Pattern Excute(TopPlay topPlay, IEnumerable<Card> playcards)
        {
            _topPlay = topPlay;
            _playcards = playcards;


            if (TopPlayPatternMatch() && PatternMatch())
            {
                if (!this._topPlay.Pattern.HasValue)
                {
                    return MacthPattern;
                }
                else
                {
                    return _compareStrategy.Compare(this._topPlay.Cards, this._playcards) > 0 ? MacthPattern : Pattern.Illegal;
                }
            }
            else if (_next != null)
            {
                return _next.Excute(topPlay, playcards);
            }

            return Pattern.Illegal;
        }

        protected virtual bool TopPlayPatternMatch()
        {
            return !this._topPlay.Pattern.HasValue || this._topPlay.Pattern == MacthPattern;
        }

        protected abstract Pattern MacthPattern { get; }

        protected abstract bool PatternMatch();

        protected int[] GetCardsArray(IEnumerable<Card> cards)
        {
            var cardArray = new int[13];

            foreach (var card in cards)
            {
                cardArray[(int)card.Rank]++;
            }

            return cardArray;
        }
    }
}
