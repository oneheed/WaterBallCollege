// See https://aka.ms/new-console-template for more information
// 定義根日誌器
using LoggingFramework.Exporter;

internal class FileExporter : IExporter
{
    private readonly string _fileName;

    public FileExporter(string fileName)
    {
        this._fileName = fileName;
    }

    public void Export(string message)
    {
        File.AppendAllLines(_fileName, new List<string> { message });
    }
}