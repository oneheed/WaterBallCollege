namespace C3M1H1_YouTube_V1.Models
{
    internal class Channel
    {
        private readonly IList<Subscriber> _observers = new List<Subscriber>();

        private readonly IList<Video> _videos = new List<Video>();

        public string Name { get; private set; }

        public Channel(string name)
        {
            Name = name;
        }

        public void Subscribe(Subscriber subscriber)
        {
            _observers.Add(subscriber);

            Console.WriteLine($"{subscriber.Name} 訂閱了 {this.Name}。");
        }

        public void Unsubscripted(Subscriber subscriber)
        {
            _observers.Remove(subscriber);

            Console.WriteLine($"{subscriber.Name} 解除訂閱了 {this.Name}。");
        }

        public void Upload(Video video)
        {
            Console.WriteLine($"頻道 {this.Name} 上架了一則新影片 \"{video.Title}\"。");

            video.SetChannel(this);

            _videos.Add(video);

            Notify(video);
        }

        private void Notify(Video video)
        {
            foreach (var observer in this._observers.ToList())
            {
                observer.Behavior(video);
            }
        }
    }
}
