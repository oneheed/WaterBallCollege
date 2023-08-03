using Microservices.Http;

namespace Microservices.Processor
{
    internal abstract class HttpMessageProcessor : IHttpClient
    {
        private readonly IHttpClient? next;

        protected HttpMessageProcessor(IHttpClient process)
        {
            next = process;
        }

        public virtual HttpResponse Process(HttpRequest httpRequest, List<string> hosts)
        {
            if (hosts.Any() && next is HttpMessageProcessor temp)
            {
                return temp.Process(httpRequest, hosts);
            }
            else if (hosts.Any() && next != null)
            {
                httpRequest!.Host = hosts[0];
                return next.SendRequest(httpRequest);
            }

            throw new ArgumentOutOfRangeException(nameof(hosts), "Not mapping");
        }

        public HttpResponse SendRequest(HttpRequest httpRequest)
        {
            return Process(httpRequest, new List<string> { httpRequest.Host });
        }
    }
}