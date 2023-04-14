using System;
using System.Threading;
using System.Threading.Tasks;

static class Program
{
    static bool isSignaled = false;

    static async Task Main(string[] args)
    {
        Console.WriteLine("Main Method Started");

        var task1 = Task.Run(async () =>
        {
            Console.WriteLine("Task 1 started");
            Console.WriteLine("Task 1 waiting for signal");
            while (!isSignaled)
            {
                await Task.Delay(100);
            }
            Console.WriteLine("Task 1 received signal");
            // Do work here
        });

        var task2 = Task.Run(() =>
        {
            Console.WriteLine("Task 2 started");
            // Do work here
            Console.WriteLine("Task 2 completed work");
            isSignaled = true;
            Console.WriteLine("Task 2 signaled Task 1");
        });

        await Task.WhenAll(task1, task2);

        Console.WriteLine("Main Method Completed");
        Console.ReadKey();
    }
}
