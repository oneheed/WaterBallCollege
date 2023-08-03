namespace Microservices.Http
{
    internal interface IHttpMessage
    {
        HttpResponse SendRequest(HttpRequest httpRequest);
    }
}
