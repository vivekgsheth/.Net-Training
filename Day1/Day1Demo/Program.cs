using System;
using System.Threading;
using System.Threading.Tasks;

namespace Day1Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = SlowOperationAsync();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);  // 2 - Main
            }
            Console.WriteLine("Slow operation result : {0}", task.Result); // 4 - Main
            Console.WriteLine("Main operation completed : {0}", Thread.CurrentThread.ManagedThreadId); // 5 - Main
        }

        static async Task<int> SlowOperationAsync()
        {
            Console.WriteLine("Slow operation started on : {0}", Thread.CurrentThread.ManagedThreadId); // 1 - Main
            await Task.Delay(2000);
            Console.WriteLine("Slow operation completed on : {0}", Thread.CurrentThread.ManagedThreadId); // 3 - Worker
            return 42;
        }
    }
}
