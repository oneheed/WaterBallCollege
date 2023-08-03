using Microservices.Http;

namespace Microservices.Processor
{
    internal class LoadBalancingProcessor : HttpMessageProcessor
    {
        private readonly Dictionary<string, DateTime> _map = new();

        public LoadBalancingProcessor(IHttpClient process) : base(process)
        {
        }

        public override HttpResponse Process(HttpRequest httpRequest, List<string> hosts)
        {
            hosts.ForEach(u => _map.TryAdd(u, default));
            var host = _map
                .Where(m => hosts.Contains(m.Key) && m.Value < DateTime.UtcNow)
                .OrderBy(m => m.Value).FirstOrDefault().Key;

            hosts = new List<string>();
            if (host != null)
            {
                _map[host] = DateTime.UtcNow;
                hosts.Add(host);
            }

            return base.Process(httpRequest, hosts);
        }
    }
}
