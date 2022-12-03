// See https://aka.ms/new-console-template for more information

using C4M2H1;

var analyzer = new RelationshipAnalyzerAdapter();
var script = File.ReadAllText("Resources/Data.txt");
analyzer.Parse(script);
Console.WriteLine(string.Join(" ", analyzer.GetMutualFrineds("B", "C")));
Console.WriteLine(analyzer.HasConnection("A", "Z"));