using C3M1H1_Youtube.interfaces;

namespace C3M1H1_Youtube.Models
{
    internal class Subscriber : ISubscriber
    {
        public string Name { get; private set; }

        public Action<ISubscriber, Video> OnExecute { get; private set; }

        public Subscriber(string name, Action<ISubscriber, Video> onExecute)
        {
            Name = name;
            OnExecute = onExecute;
        }
    }
}
