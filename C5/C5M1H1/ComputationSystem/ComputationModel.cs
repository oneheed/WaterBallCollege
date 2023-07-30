using System.Text;

namespace ComputationSystem
{
    internal class ComputationModel : IModel
    {
        public double[,] Source { get; private set; }

        public ComputationModel(double[,] source)
        {
            this.Source = source;
        }

        public double[,] Calculate(double[,] target)
        {
            var targetRowCount = target.GetLength(0);
            var targetColCount = target.GetLength(1);
            var sourceRowCount = this.Source.GetLength(0);
            var sourceColCount = this.Source.GetLength(1);

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
                            sum += target[i, k] * this.Source[k, j];
                        }

                        result[i, j] = sum;
                    }
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
