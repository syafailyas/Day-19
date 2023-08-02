using System;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreDemo
{
    class Program
    {
        public static Semaphore semaphore = new Semaphore(1, 4);

        static async Task Main()
        {
            Task[] tasks = new Task[10];

            for (int i = 1; i <= 10; i++)
            {
                int taskId = i;
                tasks[i - 1] = Task.Run(() => DoSomeTask(taskId));
            }

            await Task.WhenAll(tasks);
            Console.ReadKey();
        }

        static void DoSomeTask(int taskId)
        {
            Console.WriteLine($"Task {taskId} Wants to Enter into Critical Section for processing");
            try
            {   
                semaphore.WaitOne();
                Console.WriteLine("Success: Task " + taskId + " is Doing its work");
                Thread.Sleep(5000);
                Console.WriteLine($"Task {taskId} Exit.");
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
