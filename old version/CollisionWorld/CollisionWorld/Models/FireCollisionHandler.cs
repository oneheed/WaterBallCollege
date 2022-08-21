using CollisionWorld.Base;

namespace CollisionWorld.Models
{
    public class FireCollisionHandler : CollisionHandler
    {
        public FireCollisionHandler(CollisionHandler next) : base(next)
        {
        }

        protected override bool Match(Sprite source)
        {
            return source is Fire;
        }

        protected override ResultEvent DoHandler(MoveEvent moveEvent)
        {
            var result = new ResultEvent();

            switch (moveEvent.Target)
            {
                case Water:
                    result.IsMove = false;
                    result.RemovedSprites.Add(moveEvent.Source);
                    result.RemovedSprites.Add(moveEvent.Target);
                    break;

                case Fire:
                    result.IsMove = false;
                    break;

                case Hero hero:
                    result.IsMove = false;
                    result.RemovedSprites.Add(moveEvent.Source);
                    hero.ControlHp(-10);
                    if (hero.Dead()) { result.RemovedSprites.Add(moveEvent.Target); }
                    break;
            }

            return result;
        }
    }
}
