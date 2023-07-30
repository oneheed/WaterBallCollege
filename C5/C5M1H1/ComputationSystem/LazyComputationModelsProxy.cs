namespace ComputationSystem
{
    internal class LazyComputationModelsProxy : IModels
    {
        public IModel CreateModel(string modelName)
        {
            return new LazyComputationModelProxy(ComputationModels.Instance, modelName);
        }
    }
}
