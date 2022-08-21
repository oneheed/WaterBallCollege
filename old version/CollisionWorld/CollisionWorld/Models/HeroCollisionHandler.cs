using CollisionWorld.Base;

namespace CollisionWorld.Models
{
    public class HeroCollisionHandler : CollisionHandler
    {
        public HeroCollisionHandler(CollisionHandler next) : base(next)
        {
        }

        protected override bool Match(Sprite source)
        {
            return source is Hero;
        }

        protected override ResultEvent DoHandler(MoveEvent moveEvent)
        {
            var result = new ResultEvent();
            var hero = (Hero)moveEvent.Source;

            switch (moveEvent.Target)
            {
                case Water:
                    result.IsMove = true;
                    result.RemovedSprites.Add(moveEvent.Target);
                    hero.ControlHp(10);
                    break;

                case Fire:
                    result.IsMove = true;
                    result.RemovedSprites.Add(moveEvent.Target);
                    hero.ControlHp(-10);
                    if (hero.Dead()) { result.RemovedSprites.Add(moveEvent.Source); }
                    break;

                case Hero:
                    result.IsMove = false;
                    break;
            }

            return result;
        }
    }
}
