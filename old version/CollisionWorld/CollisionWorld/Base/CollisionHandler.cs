using CollisionWorld.Models;

namespace CollisionWorld.Base
{
    public abstract class CollisionHandler
    {
        protected CollisionHandler next;

        protected CollisionHandler(CollisionHandler next)
        {
            this.next = next;
        }

        public ResultEvent Handler(MoveEvent moveEvent)
        {
            if (Match(moveEvent.Source))
            {
                return DoHandler(moveEvent);
            }
            else if (this.next != null)
            {
                return this.next.Handler(moveEvent);
            }

            return new ResultEvent();
        }

        protected abstract bool Match(Sprite source);

        protected abstract ResultEvent DoHandler(MoveEvent moveEvent);
    }
}
