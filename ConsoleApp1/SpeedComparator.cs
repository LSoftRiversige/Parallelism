using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace ParallelismRecearch
{
    public static class SpeedComparator
    {
        public static int BestTaskCount(int arrayCount, int minTaskCount, int maxTaskCount)
        {
            int[] buffer = Utils.GenerateIntArray(arrayCount, 15);
            
            long elapsed = 0;
            long minElapsed = long.MaxValue;
            int bestTaskCount = -1;
            for (int i = minTaskCount; i <= maxTaskCount; i++)
            {
                Stopwatch watch = Stopwatch.StartNew();
                //-------------------------
                int s = ThreadArray.Sum(buffer, i);
                //-------------------------
                watch.Stop();
                elapsed = watch.ElapsedMilliseconds;
                Console.WriteLine($"TaskCount = {i}: Sum of int[{arrayCount}] = {s}, elapsed time is {elapsed} ms.");
                if (elapsed < minElapsed)
                {
                    minElapsed = elapsed;
                    bestTaskCount = i;
                }
            }
            return bestTaskCount;
        }
    }
}
