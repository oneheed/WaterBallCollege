// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using ComputationSystem;

var target = new double[1000, 1000];
for (var i = 0; i < target.GetLongLength(0); i++)
{
    for (var j = 0; j < target.GetLongLength(1); j++)
    {
        target[i, j] = 1.0;
    }
}

var stopWatch = new Stopwatch();

stopWatch.Start();

var tasks = new List<Task>();
var models = new List<IModel>();
for (var i = 0; i < 10; i++)
{
    tasks.Add(Task.Run(() =>
    {
        var reflection = new ComputationModels().CreateModel("Reflection");
        models.Add(reflection);
        var reflectionResult = reflection.Calculate(target);
        //reflectionResult.Print();
    }));
}

await Task.WhenAll(tasks);
Console.WriteLine(models[3].Equals(models[4]));
Console.WriteLine(models[0].Source.Equals(models[1].Source));
stopWatch.Stop();

Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000);