namespace C3M1H1_YouTube_V1.Models
{
    internal class WaterBall : Subscriber
    {
        public override string Name => "水球";

        public override void Behavior(Video video)
        {
            if (video.Length >= TimeSpan.FromMinutes(3))
            {
                video.Like(this.Name);
            }
        }
    }
}
