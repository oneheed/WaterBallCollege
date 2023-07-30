// See https://aka.ms/new-console-template for more information
// 定義根日誌器
using Microservices.Logger;

internal class CompositeExporter : IExporter
{
    private readonly IList<IExporter> _exporters = new List<IExporter>();

    public CompositeExporter(params IExporter[] exporters)
    {
        Array.ForEach(exporters, _exporters.Add);
    }

    public void Export(string message)
    {
        foreach (var exporter in _exporters)
        {
            exporter.Export(message);
        }
    }
}