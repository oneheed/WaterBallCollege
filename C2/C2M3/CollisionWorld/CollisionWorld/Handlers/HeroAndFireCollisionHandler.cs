using CollisionWorld.Sprites;

namespace CollisionWorld.Handlers
{
    public class HeroAndFireCollisionHandler : CollisionHandler
    {
        protected override string CollideName => "Hero";

        protected override string CollidedName => "Fire";

        public HeroAndFireCollisionHandler(CollisionHandler next) : base(next)
        {
        }

        public override void DoHandling(Sprite collide, Sprite collided)
        {
            Hero hero;

            if (collide is Hero)
            {
                hero = (Hero)collide;
                collided.RemovedFromWorld();
            }
            else
            {
                hero = (Hero)collided;
                collide.RemovedFromWorld();
            }

            hero.Damage(10);
        }
    }
}
