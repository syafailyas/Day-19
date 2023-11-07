using System;
using System.Threading;
using System.Threading.Tasks;

static class Program
{
	static int counter = 0;
	static object asd = new object(); //Variable for locking
	static X x = new();
	static async Task Main(string[] args)
	{
		var task1 = Task.Run(() => IncrementCounterAsync());
		var task2 = Task.Run(() => IncrementCounterAsync());

		await Task.WhenAll(task1, task2);

		Console.WriteLine($"Counter: {counter}");
		Console.ReadKey();
	}

	static async Task IncrementCounterAsync()
	{
		for (int i = 0; i < 100; i++)
		{
			lock (x)
			{
				x.counter++;
				Console.WriteLine($"Counter from: {x.counter}");
			}

			await Task.Delay(100);
		}
	}
}

class X 
{
	public int counter;
}