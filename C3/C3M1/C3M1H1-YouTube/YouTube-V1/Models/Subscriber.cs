namespace C3M1H1_YouTube_V1.Models
{
    internal abstract class Subscriber
    {
        public virtual string Name { get; private set; }

        public abstract void Behavior(Video video);
    }
}
