using Microservices.Http;

namespace Microservices.Processor
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

        public override HttpResponse Process(HttpRequest httpRequest, List<string> hosts)
        {
            if (hosts.TrueForAll(url => _map.Contains(url)))
            {
                throw new ArgumentOutOfRangeException(nameof(hosts), "Black List");
            }

            return base.Process(httpRequest, hosts);
        }
    }
}
