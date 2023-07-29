using CollisionWorld.Sprites;

namespace CollisionWorld.Handlers
{
    public class WaterAndFireCollisionHandler : CollisionHandler
    {
        protected override string CollideName => "Water";

        protected override string CollidedName => "Fire";

        public WaterAndFireCollisionHandler(CollisionHandler next) : base(next)
        {
        }

        public override void DoHandling(Sprite collide, Sprite collided)
        {
            collide.RemovedFromWorld();
            collided.RemovedFromWorld();
        }
    }
}
