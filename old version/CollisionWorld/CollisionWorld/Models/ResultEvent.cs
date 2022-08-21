using CollisionWorld.Base;

namespace CollisionWorld.Models
{
    public class ResultEvent
    {
        public bool IsMove { get; set; }

        public IList<Sprite> RemovedSprites { get; set; } = new List<Sprite>();
    }
}
