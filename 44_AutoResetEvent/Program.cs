namespace AutoResetEvents
{
	class Program
	{
		static AutoResetEvent autoResetEvent = new AutoResetEvent(true);
		
		static void Main(string[] args)
		{
			Thread newThread = new Thread(SomeMethod)
			{
				Name = "NewThread"
			};
			Thread newThread2 = new Thread(SomeMethod)
			{
				Name = "NewThread2"
			};
			newThread.Start();
			newThread2.Start();  
			Console.ReadLine();
			
		}
		static void SomeMethod()
		{
			autoResetEvent.WaitOne(); //Wait 
			Console.WriteLine("Starting........");
			Console.WriteLine(Thread.CurrentThread.Name);
			Thread.Sleep(2000);
			Console.WriteLine("Finishing........");
			Console.WriteLine(Thread.CurrentThread.Name);
			autoResetEvent.Set(); //Release
		}
	}
}
