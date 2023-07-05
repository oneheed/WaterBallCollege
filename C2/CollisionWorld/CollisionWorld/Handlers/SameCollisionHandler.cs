using CollisionWorld.Sprites;

namespace CollisionWorld.Handlers
{
    public class SameCollisionHandler : CollisionHandler
    {
        public SameCollisionHandler(CollisionHandler next) : base(next)
        {
        }

        public override void Collision(Sprite collide, Sprite collided)
        {
            if (collide.Name.Equals(collided.Name))
            {
                DoHandling(collide, collided);
            }
            else if (_next != null)
            {
                this._next.Collision(collide, collided);
            }
        }

        public override void DoHandling(Sprite collide, Sprite collided)
        {
            throw new NotImplementedException();
        }
    }
}
