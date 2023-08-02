// See https://aka.ms/new-console-template for more information
// 定義根日誌器
using LoggingFramework.Exporter;

internal class ConsoleExporter : IExporter
{
    public void Export(string message)
    {
        Console.WriteLine(message);
    }
}