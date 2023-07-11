using System.Text;

namespace ComputationSystem
{
    internal class ComputationModel : IModel
    {
        private readonly IModels models;

        private readonly string modelName;

        private double[,] _source;

        public double[,] Source => this._source;

        private readonly static object _lock = new();

        public ComputationModel(IModels models, string modelName)
        {
            this.models = models;
            this.modelName = modelName;
        }

        public double[,] Calculate(double[,] target)
        {
            lock (_lock)
            {
                if (_source == null)
                {
                    _source = this.models.LazyLoad(modelName);
                }
            }

            var targetRowCount = target.GetLength(0);
            var targetColCount = target.GetLength(1);
            var sourceRowCount = _source.GetLength(0);
            var sourceColCount = _source.GetLength(0);

            var result = new double[targetRowCount, sourceColCount];

            if (targetColCount != sourceRowCount)
            {
                Console.WriteLine("Matrixes can't be multiplied!!");
            }
            else
            {
                for (var i = 0; i < targetRowCount; i++)
                {
                    for (var j = 0; j < sourceColCount; j++)
                    {
                        var sum = 0.0;
                        for (var k = 0; k < targetColCount; k++)
                        {
                            sum += target[i, k] * _source[k, j];
                        }
                        result[i, j] = sum;
                    }
                }
            }

            return result;
        }

        public double[,] ParallelCalculate(double[,] target)
        {
            if (_source == null)
            {
                _source = this.models.LazyLoad(modelName);
            }

            var targetRowCount = target.GetLength(0);
            var targetColCount = target.GetLength(1);
            var sourceRowCount = _source.GetLength(0);
            var sourceColCount = _source.GetLength(0);

            var result = new double[targetRowCount, sourceColCount];
            var options = new ParallelOptions { MaxDegreeOfParallelism = 4 };
            if (targetColCount != sourceRowCount)
            {
                Console.WriteLine("Matrixes can't be multiplied!!");
            }
            else
            {
                for (var i = 0; i < targetRowCount; i++)
                {
                    Parallel.For(0, sourceColCount, options, j =>
                    {
                        var sum = 0.0;
                        for (var k = 0; k < targetColCount; k++)
                        {
                            sum += target[i, k] * _source[k, j];
                        }
                        result[i, j] = sum;
                    });
                }
            }

            return result;
        }
    }


    internal static class ComputationModelExtension
    {
        public static void Print(this double[,] target)
        {
            var rowBuilder = new StringBuilder();

            for (var i = 0; i < target.GetLength(0); i++)
            {
                var colBuilder = new StringBuilder();
                for (var j = 0; j < target.GetLength(1); j++)
                {
                    colBuilder.Append($"{target[i, j]} ");
                }

                rowBuilder.AppendLine(colBuilder.ToString());
            }

            Console.WriteLine(rowBuilder.ToString());
        }
    }
}
