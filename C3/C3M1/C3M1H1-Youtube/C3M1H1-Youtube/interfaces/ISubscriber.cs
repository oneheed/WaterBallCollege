using C3M1H1_Youtube.Models;

namespace C3M1H1_Youtube.interfaces
{
    internal interface ISubscriber
    {
        string Name { get; }

        Action<ISubscriber, Video> OnExecute { get; }

        public void Execute(Video video)
        {
            OnExecute(this, video);
        }
    }
}