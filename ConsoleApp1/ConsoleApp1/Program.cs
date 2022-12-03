// See https://aka.ms/new-console-template for more information

using System.Diagnostics;


//ThreadPool.SetMinThreads(2, 2);
//ThreadPool.SetMaxThreads(2, 2);

//Stopwatch watch = new Stopwatch();
//watch.Start();

//long Sum(int i)
//{
//    Console.WriteLine(String.Format("{0}: Task {1}", watch.Elapsed, Thread.CurrentThread.ManagedThreadId));

//    long sum = 0;
//    for (; i > 0; i--)
//        checked { sum += i; }

//    return sum;
//}
//List<Task<long>> tasks = new List<Task<long>>();
////1000000000这个数字会抛出System.AggregateException

//foreach (var item in Enumerable.Range(1, 100))
//{
//    var task = new Task<long>(n => Sum((int)n), 100000);
//    tasks.Add(task);
//    task.Start();
//}

//await Task.WhenAll(tasks);

//foreach (var task in tasks)
//{
//    Console.WriteLine($"Result:{task.Result}");
//}

//ThreadPool.GetMinThreads(out int worker, out int maxThreads);

//Console.WriteLine($"{worker} : {maxThreads}");

//var test = ThreadPool.SetMinThreads(32, 32);
//////ThreadPool.SetMaxThreads(10, 10);

//ThreadPool.GetMinThreads(out worker, out maxThreads);

//Console.WriteLine($"{worker} : {maxThreads}");

//Stopwatch watch = new Stopwatch();
//watch.Start();

//void callback(object index)
//{
//    Console.WriteLine(String.Format("{0}: Task {1} started {2}", watch.Elapsed, index, Thread.CurrentThread.ManagedThreadId));
//    Thread.Sleep(10000);
//    Console.WriteLine(String.Format("{0}: Task {1}  {2}", watch.Elapsed, index, Thread.CurrentThread.ManagedThreadId));
//}

//async Task callback1(object index)
//{
//    Console.WriteLine(String.Format("{0}: Task {1} started {2}", watch.Elapsed, index, Thread.CurrentThread.ManagedThreadId));
//    await Task.Delay(1000);
//    Console.WriteLine(String.Format("{0}: Task {1}  {2}", watch.Elapsed, index, Thread.CurrentThread.ManagedThreadId));
//}

//void callback2(object index)
//{
//    Console.WriteLine(String.Format("{0}: Task {1} started {2}", watch.Elapsed, index, Thread.CurrentThread.ManagedThreadId));
//    Thread.Sleep(10000);
//    Console.WriteLine(String.Format("{0}: Task {1}  {2}", watch.Elapsed, index, Thread.CurrentThread.ManagedThreadId));
//}

//var tasks = new List<Task>();
//for (int i = 0; i < 50; i++)
//{
//    //tasks.Add(Task.Run(() => callback2(i)));

//    tasks.Add(callback1(i));

//    //ThreadPool.QueueUserWorkItem(callback, i);

//    //ThreadPool.QueueUserWorkItem(state => callback(i));
//}

//ThreadPool.SetMinThreads(5, 3);
//ThreadPool.SetMaxThreads(5, 10);

//ManualResetEvent waitHandle = new ManualResetEvent(false);

//Stopwatch stopwatch = new Stopwatch();
//stopwatch.Start();

////WebRequest request = HttpWebRequest.Create("https://www.cnblogs.com/");

////request.BeginGetResponse(ar =>
////{
////    var response = request.EndGetResponse(ar);
////    Console.WriteLine(stopwatch.Elapsed + ": Response Get");
////}, null);

//HttpClient client = new HttpClient();
//await client.GetAsync("https://www.cnblogs.com/")
//    .ContinueWith(ar =>
//    {
//        var test = ar.Result.Content.ReadAsStringAsync();
//        Console.WriteLine(stopwatch.Elapsed + $": Response Get {test.Result}");
//    });


//Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

//// Execute the continuation when the antecedent finishes.
//await taskA.ContinueWith(antecedent => Console.WriteLine($"Today is {antecedent.Result}."));

////for (int i = 0; i < 10; i++)
////{
////    ThreadPool.QueueUserWorkItem(index =>
////    {
////        Console.WriteLine(String.Format("{0}: Task {1} started", stopwatch.Elapsed, index));
////        waitHandle.WaitOne();
////    }, i);
////}

////waitHandle.WaitOne();

////Task.WhenAll(s);

//Console.ReadKey();


//async Task Test()
//{
//    System.Console.WriteLine("Enter Test");
//    await Task.Delay(100);
//    System.Console.WriteLine("Leave Test");
//}

//var task = Test().ContinueWith(
//async (task) =>
//{
//    System.Console.WriteLine("Enter callback");
//    await Task.Delay(2000);
//    System.Console.WriteLine("Leave callback");

//    return 100;
//},
//TaskContinuationOptions.AttachedToParent)
//   .ContinueWith(async (task) =>
//   {
//       var reaut = await await task;
//       System.Console.WriteLine($"Enter callback {reaut}");
//       await Task.Delay(1000);
//       System.Console.WriteLine($"Leave callback {reaut}");
//   }, TaskContinuationOptions.AttachedToParent);

//await task.Result;
//Console.WriteLine("Done with test");

async Task Test()
{
    System.Console.WriteLine("Enter Test");
    await Task.Delay(1000);
    System.Console.WriteLine("Leave Test");
}

var task = Test().ContinueWith(
async (task) =>
{
    System.Console.WriteLine("Enter callback");
    await Task.Delay(1000);
    System.Console.WriteLine("Leave callback");
},
TaskContinuationOptions.AttachedToParent);

await await task;

Console.WriteLine("Done with test");

Console.ReadKey();