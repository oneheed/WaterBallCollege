using LoggingFramework.Loggers;

namespace LoggingFramework.Layouts
{
    internal interface ILayout
    {
        string Format(LevelType levelType, string name, string message);
    }
}