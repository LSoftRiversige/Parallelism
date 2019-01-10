using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParallelismRecearch
{
    public static class Utils
    {
        public static int ProcessorCount()
        {
            return Environment.ProcessorCount;
        }

        public static int[] GenerateIntArray(int count, int maxValue)
        {
            return Enumerable.Range(0, count).Select(s => new Random(s).Next(maxValue)).ToArray();
        }
    }
}
