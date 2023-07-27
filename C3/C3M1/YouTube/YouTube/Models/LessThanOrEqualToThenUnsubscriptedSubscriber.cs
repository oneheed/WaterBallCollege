using C3M1H1_YouTube.Interfaces;

namespace C3M1H1_YouTube.Models
{
    internal class LessThanOrEqualToThenUnsubscriptedSubscriber : ISubscriber
    {
        public string Name { get; private set; }

        public TimeSpan Condition { get; private set; }

        public LessThanOrEqualToThenUnsubscriptedSubscriber(string name, TimeSpan condition)
        {
            Name = name;
            Condition = condition;
        }

        public void Behavior(Video video)
        {
            if (video.Length <= this.Condition)
            {
                video.GetChannel().Unsubscripted(this);
            }
        }
    }
}
