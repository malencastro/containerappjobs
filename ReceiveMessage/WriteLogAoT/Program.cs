// See https://aka.ms/new-console-template for more information
Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " Hello, Message 1!");

var periodTimeSpan = TimeSpan.FromMinutes(1);
Thread.Sleep(periodTimeSpan);

Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " Hello, Message 2!");