namespace C3M1H1_Youtube.Models
{
    internal class Video
    {
        private Channel? _channel;

        public string Title { get; private set; }

        public string Description { get; private set; }

        public TimeSpan Length { get; private set; }

        public Video(string title, string description, TimeSpan length)
        {
            Title = title;
            Description = description;
            Length = length;
        }

        public void SetChannel(Channel channel)
        {
            _channel = channel;
        }

        public Channel GetChannel()
        {
            return _channel!;
        }

        public void Like(string name)
        {
            Console.WriteLine($"{name} 對影片 \"{this.Title}\" 按讚。");
        }
    }
}