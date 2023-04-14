using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main Method Started");

            var result = await OnlyOneAsync();

            Console.WriteLine($"Result : {result}");

            Console.WriteLine("Main Method Completed");
            Console.ReadKey();
        }

        public static async Task<string> OnlyOneAsync()
        {
            Console.WriteLine("OnlyOne Method Started");

            var tasks = new[]
            {
                LongRunningTaskAsync(),
                LongRunningTaskAsync(),
                LongRunningTaskAsync()
            };

            var firstCompletedTask = await Task.WhenAny(tasks);
            await Task.WhenAll(tasks);

            Console.WriteLine("OnlyOne Method Completed");
            return firstCompletedTask.Result;
        }

        public static async Task<string> LongRunningTaskAsync()
        {
            Console.WriteLine("LongRunningTask Started");
            await Task.Delay(3000);
            Console.WriteLine("LongRunningTask Completed");
            return "LongRunningTask Result";
        }
    }
}
