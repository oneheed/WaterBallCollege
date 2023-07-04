namespace C3M1H1_YouTube_V1.Models
{
    internal class FireBall : Subscriber
    {
        public override string Name => "火球";

        public override void Behavior(Video video)
        {
            if (video.Length <= TimeSpan.FromMinutes(1))
            {
                video.GetChannel().Unsubscripted(this);
            }
        }
    }
}
