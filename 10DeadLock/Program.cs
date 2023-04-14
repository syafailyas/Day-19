using System;
using System.Threading.Tasks;

static class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Main Method Started");
		Task task1 = null;
        Task task2 = null;
        task1 = Task.Run(async () =>
		{
			Console.WriteLine("Task 1 started");
			await Task.Delay(1000);

			Console.WriteLine("Task 1 waiting for Task 2");
			await task2;

			Console.WriteLine("Task 1 completed");
		});

		task2 = Task.Run(async () =>
		{
			Console.WriteLine("Task 2 started");
			await Task.Delay(1000);

			Console.WriteLine("Task 2 waiting for Task 1");
			await task1;

			Console.WriteLine("Task 2 completed");
		});

		Task.WaitAll(task1, task2);

		Console.WriteLine("Main Method Completed");
		Console.ReadKey();
	}
}
