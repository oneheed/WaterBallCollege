using Microservices.Http;

namespace Microservices.Processor
{
    internal class ServiceDiscoveryProcessor : HttpMessageProcessor
    {
        private Dictionary<string, List<string>> _map = new()
        {
            { "waterballsa.tw", new() { "35.0.0.1", "35.0.0.2", "35.0.0.3" } },
        };

        public ServiceDiscoveryProcessor(IHttpMessage process) : base(process)
        {
        }

        public override HttpResponse Process(HttpRequest httpRequest, List<string> hosts)
        {
            return base.Process(httpRequest,
                _map.Where(m => hosts.Contains(m.Key)).SelectMany(m => m.Value).ToList());
        }
    }
}
