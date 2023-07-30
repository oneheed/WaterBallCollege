namespace ComputationSystem
{
    internal class ComputationModels : IModels
    {
        public static ComputationModels Instance { get; } = new();

        private ComputationModels()
        {
            Console.WriteLine($"Create {nameof(ComputationModels)} models");
        }

        public IModel CreateModel(string modelName)
        {
            var matrix = Load(modelName);

            return new ComputationModel(matrix);
        }

        private double[,] Load(string modelName)
        {
            Console.WriteLine($"Create {modelName} model");

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
