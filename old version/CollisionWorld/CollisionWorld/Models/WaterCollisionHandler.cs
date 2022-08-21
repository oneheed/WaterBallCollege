using CollisionWorld.Base;

namespace CollisionWorld.Models
{
    public class WaterCollisionHandler : CollisionHandler
    {
        public WaterCollisionHandler(CollisionHandler next) : base(next)
        {
        }

        protected override bool Match(Sprite source)
        {
            return source is Water;
        }

        protected override ResultEvent DoHandler(MoveEvent moveEvent)
        {
            var result = new ResultEvent();

            switch (moveEvent.Target)
            {
                case Water:
                    result.IsMove = false;
                    break;

                case Fire:
                    result.IsMove = false;
                    result.RemovedSprites.Add(moveEvent.Source);
                    result.RemovedSprites.Add(moveEvent.Target);
                    break;

                case Hero hero:
                    result.IsMove = false;
                    result.RemovedSprites.Add(moveEvent.Source);
                    hero.ControlHp(10);
                    break;
            }

            return result;
        }
    }
}
