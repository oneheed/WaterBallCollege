// See https://aka.ms/new-console-template for more information
// 定義根日誌器
using LoggingFramework.Layouts;
using LoggingFramework.Loggers;

internal class StandardLayout : ILayout
{
    public string Format(LevelType levelType, string name, string message)
    {
        return $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} |-{levelType} {name} - {message}";
    }
}