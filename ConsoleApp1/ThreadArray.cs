using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelismRecearch
{

    public delegate int Calclualator<T>(T[] source, int startIndex, int endIndex);

    public class ThreadArray
    {
        private static char[] vowels = new char[] { 'а', 'о', 'е', 'и', 'ю', 'я', 'э', 'ы', 'А', 'О', 'Е', 'И', 'Ю', 'Я',
            'Э', 'Ы', 'e', 'y', 'i', 'o', 'a', 'u', 'E', 'Y', 'I', 'O', 'A', 'U' };

        private static int CalculateParallel<T>(T[] source, int taskCount, Calclualator<T> calclualator)
        {
            int len = source.Length;

            if (len < taskCount * 3)
            {
                return calclualator(source, 0, len);
            }

            int lenByProc = len / taskCount;
            Task<int>[] tasks = new Task<int>[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                int sIdx = lenByProc * i;
                bool lastProc = i == taskCount - 1;
                int fIdx = lastProc ? len : sIdx + lenByProc;               
                tasks[i] = Task.Run(() => calclualator(source, sIdx, fIdx));
            }

            return tasks.Sum(t=>t.Result);
        }

        public static int VowelsCount(string source, int taskCount)
        {
            return CalculateParallel(source.ToCharArray(), taskCount, (s, i1, i2) => VowelsCount(s, i1, i2));
        }

        public static int VowelsCount(char[] line, int startIndex, int endIndex)
        {
            int result = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (vowels.Contains(line[i]))
                {
                    result++;
                }
            }
            return result;
        }

        public static int Sum(int[] source, int startIndex, int finishIndex)
        {
            int result = 0;
            for (int i = startIndex; i < finishIndex; i++)
            {
                result += source[i];
            }
            return result;
        }

        public static int Sum(int[] source, int taskCount)
        {
            return CalculateParallel(source, taskCount, (s, i1, i2) => Sum(s, i1, i2));
        }
    }
}
