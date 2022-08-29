using Big2.Enums;
using Big2.Models;

namespace Big2.Handlers
{
    public abstract class CardHandler
    {
        private CardHandler _next;

        protected IEnumerable<Card> _topcards;

        protected IEnumerable<Card> _playcards;

        public CardHandler(CardHandler next)
        {
            _next = next;
        }

        public Pattern Compare(IEnumerable<Card> topcards, IEnumerable<Card> playcards)
        {
            _topcards = topcards;
            _playcards = playcards;

            if (Match())
            {
                return DoHandling();
            }
            else if (_next != null)
            {
                return _next.Compare(topcards, playcards);
            }

            return Pattern.Illegal;
        }


        protected abstract bool Match();

        protected abstract Pattern DoHandling();
    }
}
