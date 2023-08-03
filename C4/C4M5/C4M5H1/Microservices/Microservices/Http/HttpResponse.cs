namespace Microservices.Http
{
    internal class HttpResponse
    {
        public HttpStatus HttpStatus { get; private set; }

        public HttpResponse(HttpStatus httpStatus)
        {
            HttpStatus = httpStatus;
        }
    }
}
