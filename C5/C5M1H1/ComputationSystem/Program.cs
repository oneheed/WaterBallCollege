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
for (var i = 0; i < 10; i++)
{
    tasks.Add(Task.Run(() =>
    {
        var models = new LazyComputationModelsProxy();
        var model = models.CreateModel("Reflection");
        var result = model.Calculate(target);
        //result.Print();
    }));
}

await Task.WhenAll(tasks);
stopWatch.Stop();

Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000);