namespace FriendRelationshipAnalyzer.Interfaces
{
    internal interface IRelationshipGraph
    {
        bool HasConnection(string name1, string name2);
    }
}
