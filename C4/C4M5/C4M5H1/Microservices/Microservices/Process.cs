namespace Microservices
{
    internal abstract class HttpMessageProcessor : IHttpMessage
    {
        private readonly IHttpMessage? next;

        protected HttpMessageProcessor(IHttpMessage process)
        {
            this.next = process;
        }

        public virtual string Process(List<string> urls)
        {
            if (urls.Any() && next is HttpMessageProcessor temp)
            {
                return temp.Process(urls);
            }
            else if (urls.Any() && next != null)
            {
                return next.SendRequest(new HttpRequest { Url = urls[0] });
            }

            throw new ArgumentOutOfRangeException(nameof(urls), "Not mapping");
        }

        public string SendRequest(HttpRequest httpRequest)
        {
            return Process(new List<string> { httpRequest.Url });
        }
    }

    internal interface IHttpMessage
    {
        string SendRequest(HttpRequest httpRequest);
    }
}