using System;
using System.Diagnostics;

namespace ParallelismRecearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Best task count is {SpeedComparator.BestTaskCount(1000000, 1, Environment.ProcessorCount)}");
            //Console.WriteLine($"Best task count is {SpeedComparator.BestTaskCount(100, 1, Environment.ProcessorCount)}");
            //Console.WriteLine($"Best task count is {SpeedComparator.BestTaskCount(1000, 1, Environment.ProcessorCount)}");
            //Console.WriteLine($"Best task count is {SpeedComparator.BestTaskCount(10000, 1, Environment.ProcessorCount)}");
            //Console.WriteLine($"Best task count is {SpeedComparator.BestTaskCount(100000, 1, Environment.ProcessorCount)}");
            Console.WriteLine($"Best task count is {SpeedComparator.BestTaskCount(1000000, 1, Environment.ProcessorCount)}");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
