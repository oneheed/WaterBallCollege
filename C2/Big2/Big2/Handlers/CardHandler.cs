using Big2.Enums;
using Big2.Models;
using Big2.Strategies.CardCompare;

namespace Big2.Handlers
{
    public abstract class CardHandler
    {
        private readonly CardHandler? _next;

        private readonly CompareStrategy _compareStrategy;

        protected TopPlay _topPlay = new TopPlay();

        protected IEnumerable<Card> _playcards = new List<Card>();


        protected CardHandler(CompareStrategy compareStrategy, CardHandler? next)
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
                    return _compareStrategy.Compare(this._topPlay.Cards, this._playcards) > 0 ? MacthPattern : throw new IllegalPatternException();
                }
            }
            else if (_next != null)
            {
                return _next.Excute(topPlay, playcards);
            }

            throw new IllegalPatternException();
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
