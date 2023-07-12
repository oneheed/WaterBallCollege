namespace FriendRelationshipAnalyzer.Interfaces
{
    internal interface IRelationshipAnalyzer
    {
        void Parse(string script);

        IEnumerable<string> GetMutualFriends(string name1, string name2);
    }
}
