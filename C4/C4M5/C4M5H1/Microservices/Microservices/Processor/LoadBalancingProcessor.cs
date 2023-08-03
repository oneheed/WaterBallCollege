using Microservices.Http;

namespace Microservices.Processor
{
    internal class LoadBalancingProcessor : HttpMessageProcessor
    {
        private Dictionary<string, DateTime> _map = new();

        public LoadBalancingProcessor(IHttpMessage process) : base(process)
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

            var result = base.Process(httpRequest, hosts);

            if (result.HttpStatus == HttpStatus.Fail)
            {
                _map[host] = DateTime.UtcNow.AddMinutes(10);
            }

            return result;
        }
    }
}
