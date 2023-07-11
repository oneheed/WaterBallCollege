namespace ComputationSystem
{
    internal interface IModels
    {
        IModel CreateModel(string modelName);

        double[,] LazyLoad(string modelName);
    }
}
