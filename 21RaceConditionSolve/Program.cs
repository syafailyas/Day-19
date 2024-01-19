﻿using System;
using System.Threading;
using System.Threading.Tasks;

static class Program
{
	static int counter = 0;
	static object asd = new object(); // Variable for locking

	static async Task Main(string[] args)
	{
		var task1 = Task.Run( () => IncrementCounterAsync() );
		var task2 = Task.Run( () => IncrementCounterAsync() );

		await Task.WhenAll(task1, task2);

		Console.WriteLine($"Counter: {counter}");
		Console.ReadKey();
	}

	static async Task IncrementCounterAsync()
	{
		for (int i = 0; i < 100; i++)
		{
			lock (asd)
			{
				counter++;

				Console.WriteLine($"Counter from: {counter}");
			}
			await Task.Delay(100);
		}
	}
}