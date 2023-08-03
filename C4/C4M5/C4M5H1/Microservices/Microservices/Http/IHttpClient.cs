namespace Microservices.Http
{
    internal interface IHttpClient
    {
        HttpResponse SendRequest(HttpRequest httpRequest);
    }
}
