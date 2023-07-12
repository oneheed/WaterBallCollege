// See https://aka.ms/new-console-template for more information

using FriendRelationshipAnalyzer;

var analyzer = new RelationshipAnalyzerAdapter();
var script = File.ReadAllText("Resources/Data.txt");
analyzer.Parse(script);

Console.WriteLine(string.Join(" ", analyzer.GetMutualFriends("B", "C")));
Console.WriteLine(analyzer.HasConnection("A", "Z"));