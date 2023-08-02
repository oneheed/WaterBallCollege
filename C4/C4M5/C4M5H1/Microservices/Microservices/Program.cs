// See https://aka.ms/new-console-template for more information
using Microservices;

var processor = new ServiceDiscoveryProcessor(
    new LoadBalancingProcessor(
        new BlacklistProcessor(
            new FakeHttpClient())));


try
{
    for (int i = 0; i < 10; i++)
    {
        processor.SendRequest(new HttpRequest { Url = "waterballsa.tw" });
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
