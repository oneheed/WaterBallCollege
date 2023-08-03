using Microservices.Http;

namespace Microservices
{
    internal class FakeHttpClient : IHttpMessage
    {
        public HttpResponse SendRequest(HttpRequest httpRequest)
        {
            var result = new Random().Next(10) <= 6 ? HttpStatus.Success : HttpStatus.Fail;

            Console.WriteLine($"{httpRequest.Url} {result}");

            return new HttpResponse(result);
        }
    }
}
