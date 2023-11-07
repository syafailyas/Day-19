using System.Security.AccessControl;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreDemo
{
	class Program
	{
		public static Semaphore semaphore = new Semaphore(2, 5);

		static async Task Main()
		{
			Task[] tasks = new Task[10];
			for (int i = 1; i <= 10; i++)
			{
				int taskId = i;
				tasks[i - 1] = Task.Run( () =>  DoSomeTask(taskId, i));
			}

			await Task.WhenAll(tasks);
			Console.WriteLine("All task finished");
		}

		static async void DoSomeTask(int taskId, int index)
		{
			Console.WriteLine($"Task {taskId} Wants to Enter");
			try
			{   
				semaphore.WaitOne();
				Console.WriteLine("Success: Task " + taskId + " is Doing its work");
				await Task.Delay(5000);
				Console.WriteLine($"Task {taskId} Exit.");
			}
			finally
			{
				if (index == 2) 
				{
					semaphore.Release();
				}
				else 
				{
					semaphore.Release();
				}
			}
		}
	}
}
