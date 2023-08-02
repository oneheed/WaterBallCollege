namespace Microservices
{
    internal class ServiceDiscoveryProcessor : HttpMessageProcessor
    {
        private Dictionary<string, List<string>> _map = new()
        {
            { "waterballsa.tw", new() { "35.0.0.1", "35.0.0.2", "35.0.0.3" } },
        };

        public ServiceDiscoveryProcessor(HttpMessageProcessor process) : base(process)
        {
        }

        public override string Process(List<string> urls)
        {
            return base.Process(
                _map.Where(m => urls.Contains(m.Key)).SelectMany(m => m.Value).ToList());
        }
    }
}
