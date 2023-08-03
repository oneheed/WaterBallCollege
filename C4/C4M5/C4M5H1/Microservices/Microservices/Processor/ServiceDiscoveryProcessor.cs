using Microservices.Http;

namespace Microservices.Processor
{
    internal class ServiceDiscoveryProcessor : HttpMessageProcessor
    {
        private readonly Dictionary<string, List<string>> _map = new()
        {
            { "waterballsa.tw", new() { "35.0.0.1", "35.0.0.2", "35.0.0.3" } },
        };

        private readonly Dictionary<string, DateTime> _invalidMap = new();

        public ServiceDiscoveryProcessor(IHttpClient process) : base(process)
        {
        }

        public override HttpResponse Process(HttpRequest httpRequest, List<string> hosts)
        {
            var mapHosts = _map.Where(m => hosts.Contains(m.Key)).SelectMany(m => m.Value).ToList();

            mapHosts.ForEach(u => _invalidMap.TryAdd(u, default));
            var supportHosts = _invalidMap
                .Where(m => mapHosts.Contains(m.Key) && m.Value < DateTime.UtcNow)
                .Select(s => s.Key).ToList();

            var result = base.Process(httpRequest, supportHosts);

            if (result.HttpStatus == HttpStatus.Fail)
            {
                _invalidMap[httpRequest.Host] = DateTime.UtcNow.AddMinutes(10);
            }

            return result;
        }
    }
}
