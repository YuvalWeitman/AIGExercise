//Console.WriteLine("Hello, World!");



using SnoozeScheduler;
using System.Diagnostics;

public class Program1
{
    private static void Main(string[] args)
    {
        var service = new PullRecordsService();
        service.Execute();
    }
}