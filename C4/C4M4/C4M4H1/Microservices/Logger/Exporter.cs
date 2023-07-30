namespace Microservices.Logger
{
    internal interface IExporter
    {
        void Export(string message);
    }
}