using System.Threading.Tasks;
static class Program {
	static async Task Main() 
	{
		CancellationTokenSource source = new CancellationTokenSource();
		CancellationToken token = source.Token;
		
		Task task = Task.Run(() => DoLongRunningLoop(token));
		
		if (Console.ReadKey().KeyChar == ' ') 
		{
			source.Cancel();
		}
		
		try
		{
			await task;
		}
		catch (OperationCanceledException) 
		{
			Console.WriteLine("Operation cancelled");
		}
		finally 
		{
			source.Dispose();
			Console.WriteLine("Running Loop Finished");
		}
	}
	static async Task DoLongRunningLoop(CancellationToken myToken)
	{
		for (int i = 0; i < 100; i++) 
		{
			myToken.ThrowIfCancellationRequested();
			Console.WriteLine($"Task : {i} % ");
			await Task.Delay(100);
		}
		Console.WriteLine($"Task Completed");
	}
}