namespace C4M2H1
{
    internal class SuperRelationshipAnalyzer
    {
        private readonly Dictionary<string, List<string>> _friendsData = new();

        public void Init(string script)
        {
            foreach (var item in script.Split("\r\n"))
            {
                var key = item.Split(" -- ");
                AddFriendsData(key[0], key[1]);
                AddFriendsData(key[1], key[0]);
            }
        }

        public bool IsMutualFrined(string targetName, string name1, string name2)
        {
            return _friendsData[name1].Any(f => f.Equals(targetName)) &&
                _friendsData[name2].Any(f => f.Equals(targetName));
        }

        private void AddFriendsData(string traget, string name)
        {
            if (!_friendsData.ContainsKey(traget))
            {
                _friendsData[traget] = new List<string>();
                _friendsData[traget].Add(name);
            }
            else
            {
                _friendsData[traget].Add(name);
            }
        }
    }
}
