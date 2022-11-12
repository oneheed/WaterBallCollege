// See https://aka.ms/new-console-template for more information

using C4M2H1;

var analyzer = new RelationshipAnalyzer();
var script = File.ReadAllText("Resources/Data.txt");

analyzer.Parse(script);

foreach (var item in analyzer.GetMutualFrineds("A", "B"))
{
    Console.WriteLine(item);
}