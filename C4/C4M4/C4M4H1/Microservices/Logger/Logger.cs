using Microservices.Exporter;
using Microservices.Layout;

namespace Microservices.Logger
{
    internal class Logger
    {
        private static readonly Dictionary<string, Logger> _loggers = new();

        public LevelType LevelThreshold { get; private set; }

        public Logger ParentLogger { get; private set; }

        public string Name { get; private set; }

        private readonly IExporter _exporter;

        private readonly ILayout _layout;

        public Logger(LevelType levelThreshold, Logger parent = null, string name = "root", IExporter exporter = null, ILayout layout = null)
        {
            this.LevelThreshold = levelThreshold;
            this.ParentLogger = parent;
            this.Name = name;
            this._exporter = exporter;
            this._layout = layout;
        }

        public void Trace(string message) => Write(LevelType.TRACE, message);

        public void Info(string message) => Write(LevelType.INFO, message);

        public void Debug(string message) => Write(LevelType.DEBUG, message);

        public void Warn(string message) => Write(LevelType.WARN, message);

        public void Error(string message) => Write(LevelType.ERROR, message);

        private void Write(LevelType levelType, string message)
        {
            var layout = _layout ?? this.ParentLogger._layout;
            var exporter = _exporter ?? this.ParentLogger._exporter;

            if (levelType >= LevelThreshold)
            {
                var convertMessage = layout.Format(levelType, this.Name, message);

                exporter.Export(convertMessage);
            }
        }

        public static Logger? GetLogger(string loggerName)
        {
            return _loggers.TryGetValue(loggerName, out var logger) ? logger : default;
        }

        public static void DeclareLoggers(params Logger[] loggers)
        {
            foreach (var logger in loggers)
            {
                _loggers.TryAdd(logger.Name, logger);
            }
        }
    }
}