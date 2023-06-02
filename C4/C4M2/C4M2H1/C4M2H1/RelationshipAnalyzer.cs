namespace C4M2H1
{
    internal class RelationshipAnalyzer : IRelationshipAnalyzer
    {
        private readonly Dictionary<string, List<string>> _friendsData = new();

        public void Parse(string script)
        {
            foreach (var item in script.Split("\r\n"))
            {
                var key = item.Split(':');
                _friendsData[key[0]] = key[1].Trim().Split(" ").ToList();
            }
        }

        public IEnumerable<string> GetMutualFriends(string name1, string name2)
        {
            return _friendsData[name1].Intersect(_friendsData[name2]);
        }
    }
}
