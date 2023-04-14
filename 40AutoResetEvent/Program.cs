using System.Threading;
using System.Threading.Tasks;

static class Program
{
	static async Task Main(string[] args)
	{
		Console.WriteLine("Main Method Started");
		AutoResetEvent autoResetEvent = new AutoResetEvent(false);
		
		var task1 = Task.Run(async () =>
		{
			Console.WriteLine("Task 1 started");
			Console.WriteLine("Task 1 waiting for signal");
			await Task.Run(() => autoResetEvent.WaitOne());
			Console.WriteLine("Task 1 received signal");
			// MyMethod
		});

		var task2 = Task.Run(() =>
		{
			Console.WriteLine("Task 2 started");
			// MyMethod
			Console.WriteLine("Task 2 completed work");
			autoResetEvent.Set();
			Console.WriteLine("Task 2 signaled Task 1");
		});

		await Task.WhenAll(task1, task2);

		Console.WriteLine("Main Method Completed");
		Console.ReadKey();
	}
}
