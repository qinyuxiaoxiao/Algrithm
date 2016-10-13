using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CodeTest
{
    class Histogram
    {
        private static int CalcMaxArea(int[] barHeights)
        {
            int maxArea = 0;
            for (int i = 0; i < barHeights.Length; i++)
            {
                int minHeight = barHeights[i];
                for (int j = i; j < barHeights.Length; j++)
                {
                    minHeight = Math.Min(barHeights[j], minHeight);
                    maxArea = Math.Max((j - i + 1) * minHeight, maxArea);
                }
            }
            return maxArea;
        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 1, 5, 6, 2, 3 })));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 1, 5, 6, 2, 3, 10 })));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 1, 5, 6, 2, 3, 11})));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 2, 5, 6, 2, 3, 10 })));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 1, 5, 5, 6, 2, 3, 10 })));
        //}
    }
}
