namespace Microservices
{
    internal class FakeHttpClient : IHttpMessage
    {
        public string Process(List<string> urls)
        {
            throw new NotImplementedException();
        }

        public string SendRequest(HttpRequest httpRequest)
        {
            var test = new Random().Next(2);
            var result = test == 1 ? "Success" : "Fail";

            return result;
        }
    }
}
