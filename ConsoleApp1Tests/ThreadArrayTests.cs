using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConsoleApp1;
using System.Linq;

namespace ConsoleApp1
{
    public class ThreadArrayTests
    {
        [Fact]
        public void Sum_CompareThreadAndUsualSumOn2Proc_Equal()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int sampleSum = ThreadArray.Sum(arr, 0, arr.Length);
            int testedsum = ThreadArray.Sum(arr, 2);

            Assert.Equal(sampleSum, testedsum);
        }

        [Fact]
        public void Sum_CompareThreadAndUsualSumOn3Proc_Equal()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int sampleSum = ThreadArray.Sum(arr, 0, arr.Length);
            int testedsum = ThreadArray.Sum(arr, 3);

            Assert.Equal(sampleSum, testedsum);
        }

        [Fact]
        public void Sum_CompareThreadAndUsualSumOnAllProc_Equal()
        {
            int[] arr = Utils.GenerateIntArray(100000, 29);
            int sampleSum = ThreadArray.Sum(arr, 0, arr.Length);
            int testedSum = ThreadArray.Sum(arr, Environment.ProcessorCount);

            Assert.Equal(sampleSum, testedSum);
        }

        [Fact]
        public void VowelCount_TestCount_Equal()
        {
            string s = "текст для проверки количества гласных";

            int checkCount = ThreadArray.VowelsCount(s, 1);

            Assert.Equal(11, checkCount);
        }

        [Fact]
        public void VowelCount_TestCount2Proc_Equal()
        {
            string s = "текст для проверки количества гласных";

            int checkCount = ThreadArray.VowelsCount(s, 2);

            Assert.Equal(11, checkCount);
        }

        [Fact]
        public void VowelCount_TestCountAllProc_Equal()
        {
            string s =
                $"текст для проверки количества гласных текст для проверки " +
                $"количества гласных текст для проверки количества гласных текст для проверки " +
                $"количества гласных текст для проверки количества гласных текст для проверки количества гласных";

            int checkCount = ThreadArray.VowelsCount(s, Environment.ProcessorCount);

            Assert.Equal(66, checkCount);
        }
    }
}
