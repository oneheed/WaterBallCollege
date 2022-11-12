namespace C4M2H1
{
    internal interface IRelationshipAnalyzer
    {
        void Parse(string script);

        IEnumerable<string> GetMutualFrineds(string name1, string name2);
    }
}
