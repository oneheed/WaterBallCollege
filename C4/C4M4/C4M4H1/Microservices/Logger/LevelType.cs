namespace Microservices.Logger
{
    [Flags]
    internal enum LevelType
    {
        TRACE = 1,

        INFO = 2,

        DEBUG = 4,

        WARN = 8,

        ERROR = 16,
    }
}
