namespace ComputationSystem
{
    internal class ComputationModels : IModels
    {
        private readonly static Dictionary<string, IModel> _models = new();

        private readonly static object _lock = new();

        public IModel? CreateModel(string modelName)
        {
            lock (_lock)
            {
                if (_models.TryGetValue(modelName, out var model))
                {
                    return model;
                }
                else
                {
                    model = new ComputationModel(this, modelName);
                    _models.TryAdd(modelName, model);

                    return model;
                }
            }
        }

        public double[,] LazyLoad(string modelName)
        {
            var filePath = $"Resources\\{modelName}.mat";
            if (File.Exists(filePath))
            {
                var rows = File.ReadAllLines(filePath);
                var data = rows.Select(r => r.Split(" ").Select(double.Parse).ToArray()).ToArray();
                var matrix = new double[data.Length, data.Max(col => col.Length)];

                for (var i = 0; i < matrix.GetLongLength(0); i++)
                {
                    for (var j = 0; j < matrix.GetLongLength(1); j++)
                    {
                        matrix[i, j] = data[i][j];
                    }
                }

                return matrix;
            }

            return default;
        }
    }
}
