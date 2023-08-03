using Microservices.Http;

namespace Microservices
{
    internal class FakeHttpClient : IHttpClient
    {
        public HttpResponse SendRequest(HttpRequest httpRequest)
        {
            var result = new Random().Next(10) <= 6 ? HttpStatus.Success : HttpStatus.Fail;

            Console.WriteLine($"[{result}] {httpRequest.Url}");

            return new HttpResponse(result);
        }
    }
}
