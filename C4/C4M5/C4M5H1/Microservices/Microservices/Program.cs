// See https://aka.ms/new-console-template for more information
using Microservices;
using Microservices.Http;
using Microservices.Processor;

var processor = new ServiceDiscoveryProcessor(
    new LoadBalancingProcessor(
        new BlacklistProcessor(
            new FakeHttpClient())));

//var processor = new BlacklistProcessor(
//    new LoadBalancingProcessor(
//        new ServiceDiscoveryProcessor(
//            new FakeHttpClient())));

try
{
    for (int i = 0; i < 10; i++)
    {
        processor.SendRequest(new HttpRequest(HttpMethod.Get, "http://waterballsa.tw/world"));
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
