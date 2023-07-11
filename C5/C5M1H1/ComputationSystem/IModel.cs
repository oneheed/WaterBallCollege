namespace ComputationSystem
{
    internal interface IModel
    {
        double[,] Calculate(double[,] target);

        double[,] ParallelCalculate(double[,] target);

        double[,] Source { get; }
    }
}
