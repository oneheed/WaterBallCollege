namespace Microservices
{
    internal class LoadBalancingProcessor : HttpMessageProcessor
    {
        private Dictionary<string, DateTime> _map = new();

        public LoadBalancingProcessor(HttpMessageProcessor process) : base(process)
        {
        }

        public override string Process(List<string> urls)
        {
            urls.ForEach(u => _map.TryAdd(u, default));

            var url = _map
                .Where(m => urls.Contains(m.Key) && m.Value < DateTime.UtcNow)
                .OrderBy(m => m.Value).FirstOrDefault().Key;

            var temp = new List<string>();
            if (url != null)
            {
                _map[url] = DateTime.UtcNow;
                temp.Add(url);
            }

            var result = base.Process(temp);

            if (result == "Fail")
            {
                Console.WriteLine($"{url} Fail");
                _map[url] = DateTime.UtcNow.AddMinutes(10);
            }
            else
            {
                Console.WriteLine($"{url}");
            }

            return result;
        }
    }
}
