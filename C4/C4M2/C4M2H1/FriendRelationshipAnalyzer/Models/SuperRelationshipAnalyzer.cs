namespace FriendRelationshipAnalyzer.Models
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

        public bool IsMutualFriend(string targetName, string name1, string name2)
        {
            return _friendsData[name1].Contains(targetName) &&
                _friendsData[name2].Contains(targetName);
        }

        private void AddFriendsData(string target, string name)
        {
            if (!_friendsData.ContainsKey(target))
            {
                _friendsData[target] = new List<string>
                {
                    name,
                };
            }
            else
            {
                _friendsData[target].Add(name);
            }
        }
    }
}
