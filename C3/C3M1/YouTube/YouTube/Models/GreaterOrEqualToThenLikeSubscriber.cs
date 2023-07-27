using C3M1H1_YouTube.Interfaces;

namespace C3M1H1_YouTube.Models
{
    internal class GreaterOrEqualToThenLikeSubscriber : ISubscriber
    {
        public string Name { get; private set; }

        public TimeSpan Condition { get; private set; }

        public GreaterOrEqualToThenLikeSubscriber(string name, TimeSpan condition)
        {
            Name = name;
            Condition = condition;
        }

        public void Behavior(Video video)
        {
            if (video.Length >= this.Condition)
            {
                video.Like(this);
            }
        }
    }
}
