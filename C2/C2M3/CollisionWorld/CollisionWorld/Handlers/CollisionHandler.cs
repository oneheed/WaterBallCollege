using CollisionWorld.Sprites;

namespace CollisionWorld.Handlers
{
    public abstract class CollisionHandler
    {
        protected virtual string CollideName { get; } = string.Empty;

        protected virtual string CollidedName { get; } = string.Empty;

        protected readonly CollisionHandler? _next;

        protected CollisionHandler(CollisionHandler next)
        {
            this._next = next;
        }

        public virtual void Collision(Sprite collide, Sprite collided)
        {
            if (collide.Name.Equals(CollideName) && collided.Name.Equals(CollidedName) ||
                (collide.Name.Equals(CollidedName) && collided.Name.Equals(CollideName)))
            {
                DoHandling(collide, collided);
            }
            else if (_next != null)
            {
                this._next.Collision(collide, collided);
            }
        }

        public abstract void DoHandling(Sprite collide, Sprite collided);
    }
}
