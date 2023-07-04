using C3M1H1_YouTube.Models;

namespace C3M1H1_YouTube.Interfaces
{
    internal interface ISubscriber
    {
        string Name { get; }

        TimeSpan Condition { get; }

        abstract void Behavior(Video video);
    }
}