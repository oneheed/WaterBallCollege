namespace Microservices.Exporter
{
    internal interface IExporter
    {
        void Export(string message);
    }
}