using Microservices.Exporter;
using Microservices.Layout;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microservices.Logger
{
    internal class Logger
    {
        private static readonly Dictionary<string, Logger> _loggers = new();

        public LevelType LevelThreshold { get; private set; }

        public Logger? ParentLogger { get; private set; }

        public string Name { get; private set; }

        private readonly IExporter? _exporter;

        private readonly ILayout? _layout;

        public Logger(LevelType levelThreshold, Logger? parent = null, string name = "root", IExporter? exporter = null, ILayout? layout = null)
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
            var layout = _layout ?? this.ParentLogger!._layout;
            var exporter = _exporter ?? this.ParentLogger!._exporter;

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

        public static void GenerateFormConfig(string fileName)
        {
            var json = File.ReadAllText(fileName);
            var jsonObject = JsonConvert.DeserializeObject<JObject>(json);

            var loggerObjects = jsonObject["loggers"];

            GenerateLogger(null, "root", (JObject)loggerObjects);
        }

        private static void GenerateLogger(Logger? parent, string name, JObject? loggerObjects)
        {
            var currentName = name;
            LevelType levelThreshold = LevelType.TRACE;
            IExporter? exporter = default;
            ILayout? layout = default;


            JObject? next = default;

            foreach (var loggerObject in loggerObjects)
            {
                switch (loggerObject.Key)
                {
                    case "levelThreshold":
                        levelThreshold = Enum.TryParse(typeof(LevelType), loggerObject.Value!.ToString(), true, out var templevel) ? (LevelType)templevel! : LevelType.TRACE;
                        break;

                    case "exporter":
                        exporter = GenerateExporter((JObject)loggerObject.Value!);
                        break;

                    case "layout":
                        layout = GenerateLayout(loggerObject.Value!.ToString());
                        break;

                    default:
                        name = loggerObject.Key;
                        next = (JObject)loggerObject.Value!;
                        break;
                }
            }

            var current = new Logger(levelThreshold, parent, currentName, exporter, layout);
            if (next != null)
            {
                GenerateLogger(current, name, next);
            }

            _loggers.TryAdd(current.Name, current);
        }

        private static IExporter? GenerateExporter(JObject? exporterObjects)
        {
            var name = exporterObjects!["type"]!.ToString();
            switch (name)
            {
                case "console":

                    return new ConsoleExporter();

                case "file":
                    var fileName = exporterObjects!["fileName"]!.ToString();

                    return new FileExporter(fileName);

                case "composite":
                    var exporters = (JArray)exporterObjects!["children"]!;
                    var list = new List<IExporter>();
                    foreach (var item in exporters)
                    {
                        var exporter = GenerateExporter((JObject)item);

                        if (exporter != null)
                        {
                            list.Add(exporter);
                        }
                    }

                    return new CompositeExporter(list.ToArray());

                default:
                    return default;
            }
        }

        private static ILayout? GenerateLayout(string name)
        {
            switch (name)
            {
                case "standard":

                    return new StandardLayout();

                default:
                    return default;
            }
        }
    }
}