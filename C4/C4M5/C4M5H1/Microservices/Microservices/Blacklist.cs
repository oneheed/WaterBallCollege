namespace Microservices
{
    internal class BlacklistProcessor : HttpMessageProcessor
    {
        private List<string> _map = new()
        {
            //"35.0.0.3",
        };

        public BlacklistProcessor(IHttpMessage process) : base(process)
        {
        }

        public override string Process(List<string> urls)
        {
            if (urls.TrueForAll(url => _map.Contains(url)))
            {
                throw new ArgumentOutOfRangeException(nameof(urls), "Black List");
            }

            return base.Process(urls);
        }
    }
}
