using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CodeTest
{
    class SortedMerge
    {
        private static void Merge(int[] largeNumbers, int[] smallNumbers, int largeCount, int smallCount)
        {
            if (smallNumbers == null || smallNumbers.Length == 0) return;

            int i = largeCount - 1;
            int j = smallCount - 1;
            int pos = largeCount + smallCount - 1;
            while(j >= 0)
            {
                if (smallNumbers[j] > largeNumbers[i])
                {
                    largeNumbers[pos--] = smallNumbers[j--];
                }
                else
                {
                    largeNumbers[pos--] = largeNumbers[i--];
                }
            }
        }

        //static void Main(string[] args)
        //{
        //    const int LARGE_COUNT = 8;
        //    const int SMALL_COUNT = 6;
        //    int[] largeNumbers = new int[LARGE_COUNT + SMALL_COUNT] { 1, 3, 5, 6, 8, 8, 9, 9, -1, -1, -1, -1, -1, -1 };
        //    int[] smallNumbers = new int[SMALL_COUNT]{ 2, 3, 4, 7, 10, 11 };

        //    Merge(largeNumbers, smallNumbers, LARGE_COUNT, SMALL_COUNT);
        //    Console.WriteLine(string.Join(", ", largeNumbers));
        //}
    }
}
