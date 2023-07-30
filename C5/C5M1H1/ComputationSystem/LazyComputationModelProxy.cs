namespace ComputationSystem
{
    internal class LazyComputationModelProxy : IModel
    {
        private readonly ComputationModels _computationModels;

        private readonly string _modelName;

        private readonly static Dictionary<string, IModel> _models = new();

        private readonly static object _lock = new();

        public LazyComputationModelProxy(ComputationModels models, string modelName)
        {
            _computationModels = models;
            _modelName = modelName;
        }

        private IModel LazyInstance()
        {
            var model = default(IModel);

            lock (_lock)
            {
                if (!_models.TryGetValue(_modelName, out model))
                {
                    model = _computationModels.CreateModel(_modelName);
                    _models.TryAdd(_modelName, model);
                }
            }

            return model;
        }

        public double[,] Calculate(double[,] target)
        {
            return LazyInstance().Calculate(target);
        }
    }
}
